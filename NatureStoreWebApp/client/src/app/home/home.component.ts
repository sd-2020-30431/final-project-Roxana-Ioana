import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import { User } from '../model/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userDetails: User;

  constructor(private router: Router, private service: UserService) { }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res as User;
      },
      err => {
        console.log(err);
      },
    );
  }

  onLogout()
  {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }

  onAdminLogin(){
    this.router.navigate(['/products']);
  }

  onStartCommand(){
    this.router.navigate(['/command', this.userDetails.id]);
  }
}
