using AutoMapper;
using NOM.BACKGROUND.Domain._Base.Mappings;
using MediatR;
using System.Threading.Tasks;

namespace NOM.BACKGROUND.Domain.Interfaces
{
    public interface INotificationService
    {
        Task<long> SentNotification(CreateCommand request);
    }

    public class CreateCommand : IRequest<long>, IMapTo<Dao.Entities.Notification>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime CreateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCommand, Dao.Entities.Notification>();
        }
    }
}
