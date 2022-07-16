export class SwaggerResponseHandler<TResult> {
    status: number;
    headers: { [key: string]: any; };
    result: TResult;
    error: any;
    success: boolean;

    constructor(status: number, headers: { [key: string]: any; }, result: TResult) {
        let rs: any = result;
        this.status = status;
        this.headers = headers;
        if (status === 200 || status === 204) {
            this.result = result;
            this.success = true;
        } else {
            this.error = rs?.errors;
            this.success = false;
        }
    }
}