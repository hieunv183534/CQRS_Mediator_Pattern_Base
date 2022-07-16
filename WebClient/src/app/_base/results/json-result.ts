
export class JsonResult<T = any> {
    data: T;
    desc: string;
    msg: string;
    result: string;

    public get ok(): boolean {
        return this.result === 'Success';
    }
}
