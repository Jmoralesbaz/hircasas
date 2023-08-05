export interface Iusers {
    id:number,
    person:number,
    userName:string,
    password:string,
    rol:string,
    asset:boolean,
}
export class Users implements Iusers{
    id:number;
    person:number;
    userName:string;
    password:string;
    rol:string;
    asset:boolean;
    constructor(){
        this.id=0;
        this.person=0;
        this.userName="";
        this.password="";
        this.rol="";
        this.asset=true;
    }
}