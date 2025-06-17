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
        
        public bool ExisteEnCarrito(int codigo)
        {
            return ItemCarrito.Any(item => item.producto.codigo == codigo);
        }
        
        public void agregarAlCarrito(int codigo, int cantidad, Tienda tienda)
        {
            if (!tienda.ProductoExiste(codigo))
            {
                throw new ArgumentException($"El producto con código {codigo} no existe.");
            }

            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            }

            var producto = tienda.Producto.First(p => p.codigo == codigo);

            if (producto.stock <= 0)
            {
                throw new InvalidOperationException(
                    $"No hay stock disponible de {producto.nombre}. " +
                    $"Actualmente agotado.");
            }

            if (producto.stock < cantidad)
            {
                throw new InvalidOperationException(
                    $"No hay suficiente stock de {producto.nombre}. " +
                    $"Stock actual: {producto.stock} unidades. " +
                    $"Intente con una cantidad menor.");
            }

            ItemCarrito.Add(new ItemCarrito(producto, cantidad));
            Console.WriteLine($"Se agregaron {cantidad} unidades de {producto.nombre} al carrito.");
        }

        public void eliminarDelCarrito(int codigo)
        {
            if (!ExisteEnCarrito(codigo))
            {
                throw new ArgumentException($"El producto con código {codigo} no está en el carrito.");
            }

            ItemCarrito temporal = null;

            foreach (ItemCarrito itemCarrito in ItemCarrito)
            {
                if (codigo == itemCarrito.producto.codigo)
                {
                    temporal = itemCarrito;
                }
            }
                ItemCarrito.Remove(temporal);
                Console.WriteLine($"Se eliminó {temporal.producto.nombre} del carrito.");
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
            foreach (ItemCarrito itemCarrito in ItemCarrito.ToList())
            {
                foreach (Producto producto in tienda.Producto.ToList())
                {
                    if (itemCarrito.producto == producto)
                    {
                        producto.restarStock(itemCarrito.cantidad);
                    }

                }
                ItemCarrito.Remove(itemCarrito);
            }
            Console.WriteLine("El total pagado es: $" + total);
            foreach (var item in ItemCarrito)
            {
                Console.WriteLine($"- {item.cantidad} x {item.producto.nombre} (${item.producto.precio:N2} c/u)");
            }
        }
    }
}
