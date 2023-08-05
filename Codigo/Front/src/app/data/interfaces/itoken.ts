export interface Itoken {
  token: string,
  dataUser:Idatauder
}
export interface Idatauder{
  rol:string,
  person: number,
  user: string,
  
  expired:number
}
