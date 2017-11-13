import { Injectable }from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';

export interface ICustomNgHttpService{
Leavemanagement_GetAllLeaveStatus(): Promise<any>;
Leavemanagement_GetLeaveTypes(): Promise<any>;
Values_Get(): Promise<string[]>;
Values_Post(value : string): Promise<void>;
Values_Put(id : number,value : string): Promise<void>;
Values_Delete(id : number): Promise<any>;

}@Injectable()

export class CustomNgHttpService implements ICustomNgHttpService {

             baseUrl: string ='http://localhost:59436/';
static $inject = ['$http', '$q'];
 constructor(private http: Http){}
public GetCall<T>(url : string):Promise<T>{
     return this.http.get(url).toPromise()
    .then(i => <T>i.json())
 .catch(this.handleError);
    }

PostCall<T>(url: string, data: any,config:any): Promise<any> {
       
        return this.http.post(url, data)
        .toPromise()
        .then(i=> i.json())
        .catch(this.handleError)
    
}

PutCall<T> (url : string,data : any, config : any): Promise<T> {

 return this.http.put(url, data, config)
                .toPromise()
        .then(i=> i.json())
        .catch(this.handleError)
}

    DeleteCall<T>(url: string, data: any, config: any){
    return this.http.delete(url)
    .toPromise()
    .then(i=> i.json())
    .catch(this.handleError)
}

private handleError (error:   any) {
    // In a real world app, we might use a remote logging infrastructure<br/>
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Promise.reject(errMsg);


}
Leavemanagement_GetAllLeaveStatus(): Promise<any>{
                    var url = this.baseUrl+'Leavemanagement'+'\\'+'GetAllLeaveStatus'; 
 return this.GetCall<any>(url);
}
Leavemanagement_GetLeaveTypes(): Promise<any>{
                    var url = this.baseUrl+'Leavemanagement'+'\\'+'GetLeaveTypes'; 
 return this.GetCall<any>(url);
}
Values_Get(): Promise<string[]>{
                    var url = this.baseUrl+'Values'+'\\'+'Get'; 
 return this.GetCall<string[]>(url);
}Values_Post(value : string): Promise<void>{
                    var url = this.baseUrl+'Values'+'\\'+'Post'; 
 return this.PostCall<void>(url, value, '');
}
Values_Put(id : number,value : string): Promise<void>{
                    var url = this.baseUrl+'Values'+'\\'+'Put'; 
 return this.PutCall<void>(url, value, '');
}Values_Delete(id : number): Promise<any>{
                    var url = this.baseUrl+'Values\\'+'Delete'+'\\'+id; 
 return this.DeleteCall<any>(url, '', '');
}
}
