using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Menu
    {
        public Menu()
        {
            GroupMenu = new HashSet<GroupMenu>();
            InverseParentMenuCodeNavigation = new HashSet<Menu>();
            MenuParameter = new HashSet<MenuParameter>();
            MenuService = new HashSet<MenuService>();
            MenuVersion = new HashSet<MenuVersion>();
        }

        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public byte? MenuLevel { get; set; }
        public int? OrderIndex { get; set; }
        public string ParentMenuCode { get; set; }
        public string Image { get; set; }
        public string ShortcutKey { get; set; }
        public string FormName { get; set; }
        public string DllName { get; set; }
        public string NameSpace { get; set; }
        public string Script { get; set; }
        public bool? IsLeaf { get; set; }

        public virtual Menu ParentMenuCodeNavigation { get; set; }
        public virtual ICollection<GroupMenu> GroupMenu { get; set; }
        public virtual ICollection<Menu> InverseParentMenuCodeNavigation { get; set; }
        public virtual ICollection<MenuParameter> MenuParameter { get; set; }
        public virtual ICollection<MenuService> MenuService { get; set; }
        public virtual ICollection<MenuVersion> MenuVersion { get; set; }
    }
}
