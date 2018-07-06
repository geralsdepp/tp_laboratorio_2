using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand _comando;
        private static SqlConnection _conexion;

        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            string connection = @"Data Source=LAB3PC12\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True";
            try
            {
                 _conexion = new SqlConnection(connection);

                 
                string insert = "INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES (@DireccionEntrega, @TrackingID, @alumno)";
                using (_comando = new SqlCommand(insert, _conexion))
                {
                    _comando.CommandType = System.Data.CommandType.Text;
                    _comando.Parameters.AddWithValue("@DireccionEntrega", p.DireccionEntrega);
                    _comando.Parameters.AddWithValue("@TrackingID", p.TrackingID);
                    _comando.Parameters.AddWithValue("@alumno", "Geraldine Meza");
                    _conexion.Open();
                    int execute = _comando.ExecuteNonQuery();
                    retorno = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("No se ha podido agregar los datos a la BD", ex.InnerException);
            }

            return retorno;
        }

        static PaqueteDAO() { }
    }
}
