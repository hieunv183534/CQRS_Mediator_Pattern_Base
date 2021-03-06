//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL_REPORT = new InjectionToken<string>('API_BASE_URL_REPORT');

export interface IReportBiApi {
    view(reportId?: number | null | undefined, reportCode?: string | null | undefined, reportParams?: string | null | undefined, type?: number | undefined, fileName?: string | null | undefined): Observable<SwaggerResponseHandler<FileResponse>>;
    export(reportId?: number | null | undefined, reportCode?: string | null | undefined, reportParams?: string | null | undefined, type?: number | undefined, fileName?: string | null | undefined): Observable<SwaggerResponseHandler<FileResponse>>;
    testDataSet(request: NOMREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery): Observable<SwaggerResponseHandler<string>>;
    listConnection(request: NOMDomainGlobal_BaseModelsBasePagingModel): Observable<SwaggerResponseHandler<NOMDomainGlobal_BaseModelsPagingResultModel1>>;
    test(): Observable<SwaggerResponseHandler<string>>;
    testQueue(): Observable<SwaggerResponseHandler<string>>;
    barcode(): Observable<SwaggerResponseHandler<FileResponse>>;
}

@Injectable({
    providedIn: 'root'
})
export class ReportBiApi implements IReportBiApi {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL_REPORT) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    view(reportId?: number | null | undefined, reportCode?: string | null | undefined, reportParams?: string | null | undefined, type?: number | undefined, fileName?: string | null | undefined): Observable<SwaggerResponseHandler<FileResponse>> {
        let url_ = this.baseUrl + "/api/ReportBi/View?";
        if (reportId !== undefined && reportId !== null)
            url_ += "ReportId=" + encodeURIComponent("" + reportId) + "&";
        if (reportCode !== undefined && reportCode !== null)
            url_ += "ReportCode=" + encodeURIComponent("" + reportCode) + "&";
        if (reportParams !== undefined && reportParams !== null)
            url_ += "ReportParams=" + encodeURIComponent("" + reportParams) + "&";
        if (type === null)
            throw new Error("The parameter 'type' cannot be null.");
        else if (type !== undefined)
            url_ += "Type=" + encodeURIComponent("" + type) + "&";
        if (fileName !== undefined && fileName !== null)
            url_ += "FileName=" + encodeURIComponent("" + fileName) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processView(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processView(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<SwaggerResponseHandler<FileResponse>>;
                }
            } else
                return _observableThrow(response_) as any as Observable<SwaggerResponseHandler<FileResponse>>;
        }));
    }

    protected processView(response: HttpResponseBase): Observable<SwaggerResponseHandler<FileResponse>> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf(new SwaggerResponseHandler(status, _headers, { fileName: fileName, data: responseBlob as any, status: status, headers: _headers }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<SwaggerResponseHandler<FileResponse>>(new SwaggerResponseHandler(status, _headers, null as any));
    }

    export(reportId?: number | null | undefined, reportCode?: string | null | undefined, reportParams?: string | null | undefined, type?: number | undefined, fileName?: string | null | undefined): Observable<SwaggerResponseHandler<FileResponse>> {
        let url_ = this.baseUrl + "/api/ReportBi/Export?";
        if (reportId !== undefined && reportId !== null)
            url_ += "ReportId=" + encodeURIComponent("" + reportId) + "&";
        if (reportCode !== undefined && reportCode !== null)
            url_ += "ReportCode=" + encodeURIComponent("" + reportCode) + "&";
        if (reportParams !== undefined && reportParams !== null)
            url_ += "ReportParams=" + encodeURIComponent("" + reportParams) + "&";
        if (type === null)
            throw new Error("The parameter 'type' cannot be null.");
        else if (type !== undefined)
            url_ += "Type=" + encodeURIComponent("" + type) + "&";
        if (fileName !== undefined && fileName !== null)
            url_ += "FileName=" + encodeURIComponent("" + fileName) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processExport(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processExport(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<SwaggerResponseHandler<FileResponse>>;
                }
            } else
                return _observableThrow(response_) as any as Observable<SwaggerResponseHandler<FileResponse>>;
        }));
    }

    protected processExport(response: HttpResponseBase): Observable<SwaggerResponseHandler<FileResponse>> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf(new SwaggerResponseHandler(status, _headers, { fileName: fileName, data: responseBlob as any, status: status, headers: _headers }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<SwaggerResponseHandler<FileResponse>>(new SwaggerResponseHandler(status, _headers, null as any));
    }

    testDataSet(request: NOMREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery): Observable<SwaggerResponseHandler<string>> {
        let url_ = this.baseUrl + "/api/ReportBi/TestDataSet";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(request);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processTestDataSet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processTestDataSet(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<SwaggerResponseHandler<string>>;
                }
            } else
                return _observableThrow(response_) as any as Observable<SwaggerResponseHandler<string>>;
        }));
    }

    protected processTestDataSet(response: HttpResponseBase): Observable<SwaggerResponseHandler<string>> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : <any>null;
    
            return _observableOf(new SwaggerResponseHandler(status, _headers, result200));
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<SwaggerResponseHandler<string>>(new SwaggerResponseHandler(status, _headers, null as any));
    }

    listConnection(request: NOMDomainGlobal_BaseModelsBasePagingModel): Observable<SwaggerResponseHandler<NOMDomainGlobal_BaseModelsPagingResultModel1>> {
        let url_ = this.baseUrl + "/api/ReportBi/ListConnection";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(request);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processListConnection(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processListConnection(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<SwaggerResponseHandler<NOMDomainGlobal_BaseModelsPagingResultModel1>>;
                }
            } else
                return _observableThrow(response_) as any as Observable<SwaggerResponseHandler<NOMDomainGlobal_BaseModelsPagingResultModel1>>;
        }));
    }

    protected processListConnection(response: HttpResponseBase): Observable<SwaggerResponseHandler<NOMDomainGlobal_BaseModelsPagingResultModel1>> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = NOMDomainGlobal_BaseModelsPagingResultModel1.fromJS(resultData200);
            return _observableOf(new SwaggerResponseHandler(status, _headers, result200));
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<SwaggerResponseHandler<NOMDomainGlobal_BaseModelsPagingResultModel1>>(new SwaggerResponseHandler(status, _headers, null as any));
    }

    test(): Observable<SwaggerResponseHandler<string>> {
        let url_ = this.baseUrl + "/api/ReportBi/Test";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processTest(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processTest(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<SwaggerResponseHandler<string>>;
                }
            } else
                return _observableThrow(response_) as any as Observable<SwaggerResponseHandler<string>>;
        }));
    }

    protected processTest(response: HttpResponseBase): Observable<SwaggerResponseHandler<string>> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : <any>null;
    
            return _observableOf(new SwaggerResponseHandler(status, _headers, result200));
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<SwaggerResponseHandler<string>>(new SwaggerResponseHandler(status, _headers, null as any));
    }

    testQueue(): Observable<SwaggerResponseHandler<string>> {
        let url_ = this.baseUrl + "/api/ReportBi/TestQueue";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processTestQueue(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processTestQueue(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<SwaggerResponseHandler<string>>;
                }
            } else
                return _observableThrow(response_) as any as Observable<SwaggerResponseHandler<string>>;
        }));
    }

    protected processTestQueue(response: HttpResponseBase): Observable<SwaggerResponseHandler<string>> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : <any>null;
    
            return _observableOf(new SwaggerResponseHandler(status, _headers, result200));
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<SwaggerResponseHandler<string>>(new SwaggerResponseHandler(status, _headers, null as any));
    }

    barcode(): Observable<SwaggerResponseHandler<FileResponse>> {
        let url_ = this.baseUrl + "/api/ReportBi/Barcode";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processBarcode(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processBarcode(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<SwaggerResponseHandler<FileResponse>>;
                }
            } else
                return _observableThrow(response_) as any as Observable<SwaggerResponseHandler<FileResponse>>;
        }));
    }

    protected processBarcode(response: HttpResponseBase): Observable<SwaggerResponseHandler<FileResponse>> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf(new SwaggerResponseHandler(status, _headers, { fileName: fileName, data: responseBlob as any, status: status, headers: _headers }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<SwaggerResponseHandler<FileResponse>>(new SwaggerResponseHandler(status, _headers, null as any));
    }
}

