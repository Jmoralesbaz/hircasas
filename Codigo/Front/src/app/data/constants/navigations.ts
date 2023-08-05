export const RoutsNavigation = {
    Access: {
        Path: 'acceso',
        Login: {
            Url: 'identificacion'
        },
        ForwardPassword: {
            Url: 'recuperar-clave'
        },
        CahnegPassword: {
            Url: 'cambiar-clave'
        }
    },   
    Operations: {
        Path: 'ecommerce',
        configurations: {
            Path: 'operaciones',
            Items: {
                Url: 'articulos',
                Roles:['Administrator','Customer']
            },
            Users: {
                Url: 'usuarios',
                Roles:['Administrator']
            },
            Pepols: {
                Url: 'personas',
                Roles:['Administrator']
            },
            Inventory: {
                Url: 'inventario',
                Roles:['Administrator']
            },
            Invoice: {
                Url: 'facturacion',
                Roles:['Administrator']
            },
            Ventas: {
                Url: 'ventas',
                Roles:['Administrator']
            }
        }
    }
}