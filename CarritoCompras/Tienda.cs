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
    }
}
