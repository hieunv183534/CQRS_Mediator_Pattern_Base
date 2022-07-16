
export class PagingResult<T = any> {
    data: T;
    countPaging: number;

    public get ok(): boolean {
        return true;
    }
}
