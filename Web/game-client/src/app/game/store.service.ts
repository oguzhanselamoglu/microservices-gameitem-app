import { Injectable } from '@angular/core';
import { HttpService } from 'app/core/auth/Http.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

constructor(private httpService: HttpService) { }

getStores(): Observable<any> {
    return this.httpService.getRequest('store/store/GetGameItem');
  }
}
