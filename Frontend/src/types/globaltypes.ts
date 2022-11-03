export {}

declare global {
  interface StudentDTO{
    name: string,
    address: string,
    zipcode: number,
    postaldistrict: string,
    email: string
  }

  interface Student{
    id: number,
    name: string,
    address: string,
    zipcode: number,
    postaldistrict: string,
    email: string
  }
}
