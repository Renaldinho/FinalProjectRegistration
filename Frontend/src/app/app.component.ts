import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {HttpService} from "../services/http.service";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {MatDialog} from "@angular/material/dialog";
import {StudentformComponent} from "./components/studentform/studentform.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  displayedColumns: String[] = ["id","name","address","zipcode","postal district","email"]
  studentDataSource!: MatTableDataSource<Student>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private http: HttpService,private studentFormDialog:MatDialog) {

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
      address: "1111", email: "11111", id: 4, name: "caca", postaldistrict: "321312", zipcode: 1111

    }
    this.http.editStudent(student);
  }


  applyFilter(event: KeyboardEvent) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.studentDataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit(): void {
    this.http.getStudents().then((response)=>{
      this.studentDataSource = new MatTableDataSource<Student>(response);
      this.studentDataSource.paginator = this.paginator;
      this.studentDataSource.sort = this.sort;
      console.log(response)
    })
  }

  openStudentForm(id:any) {
    const dialogReferrence = this.studentFormDialog.open(StudentformComponent,{
      //width: '250px',
      enterAnimationDuration: '1000ms',
      exitAnimationDuration: '1000ms',
      data: id
    })

    dialogReferrence.afterClosed().subscribe(result =>
    {
      const student: Student = result;
      this.studentDataSource.data.push(student)
    })

  }
}


