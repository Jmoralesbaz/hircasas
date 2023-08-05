export interface Ilogin {
    user:string,
    password:string,
}
export class Login implements Ilogin{
    user: string;
    password: string;
    constructor(){
        this.user="";
        this.password="";
    }

}
