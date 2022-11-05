import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-studentform',
  templateUrl: './studentform.component.html',
  styleUrls: ['./studentform.component.css']
})
export class StudentformComponent implements OnInit {

  constructor(private builder: FormBuilder,public dialogRef: MatDialogRef<StudentformComponent>,
              @Inject(MAT_DIALOG_DATA) public data: Student) {
    this.fillFields(data);
  }

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
      if (this.data==null){
        const studentDTO: any = {
          name: this.studentForm.controls.name.value,
          address: this.studentForm.controls.address.value,
          zipcode: this.studentForm.controls.zipcode.value,
          postaldistrict: this.studentForm.controls.postaldistrict.value,
          email: this.studentForm.controls.email.value
        }
        this.dialogRef.close(studentDTO);
      }
      else {
        const student: any = {
          id: this.data.id,
          name: this.studentForm.controls.name.value,
          address: this.studentForm.controls.address.value,
          zipcode: this.studentForm.controls.zipcode.value,
          postaldistrict: this.studentForm.controls.postaldistrict.value,
          email: this.studentForm.controls.email.value
        }
        this.dialogRef.close(student);
        console.log(student)
      }

    }
  }

  private fillFields(data: any) {
    if (data==null)
      return;
    this.studentForm.controls.id.setValue(data.id.toString());
    this.studentForm.controls.name.setValue(data.name);
    this.studentForm.controls.email.setValue(data.email);
    this.studentForm.controls.address.setValue(data.address);
    this.studentForm.controls.postaldistrict.setValue(data.postalDistrict);
    this.studentForm.controls.zipcode.setValue(data.zipCode.toString())
  }
}
