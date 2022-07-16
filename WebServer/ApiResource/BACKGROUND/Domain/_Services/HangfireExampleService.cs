using NOM.Dao.Entities;
using NOM.BACKGROUND.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NOM.BACKGROUND.Domain.Services
{
    public class HangfireExampleService : IHangfireExampleService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HangfireExampleService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async void test(string a)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                //var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                //var getData = db.Item.FirstOrDefault();
                //var mediator = scopedServices.GetRequiredService<IMediator>();


                /// ducnv test
                //var cmd = new CreateCommand
                //{
                //    Title = "Thông báo",
                //    Description = "Nguyen van duc dang uong cafe"
                //};
                //mediator.Send(cmd);
            }
            
        }
    }
}
