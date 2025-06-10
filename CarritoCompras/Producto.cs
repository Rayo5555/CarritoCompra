using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Producto
    {
        public int codigo, stock;
        public float precio;
        public string nombre;
        public Categoria categoria;

        public Producto (int codigo, int stock, float precio, string nombre, Categoria categoria)
        {
            this.codigo = codigo;
            this.stock = stock;
            this.precio = precio;
            this.nombre= nombre;
            this.categoria = categoria;
        }

        public void restarStock(int cantidad)
        {
            stock = stock - cantidad;
        }
    }
}
