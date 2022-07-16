using System;

namespace NOM.Domain.Application.OriginalProperties.Commands;
/// <summary>
/// haitc 02/06/2022
/// </summary>
public record OriginalPropertiesCmdDto
{
    //public string PropertyId { get; set; }
    public string PropertyCode { get; set; }
    public string PropertyName { get; set; }
    public string AliasName { get; set; }
    public decimal DatatYpe { get; set; }
    public decimal? MaximumLength { get; set; }
    public bool AllowNulls { get; set; }
    public string Regex { get; set; }
    public string RegexMessage { get; set; }
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
    public DateTime? ApprovedDate { get; set; }
    public string ApprovedBy { get; set; }
    public string ApprovedDescription { get; set; }
}