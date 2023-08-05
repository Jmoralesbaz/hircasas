export interface Iinvoice {
    sale:number,
    rfc: string,
    razonSocial: string,
    codigoPostal: string,
    regimenFiscal: string,
    usoCfdi: string,
    folio: string
}
export class Invoice implements Iinvoice{
    sale: number;
    rfc: string;
    razonSocial: string;
    codigoPostal: string;
    regimenFiscal: string;
    usoCfdi: string;
    folio: string;
    constructor(){
        this.sale=0;
        this.rfc="";
        this.razonSocial="";
        this.codigoPostal="";
        this.regimenFiscal="";
        this.usoCfdi="";
        this.folio="";
    }

}