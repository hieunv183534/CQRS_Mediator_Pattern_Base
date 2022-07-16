export class TableTreeConfigModel implements ITableTreeConfig {

  keyId: string;
  keyParentId: string;
  collapseDefault: boolean;
  mapOfExpandedData: { [key: string]: any[] };

  constructor(source: ITableTreeConfig) {
    this.keyId = source.keyId;
    this.keyParentId = source.keyParentId;
    this.collapseDefault = source.collapseDefault;
    this.mapOfExpandedData = source.mapOfExpandedData;
  }

  convertDataRawToDataTree(dataRaw: any[]): any[] {
    dataRaw.forEach(item => {
      item.children = dataRaw.filter(x => x[this.keyParentId] === item[this.keyId]);
    });

    const result = dataRaw.filter(x => x[this.keyParentId] === null);
    for (const item of result) {
      this.mapOfExpandedData[item[this.keyId]] = this.convertTreeToList(item);
    }
    return result;
  }

  collapse(array: any[], data: any, $event: boolean): void {
    if (!$event) {
      if (data.children) {
        data.children.forEach(d => {
          // tslint:disable-next-line: no-non-null-assertion
          const target = array.find(a => a[this.keyId] === d[this.keyId])!;
          target.expand = this.collapseDefault;
          this.collapse(array, target, false);
        });
      } else {
        return;
      }
    }
  }

  convertTreeToList(root: any): any[] {
    const stack: any[] = [];
    const array: any[] = [];
    const hashMap = {};
    stack.push({ ...root, level: 0, expand: this.collapseDefault });

    while (stack.length !== 0) {
      // tslint:disable-next-line: no-non-null-assertion
      const node = stack.pop()!;
      this.visitNode(node, hashMap, array);
      if (node.children) {
        for (let i = node.children.length - 1; i >= 0; i--) {
          // tslint:disable-next-line: no-non-null-assertion
          stack.push({ ...node.children[i], level: node.level! + 1, expand: this.collapseDefault, parent: node });
        }
      }
    }

    return array;
  }

  visitNode(node: any, hashMap: { [key: string]: boolean }, array: any[]): void {
    if (!hashMap[node[this.keyId]]) {
      hashMap[node[this.keyId]] = true;
      array.push(node);
    }
  }
}

export interface ITableTreeConfig {
  keyId: string;
  keyParentId: string;
  collapseDefault: boolean;
  mapOfExpandedData: { [key: string]: any[] };
}
