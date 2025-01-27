using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{

    public class MarcaNegocio
    {

        public List<Marca> listar(string filtro)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Marca> lista = new List<Marca>();

            try
            {
                if(filtro == "")
                {
                    datos.setConsulta("Select Id, Descripcion from MARCAS");
                } else
                {
                    datos.setConsulta("Select Id, Descripcion from MARCAS where Descripcion like @filtro");
                    datos.setParametro("@filtro", "%" + filtro + "%");
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Agregar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("insert into MARCAS (Descripcion) values (@texto)");
                datos.setParametro("@texto", marca.Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("update MARCAS set Descripcion = @marca where Id = @id");
                datos.setParametro("@marca", marca.Descripcion);
                datos.setParametro("@id", marca.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
        }
    }
}
