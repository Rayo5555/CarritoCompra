using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class ItemCarrito
    {
        public int cantidad;
        public Producto producto;

        public ItemCarrito(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
        }
    }
}
