import { Role } from './Role';

export class Employee{
    employee_ID:number;
    employee_Name:string;
    gender:boolean;
    address:string;
    telePhone:string;
    dateOfBirth:Date;
    role!: Role;
    token?: string;
    constructor(employee_ID:number,employee_Name:string,gender:boolean,address:string,telePhone:string,dateOfBirth:Date)
    {
        this.employee_ID=employee_ID;
        this.employee_Name=employee_Name;
        this.gender=gender;
        this.address=address;
        this.telePhone=telePhone;
        this.dateOfBirth=dateOfBirth;
    }
}