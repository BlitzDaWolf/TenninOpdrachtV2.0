using Microsoft.Extensions.DependencyInjection;
using Tennis.BLL.Interface;
using Tennis.BLL.Service;

namespace Tennis.BLL
{
    public static class BLLExstention
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<UnitOfWork>();

            service.AddScoped<IFineService, FineService>();
            service.AddScoped<IGameService, GameService>();
            service.AddScoped<IGameResultService, GameResultService>();
            service.AddScoped<IGenderService, GenderService>();
            service.AddScoped<ILeagueService, LeagueService>();
            service.AddScoped<IMemberRoleService, MemberRoleService>();
            service.AddScoped<IMemberService, MemberService>();
            service.AddScoped<IRoleService, RoleService>();

            return service;
        }
    }
}
