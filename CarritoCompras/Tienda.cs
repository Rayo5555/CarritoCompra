using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Tienda
    {
        public List<Categoria> Categoria { get; set; } = new List<Categoria>();
            Categoria.add(new Categoria("Electrónica", "Dispositivos y gadgets"));
            Categoria.add(new Categoria("Ropa", "Indumentaria para todas las edades"));
            Categoria.add(new Categoria("Alimentos", "Productos comestibles y bebidas"));
            Categoria.add(new Categoria("Libros", "Libros físicos y electrónicos"));

        public List<Producto> Producto { get; set; } = new List<Producto>();
            Productos.add(new Producto(1, 10, 599.99f, "Smartphone", Categoria[0]));
            Productos.add(new Producto(2, 5, 299.99f, "Auriculares Bluetooth", Categoria[0]));
            Productos.add(new Producto(3, 20, 49.99f, "Camiseta Deportiva", Categoria[1]));
            Productos.add(new Producto(4, 15, 89.99f, "Pantalón Jeans", Categoria[1]));
            Productos.add(new Producto(5, 50, 3.99f, "Botella de Agua", Categoria[2]));
            Productos.add(new Producto(6, 30, 7.99f, "Chocolate 70% Cacao", Categoria[2]));
            Productos.add(new Producto(7, 40, 19.99f, "Novela de Ciencia Ficción", Categoria[3]));
            Producto.add(new Producto(8, 25, 14.99f, "Manual de Programación C#", Categoria[3]));

        public void listarCategorias()
        {
            foreach(Categoria categoria in Categoria)
            {
                Console.WriteLine(categoria.nombre);
            }
        }
        public void listarProductos()
        {
            foreach (Producto producto in Producto)
            {
                Console.WriteLine(producto.nombre + " con un stock de: " + producto.stock + "unidades");
            }
        }

        public void filtrarProductos(string nCategoria)
        {
            Categoria temporal = null;
            foreach (Categoria categoria in Categoria)
            {
                if (categoria.nombre == nCategoria) 
                {
                    temporal = categoria;
                }
            }
            if (temporal != null)
            {
                foreach (Producto producto in Producto)
                {
                    if(producto.categoria == temporal)
                    {
                        Console.WriteLine(producto.nombre + " con un stock de: " + producto.stock + "unidades");
                    }
                }
            }
            else 
            {
                Console.WriteLine("No se encontro la categoria");
            }
        }

        
    }
}
