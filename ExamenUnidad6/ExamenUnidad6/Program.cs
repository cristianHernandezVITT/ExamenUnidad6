using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExamenUnidad6
{
    class Program
    {
        class Amazon
        {
            private string nombre,descripcion;
            private double precio;
            private int cantidad;
            StreamReader sr;
            StreamWriter sw;
            public void Registrar()
            {
                try
                {
                    Console.Write("Indica el nombre del producto ");
                    nombre = Console.ReadLine();
                    Console.Write("Escribe la descripción del producto ");
                    descripcion = Console.ReadLine();
                    Console.Write("Indica el precio del producto ");
                    precio = Single.Parse(Console.ReadLine());
                    Console.Write("Indica la cantidad que hay del producto ");
                    cantidad = int.Parse(Console.ReadLine());

                    sw = new StreamWriter("Amazon.txt", true);
                    sw.WriteLine("{0}", nombre);
                    sw.WriteLine("{0}", descripcion);
                    sw.WriteLine("{0:C}", precio);
                    sw.WriteLine("{0}", cantidad);
                    Console.WriteLine("\nSe ha escrito en el archivo\nPresiona ENTER para salir");
                    Console.ReadLine();
                    Console.Clear();
                }
                catch(FormatException)
                {
                    Console.WriteLine("Usa el formato correcto");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Demasiados caracteres");
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error:"+ e.Message);
                }
                finally
                {
                    sw.Close();
                }


            }
            public void Imprimir()
            {
                try
                {
                    sr = new StreamReader("Amazon.txt");
                    string line;
                    Console.WriteLine();
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine("\nPresione ENTER para salir");
                    Console.ReadLine();
                    Console.Clear();
                }
                catch(IOException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    Console.WriteLine("Ruta; " + e.StackTrace);
                }
                finally
                {
                    sr.Close();
                }
                

            }
        }
        static void Main(string[] args)
        {
            
            char opc;
            Amazon amazon = new Amazon();
            bool prueba = false;
            do
            {
                Console.WriteLine("***Almacen de Amazon***");
                Console.WriteLine("1.- Agregar un producto");
                Console.WriteLine("2.- Mostrar productos");
                Console.WriteLine("3.- Salir del programa");
                Console.Write("\n¿Cuál opción va a escoger? ");
                opc = Console.ReadKey().KeyChar;
                switch (opc)
                {
                    case '1':
                        Console.Clear();
                        amazon.Registrar();
                        prueba = true; 
                        break;
                    case '2': 
                        if(prueba == true)
                        {
                            amazon.Imprimir();
                        }
                        else
                        {
                            Console.WriteLine("Captura todos los datos que necesites primero");
                        }
                         break;
                    case '3':
                        Console.WriteLine("\nUsted va a salir del programa\nPresione ENTER para salir");
                        Console.ReadLine();
                        break;
                    default: Console.WriteLine("Esa no es una opción");break;
                }

            } while (opc != '3');
        }
    }
}
