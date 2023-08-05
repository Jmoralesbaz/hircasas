import { Component, Inject, OnInit, inject } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Observable, lastValueFrom } from "rxjs";


@Component({
    selector: 'app-baseseccion',
    templateUrl: './baseform.component.html'
})
export class BaseForm<TModel> implements OnInit{
    protected classalert:string ="";
    protected titlealert:string ="";

    protected error: boolean = false;
    protected code: number = 0;
    protected message: string = "";
    protected form!: FormGroup;
    protected index: number = -1;
    protected list: TModel[] = [];
    protected model!: TModel;
    protected dataModelString: string = "";
    constructor(@Inject('classType') private classType: new () => TModel) {        
        this.model = new classType();
    }
    ngOnInit(): void {
        this.loadData();
    }

    protected async loadData() { };
    protected async saveData() { };
    protected async blockUnBlock(index: number) { };
    protected async save() { 
        await this.getValueForm();
        await this.saveData();
        if(!this.error){
            this.addOrUpdateList(this.model);
            this.reset();
        }
       
    }
protected async reset(){
    this.dataModelString = JSON.stringify(new this.classType());
    this.index = -1;
    this.setValueForm();
}
    protected async edit(_index:number) { 
        this.index = _index;
        this.dataModelString = JSON.stringify(this.list[_index]);
        this.setValueForm();
    }

    protected async getValueForm() {
        var temp = (<any>this.model);
        const keyNames = Object.keys(this.form.controls);
        keyNames.forEach(key => {
            temp[key] = this.form.controls[key].value;
        });
        this.model = (<TModel>temp);
    }
    protected setValueForm() {                
        if (this.dataModelString != undefined && this.dataModelString != "") {
            this.model = JSON.parse(this.dataModelString);
            this.form.setValue(JSON.parse(this.dataModelString));
        }
    }
    protected addOrUpdateList(result: TModel) {
        if(result){
         if (this.index == -1) {
             this.list = [...this.list, { ...result }];
         } else {
             this.list[this.index] = result;
             this.list = [...this.list];
             this.index = -1;
         }
        }
         
     }
     protected async executeValue<TOut>(source: Observable<any>) {
        this.error = false;
        this.message = "Datos actualizados!!";
        var r = await lastValueFrom(source).catch((e: any) => {               
            this.error = true;
            this.code = (e.status==0)?500:e.status;
            this.message = e.error.message;
        });
        this.getDataAlert();        
        return r;

    }  

    protected getDataAlert():void{
        this.classalert="";
        switch(this.code){
            case 400:
                this.classalert+="warning";
                this.titlealert="Alerta";
            break;
            case 404:
                this.classalert+="info";
                this.titlealert="Info";
            break;
            case 500:            
                this.classalert+="danger";
                this.message="Error interno, comunicalo con el administrador";
                this.titlealert="Error";
            break;
            default:
                this.code=200;
                this.classalert+="success";                
                this.titlealert="Exitoso";
                break;
        }
        setTimeout(()=>{
            this.code=0;
            this.error = false;
        },3500);
    }
}