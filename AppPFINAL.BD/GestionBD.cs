using AppPFINAL.BD.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPFINAL.BD
{
    public class GestionBD
    {

        #region "Login"

        public static List<Usuario> SelectUsuario()
        {
            using (PPFINALEntities ContextoBD = new PPFINALEntities())
            {
                return ContextoBD.Usuario.ToList();
            }
        }
       
            public static void InsertRol(Usuario objRol)
        {
            using (PPFINALEntities ContextoBD = new PPFINALEntities())
            {
                ContextoBD.Usuario.Add(objRol);
                ContextoBD.SaveChanges();
            }
        }
    }
}
#endregion
