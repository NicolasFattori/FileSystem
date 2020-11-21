using System;
using System.Collections.Generic;
using System.IO;

namespace Negocio
{
    public static class FileSystem
    {
        private const string _pathRaiz = @"..\..\..\DirectorioRaiz\";
        public static string _pathUbicacionActual = _pathRaiz;
        public static string nombresArchDirecRtn;

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
            bool rtn = false;
            //if (nombreArchivo.Split(""))
                try
                {
                    string path = $"{_pathUbicacionActual}{nombreArchivo}";
                    File.Create(path).Dispose();
                    rtn = true;
                }
                catch (Exception ex)
                {

                }
            return rtn;
        }

        public static bool CambiarNombreArchivo(string archivo1, string archivo2)
        {
            bool rtn = false;
            try
            {
                string path1 = $"{_pathUbicacionActual}{archivo1}";
                string path2 = $"{_pathUbicacionActual}{archivo2}";

                if (File.Exists(path1))
                {
                    File.Delete(path2);
                    File.Move(path1, path2);
                }
                rtn = true;
            }
            catch (Exception)
            {
                throw;
            }
            return rtn;

        }

        public static void CambiarArchivoDirectorio(string path1, string path2)
        {
            string pathArchivo1 = _pathUbicacionActual + path1;
            string pathArchivo2 = @"..\..\..\" + path2;

            if (File.Exists(pathArchivo1))
            {
                File.Move(pathArchivo1, pathArchivo2);
            }
        }

        public static string MostrarArchivos()
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

            return nombresArchDirecRtn;
        }


        public static string MostrarArchivosRecursivamente(string path = _pathRaiz)
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
            var rtn = nombresArchDirecRtn;
            nombresArchDirecRtn = string.Empty;
            return rtn;
        }

        public static void NavegacionPaths(string path)
        {
            _pathUbicacionActual += path + "\\";
        }

        public static string ObtenerInformacion(string comando)
        {
            comandos.TryGetValue(comando, out string informacion);
            return informacion;
        }

    }
}
