using System;
using System.Collections.Generic;
using System.Text;

namespace NOM.DomainGlobal.Interfaces
{
    public interface IExtentionService
    {
        GetAreaModel getArea(string address);
    }

    public class GetAreaModel
    {
        public string Address { get; set; }

        public string Province { get; set; }

        public string District { get; set; }

        public string Commune { get; set; }
    }
}
