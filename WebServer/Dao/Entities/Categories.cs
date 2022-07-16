using System;
using System.Collections.Generic;

namespace NOM.Dao.Entities
{
    public partial class Category
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Identification { get; set; }
        public string DecisionNo { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string CategoryTypeId { get; set; }
        public string ParentCategoryId { get; set; }
        public string Description { get; set; }
        public decimal? OrderIndex { get; set; }
        public bool AllowedSuggestions { get; set; }
        public string ClassIcon { get; set; }
        public decimal Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedDescription { get; set; }
        public string CategoryCodeId { get; set; }
        public string ValueWhenEmptyOnGridView { get; set; }
        public string ValueWhenEmptyExport { get; set; }
        public string ValueWhenEmptyReport { get; set; }
        public bool AllowedShowCreatedDate { get; set; }
        public bool AllowedShowCreatedBy { get; set; }
        public bool AllowedShowPortal { get; set; }
        public bool AllowedShowExport { get; set; }
        public string Creator { get; set; }
        public string Publisher { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? ValidDate { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }
        public string IdentifierUrl { get; set; }
        public string Source { get; set; }
        public string Language { get; set; }
        public string Relation { get; set; }
        public string Coverage { get; set; }
        public string Rights { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Contributor { get; set; }
        public string TableName { get; set; }
    }
}
