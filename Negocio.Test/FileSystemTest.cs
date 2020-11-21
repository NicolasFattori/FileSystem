using NUnit.Framework;
using Negocio;

namespace Negocio.Test
{
    public class FileSystemTest
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void GenerarArchivo_Exito_Generacion_Archivo()
        {
            Assert.IsTrue(FileSystem.GenerarArchivo("Prueba1.txt"));
        }

        [Test]
        public void CambiarNombreArchivo_Archivo1_No_Existe()
        {
            Assert.IsFalse(FileSystem.CambiarNombreArchivo("Archivo1.txt","Archivo2.txt"));
        }

        [Test]
        public void CambiarArchivoDirectorio_Archivo1_No_Se_Encuentra_En_El_Directorio_Parado()
        {
            Assert.IsFalse(FileSystem.CambiarArchivoDirectorio("Archivo1.txt", "Archivo2.txt"));
        }

        [Test]
        public void MostrarArchivos_Exito_Mostrar_Archivos()
        {
            Assert.Pass(FileSystem.MostrarArchivos());
        }


        [Test]
        public void MostrarArchivosRecursivamente_Exito_Mostrar_Archivos()
        {
            Assert.Pass(FileSystem.MostrarArchivosRecursivamente());
        }

        [Test]
        public void NavegacionPaths_Exito_Navegacion_Entre_Repositorios()
        {
            Assert.IsNotNull(FileSystem.MostrarArchivosRecursivamente());
        }

        [Test]
        public void ObtenerInformacion_No_Exite_El_Comando()
        {
            Assert.IsNull(FileSystem.ObtenerInformacion(""));
        }


    }
}