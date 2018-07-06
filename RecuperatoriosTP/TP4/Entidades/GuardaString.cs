using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + archivo;
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(texto);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
