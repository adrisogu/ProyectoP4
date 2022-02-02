using AppPFINAL.BD.Interface;
using AppPFINAL.BD.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPFINAL.BD.Repositorio
{
    public class GestorBD : IGestorBD
    {
        public int ActualizarUsuario(Usuario objUsuario)
        {
            int n = 0;
            using (PPFINALEntities ConTextoBD = new PPFINALEntities())
            {
                ConTextoBD.Entry<Usuario>(objUsuario).State = System.Data.Entity.EntityState.Modified;
                n = ConTextoBD.SaveChanges();
            }
            return n;
        }

        public int BorrarUsuario(int Id)
        {
            int n = 0;
            using (PPFINALEntities ContextoBD = new PPFINALEntities())
            {
                var aux = ContextoBD.Usuario.Where(x => x.ID == Id).FirstOrDefault();

                if (aux == null)
                {
                    n = 0;
                }
                else 
                {
                    ContextoBD.Entry<Usuario>(aux).State = System.Data.Entity.EntityState.Deleted;
                    n = ContextoBD.SaveChanges();
                }
            }
            return n;
        }

        public int CrearUsuario(Usuario objUsuario)
        {
            int n = 0;

            using (PPFINALEntities ContextoBD = new PPFINALEntities())
            {
                ContextoBD.Usuario.Add(objUsuario);
                n = ContextoBD.SaveChanges();
            }

            return n;
        }

        public IEnumerable<Usuario> ListadoUsuario()
        {
            List<Usuario> ListadoUsuarios = new List<Usuario>();
            using (PPFINALEntities ContextoDB = new PPFINALEntities())
            {
                ListadoUsuarios = ContextoDB.Usuario.ToList();
            }
            return ListadoUsuarios;
        }

        public int Create(Tarjeta objTarjeta)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tarjeta> ListadoTarjeta()
        {
            List<Tarjeta> listadoRetornar = new List<Tarjeta>();
            using (PPFINALEntities ContextoBD = new PPFINALEntities())
            {
                listadoRetornar = ContextoBD.Tarjeta.ToList();
            }

            return listadoRetornar;
        }

        public int ActualizarTarjeta(Tarjeta objTarjeta)
        {
            int n = 0;
            using (PPFINALEntities ConTextoBD = new PPFINALEntities())
            {
                ConTextoBD.Entry<Tarjeta>(objTarjeta).State = System.Data.Entity.EntityState.Modified;
                n = ConTextoBD.SaveChanges();
            }
            return n;
        }
    }
}

