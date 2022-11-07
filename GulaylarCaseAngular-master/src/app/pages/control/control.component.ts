import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { SubscribeService } from '../../_services/subscribe.service'
import { CourseService } from '../../_services/course.service'
import { Subscribe, Course, User } from '../../_models'
import { WatchHistoryService } from '../../_services/WatchHistory.service'
import { WatchHistory } from '../../_models/WatchHistory'
import { WatchHistoryReq } from '../../_models/WatchHistoryReq'

import { NgbCalendar, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

import Swal from 'sweetalert2'


import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

import { UserService } from '../../_services/user.service';


@Component({
  selector: 'app-control',
  templateUrl: './control.component.html',
  styleUrls: ['./control.component.css']
})
export class ControlComponent implements OnInit {
  id: number
  subscribe: Subscribe
  course: Course
  watchHistory: WatchHistory
  watchHistorys: WatchHistory[]
  subscribeUser: Subscribe
  users: User[];
  datenow: Date;
  watchHistoryReq: WatchHistoryReq

  constructor(
    private route: ActivatedRoute,
    private subscribeService: SubscribeService,
    private courseService: CourseService,
    private watchHistoryService: WatchHistoryService,
    private modalService: NgbModal,
    private userService: UserService,
    private calendar: NgbCalendar) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.watchHistoryReq = new WatchHistoryReq()





      this.id = params['id']
      this.course = new Course()
      this.course.Subscribe = []
      this.getSubscribe(this.id);
      this.getCourseById(this.id);
    });
    this.datenow = new Date();
    this.watchHistory = new WatchHistory();
  }
  getSubscribe(id) {
    this.courseService.getItem(id).subscribe(res => {
      this.course = res.Entity;
    });
  }

  GetUsers() {
    this.userService.getAll().subscribe(res => {
      this.users = res.List;
    });
  }


  closeResult = '';
  openModal(userModel) {
    this.modalService.open(userModel, { ariaLabelledBy: 'User-Modal' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
    this.GetUsers()
  }

  AddCourse(item) {

  }
  getCourseById(id) {
    this.watchHistoryService.GetByCourseId(id).subscribe(res => {
      this.watchHistorys = res.List;
    });
  }

  ChangeStatus(item: Subscribe) {
    this.watchHistory.CourseId = this.id;
    this.watchHistory.UserId = item.UserId;
    this.watchHistoryService.WatchStatus(this.watchHistory).subscribe(res => {
      this.getSubscribe(this.id);
      this.getCourseById(this.id);
    });

  }
  checkCourse(item: Subscribe) {
    if (this.watchHistorys != null) {
      var checkItem = this.watchHistorys.find(x => x.UserId == item.User.Id);
      if (checkItem) {
        return true;
      }
    }
    return false;
  }


  checkUserCourse(item: User) {
    if (this.course.Subscribe != null) {
      var checkItem = this.course.Subscribe.find(x => x.UserId == item.Id);
      if (checkItem) {
        return true;
      }
    }
    return false;
  }



  SaveSubscribe(item: User) {
    this.subscribe = new Subscribe();
    this.subscribe.CourseId = this.id;
    this.subscribe.UserId = item.Id;
    this.subscribeService.save(item.Id, this.subscribe).subscribe(res => {
      this.bildirim('Başarı ile kayıt edildi.');
      this.modalService.dismissAll()
      this.getSubscribe(this.id);
      this.getCourseById(this.id);
    });
  }

  SubscribeDelete(item: Subscribe) {
    this.subscribeService.delete(item.UserId, item.Id).subscribe(res => {
      this.modalService.dismissAll()
      this.getSubscribe(this.id);
      this.getCourseById(this.id);
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  bildirim(message) {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: message,
      showConfirmButton: false,
      timer: 1500
    })
  }
}
