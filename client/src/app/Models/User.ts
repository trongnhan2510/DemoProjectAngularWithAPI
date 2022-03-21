import { Role } from "./Role";

export class User {
    user_ID: number;
    username: string;
    password: string;
    role: string;

    /**
     *
     */
    constructor(user_ID:number, username:string,password:string,role:Role) {
        this.user_ID = user_ID,
        this.password=password,
        this.username=username,
        this.role = role
    }
}