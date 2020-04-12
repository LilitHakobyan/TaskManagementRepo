import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Job } from './models/job';

@Injectable()
export class DataService {

  private url = "/api/jobs";

  constructor(private http: HttpClient) {
  }

  getJobs() {
    return this.http.get(this.url);
  }

  getJob(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  createJob(job: Job) {
    return this.http.post(this.url, job);
  }

  updateJob(job: Job) {

    return this.http.put(this.url, job);
  }

  deleteJob(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
