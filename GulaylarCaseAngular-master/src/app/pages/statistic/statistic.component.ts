import { Component, OnInit, ViewChild } from '@angular/core';

import { ActivatedRoute } from '@angular/router';

import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, BaseChartDirective, Label } from 'ng2-charts';
import * as pluginAnnotations from 'chartjs-plugin-annotation';
import { WatchHistoryService } from 'src/app/_services/WatchHistory.service';

import { WatchHistoryReq } from 'src/app/_models/WatchHistoryReq'
import { DayAnalytics } from 'src/app/_models/DayAnalytics'
import { WatchHistory } from '../../_models/WatchHistory'
import { Course } from 'src/app/_models/Course'

import { NgbCalendar, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit {
  datemodel: NgbDateStruct;
  today = this.calendar.getToday();
  watchHistoryReq: WatchHistoryReq
  dayAnalytics: DayAnalytics[]
  id: number
  asdasdad: number[] = [];

  public lineChartData: ChartDataSets[] = [{ data: this.asdasdad, label: 'İzleme Miktarı' }];
  public lineChartLabels: Label[] = [];

  public lineChartColors: Color[] = [
    { // grey
      backgroundColor: 'rgba(148,159,177,0.2)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    },
    { // dark grey
      backgroundColor: 'rgba(77,83,96,0.2)',
      borderColor: 'rgba(77,83,96,1)',
      pointBackgroundColor: 'rgba(77,83,96,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(77,83,96,1)'
    },
    { // red
      backgroundColor: 'rgba(255,0,0,0.3)',
      borderColor: 'red',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    }
  ];
  public lineChartLegend = true;
  public lineChartType = 'line';
  public lineChartPlugins = [pluginAnnotations];

  watchHistorys: WatchHistory[]
  course: Course

  @ViewChild(BaseChartDirective, { static: true }) chart: BaseChartDirective;

  constructor(
    private route: ActivatedRoute,
    private watchHistoryService: WatchHistoryService,
    private calendar: NgbCalendar
  ) { }

  ngOnInit() {
    var dateObj = new Date();
    var now_month = dateObj.getUTCMonth() + 1;
    var now_day = dateObj.getUTCDate();
    var now_year = dateObj.getUTCFullYear();
    this.datemodel = {
      year: now_year,
      month: now_month,
      day: now_day,
    }


    this.route.params.subscribe(params => {
      this.id = params['id']
      this.course = new Course()
      this.course.Subscribe = []




      this.watchHistoryReq = new WatchHistoryReq();
      this.watchHistoryReq.CourseId = this.id
      this.watchHistoryReq.StartDate = new Date(this.datemodel.year + "-" + this.datemodel.month + "-" + (this.datemodel.day - 20))
      this.watchHistoryReq.EndDate = new Date(this.datemodel.year + "-" + this.datemodel.month + "-" + (this.datemodel.day + 1))

      this.getAll()
      this.changeDate()
    });


  }


  getAll() {
    this.watchHistoryService.StatisticTask(this.watchHistoryReq).subscribe(res => {
      this.dayAnalytics = res.List;
      this.GetLineChartData()
    });
  }

  GetLineChartData() {
    this.dayAnalytics.forEach(element => {
      this.lineChartLabels.push(element.NowDate.toString())
      this.asdasdad.push(element.CountData)
    });
  }



  changeDate() {
    this.watchHistoryReq.CourseId = this.id
    this.watchHistoryReq.StartDate = new Date(this.datemodel.year + "-" + this.datemodel.month + "-" + (this.datemodel.day + 1))
    this.watchHistoryService.GetByDateTime(this.watchHistoryReq).subscribe(res => {
      this.watchHistorys = res.List;
    });
  }


}
