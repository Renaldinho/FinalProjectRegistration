import { Component, OnInit } from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-studentform',
  templateUrl: './studentform.component.html',
  styleUrls: ['./studentform.component.css']
})
export class StudentformComponent implements OnInit {

  constructor(private builder: FormBuilder,public dialogRef: MatDialogRef<StudentformComponent>) { }

  ngOnInit(): void {
  }

  studentForm = this.builder.group({
    id:this.builder.control({value:'1',disabled:true}),
    name:this.builder.control('',Validators.required),
    address:this.builder.control('',Validators.required),
    zipcode:this.builder.control('',Validators.required),
    postaldistrict:this.builder.control('',Validators.required),
    email:this.builder.control('',Validators.required)
  })

  cancel() {
    this.dialogRef.close();
  }

  saveStudent() {
    if (this.studentForm.valid){
      const student: any = {
        name: this.studentForm.controls.name.value,
        address: this.studentForm.controls.address.value,
        zipcode: this.studentForm.controls.zipcode.value,
        postaldistrict: this.studentForm.controls.postaldistrict.value,
        email: this.studentForm.controls.email.value
      }
      this.dialogRef.close(student);
    }
  }
}
