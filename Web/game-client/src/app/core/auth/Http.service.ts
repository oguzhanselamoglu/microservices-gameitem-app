import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class HttpService {
    apiAddress: string = environment.apiUrl ;
    identityAddress: string = environment.identityUrl + '';
    constructor(private httpClient: HttpClient) {}

    get(url: string): Promise<any> {
        const fullUrl: string = this.apiAddress + url;
        return this.httpClient.get<Promise<any>>(fullUrl).toPromise();
    }

    post(url: string, body: any): Promise<any> {
        const fullUrl: string = this.apiAddress + url;
        return this.httpClient
            .post<Promise<any>>(fullUrl, body)
            .toPromise()
            .then((res) => ({
                 res
            }));
    }
    signUp(url: string, body: any): Observable<any> {
        const fullUrl: string = this.identityAddress + url;
        return this.httpClient
            .post<Promise<any>>(fullUrl, body);

    }

    signIn(url: string, model: any): Observable<any> {
        const body = new HttpParams()
        .set('grant_type', 'password')
        .set('username', model.userName)
        .set('password', model.password)
        .set('client_id', 'adminclient')
       // .set('scope', model.scope)
        .set('client_secret', 'secret');

        const fullUrl: string = this.identityAddress + url;

        return this.httpClient.post<any>(fullUrl,
        body.toString(),
        { headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded') });



    }

    getRequest(url: string): Observable<any> {
        const fullUrl: string = this.apiAddress + url;
        return this.httpClient
            .get(fullUrl);
    }
}
