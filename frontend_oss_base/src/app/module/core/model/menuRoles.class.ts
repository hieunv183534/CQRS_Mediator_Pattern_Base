export interface MenuRoles {
  title?: string;
  expanded?: boolean;
  key?: string;
  children?: MenuRoles[];
  isLeaf?: boolean;
}
