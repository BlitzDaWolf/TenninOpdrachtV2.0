using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tennis.App.Api;
using Tennis.DTO.Create;
using Tennis.DTO.Read;

namespace Tennis.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MemberCreateDTO test = new MemberCreateDTO();
        GameCreateDTO GameC = new GameCreateDTO();
        GameResultCreateDTO ResultC = new GameResultCreateDTO();
        MemberRoleCreateDTO RoleC = new MemberRoleCreateDTO();

        GenericCreate<MemberCreateDTO> generic;
        GenericCreate<GameCreateDTO> gameGeneric;
        GenericCreate<GameResultCreateDTO> resultGeneric;
        GenericCreate<MemberRoleCreateDTO> RoleGeneric;
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            generic = new GenericCreate<MemberCreateDTO>(testPanel, test);
            generic.Done += Generic_Done;
            gameGeneric = new GenericCreate<GameCreateDTO>(GameT, GameC);
            resultGeneric = new GenericCreate<GameResultCreateDTO>(ResultT, ResultC);
            RoleGeneric = new GenericCreate<MemberRoleCreateDTO>(RoleT, RoleC);

        }

        private async void Generic_Done()
        {
            await GenericAPI.create<MemberCreateDTO>(test, "Member");
            // throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await generic.Generate();
            await gameGeneric.Generate();
            await resultGeneric.Generate();
            await RoleGeneric.Generate();
        }
    }
}
