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
        public List<Producto> Producto { get; set; } = new List<Producto>();

            public Tienda(){
                Categoria.Add(new Categoria("Electrónica", "Dispositivos y gadgets"));
                Categoria.Add(new Categoria("Ropa", "Indumentaria para todas las edades"));
                Categoria.Add(new Categoria("Alimentos", "Productos comestibles y bebidas"));
                Categoria.Add(new Categoria("Libros", "Libros físicos y electrónicos"));
        
                Producto.Add(new Producto(1, 10, 599.99f, "Smartphone", Categoria[0]));
                Producto.Add(new Producto(2, 5, 299.99f, "Auriculares Bluetooth", Categoria[0]));
                Producto.Add(new Producto(3, 20, 49.99f, "Camiseta Deportiva", Categoria[1]));
                Producto.Add(new Producto(4, 15, 89.99f, "Pantalón Jeans", Categoria[1]));
                Producto.Add(new Producto(5, 50, 3.99f, "Botella de Agua", Categoria[2]));
                Producto.Add(new Producto(6, 30, 7.99f, "Chocolate 70% Cacao", Categoria[2]));
                Producto.Add(new Producto(7, 40, 19.99f, "Novela de Ciencia Ficción", Categoria[3]));
                Producto.Add(new Producto(8, 25, 14.99f, "Manual de Programación C#", Categoria[3]));
            }
        

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
                Console.WriteLine($"Código: {producto.codigo}");
                Console.WriteLine($"Nombre: {producto.nombre}");
                Console.WriteLine($"Stock: {producto.stock} unidades");
                Console.WriteLine($"Precio: ${producto.precio:N2}");
                Console.WriteLine("----------------------------------");
            }
        }
        public bool CategoriaExiste(string categoria)
        {
            return Categoria.Any(p  => p.nombre == categoria);
        }

        public bool ProductoExiste(int codigo)
        {
            return Producto.Any(p => p.codigo == codigo);
        }

        public void filtrarProductos(string nCategoria)
        {
            if (string.IsNullOrWhiteSpace(nCategoria))
            {
                throw new ArgumentException("El nombre de la categoría no puede estar vacío.");
            }
            if (!CategoriaExiste(nCategoria))
            {
                throw new ArgumentException($"La categoría '{nCategoria}' no existe.");
            }
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
                        Console.WriteLine($"Código: {producto.codigo}");
                        Console.WriteLine($"Nombre: {producto.nombre}");
                        Console.WriteLine($"Stock: {producto.stock} unidades");
                        Console.WriteLine($"Precio: ${producto.precio:N2}");
                        Console.WriteLine("----------------------------------");
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
