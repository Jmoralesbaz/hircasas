export interface Iinventory 
    {
        item:number,
        quantity:number,
        checkIn:Date
      }
export class Inventory implements Iinventory{
    item: number;
    quantity: number;
    checkIn: Date;
constructor(){
    this.item=0;;
    this.quantity=0;;
    this.checkIn= new Date();
}
}
