using AutoMapper;
using System.Windows;
using Tennis.DTO.Read;
using Tennis.DTO.Update;

namespace Tennis.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IMapper Mapper { get; private set; }

        public App()
        {
            ApiHelper.InitiliateClient();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TennisMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            App.Mapper = mapper;
        }
    }

    public class TennisMapper : Profile
    {
        public TennisMapper()
        {
            CreateMap<MemberReadDTO, MemberUpdateDTO>().ReverseMap();
        }
    }
}
