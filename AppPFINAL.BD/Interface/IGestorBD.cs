using AppPFINAL.BD.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPFINAL.BD.Interface
{
    public interface IGestorBD
    {
        IEnumerable<Tarjeta> ListadoTarjeta();
      
        IEnumerable<Usuario> ListadoUsuario();

        int CrearUsuario(Usuario objUsuario);

        int ActualizarUsuario(Usuario objUsuario);
        int BorrarUsuario(int Id);

        int Create(Tarjeta objTarjeta);

        int ActualizarTarjeta(Tarjeta objTarjeta);




    }


}
