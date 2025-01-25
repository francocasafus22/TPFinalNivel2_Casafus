using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> list = new List<Articulo>();

            try
            {
                datos.setConsulta("select A.Id as Id, A.Codigo, Nombre, A.Descripcion as Descripcion, ImagenUrl,C.Id as Id_Descripcion ,C.Descripcion as Categoria, M.Id as Id_Marca,M.Descripcion as Marca,Precio from Articulos A inner join CATEGORIAS C ON A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id; ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["Id_Descripcion"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["Id_Marca"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    list.Add(aux);
                }

                return list;
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

        public void agregarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.setParametro("@Codigo", articulo.Codigo);
                datos.setParametro("@Nombre", articulo.Nombre);
                datos.setParametro("@Descripcion", articulo.Descripcion);
                datos.setParametro("@IdMarca", articulo.Marca.Id);
                datos.setParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setParametro("@ImagenUrl", articulo.Imagen);
                datos.setParametro("@Precio", articulo.Precio);
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

        public void borrarArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("delete from ARTICULOS where Id = @id");
                datos.setParametro("@id", id);
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

        public void modificarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id");
                datos.setParametro("@Codigo", articulo.Codigo);
                datos.setParametro("@Nombre", articulo.Nombre);
                datos.setParametro("@Descripcion", articulo.Descripcion);
                datos.setParametro("@IdMarca", articulo.Marca.Id);
                datos.setParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setParametro("@ImagenUrl", articulo.Imagen);
                datos.setParametro("@Precio", articulo.Precio);
                datos.setParametro("@Id", articulo.Id);
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
