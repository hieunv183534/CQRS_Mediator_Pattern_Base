using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NOM.DomainGlobal.Interfaces
{
    public interface IVmapService
    {
        Task<(string vPostCode, double? Lat, double? Long)> GetVmap(string address);
    }
}
