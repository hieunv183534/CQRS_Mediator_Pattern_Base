using NOM.Dao.Entities;
using NOM.DomainGlobal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NOM.DomainGlobal.Services
{
    public class CodeService : ICodeService
    {
        private readonly ApplicationDbContext _context;
        public CodeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string ItemCode()
        {
            string result = "";

            bool created = false;
            while (!created)
            {
                var itemcode = $"MH08{GenerateNumber()}VN";

                //if (!_context.Item.Any(x => x.ItemCode == itemcode))
                //{
                //    result = itemcode;
                //    created = true;
                //    break;
                //}
            }

            return result;
        }

        public string ItemArCode()
        {
            string result = "";

            bool created = false;
            while (!created)
            {
                var itemcode = $"MZ08{GenerateNumber()}VN";

                //if (!_context.Item.Any(x => x.ItemCode == itemcode))
                //{
                //    result = itemcode;
                //    created = true;
                //    break;
                //}
            }

            return result;
        }

        private string GenerateNumber()
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 8; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return r;
        }
    }
}
