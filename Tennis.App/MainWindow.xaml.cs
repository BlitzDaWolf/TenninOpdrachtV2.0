using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tennis.App.Api;
using Tennis.App.Generic;
using Tennis.DTO.Create;
using Tennis.DTO.Read;
using Tennis.DTO.Update;

namespace Tennis.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MemberUpdateDTO test = new MemberUpdateDTO();
        GameCreateDTO GameC = new GameCreateDTO();
        GameResultCreateDTO ResultC = new GameResultCreateDTO();
        MemberRoleCreateDTO RoleC = new MemberRoleCreateDTO();

        GenericUpdate<MemberUpdateDTO> generic;
        // GenericCreate<MemberCreateDTO> generic;
        GenericCreate<GameCreateDTO> gameGeneric;
        GenericCreate<GameResultCreateDTO> resultGeneric;
        GenericCreate<MemberRoleCreateDTO> RoleGeneric;

        GenericFilter<MemberReadDTO> v;
        List<MemberReadDTO> res;
        private List<MemberReadDTO> filterdList;

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            // generic = new GenericCreate<MemberCreateDTO>(testPanel, test, 3, 5);
            generic = new GenericUpdate<MemberUpdateDTO>(testPanel, test, 3, 5);
            gameGeneric = new GenericCreate<GameCreateDTO>(GameT, GameC, 2, 3);
            resultGeneric = new GenericCreate<GameResultCreateDTO>(ResultT, ResultC, 2, 3);
            RoleGeneric = new GenericCreate<MemberRoleCreateDTO>(RoleT, RoleC, 2, 3);

            generic.Done += Generic_Done;
        }

        private async void Generic_Done()
        {
            await GenericAPI.create(test, "Member");
            test = null;

            var res = await GenericAPI.GetAll<MemberReadDTO>("Member");
            memberList.ItemsSource = res;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            res = await GenericAPI.GetAll<MemberReadDTO>("Member");
            filterdList = res;
            memberList.ItemsSource = filterdList;

            await generic.Generate();
            await gameGeneric.Generate();
            await resultGeneric.Generate();
            await RoleGeneric.Generate();
            await generic.Generate();

            v = new GenericFilter<MemberReadDTO>(test2);

            v.Generate();
            v.Change += V_Change;
        }

        private void V_Change(MemberReadDTO filter)
        {
            var t = from c in res where
                    c.FirstName.Contains(filter.FirstName) && c.LastName.Contains(filter.LastName)
                    select c;
            memberList.ItemsSource = t;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MemberReadDTO)memberList.SelectedItem;
            if (selected != null)
            {
                test.Id = selected.Id;
            }
        }
    }
}
