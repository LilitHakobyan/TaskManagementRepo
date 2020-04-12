import { Component, Inject, Injectable } from '@angular/core';

import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';

@Component({
  templateUrl: 'message.component.html'
})
export class MessageComponent {
  message:string;
  constructor(private dialogRef: MatDialogRef<MessageComponent>, @Inject(MAT_DIALOG_DATA) public data: any) {
    this.message = data.message;
  }
  public closeMe() {
    this.dialogRef.close();
  }
}
