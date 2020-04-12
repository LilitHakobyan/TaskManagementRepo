import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './models/user';

@Injectable()
export class LoginService {

  private url = "/api/users";

  constructor(private http: HttpClient) {
  }

  getUsers() {
    return this.http.get(this.url);
  }

  getUser(id: number) {
    return this.http.get(this.url + '/' + id);
  }
  getUserByCred(user: User) {
    return this.http.post(this.url, user);
  }
}
