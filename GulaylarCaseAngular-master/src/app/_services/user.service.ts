import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

import { environment } from '../../environments/environment.prod'
import { User } from '../_models/User';
import { ServiceResponse } from '../_models';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<ServiceResponse<User>>(`${environment.apiUrl}/Users/`);
  }
  authenticate(model: User): Observable<any> {
    return this.http.post<ServiceResponse<User>>(`${environment.apiUrl}/Users/authenticate`, model);
  }
  userRegister(model: User): Observable<any> {
    return this.http.post<ServiceResponse<User>>(`${environment.apiUrl}/Users/register`, model);
  }
  getById(id: number): Observable<any> {
    return this.http.get<ServiceResponse<User>>(`${environment.apiUrl}/Users/` + id);
  }
  deleteById(id: number): Observable<any> {
    return this.http.delete<ServiceResponse<User>>(`${environment.apiUrl}/Users/` + id);
  }
  save(model: User): Observable<any> {
    return this.http.post<ServiceResponse<User>>(`${environment.apiUrl}/Users/`, model);
  }
  edit(model: User): Observable<any> {
    return this.http.put<ServiceResponse<User>>(`${environment.apiUrl}/Users/`, model);
  }
  changepassword(userId: number, oldpassword: string, newpassword: string): Observable<any> {
    return this.http.post<ServiceResponse<User>>(`${environment.apiUrl}/Users/changepassword/`, { userId, oldpassword, newpassword });
  }

}
