import { Component } from '@angular/core';
import {HttpService} from "../services/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {


  constructor(private http: HttpService) {

  }

  printStudents() {
    console.log(this.http.students);
  }

  async createTestStudent() {
    const studentDTO: StudentDTO ={
      name: "name",address: "bob", zipcode: 12133, postaldistrict: "2121",email: "mail"
    }

    await this.http.createStudent(studentDTO);
  }

  deleteStudent(id: number) {
    this.http.deleteStudent(id);
  }

  editStudent() {
    const student: Student = {
      address: "1111", email: "11111", id: 8, name: "bababababbaba", postaldistrict: "321312", zipcode: 1111

    }
    this.http.editStudent(student);
  }
}


