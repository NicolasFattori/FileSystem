using System;
using System.Collections.Generic;
using System.IO;

namespace Negocio
{
    public static class FileSystem
    {
        private const string _pathRaiz = @"..\..\..\DirectorioRaiz\";
        private static string _pathUbicacionActual = _pathRaiz;
        private static string nombresArchDirecRtn;

        private static Dictionary<string, string> comandos = new Dictionary<string, string>();
        static FileSystem()
        {
            comandos.Add("touch", "Crea un archivo nuevo con el siguiente nombre y extensión");
            comandos.Add("mv", "Cambia de nombre un archivo o Mueve un archivo de directorio");
            comandos.Add("ls", "Muestra los archivos/carpetas que se encuentran en el directorio");
            comandos.Add("ls -R", "Muestra el contenido de todos los subdirectorios de forma recursiva");
            comandos.Add("cd", "Permite navegar entre los diferentes directorios");
        }       

        public static bool GenerarArchivo(string nombreArchivo)
        {
            bool rtn;
            try
            {
                string path = $"{_pathUbicacionActual}{nombreArchivo}";
                File.Create(path).Dispose();
                rtn = true;
            }
            catch (Exception)
            {
                _pathUbicacionActual = _pathRaiz;
                rtn = false;
            }
            return rtn;
        }

        public static bool CambiarNombreArchivo(string archivo1, string archivo2)
        {
            bool rtn;
            try
            {
                string path1 = $"{_pathUbicacionActual}{archivo1}";
                string path2 = $"{_pathUbicacionActual}{archivo2}";

                if (File.Exists(path1))
                {
                    File.Delete(path2);
                    File.Move(path1, path2);
                    rtn = true;
                }
                else
                {
                    rtn = false;
                }

            }
            catch (Exception)
            {
                _pathUbicacionActual = _pathRaiz;
                rtn = false;
            }
            return rtn;

        }

        public static bool CambiarArchivoDirectorio(string path1, string path2)
        {
            bool rtn;
            try
            {
                string pathArchivo1 = _pathUbicacionActual + path1;
                string pathArchivo2 = @"..\..\..\" + path2;

                if (File.Exists(pathArchivo1))
                {
                    File.Move(pathArchivo1, pathArchivo2);
                    rtn = true;
                }
                else
                {                    
                    rtn = false;
                }
            }
            catch (Exception)
            {
                _pathUbicacionActual = _pathRaiz;
                rtn = false;
            }
            return rtn;           
        }

        public static string MostrarArchivos()
        {
            string rtn;
            try
            {
                string nombresArchDirecRtn = string.Empty;
                string[] archivos = Directory.GetFiles(_pathUbicacionActual);
                string[] directorios = Directory.GetDirectories(_pathUbicacionActual);

                foreach (var item in archivos)
                {
                    var infoPathArchivo = item.Split('\\');
                    nombresArchDirecRtn += $"{infoPathArchivo[infoPathArchivo.Length - 1]}\n";
                }

                foreach (var item in directorios)
                {
                    var infoPathDirectorio = item.Split('\\');
                    nombresArchDirecRtn += $"{infoPathDirectorio[infoPathDirectorio.Length - 1]}\n";
                }

                rtn = nombresArchDirecRtn;
            }
            catch (Exception)
            {
                _pathUbicacionActual = _pathRaiz;
                rtn = "No se pudo mostrar los archivos";
            }

            return rtn;
        }


        public static string MostrarArchivosRecursivamente(string path = _pathRaiz)
        {
            string rtn;
            try
            {
                string[] directorios = Directory.GetDirectories(path);

                foreach (var direc in directorios)
                {
                    foreach (var archivo in Directory.GetFiles(direc))
                    {
                        var infoPathArchivo = archivo.Split('\\');
                        nombresArchDirecRtn += $"{infoPathArchivo[infoPathArchivo.Length - 1]}\n";
                    }

                    MostrarArchivosRecursivamente(direc);
                }

                rtn = nombresArchDirecRtn;
                nombresArchDirecRtn = string.Empty;
            }
            catch (Exception)
            {
                _pathUbicacionActual = _pathRaiz;
                rtn = "No se pudo mostrar los archivos recursivamente";
            }

            return rtn;
        }

        public static void NavegacionPaths(string path)
        {
            _pathUbicacionActual += path + "\\";
        }

        public static string ObtenerInformacion(string comando)
        {
            string rtn;
            try
            {
                comandos.TryGetValue(comando, out rtn);
            }
            catch (Exception)
            {
                _pathUbicacionActual = _pathRaiz;
                rtn = "No se pudo obtener la informacion del comando";
            }

            return rtn;
        }

    }
}