export class NOMREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery implements INOMREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery {
    reportId?: number | undefined;
    reportCode?: string | undefined;
    reportParams?: string | undefined;

    constructor(data?: INOMREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.reportId = _data["reportId"];
            this.reportCode = _data["reportCode"];
            this.reportParams = _data["reportParams"];
        }
    }

    static fromJS(data: any): NOMREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery {
        data = typeof data === 'object' ? data : {};
        let result = new NOMREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["reportId"] = this.reportId;
        data["reportCode"] = this.reportCode;
        data["reportParams"] = this.reportParams;
        return data;
    }

    clone(): NOMREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery {
        const json = this.toJSON();
        let result = new NOMREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery();
        result.init(json);
        return result;
    }
}

export interface INOMREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery {
    reportId?: number | undefined;
    reportCode?: string | undefined;
    reportParams?: string | undefined;
}

export class NOMDomainGlobal_BaseModelsPagingResultModel1 implements INOMDomainGlobal_BaseModelsPagingResultModel1 {
    data?: NOMDomainGlobal_BaseModelsComboboxModel1[] | undefined;
    paging?: NOMDomainGlobal_BaseModelsPagingModel | undefined;

    constructor(data?: INOMDomainGlobal_BaseModelsPagingResultModel1) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["data"])) {
                this.data = [] as any;
                for (let item of _data["data"])
                    this.data!.push(NOMDomainGlobal_BaseModelsComboboxModel1.fromJS(item));
            }
            this.paging = _data["paging"] ? NOMDomainGlobal_BaseModelsPagingModel.fromJS(_data["paging"]) : <any>undefined;
        }
    }

    static fromJS(data: any): NOMDomainGlobal_BaseModelsPagingResultModel1 {
        data = typeof data === 'object' ? data : {};
        let result = new NOMDomainGlobal_BaseModelsPagingResultModel1();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.data)) {
            data["data"] = [];
            for (let item of this.data)
                data["data"].push(item.toJSON());
        }
        data["paging"] = this.paging ? this.paging.toJSON() : <any>undefined;
        return data;
    }

    clone(): NOMDomainGlobal_BaseModelsPagingResultModel1 {
        const json = this.toJSON();
        let result = new NOMDomainGlobal_BaseModelsPagingResultModel1();
        result.init(json);
        return result;
    }
}

