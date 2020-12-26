using System.Collections.Generic;
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
    /// Interaction logic for MemberPage.xaml
    /// </summary>
    public partial class MemberPage : Page
    {
        GenericCreate<MemberCreateDTO> GenericCreate;
        GenericUpdate<MemberUpdateDTO> GenericUpdate;

        MemberCreateDTO create = new MemberCreateDTO();
        MemberUpdateDTO update = new MemberUpdateDTO();

        List<MemberReadDTO> _memberList;

        public MemberPage()
        {
            InitializeComponent();

            GenericUpdate = new GenericUpdate<MemberUpdateDTO>(updateMember, update);
            GenericUpdate.Done += GenericUpdate_Done;
            GenericUpdate.Cancel += GenericUpdate_Cancel;
            GenericCreate = new GenericCreate<MemberCreateDTO>(testPanel, create);
            GenericCreate.Done += GenericCreate_Done;
        }

        private void GenericUpdate_Cancel()
        {
            testPanel.Visibility = Visibility.Visible;
            updateMember.Visibility = Visibility.Hidden;
        }

        private async void GenericUpdate_Done()
        {
            await GenericAPI.update(update, "member");
            _memberList = await GenericAPI.GetAll<MemberReadDTO>("member");
            testPanel.Visibility = Visibility.Visible;
            updateMember.Visibility = Visibility.Hidden;
            memberList.ItemsSource = _memberList;
        }

        private async void GenericCreate_Done()
        {
            await GenericAPI.create(create, "member");
            _memberList = await GenericAPI.GetAll<MemberReadDTO>("member");
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _memberList = await GenericAPI.GetAll<MemberReadDTO>("member");
            memberList.ItemsSource = _memberList;

            await GenericCreate.Generate();
            await GenericUpdate.Generate();
        }

        private async void RemoveUser(object sender, RoutedEventArgs e)
        {
            MessageBoxResult sure = MessageBox.Show("Are you sure you want to remove this member?", "Comfirm", MessageBoxButton.YesNo);
            if (sure == MessageBoxResult.Yes)
            {
                var m = (MemberReadDTO)memberList.SelectedItem;
                await GenericAPI.Remove<MemberReadDTO>(m.Id, "member");
                _memberList.RemoveAt(_memberList.IndexOf(m));
                memberList.ItemsSource = new List<MemberReadDTO>(_memberList);
            }
        }

        private async void UpdateUser(object sender, RoutedEventArgs e)
        {
            var m = (MemberReadDTO)memberList.SelectedItem;
            update = App.Mapper.Map<MemberUpdateDTO>(m);
            GenericUpdate.o = update;
            await GenericUpdate.Generate();
            testPanel.Visibility = Visibility.Hidden;
            updateMember.Visibility = Visibility.Visible;
        }
    }
}
