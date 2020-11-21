using Negocio;
using System;

namespace Ejercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var readConsole = Console.ReadLine();
                var input = readConsole.Split(' ');
                var comando = input[0].ToLower();
                switch (comando)
                {
                    case "touch":
                        var nombreArchivo = input[1];
                        FileSystem.GenerarArchivo(nombreArchivo);
                        break;

                    case "mv":
                        var valor1 = input[1];
                        var valor2 = input[2];
                        if (valor1.Contains("\\") || valor2.Contains("\\"))
                        {
                            FileSystem.CambiarArchivoDirectorio(valor1, valor2);
                        }
                        else
                        {
                            FileSystem.CambiarNombreArchivo(valor1, valor2);
                        }
                        break;

                    case "ls":
                        string informacion = input.Length > 1 ? FileSystem.MostrarArchivosRecursivamente() : FileSystem.MostrarArchivos();
                        Console.WriteLine(informacion);
                        break;

                    case "cd":
                        var path = input[1];
                        FileSystem.NavegacionPaths(path);
                        break;

                    case "help":
                        var comandoABuscar = input[1].ToLower();
                        if (comandoABuscar == "ls")
                        {
                            comandoABuscar = input.Length > 2 ? comandoABuscar += " " + input[2] : comandoABuscar;
                        }
                        Console.WriteLine(FileSystem.ObtenerInformacion(comandoABuscar));
                        break;

                    default:
                        Console.WriteLine("Comando no reconocido");
                        break;
                }
            }
        }
    }
}
