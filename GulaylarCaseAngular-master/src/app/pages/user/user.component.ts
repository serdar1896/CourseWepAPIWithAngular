import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { User, Course, Subscribe } from 'src/app/_models';
import { SubscribeService } from 'src/app/_services/subscribe.service';

import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from 'src/app/_services';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  id: number
  courses: Course[];
  subscribes: Subscribe[];
  user : User

  constructor(
    private route: ActivatedRoute,
    private userService: UserService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id']
      this.GetUserSubscribes();
    });
  }


  GetUserSubscribes() {
    this.userService.getById(this.id).subscribe(res => {
      this.user = res.Entity;
    });
  }

}
