using System;

namespace CarritoCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola");
            Tienda tienda = new Tienda();
            Carrito carrito = new Carrito();
            bool b = true;

            while (b)
            {
                Console.WriteLine("Bienvenido a la tienda");
                Console.WriteLine("1. Mostrar categorías disponibles");
                Console.WriteLine("2. Mostrar productos disponibles");
                Console.WriteLine("3. Mostrar productos por categoría");
                Console.WriteLine("4. Agregar producto al carrito");
                Console.WriteLine("5. Eliminar producto de carrito");
                Console.WriteLine("6. Ver contenido del carrito");
                Console.WriteLine("7. Ver total a pagar");
                Console.WriteLine("8. Finalizar compra");
                Console.WriteLine("9. Salir del programa");
                Console.WriteLine("Ingrese opción (1-9): ");
                int opcion = Console.ReadLine();

                switch (opcion)
                {
                    case 1:
                        tienda.listarCategorias();
                        break;
                    case 2:
                        tienda.listarProductos();
                        break;
                    case 3:
                        tienda.filtrarProductos();
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el código del producto: ");
                        codigo = Console.ReadLine();
                        Console.WriteLine("Ingrese la cantidad a agregar: ");
                        cantidad = Console.ReadLine();
                        carrito.agregarAlCarrito(codigo, cantidad, tienda);
                        break;
                    case 5:
                        Console.WriteLine("Ingrese el código del producto: ");
                        codigo = Console.ReadLine();
                        carrito.eliminarDelCarrito(codigo);
                        break;
                    case 6:
                        carrito.listarCarrito();
                        break;
                    case 7:
                        float total = carrito.totalPagar();
                        Console.WriteLine("El total a pagar es de: $"+ total);
                        break;
                    case 8:
                        carrito.finalizarCompra();
                        break;
                    case 9:
                        b = false;
                        break;
                    default:
                        Console.WriteLine("Ingrese una opción válida!");
                        break;

                }

                Console.WriteLine("Gracias por la visita!!!");
                    

            } 
        }
    }
}
