import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

import { environment } from '../../environments/environment.prod'
import { Course } from '../_models/Course';
import { ServiceResponse } from '../_models/serviceResponse';

@Injectable({ providedIn: 'root' })
export class CourseService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<ServiceResponse<Course>>(`${environment.apiUrl}/Courses`);
  }
  getItem(id : number) {
    return this.http.get<ServiceResponse<Course>>(`${environment.apiUrl}/Courses/`+ id);
  }

  delete(id : number) {
    return this.http.delete<ServiceResponse<Course>>(`${environment.apiUrl}/Courses/`+ id);
  }

  edit(item : Course) {
    return this.http.put<ServiceResponse<Course>>(`${environment.apiUrl}/Courses/`+ item.Id, item);
  }

  save(item : Course) {
    return this.http.post<ServiceResponse<Course>>(`${environment.apiUrl}/Courses/`, item);
  }
}
