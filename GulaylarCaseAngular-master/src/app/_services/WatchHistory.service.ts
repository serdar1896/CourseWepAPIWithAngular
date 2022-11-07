import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.prod';
import { WatchHistory } from '../_models/WatchHistory';
import { ServiceResponse } from '../_models/serviceResponse';
import { WatchHistoryReq } from '../_models/WatchHistoryReq';
import { DayAnalytics } from 'src/app/_models/DayAnalytics';

@Injectable({ providedIn: 'root' })
export class WatchHistoryService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<ServiceResponse<WatchHistory>>(`${environment.apiUrl}/WatchHistorys`);
  }
  getItem(id: number) {
    return this.http.get<ServiceResponse<WatchHistory>>(`${environment.apiUrl}/WatchHistorys/` + id);
  }

  delete(id: number) {
    return this.http.delete<ServiceResponse<WatchHistory>>(`${environment.apiUrl}/WatchHistorys/` + id);
  }

  edit(item: WatchHistory) {
    return this.http.put<ServiceResponse<WatchHistory>>(`${environment.apiUrl}/WatchHistorys/` + item.Id, item);
  }

  save(item: WatchHistory) {
    return this.http.post<ServiceResponse<WatchHistory>>(`${environment.apiUrl}/WatchHistorys/`, item);
  }
  WatchStatus(item: WatchHistory) {
    return this.http.post<ServiceResponse<WatchHistory>>(`${environment.apiUrl}/WatchStatus/`, item);
  }
  GetByCourseId(courseId: number) {
    return this.http.get<ServiceResponse<WatchHistory>>(`${environment.apiUrl}/GetByCourseId/` + courseId);
  }
  GetByDateTime(item: WatchHistoryReq) {
    return this.http.post<ServiceResponse<WatchHistory>>(`${environment.apiUrl}/GetByDateTime/`, item);
  }
  StatisticTask(item: WatchHistoryReq) {
    return this.http.post<ServiceResponse<DayAnalytics>>(`${environment.apiUrl}/StatisticTask/`, item);
  }
}
