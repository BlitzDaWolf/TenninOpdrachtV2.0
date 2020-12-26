using System;
using System.Collections.Generic;
using System.Linq;
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
        private GenericCreate<GameResultCreateDTO> createResult;

        GameCreateDTO createDTO = new GameCreateDTO();
        GameResultCreateDTO createResultDTO = new GameResultCreateDTO();

        public GamePage()
        {
            InitializeComponent();

            create = new GenericCreate<GameCreateDTO>(GameCreate, createDTO);
            create.Done += Create_Done;
            createResult = new GenericCreate<GameResultCreateDTO>(resultCreate, createResultDTO);
            createResult.Done += CreateResult_Done;
        }

        private async void CreateResult_Done()
        {
            await GenericAPI.create(createResultDTO, "GameResult");
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

        private async void ResultClick(object sender, RoutedEventArgs e)
        {
            GameReadDTO selected = (GameReadDTO)gameList.SelectedItem;
            var res = (await GenericAPI.GetAll<GameResultReadDTO>("GameResult")).Where(x => x.GameId == selected.Id).ToList();
            resultList.ItemsSource = res;
            createResultDTO.GameId = selected.Id;
            await createResult.Generate();
            GameCreate.Visibility = Visibility.Hidden;
            Result.Visibility = Visibility.Visible;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            GameCreate.Visibility = Visibility.Visible;
            Result.Visibility = Visibility.Hidden;
        }
    }
}
