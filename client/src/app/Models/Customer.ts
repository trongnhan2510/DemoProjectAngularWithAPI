import { Role } from "./Role";

export class Customer{
    customer_ID:number;
    customer_Name:string;
    address:string;
    telephone:string;
    role!: Role;
    token?: string;
    constructor(customer_ID:number,customer_Name:string,address:string,telephone:string)
    {
        this.customer_ID = customer_ID,
        this.customer_Name=customer_Name,
        this.address=address,
        this.telephone=telephone;
    }
}