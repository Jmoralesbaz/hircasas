export const RoutsServices={
    Api:{
        URL:'api/v1/hircasa/',
        Sources:{
            Seccions:{
                Authentication:{
                    PATH:'authentication/',
                    Accions:{
                        authenticate:'login',
                        close:'logout'
                    }
                },
                Persons:{
                    PATH:'person/',
                    Accions:{
                       
                        All:'all',
                        Add:'add',
                        Update:'edit/', 
                        Asset:'asset/'
                    }
                },
                Users:{
                    PATH:'user/',
                    Accions:{
                       
                        All:'all',
                        Add:'add',
                        Update:'edit/', 
                        Asset:'asset/'
                    }
                },Items:{
                    PATH:'item/',
                    Accions:{
                       
                        All:'all',
                        Add:'add',
                        Update:'edit/', 
                        Asset:'asset/'
                    }
                },Inventory:{
                    PATH:'inventory/',
                    Accions:{
                       
                        All:'all',
                        Add:'add',
 
                    }
                },
                Sales:{
                    PATH:'sales/',
                    Accions:{
                       
                        All:'all',
                        Add:'add',
 
                    }
                },Invoices:{
                    PATH:'invoice/',
                    Accions:{
                       
                        All:'all',
                        Add:'add',
                        Update:'edit/',                        
                    }
                }
            }                        
        }
    }
}