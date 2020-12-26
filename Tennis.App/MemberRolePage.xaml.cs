using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Tennis.App.Api;
using Tennis.App.Generic;
using Tennis.DTO.Create;
using Tennis.DTO.Read;

namespace Tennis.App
{
    /// <summary>
    /// Interaction logic for MemberROlePage.xaml
    /// </summary>
    public partial class MemberRolePage : Page
    {
        private GenericCreate<MemberRoleCreateDTO> create;
        private MemberRoleCreateDTO roleCreateDTO = new MemberRoleCreateDTO();
        private List<MemberRoleReadDTO> allRoles = new List<MemberRoleReadDTO>();

        public MemberRolePage()
        {
            InitializeComponent();
            create = new GenericCreate<MemberRoleCreateDTO>(createRole, roleCreateDTO);
            create.Done += Create_Done;
        }

        private async void Create_Done()
        {
            await GenericAPI.create(roleCreateDTO, "MemberRole");
            roleCreateDTO = new MemberRoleCreateDTO();
            await create.Generate();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            allRoles = await GenericAPI.GetAll<MemberRoleReadDTO>("MemberRole");
            await create.Generate();
            roleList.ItemsSource = allRoles;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (active.IsChecked.Value)
            {
                var r = allRoles.Where(x => x.Active).ToList();
                roleList.ItemsSource = r;
            }
            else
            {
                var r = allRoles;
                roleList.ItemsSource = r;
            }
        }
    }
}
