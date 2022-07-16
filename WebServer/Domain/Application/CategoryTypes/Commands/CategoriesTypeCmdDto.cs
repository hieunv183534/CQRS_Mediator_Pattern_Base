namespace NOM.Domain.Application.CategoryTypes.Commands;
/// <summary>
/// haitc 02/06/2022
/// </summary>
public record CategoriesTypeCmdDto
{
    //public string CategoryTypeId { get; set; }
    public string CategoryTypeName { get; set; }
    public string Description { get; set; }
    public byte Status { get; set; }
    public short? OrderIndex { get; set; }
    public string Classicon { get; set; }
    //public DateTime CreatedDate { get; set; }
    //public string CreatedBy { get; set; }
    //public DateTime? Modifieddate { get; set; }
    //public string ModifiedBy { get; set; }
    //public DateTime? ApprovedDate { get; set; }
    //public string ApprovedBy { get; set; }
    public string ApprovedDescription { get; set; }
}