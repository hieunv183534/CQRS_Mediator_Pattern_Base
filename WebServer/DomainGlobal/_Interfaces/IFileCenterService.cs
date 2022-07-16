using NOM.DomainGlobal.Models.FileCenter;
using System.Threading.Tasks;

namespace NOM.DomainGlobal.Interfaces
{
    public interface IFileCenterService
    {
        Task<DowloadModelResult> Dowload(DowloadModel model);

        Task<FindOneModelResult> FindOne(FindOneModel model);

        Task<bool> SynFile(SynFileModel model);
    }
}
