using AutoMapper;
using BCCP.DomainGlobal._Base.Mappings;
using System;

namespace BCCP.DomainGlobal.Application.FileCloud.Queries
{
    public class FindOneQueryResult : IMapFrom<Dao.FileCloud.FileStorage>
    {
        public long Id { get; set; }
        public Guid FileNumber { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int FileType { get; set; }
        public decimal? FileSize { get; set; }
        public long? ParentId { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Url { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dao.FileCloud.FileStorage, FindOneQueryResult>();
        }
    }
}
