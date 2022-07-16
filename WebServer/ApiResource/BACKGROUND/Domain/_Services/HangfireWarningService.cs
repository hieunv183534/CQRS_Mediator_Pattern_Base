using NOM.Dao.Entities;
using NOM.BACKGROUND.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RT.Comb;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using NOM.DomainGlobal.Interfaces;

namespace NOM.BACKGROUND.Domain.Services
{
    public class HangfireWarningService : IHangfireWarningService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HangfireWarningService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async void test(string a)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                //var getData = db.Item.FirstOrDefault();
            }

        }

        //warning.WarningType == 0 ? "Cảnh báo tiếp nhận" :
        //warning.WarningType == 1 ? "Cảnh báo giao dịch" :
        //warning.WarningType == 2 ? "Cảnh báo khai thác" :
        //warning.WarningType == 3 ? "Cảnh báo vận chuyển" :
        //warning.WarningType == 4   ? "Cảnh báo phát" :

        //warning.WarningLevel == 0 ? "Cao" :
        //warning.WarningLevel == 1 ? "Nghiêm trọng" :
        
        public static double GetBusinessDays(DateTime startD, DateTime endD)
        {
            double calcBusinessDays = 1 + ((endD - startD).TotalDays * 5 - ((double)startD.DayOfWeek - (double)endD.DayOfWeek) * 2) / 7;
            if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;
            return calcBusinessDays;
        }
    }
}
