export class TableLoadingAsync implements ITableLoadingAsync {
    keyId: string;
    dataSource: any[];
    loadingText: string;

    dataLoading: any[] = [];

    constructor(source: ITableLoadingAsync) {
        this.keyId = source.keyId;
        this.loadingText = source.loadingText;
    }

    public setDataSource(source: any[]){
        debugger;
        this.dataSource = source;
    }

    public startLoading(item: any): void {
        item.loadingText = this.loadingText;
        item.statusLoading = 1;
        this.dataLoading.splice(0, 0, item);
    }

    //Kết thúc loading và set giá trị cho item
    public endLoading(item: any = null) {
        let itemIndex = -1;
        if (!item) {
            console.error('endLoading không được để trống item');
            return;
        }
        if (!item[this.keyId]) {
            console.error(`Không thể endLoading item do không truyền id key ${this.keyId}`);
            return;
        } else {
            itemIndex = this.dataLoading.findIndex(x => x[this.keyId] === item[this.keyId]);
            if (itemIndex === -1) {
                item.errorText = `Không thể endLoading item có id ${item[this.keyId]} do không tìm thấy trong dữ liệu Loading.`
                return;
            }
        }

        this.dataLoading.splice(itemIndex, 1);
        this.dataSource.splice(0, 0, item);
    }

    public deleteItem(item: any) {
        let itemIndex = -1;
        if (!item) {
            item.errorText = 'endLoading không được để trống item';
            return;
        }
        if (!item[this.keyId]) {
            item.errorText = `Không thể xóa item do không truyền id key ${this.keyId}`;
            return;
        } else {
            itemIndex = this.dataLoading.findIndex(x => x[this.keyId] === item[this.keyId]);
            if (itemIndex === -1) {
                item.errorText = `Không thể xóa item có id ${item[this.keyId]} do không tìm thấy trong dữ liệu Loading.`
                return;
            }
        }

        this.dataLoading.splice(itemIndex, 1);
    }

    public setError(item: any, errorText: any) {
        let itemIndex = -1;
        if (!item) {
            item.errorText = 'setError không được để trống item';
            return;
        }
        if (!item[this.keyId]) {
            item.errorText = `Không thể xóa item do không truyền id key ${this.keyId}`;
            return;
        } else {
            itemIndex = this.dataLoading.findIndex(x => x[this.keyId] === item[this.keyId]);
            if (itemIndex === -1) {
                item.errorText = `Không thể sét lỗi item có id ${item[this.keyId]} do không tìm thấy trong dữ liệu Loading.`
                return;
            }
        }

        item.statusLoading = 2;
        if (errorText instanceof Object) {
            const lstMessageAlert: string[] = [];
            for (const key in errorText) {
                // tslint:disable-next-line: prefer-for-of
                for (let index = 0; index < errorText[key].length; index++) {
                    const value = errorText[key][index];
                    lstMessageAlert.push(value);
                }
            }
            this.dataLoading[itemIndex].errorText = lstMessageAlert.join(', ');
        } else {
            this.dataLoading[itemIndex].errorText = errorText;
        }

    }

    public setConfirm(item: any, confirmText: string, result: any) {
        let itemIndex = -1;
        if (!item) {
            item.errorText = 'setError không được để trống item';
            return;
        }
        if (!item[this.keyId]) {
            item.errorText = `Không thể xóa item do không truyền id key ${this.keyId}`;
            return;
        } else {
            itemIndex = this.dataLoading.findIndex(x => x[this.keyId] === item[this.keyId]);
            if (itemIndex === -1) {
                item.errorText = `Không thể sét lỗi item có id ${item[this.keyId]} do không tìm thấy trong dữ liệu Loading.`
                return;
            }
        }
        item.statusLoading = 3;
        this.dataLoading[itemIndex].errorText = null;
        this.dataLoading[itemIndex].confirmText = confirmText;
        this.dataLoading[itemIndex].confirmResult = result;
    }
}

export interface ITableLoadingAsync {
    keyId: string;
    loadingText: string;
}
