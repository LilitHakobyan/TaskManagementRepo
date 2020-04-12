import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from "../login.service";
import { User } from "../models/user";
import { MessageComponent } from "../message.component";
import { MatDialog, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [LoginService]
})
export class LoginComponent implements OnInit {
  constructor(private router: Router, private loginService: LoginService, private dialog: MatDialog) { }
  username: string;
  password: string;
  ngOnInit() {
  }
  login(): void {
    let user = new User(null, this.username, this.password);
    this.loginService.getUserByCred(user)
      .subscribe((data: User) => {
        if (data !== null) {
          this.router.navigate(["jobs"]);
        } else {
          this.dialog.open(MessageComponent, {
            data: {
              message: "Username or Password is incorrect!!!"
            }
          });
        } }
  );
  }
}

