import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CourseService } from '../../_services/course.service';
import { Course, User } from '../../_models/';

import { UserService } from '../../_services/user.service';


import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

import Swal from 'sweetalert2'

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  courses: Course[]
  SelectCourse: Course;
  users: User[];
  SelectUser: User;
  closeResult = '';

  constructor(private courseService: CourseService, private userService: UserService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.SelectCourse = new Course();
    this.GetServices();
    this.GetUsers();
  }

  GetUsers() {
    this.userService.getAll().subscribe(res => {
      this.users = res.List;
    });
  }

  GetServices() {
    this.courseService.getAll().subscribe(res => {
      this.courses = res.List;
    });
  }

  Modal(item: Course, content) {
    this.SelectCourse = new Course();
    if (item != null) {
      this.SelectCourse = item
    }

    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  userModal(item: User, userModel) {
    this.SelectUser = new User();
    if (item != null) {
      this.SelectUser = item
    }

    this.modalService.open(userModel, { ariaLabelledBy: 'User-Modal' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  Save() {
    if (this.SelectCourse.Id != null) {
      this.courseService.edit(this.SelectCourse).subscribe(res => {
        this.bildirim('Başarı ile kayıt edildi.');

        this.GetServices();
        this.modalService.dismissAll()
      });
    } else {
      this.courseService.save(this.SelectCourse).subscribe(res => {
        this.bildirim('Başarı ile kayıt edildi.');
        this.GetServices();
        this.modalService.dismissAll()
      });
    }


  }
  SaveUser() {
    if (this.SelectUser.Id != null) {
      this.userService.edit(this.SelectUser).subscribe(res => {
        this.bildirim('Başarı ile kayıt edildi.');

        this.GetUsers();
        this.modalService.dismissAll()
      });
    } else {
      this.userService.save(this.SelectUser).subscribe(res => {
        this.bildirim('Başarı ile kayıt edildi.');
        this.GetUsers();
        this.modalService.dismissAll()
      });
    }


  }
  Delete(item: Course) {
    Swal.fire({
      title: 'Emin Misiniz?',
      text: "Silinen Kayıtlar Geri Döndürülemez!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Evet, sil!'
    }).then((result) => {
      if (result.value) {
        this.courseService.delete(item.Id).subscribe(res => {
          if (res.IsSuccessful) {
            Swal.fire(
              'Silindi!',
              'Başarı ile silindi.',
              'success'
            )
            this.GetServices();
          }
        });
      }
    })

  }
  DeleteUser(item: User) {
    Swal.fire({
      title: 'Emin Misiniz?',
      text: "Silinen Kayıtlar Geri Döndürülemez!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Evet, sil!'
    }).then((result) => {
      if (result.value) {
        this.userService.deleteById(item.Id).subscribe(res => {
          if (res.IsSuccessful) {
            Swal.fire(
              'Silindi!',
              'Başarı ile silindi.',
              'success'
            )
            this.GetUsers();
          }
        });
      }
    })

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
