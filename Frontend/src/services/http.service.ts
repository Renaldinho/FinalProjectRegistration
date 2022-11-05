import {Injectable, OnInit} from '@angular/core';
import axios from 'axios';//import

//Config
export const customAxios = axios.create({
  baseURL: 'https://localhost:7105'
})


@Injectable({
  providedIn: 'root'
})
export class HttpService{

  students: Student[] = [];

  constructor() {
    this.getStudents();
  }

  async getStudents(){
    const httpResponse = await customAxios.get<Student[]>('/Student/GetStudents');
    this.students = httpResponse.data;
    return this.students;
  }

  async createStudent(dto:  StudentDTO): Promise<Student>  {
    const httpResponse = await customAxios.post('/Student/PostStudent',dto);
    this.students.push(httpResponse.data);
    return httpResponse.data
  }

  async deleteStudent(id:number){
    const httpResponse = await customAxios.delete('/Student/'+id);
    this.students.filter(s=>s.id!=httpResponse.data.id);
  }

  async editStudent(student: Student){
    const httpResponse = await customAxios.put('Student/UpdateStudent/'+student.id,student)
    let itemIndex = this.students.findIndex(s=>s.id==student.id);
    this.students[itemIndex] = httpResponse.data;
  }


}


