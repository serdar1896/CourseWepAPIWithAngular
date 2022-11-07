import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

import { environment } from '../../environments/environment.prod'
import { Subscribe } from '../_models/';
import { ServiceResponse } from '../_models/serviceResponse';

@Injectable({ providedIn: 'root' })
export class SubscribeService {
  constructor(private http: HttpClient) { }

  getAll(userId: number) {
    return this.http.get<ServiceResponse<Subscribe>>(`${environment.apiUrl}/Users/` + userId + `/Subscribes/`);
  }

  delete(userId: number, id: number) {
    return this.http.delete<ServiceResponse<Subscribe>>(`${environment.apiUrl}/Users/` + userId + `/Subscribes/` + id);
  }

  edit(item: Subscribe) {
    return this.http.put<ServiceResponse<Subscribe>>(`${environment.apiUrl}/Subscribes/` + item.Id, item);
  }

  save(userId: number, item: Subscribe) {
    return this.http.post<ServiceResponse<Subscribe>>(`${environment.apiUrl}/Users/` + userId + `/Subscribes/`, item);
  }

}
