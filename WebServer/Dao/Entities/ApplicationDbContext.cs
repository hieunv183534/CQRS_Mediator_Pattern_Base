using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NOM.Dao.Entities
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriesType> CategoriesTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryCode> CategoryCodes { get; set; }
        public virtual DbSet<CategoryCodeChild> CategoryCodeChildren { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentCategory> DocumentCategories { get; set; }
        public virtual DbSet<OriginalProperty> OriginalProperties { get; set; }
        public virtual DbSet<PortalApplication> PortalApplications { get; set; }
        public virtual DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("NOM_STRUCT");

            modelBuilder.Entity<CategoriesType>(entity =>
            {
                entity.HasKey(e => e.CategoryTypeId)
                    .HasName("SYS_C0039825");

                entity.ToTable("CATEGORIES_TYPE");

                entity.Property(e => e.CategoryTypeId)
                    .HasMaxLength(36)
                    .HasColumnName("CATEGORY_TYPE_ID");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(256)
                    .HasColumnName("APPROVED_BY");

                entity.Property(e => e.ApprovedDate)
                    .HasPrecision(6)
                    .HasColumnName("APPROVED_DATE");

                entity.Property(e => e.ApprovedDescription)
                    .HasMaxLength(500)
                    .HasColumnName("APPROVED_DESCRIPTION");

                entity.Property(e => e.CategoryTypeName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("CATEGORY_TYPE_NAME");

                entity.Property(e => e.Classicon)
                    .HasMaxLength(256)
                    .HasColumnName("CLASSICON");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(256)
                    .HasColumnName("MODIFIED_BY");

                entity.Property(e => e.Modifieddate)
                    .HasPrecision(6)
                    .HasColumnName("MODIFIEDDATE");

                entity.Property(e => e.OrderIndex)
                    .HasPrecision(5)
                    .HasColumnName("ORDER_INDEX");

                entity.Property(e => e.Status)
                    .HasPrecision(2)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(36)
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.AllowedShowCreatedBy)
                    .HasPrecision(1)
                    .HasColumnName("ALLOWED_SHOW_CREATED_BY");

                entity.Property(e => e.AllowedShowCreatedDate)
                    .HasPrecision(1)
                    .HasColumnName("ALLOWED_SHOW_CREATED_DATE");

                entity.Property(e => e.AllowedShowExport)
                    .HasPrecision(1)
                    .HasColumnName("ALLOWED_SHOW_EXPORT");

                entity.Property(e => e.AllowedShowPortal)
                    .HasPrecision(1)
                    .HasColumnName("ALLOWED_SHOW_PORTAL");

                entity.Property(e => e.AllowedSuggestions)
                    .HasPrecision(1)
                    .HasColumnName("ALLOWED_SUGGESTIONS");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(256)
                    .HasColumnName("APPROVED_BY");

                entity.Property(e => e.ApprovedDate)
                    .HasPrecision(6)
                    .HasColumnName("APPROVED_DATE");

                entity.Property(e => e.ApprovedDescription)
                    .HasMaxLength(500)
                    .HasColumnName("APPROVED_DESCRIPTION");

                entity.Property(e => e.CategoryCodeId)
                    .HasMaxLength(36)
                    .HasColumnName("CATEGORY_CODE_ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(512)
                    .HasColumnName("CATEGORY_NAME");

                entity.Property(e => e.CategoryTypeId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasColumnName("CATEGORY_TYPE_ID");

                entity.Property(e => e.ClassIcon)
                    .HasMaxLength(256)
                    .HasColumnName("CLASS_ICON");

                entity.Property(e => e.Contributor)
                    .HasMaxLength(500)
                    .HasColumnName("CONTRIBUTOR");

                entity.Property(e => e.Coverage)
                    .HasMaxLength(500)
                    .HasColumnName("COVERAGE");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Creator)
                    .HasMaxLength(500)
                    .HasColumnName("CREATOR");

                entity.Property(e => e.DecisionNo)
                    .HasMaxLength(256)
                    .HasColumnName("DECISION_NO");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.EventDate)
                    .HasPrecision(6)
                    .HasColumnName("EVENT_DATE");

                entity.Property(e => e.ExpiredDate)
                    .HasPrecision(6)
                    .HasColumnName("EXPIRED_DATE");

                entity.Property(e => e.Format)
                    .HasMaxLength(500)
                    .HasColumnName("FORMAT");

                entity.Property(e => e.Identification)
                    .HasMaxLength(512)
                    .HasColumnName("IDENTIFICATION_");

                entity.Property(e => e.IdentifierUrl)
                    .HasColumnType("NVARCHAR2(4000)")
                    .HasColumnName("IDENTIFIER_URL");

                entity.Property(e => e.IssuedDate)
                    .HasPrecision(6)
                    .HasColumnName("ISSUED_DATE");

                entity.Property(e => e.Language)
                    .HasMaxLength(500)
                    .HasColumnName("LANGUAGE");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(256)
                    .HasColumnName("MODIFIED_BY");

                entity.Property(e => e.ModifiedDate)
                    .HasPrecision(6)
                    .HasColumnName("MODIFIED_DATE");

                entity.Property(e => e.OrderIndex)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ORDER_INDEX");

                entity.Property(e => e.ParentCategoryId)
                    .HasMaxLength(36)
                    .HasColumnName("PARENT_CATEGORY_ID");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(500)
                    .HasColumnName("PUBLISHER");

                entity.Property(e => e.Relation)
                    .HasMaxLength(500)
                    .HasColumnName("RELATION");

                entity.Property(e => e.Rights)
                    .HasMaxLength(500)
                    .HasColumnName("RIGHTS");

                entity.Property(e => e.Source)
                    .HasMaxLength(500)
                    .HasColumnName("SOURCE");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Subject)
                    .HasColumnType("NVARCHAR2(4000)")
                    .HasColumnName("SUBJECT");

                entity.Property(e => e.TableName)
                    .HasMaxLength(128)
                    .HasColumnName("TABLE_NAME");

                entity.Property(e => e.Title)
                    .HasMaxLength(512)
                    .HasColumnName("TITLE");

                entity.Property(e => e.Type)
                    .HasMaxLength(500)
                    .HasColumnName("TYPE");

                entity.Property(e => e.ValidDate)
                    .HasPrecision(6)
                    .HasColumnName("VALID_DATE");

                entity.Property(e => e.ValueWhenEmptyExport)
                    .HasMaxLength(255)
                    .HasColumnName("VALUE_WHEN_EMPTY_EXPORT");

                entity.Property(e => e.ValueWhenEmptyOnGridView)
                    .HasMaxLength(255)
                    .HasColumnName("VALUE_WHEN_EMPTY_ON_GRID_VIEW");

                entity.Property(e => e.ValueWhenEmptyReport)
                    .HasMaxLength(255)
                    .HasColumnName("VALUE_WHEN_EMPTY_REPORT");
            });

            modelBuilder.Entity<CategoryCode>(entity =>
            {
                entity.ToTable("CATEGORY_CODE");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Comma)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("COMMA");

                entity.Property(e => e.MaxCodeLevel)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MAX_CODE_LEVEL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("NAME");

                entity.Property(e => e.Rtl)
                    .HasPrecision(1)
                    .HasColumnName("RTL");
            });

            modelBuilder.Entity<CategoryCodeChild>(entity =>
            {
                entity.HasKey(e => new { e.CategoryCodeId, e.CodeLevel })
                    .HasName("SYS_C0039833");

                entity.ToTable("CATEGORY_CODE_CHILD");

                entity.Property(e => e.CategoryCodeId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_CODE_ID");

                entity.Property(e => e.CodeLevel)
                    .HasPrecision(2)
                    .HasColumnName("CODE_LEVEL");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(36)
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.DefaultValue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DEFAULT_VALUE");

                entity.Property(e => e.GenerateCode)
                    .HasPrecision(1)
                    .HasColumnName("GENERATE_CODE");

                entity.Property(e => e.MaxLength)
                    .HasPrecision(2)
                    .HasColumnName("MAX_LENGTH");

                entity.Property(e => e.MinLength)
                    .HasPrecision(2)
                    .HasColumnName("MIN_LENGTH");

                entity.Property(e => e.Reference)
                    .HasPrecision(1)
                    .HasColumnName("REFERENCE");

                entity.Property(e => e.Regex)
                    .HasMaxLength(500)
                    .HasColumnName("REGEX");

                entity.Property(e => e.RegexMessage)
                    .HasMaxLength(500)
                    .HasColumnName("REGEX_MESSAGE");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("DOCUMENT");

                entity.Property(e => e.DocumentId)
                    .HasMaxLength(36)
                    .HasColumnName("DOCUMENT_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("DOCUMENT_NAME");

                entity.Property(e => e.DocumentNo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("DOCUMENT_NO");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("FILE_NAME");

                entity.Property(e => e.IssueDdate)
                    .HasPrecision(6)
                    .HasColumnName("ISSUE_DDATE");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("UNIT");
            });

            modelBuilder.Entity<DocumentCategory>(entity =>
            {
                entity.HasKey(e => new { e.DocumentId, e.CategoryId })
                    .HasName("SYS_C0039851");

                entity.ToTable("DOCUMENT_CATEGORY");

                entity.Property(e => e.DocumentId)
                    .HasMaxLength(36)
                    .HasColumnName("DOCUMENT_ID");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(36)
                    .HasColumnName("CATEGORY_ID");
            });

            modelBuilder.Entity<OriginalProperty>(entity =>
            {
                entity.HasKey(e => new { e.PropertyId, e.ParentCategoryIdExtend })
                    .HasName("SYS_C0039863");

                entity.ToTable("ORIGINAL_PROPERTIES");

                entity.Property(e => e.PropertyId)
                    .HasMaxLength(36)
                    .HasColumnName("PROPERTY_ID");

                entity.Property(e => e.ParentCategoryIdExtend)
                    .HasMaxLength(36)
                    .HasColumnName("PARENT_CATEGORY_ID_EXTEND");

                entity.Property(e => e.AliasName)
                    .HasMaxLength(128)
                    .HasColumnName("ALIAS_NAME");

                entity.Property(e => e.AllowNulls)
                    .HasPrecision(1)
                    .HasColumnName("ALLOW_NULLS");

                entity.Property(e => e.AllowedRemember)
                    .HasPrecision(1)
                    .HasColumnName("ALLOWED_REMEMBER");

                entity.Property(e => e.AllowedShowGrid)
                    .HasPrecision(1)
                    .HasColumnName("ALLOWED_SHOW_GRID");

                entity.Property(e => e.AllowedShowSearch)
                    .HasPrecision(1)
                    .HasColumnName("ALLOWED_SHOW_SEARCH");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(256)
                    .HasColumnName("APPROVED_BY");

                entity.Property(e => e.ApprovedDate)
                    .HasPrecision(6)
                    .HasColumnName("APPROVED_DATE");

                entity.Property(e => e.ApprovedDescription)
                    .HasMaxLength(500)
                    .HasColumnName("APPROVED_DESCRIPTION");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.DatatYpe)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("DATAT_YPE");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.HeaderDescription)
                    .HasMaxLength(256)
                    .HasColumnName("HEADER_DESCRIPTION");

                entity.Property(e => e.MaximumLength)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MAXIMUM_LENGTH");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(256)
                    .HasColumnName("MODIFIED_BY");

                entity.Property(e => e.ModifiedDate)
                    .HasPrecision(6)
                    .HasColumnName("MODIFIED_DATE");

                entity.Property(e => e.OrderIndex)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ORDER_INDEX");

                entity.Property(e => e.ParentCategoryId)
                    .HasMaxLength(36)
                    .HasColumnName("PARENT_CATEGORY_ID");

                entity.Property(e => e.PropertyCode)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("PROPERTY_CODE");

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("PROPERTY_NAME");

                entity.Property(e => e.Regex)
                    .HasMaxLength(500)
                    .HasColumnName("REGEX");

                entity.Property(e => e.RegexMessage)
                    .HasMaxLength(500)
                    .HasColumnName("REGEX_MESSAGE");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<PortalApplication>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .HasName("SYS_C0039867");

                entity.ToTable("PORTAL_APPLICATION");

                entity.Property(e => e.ApplicationId)
                    .HasMaxLength(128)
                    .HasColumnName("APPLICATION_ID");

                entity.Property(e => e.Actived)
                    .HasPrecision(1)
                    .HasColumnName("ACTIVED");

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("APPLICATION_NAME");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => new { e.PropertyId, e.CategoryId, e.Status })
                    .HasName("SYS_C0039880");

                entity.ToTable("PROPERTIES");

                entity.Property(e => e.PropertyId)
                    .HasMaxLength(36)
                    .HasColumnName("PROPERTY_ID");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(36)
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.AliasName)
                    .HasMaxLength(128)
                    .HasColumnName("ALIAS_NAME");

                entity.Property(e => e.AllowNulls)
                    .HasPrecision(1)
                    .HasColumnName("ALLOW_NULLS");

                entity.Property(e => e.AllowedRemember)
                    .HasPrecision(1)
                    .HasColumnName("ALLOWED_REMEMBER");

                entity.Property(e => e.AllowedShowGrid)
                    .HasPrecision(1)
                    .HasColumnName("ALLOWED_SHOW_GRID");

                entity.Property(e => e.AllowedShowSearch)
                    .HasPrecision(1)
                    .HasColumnName("ALLOWED_SHOW_SEARCH");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.DataType)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("DATA_TYPE");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.HeaderDescription)
                    .HasMaxLength(256)
                    .HasColumnName("HEADER_DESCRIPTION");

                entity.Property(e => e.MaximumLength)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MAXIMUM_LENGTH");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(256)
                    .HasColumnName("MODIFIED_BY");

                entity.Property(e => e.ModifiedDate)
                    .HasPrecision(6)
                    .HasColumnName("MODIFIED_DATE");

                entity.Property(e => e.OrderIndex)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ORDER_INDEX");

                entity.Property(e => e.ParentCategoryId)
                    .HasMaxLength(36)
                    .HasColumnName("PARENT_CATEGORY_ID");

                entity.Property(e => e.ParentCategoryIdExtend)
                    .HasMaxLength(36)
                    .HasColumnName("PARENT_CATEGORY_ID_EXTEND");

                entity.Property(e => e.PropertyCode)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("PROPERTY_CODE");

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("PROPERTY_NAME");

                entity.Property(e => e.Regex)
                    .HasMaxLength(500)
                    .HasColumnName("REGEX");

                entity.Property(e => e.RegexMessage)
                    .HasMaxLength(500)
                    .HasColumnName("REGEX_MESSAGE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
