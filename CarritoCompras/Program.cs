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
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("       BIENVENIDO A LA TIENDA       ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Mostrar categorías disponibles");
                Console.WriteLine("2. Mostrar productos disponibles");
                Console.WriteLine("3. Mostrar productos por categoría");
                Console.WriteLine("4. Agregar producto al carrito");
                Console.WriteLine("5. Eliminar producto de carrito");
                Console.WriteLine("6. Ver contenido del carrito");
                Console.WriteLine("7. Ver total a pagar");
                Console.WriteLine("8. Finalizar compra");
                Console.WriteLine("9. Salir del programa");
                Console.WriteLine("====================================");
                Console.WriteLine("Ingrese opción (1-9): ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        tienda.listarCategorias();
                        WaitForKey();
                        break;
                    case 2:
                        tienda.listarProductos();
                        WaitForKey();
                        break;
                    case 3:

                        Console.WriteLine("Ingrese la categoría: ");
                        string categoria = Console.ReadLine();
                        try
                        {
                            tienda.filtrarProductos(categoria);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        WaitForKey();
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el código del producto: ");
                        if (int.TryParse(Console.ReadLine(), out int codigo))
                        {
                            Console.WriteLine("Ingrese la cantidad a agregar: ");
                            if (int.TryParse(Console.ReadLine(), out int cantidad))
                            {
                                try
                                {
                                    carrito.agregarAlCarrito(codigo, cantidad, tienda);
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine($"Advertencia: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cantidad inválida.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Código inválido.");
                        }
                        WaitForKey();
                        break;
                    case 5:
                        Console.WriteLine("Ingrese el código del producto: ");
                        if (int.TryParse(Console.ReadLine(), out int codigoEliminar))
                        {
                            try
                            {
                                carrito.eliminarDelCarrito(codigoEliminar);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Código inválido.");
                        }
                        WaitForKey();
                        break;
                    case 6:
                        carrito.listarCarrito();
                        WaitForKey();
                        break;
                    case 7:
                        if (carrito.ItemCarrito.Count == 0)
                        {
                            Console.WriteLine("El carrito está vacío.");
                        }
                        else
                        {
                            Console.WriteLine($"Total a pagar: ${carrito.totalPagar()}");
                        }
                        WaitForKey();
                        break;
                    case 8:
                        if (carrito.ItemCarrito.Count == 0)
                        {
                            Console.WriteLine("El carrito está vacío.");
                        }
                        else
                        {
                            carrito.finalizarCompra(tienda);
                        }
                        WaitForKey();
                        break;
                    case 9:
                        Console.WriteLine("Gracias por la visita!!!");
                        Console.WriteLine("Cerrando el programa...");
                        System.Threading.Thread.Sleep(3000);
                        b = false;
                        break;
                    default:
                        Console.WriteLine("Ingrese una opción válida!");
                        break;

                }

            }
        }
        static void WaitForKey()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
