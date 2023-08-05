export interface Iperson {
    id:number,
    name:string,
    lastName:string,
    email:string,
    asset:boolean,
}
export class Person implements Iperson{
     id:number;
    name:string;
    lastName:string;
    email:string;
    asset:boolean;
    constructor(){
        this.id=0;
        this.name="";
        this.lastName="";
        this.email="";
        this.asset=false;
    }
}