using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Extentions;
using NOM.DomainGlobal.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NOM.DomainGlobal.Services
{
    public class ExtentionService : IExtentionService
    {
        private ApplicationDbContext _context;
        public ExtentionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public GetAreaModel getArea(string address)
        {
            var result = new GetAreaModel();
            // nếu địa chỉ 1 từ thì ko phân tích
            if (!address.HasValue() || address.Split(" ").Length <= 1)
            {
                result.Address = address;
                return result;
            }
            var func = EF.Functions;
            
            var value = address.Split(",");
            var path = "";
            for (int i = value.Length - 1; i >= 0; i--)
            {
                var item = value[i];
                var TextSearchToUpper = item.Trim().ToUnSign();
                //if (!result.Province.HasValue())
                //{
                //    var provinceData = _context.Province
                //        .Where(x => func.Like(x.ProvinceNameSearch, $"%{TextSearchToUpper}%"))
                //        .Select(x=>x.ProvinceCode)
                //        .FirstOrDefault();
                //    if (provinceData != null)
                //    {
                //        result.Province = provinceData;
                //        continue;
                //    }
                //}
                //if (!result.District.HasValue() && result.Province.HasValue())
                //{
                //    var districtQuery = _context.District.AsQueryable();
                //    districtQuery = districtQuery.Where(x => func.Like(x.DistrictNameSearch, $"%{TextSearchToUpper}%"));
                //    if (result.Province.HasValue())
                //    {
                //        districtQuery = districtQuery.Where(x => x.ProvinceCode == result.Province);
                //    }

                //    var DistrictData = districtQuery
                //        .Select(x => x.DistrictCode)
                //        .FirstOrDefault();
                //    if (DistrictData != null)
                //    {
                //        result.District = DistrictData;
                //        continue;
                //    }
                //}

                //if (!result.Commune.HasValue() && result.District.HasValue())
                //{
                //    var communeQuery = _context.Commune.AsQueryable();
                //    communeQuery = communeQuery.Where(x => func.Like(x.CommuneNameSearch, $"%{TextSearchToUpper}%"));
                //    if (result.District.HasValue())
                //    {
                //        communeQuery = communeQuery.Where(x => x.DistrictCode == result.District);
                //    }
                //    var communeData = communeQuery
                //        .Select(x => x.CommuneCode)
                //        .FirstOrDefault();
                //    if (communeData != null)
                //    {
                //        result.Commune = communeData;
                //        continue;
                //    }
                //}

                result.Address = $"{item}{path}{result.Address}";
                path = ", ";
            }
            return result;
        }
    }
}
