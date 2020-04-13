import { Component, OnInit, ViewChild  } from '@angular/core';
import { DataService } from '.././data.service';
import { Job } from '../models/job';
import { MatDialog, MatTable } from '@angular/material';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [DataService]
})
export class HomeComponent implements OnInit{
  job: Job = new Job();   //current job
  jobs: Job[];                // arr jobs
  tableMode: boolean =true;       // state of table
  constructor(private dataService: DataService, public dialog: MatDialog) {
  }

  ngOnInit() {
    this.loadJobs();    // load jobs when component will start  
  }
  // get data from service
  loadJobs() {
    this.dataService.getJobs()
      .subscribe((data: Job[]) => this.jobs = data);
  }
  // save data
  save() {
    if (this.job.id === null) {
      this.dataService.createJob(this.job)
        .subscribe((data: Job) => this.jobs.push(data));
    } else {
      this.dataService.updateJob(this.job)
        .subscribe(data => this.loadJobs());
    }
    this.cancel();
  }
  editJob(j: Job) {
    this.job = j;
  }
  cancel() {
    this.job = new Job();
    this.tableMode = true;
  }
  delete(j: Job) {
    this.dataService.deleteJob(j.id)
      .subscribe(data => this.loadJobs());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }
}
