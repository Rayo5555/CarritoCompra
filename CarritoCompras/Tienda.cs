using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Tienda
    {
        public List<Producto> Producto { get; set; } = new List<Producto>();
        public List<Categoria> Categoria { get; set; } = new List<Categoria>();

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
