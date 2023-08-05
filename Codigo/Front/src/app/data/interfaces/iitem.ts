export interface Iitem {
    id: number,
    item1: string,
    price: number,
    stock: number,
    asset: boolean
}
export class Item implements Iitem {
    id: number;
    item1: string;
    price: number;
    stock: number;
    asset: boolean;
    constructor() {
        this.id = 0;
        this.item1 = "";
        this.price = 0;
        this.stock = 0;
        this.asset = true;
    }
}
