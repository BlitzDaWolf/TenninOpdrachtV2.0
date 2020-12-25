using System;
using System.Collections.Generic;
using System.Text;
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
using Tennis.App.Generic;
using Tennis.DTO.Create;
using Tennis.DTO.Read;

namespace Tennis.App
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private GenericCreate<GameCreateDTO> create;
        GameCreateDTO createDTO = new GameCreateDTO();

        public GamePage()
        {
            InitializeComponent();

            create = new GenericCreate<GameCreateDTO>(GameCreate, createDTO);
            create.Done += Create_Done;
        }

        private async void Create_Done()
        {
            await GenericAPI.create(createDTO, "game");
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await create.Generate();
            gameList.ItemsSource = await GenericAPI.GetAll<GameReadDTO>("game");
        }
    }
}
