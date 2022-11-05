import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {HttpService} from "../services/http.service";
import {MatTable, MatTableDataSource} from "@angular/material/table";
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

  displayedColumns: String[] = ["id","name","address","zipcode","postal district","email","actions"]
  studentDataSource!: MatTableDataSource<Student>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) studentTable!: MatTable<Student>;

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
    this.http.deleteStudent(id).then((response => {
      this.studentDataSource.data = this.http.students
    }));

  }


  applyFilter(event: KeyboardEvent) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.studentDataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit(): void {
    this.initializeDataSource()
  }

  openStudentForm(student:Student) {
    const dialogReferrence = this.studentFormDialog.open(StudentformComponent,{
      //width: '250px',
      enterAnimationDuration: '1000ms',
      exitAnimationDuration: '1000ms',
      data: student
    })

    dialogReferrence.afterClosed().subscribe(result =>
    {
      if (result==undefined)
        return
      if (student!=null)
        this.editStudent(result);
      else
        this.createStudent(result);
    })

  }

  private initializeDataSource() {
    this.http.getStudents().then((response)=>{
      this.studentDataSource = new MatTableDataSource<Student>(this.http.students);
      this.studentDataSource.paginator = this.paginator;
      this.studentDataSource.sort = this.sort;
    })
  }

  createStudent(result: any) {
    const studentDTO: StudentDTO = result;
    this.http.createStudent(studentDTO).then((response => {
      this.studentDataSource.data = this.http.students;
    }))
  }

  editStudent(studentToEdit: Student) {
    const student: Student = studentToEdit;
    this.http.editStudent(student).then((response=> {
      this.initializeDataSource();
    }));
  }

  public saveStudent(result: any) {
    this.openStudentForm(result)
  }
}


