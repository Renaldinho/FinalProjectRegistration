import { Injectable } from '@angular/core';
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

  constructor() { }

  async getProducts(){
    const httpResponse = await customAxios.get<Student[]>('/Student/GetStudents');
    this.students = httpResponse.data;
  }

}

interface Student{
  id: number,
  name: string,
  address: string,
  zipcode: number,
  postal_district: string,
  email: string
}
