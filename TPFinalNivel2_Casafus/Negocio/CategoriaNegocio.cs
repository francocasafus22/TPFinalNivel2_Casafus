using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {

        public List<Categoria> listar(string filtro)
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (filtro == "")
                {
                    datos.setConsulta("select Id, Descripcion from Categorias");
                }
                else
                {
                    datos.setConsulta("select Id, Descripcion from Categorias where Descripcion like @filtro");
                    datos.setParametro("@filtro", "%" + filtro + "%");
                }
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
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
        public void Agregar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("insert into Categorias (Descripcion) values (@texto)");
                datos.setParametro("@texto", categoria.Descripcion);
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
        public void Modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("update Categorias set Descripcion = @texto where Id = @id");
                datos.setParametro("@texto", categoria.Descripcion);
                datos.setParametro("@id", categoria.Id);
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
