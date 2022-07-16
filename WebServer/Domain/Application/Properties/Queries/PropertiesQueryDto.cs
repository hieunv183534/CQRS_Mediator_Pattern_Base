using AutoMapper;
using NOM.Dao.Entities;
using NOM.Domain._Base.Mappings;
using System;

namespace NOM.Domain.Application.Properties.Queries;
/// <summary>
/// haitc 02/06/2022
/// </summary>
public record PropertiesQueryDto : IMapFrom<Property>
{
    public string PropertyId { get; set; }
    public string PropertyCode { get; set; }
    public string PropertyName { get; set; }
    public string AliasName { get; set; }
    public decimal DataType { get; set; }
    public decimal? MaximumLength { get; set; }
    public bool AllowNulls { get; set; }
    public string Regex { get; set; }
    public string RegexMessage { get; set; }
    public string CategoryId { get; set; }
    public string Description { get; set; }
    public string ParentCategoryId { get; set; }
    public string ParentCategoryIdExtend { get; set; }
    public string HeaderDescription { get; set; }
    public decimal? OrderIndex { get; set; }
    public bool AllowedShowGrid { get; set; }
    public bool AllowedShowSearch { get; set; }
    public bool AllowedRemember { get; set; }
    public decimal Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Property, PropertiesQueryDto>();
    }
}