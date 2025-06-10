using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Carrito
    {
        public List<ItemCarrito> ItemCarrito { get; set; } = new List<ItemCarrito>();

        public void agregarAlCarrito(int codigo, int cantidad, Tienda tienda)
        {
            Producto temporal = null;
            
            foreach(Producto producto in tienda.Producto)
            {
                if (codigo == producto.codigo)
                {
                    temporal = producto;
                }
            }

            if (temporal != null)
            {
                ItemCarrito.Add(new ItemCarrito(temporal, cantidad));
            }
        }

        public void eliminarDelCarrito(int codigo)
        {
            ItemCarrito temporal = null;

            foreach (ItemCarrito itemCarrito in ItemCarrito)
            {
                if (codigo == itemCarrito.producto.codigo)
                {
                    temporal = itemCarrito;
                }
            }

            if (temporal != null)
            {
                ItemCarrito.Remove(temporal);
            }
        }
        public void listarCarrito()
        {
            foreach (ItemCarrito itemCarrito in ItemCarrito)
            {
                Console.WriteLine(itemCarrito.producto.nombre + " con un stock de: " + itemCarrito.cantidad+ "unidades");
            }
        }
        public float totalPagar()
        {
            float total = 0;
            foreach (ItemCarrito itemCarrito in ItemCarrito)
            {
                if(itemCarrito.cantidad >= 5)
                {
                    total += (itemCarrito.producto.precio * itemCarrito.cantidad * 0.85f);
                }
                else
                {
                    total += itemCarrito.producto.precio * itemCarrito.cantidad;
                }
            }
            total = total * 1.21f;
            return total;
        }

        public void finalizarCompra(Tienda tienda)
        {
            float total = totalPagar();
            foreach(ItemCarrito itemCarrito in ItemCarrito)
            {
                foreach(Producto producto in tienda.Producto)
                {
                    if (itemCarrito.producto == producto)
                    {
                        producto.restarStock(itemCarrito.cantidad);
                    }

                }
                ItemCarrito.Remove(itemCarrito);
            }
            Console.WriteLine("El total pagado es: $" + total);
        }
    }
}