export interface INOMDomainGlobal_BaseModelsPagingResultModel1 {
    data?: NOMDomainGlobal_BaseModelsComboboxModel1[] | undefined;
    paging?: NOMDomainGlobal_BaseModelsPagingModel | undefined;
}

export class NOMDomainGlobal_BaseModelsComboboxModel1 implements INOMDomainGlobal_BaseModelsComboboxModel1 {
    value?: string | undefined;
    text?: string | undefined;
    parent?: string | undefined;

    constructor(data?: INOMDomainGlobal_BaseModelsComboboxModel1) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.value = _data["value"];
            this.text = _data["text"];
            this.parent = _data["parent"];
        }
    }

    static fromJS(data: any): NOMDomainGlobal_BaseModelsComboboxModel1 {
        data = typeof data === 'object' ? data : {};
        let result = new NOMDomainGlobal_BaseModelsComboboxModel1();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["value"] = this.value;
        data["text"] = this.text;
        data["parent"] = this.parent;
        return data;
    }

    clone(): NOMDomainGlobal_BaseModelsComboboxModel1 {
        const json = this.toJSON();
        let result = new NOMDomainGlobal_BaseModelsComboboxModel1();
        result.init(json);
        return result;
    }
}

export interface INOMDomainGlobal_BaseModelsComboboxModel1 {
    value?: string | undefined;
    text?: string | undefined;
    parent?: string | undefined;
}

export class NOMDomainGlobal_BaseModelsPagingModel implements INOMDomainGlobal_BaseModelsPagingModel {
    count?: number | undefined;
    page?: number | undefined;
    size?: number | undefined;
    loadMore?: boolean | undefined;
    order?: { [key: string]: boolean; } | undefined;

