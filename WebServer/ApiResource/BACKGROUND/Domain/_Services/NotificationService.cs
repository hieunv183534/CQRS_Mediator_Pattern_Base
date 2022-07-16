using AutoMapper;
using NOM.Dao.Entities;
using NOM.BACKGROUND.Domain.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RT.Comb;

namespace NOM.BACKGROUND.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        //private IHubContext<SignalRHub> _signalrHub;

        public NotificationService(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            //_signalrHub = signalrHub;
        }

        public async Task<long> SentNotification(CreateCommand request)
        {
            var notification = _mapper.Map<NOM.Dao.Entities.Notification>(request);

            // sinh mã nếu db không dùng identity
            notification.CreateDate = System.DateTime.Now;
            notification.Id = Provider.Sql.CreateDoubleID(999999);
            _context.Notification.Add(notification);
            await _context.SaveChangesAsync();

            // push notifi
            //MessageInstanceNotification msg = new MessageInstanceNotification();
            //msg.Title = notification.Title;
            //msg.Desciption = notification.Description;
            //msg.CreateDate = notification.CreateDate;
            //msg.Id = notification.Id;

            //await _signalrHub.Clients.All.SendAsync("BroadcastMessage", msg);

            return notification.Id;
        }

    }
}
