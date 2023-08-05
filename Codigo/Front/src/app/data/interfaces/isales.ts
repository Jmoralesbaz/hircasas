

export interface IItemSale {
    item: number,
    itemName: string,
    quantity: number,
    price: number
}
export interface Isales {
    person: number,
    items:IItemSale []
}
export class Sales implements Isales{
    person: number
    items: IItemSale[]
    constructor(){
        this.person=0;
        this.items=[];
    }

}
export interface IsalesDetals extends Isales{
    id:number,
    totalItems:number,
    amount:number,
    dateSale:Date,
}
export class SalesDetails implements IsalesDetals{
    id: number;
    totalItems: number;
    amount: number;
    dateSale: Date;
    person: number;
    items: IItemSale[];
    constructor(){
        this.id=0;
        this.totalItems=0;
        this.amount=0;
        this.dateSale= new Date();
        this.person=0;
        this.items=[];
    }

}