    constructor(data?: INOMDomainGlobal_BaseModelsPagingModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.count = _data["count"];
            this.page = _data["page"];
            this.size = _data["size"];
            this.loadMore = _data["loadMore"];
            if (_data["order"]) {
                this.order = {} as any;
                for (let key in _data["order"]) {
                    if (_data["order"].hasOwnProperty(key))
                        (<any>this.order)![key] = _data["order"][key];
                }
            }
        }
    }

    static fromJS(data: any): NOMDomainGlobal_BaseModelsPagingModel {
        data = typeof data === 'object' ? data : {};
        let result = new NOMDomainGlobal_BaseModelsPagingModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["count"] = this.count;
        data["page"] = this.page;
        data["size"] = this.size;
        data["loadMore"] = this.loadMore;
        if (this.order) {
            data["order"] = {};
            for (let key in this.order) {
                if (this.order.hasOwnProperty(key))
                    (<any>data["order"])[key] = this.order[key];
            }
        }
        return data;
    }

    clone(): NOMDomainGlobal_BaseModelsPagingModel {
        const json = this.toJSON();
        let result = new NOMDomainGlobal_BaseModelsPagingModel();
        result.init(json);
        return result;
    }
}

export interface INOMDomainGlobal_BaseModelsPagingModel {
    count?: number | undefined;
    page?: number | undefined;
    size?: number | undefined;
    loadMore?: boolean | undefined;
    order?: { [key: string]: boolean; } | undefined;
}

export class NOMDomainGlobal_BaseModelsBasePagingModel implements INOMDomainGlobal_BaseModelsBasePagingModel {
    where?: any | undefined;
    whereLoopBack?: any | undefined;
    select?: any | undefined;
    selectLoopBack?: any | undefined;
    order?: { [key: string]: boolean; } | undefined;
    orderLoopBack?: any | undefined;
    page?: number | undefined;
    size?: number | undefined;
    count?: number | undefined;
    loadMore?: boolean | undefined;

    constructor(data?: INOMDomainGlobal_BaseModelsBasePagingModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.where = _data["where"];
            this.whereLoopBack = _data["whereLoopBack"];
            this.select = _data["select"];
            this.selectLoopBack = _data["selectLoopBack"];
            if (_data["order"]) {
                this.order = {} as any;
                for (let key in _data["order"]) {
                    if (_data["order"].hasOwnProperty(key))
                        (<any>this.order)![key] = _data["order"][key];
                }
            }
            this.orderLoopBack = _data["orderLoopBack"];
            this.page = _data["page"];
            this.size = _data["size"];
            this.count = _data["count"];
            this.loadMore = _data["loadMore"];
        }
    }

    static fromJS(data: any): NOMDomainGlobal_BaseModelsBasePagingModel {
        data = typeof data === 'object' ? data : {};
        let result = new NOMDomainGlobal_BaseModelsBasePagingModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["where"] = this.where;
        data["whereLoopBack"] = this.whereLoopBack;
        data["select"] = this.select;
        data["selectLoopBack"] = this.selectLoopBack;
        if (this.order) {
            data["order"] = {};
            for (let key in this.order) {
                if (this.order.hasOwnProperty(key))
                    (<any>data["order"])[key] = this.order[key];
            }
        }
        data["orderLoopBack"] = this.orderLoopBack;
        data["page"] = this.page;
        data["size"] = this.size;
        data["count"] = this.count;
        data["loadMore"] = this.loadMore;
        return data;
    }

    clone(): NOMDomainGlobal_BaseModelsBasePagingModel {
        const json = this.toJSON();
        let result = new NOMDomainGlobal_BaseModelsBasePagingModel();
        result.init(json);
        return result;
    }
}

export interface INOMDomainGlobal_BaseModelsBasePagingModel {
    where?: any | undefined;
    whereLoopBack?: any | undefined;
    select?: any | undefined;
    selectLoopBack?: any | undefined;
    order?: { [key: string]: boolean; } | undefined;
    orderLoopBack?: any | undefined;
    page?: number | undefined;
    size?: number | undefined;
    count?: number | undefined;
    loadMore?: boolean | undefined;
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}

export class SwaggerException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((event.target as any).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}

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