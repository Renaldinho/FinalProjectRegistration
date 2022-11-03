import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {HttpService} from "../services/http.service";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit{

  displayedColumns: String[] = ["id","name","address","zipcode","postal district","email"]
  studentDataSource!: MatTableDataSource<Student>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private http: HttpService) {
    this.studentDataSource = new MatTableDataSource<Student>(this.http.students);
  }

  ngAfterViewInit(): void {
    this.studentDataSource.paginator = this.paginator;
    this.studentDataSource.sort = this.sort;
  }

  printStudents() {
    this.studentDataSource = new MatTableDataSource<Student>(this.http.students);
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


  applyFilter(event: KeyboardEvent) {
    console.log((event.target as HTMLInputElement).value);
  }
}


