using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace TestCorreo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InstanciaPaqueteLst()
        {
            Correo c = new Correo();
            Assert.IsInstanceOfType(c.Paquetes, typeof(List<Paquete>));
        }

        [TestMethod]
        public void CargarDosPaquetes()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Coihue 3360", "23233");
            Paquete p2 = new Paquete("Mercedes 1960", "23233");
            try
            {
                c += p1;
                c += p2;
            }
            catch (TrackingIdRepetidoException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
           
            Assert.IsFalse(c.Paquetes.Contains(p2));
        }
    }
}
