using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Reflection;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar(string filtro)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> list = new List<Articulo>();

            try
            {
                if(filtro == "")
                {
                    datos.setConsulta("select A.Id as Id, A.Codigo, Nombre, A.Descripcion as Descripcion, ImagenUrl,C.Id as Id_Descripcion ,C.Descripcion as Categoria, M.Id as Id_Marca,M.Descripcion as Marca,Precio from Articulos A inner join CATEGORIAS C ON A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id; ");
                } else
                {
                    datos.setConsulta("select A.Id as Id, A.Codigo, Nombre, A.Descripcion as Descripcion, ImagenUrl,C.Id as Id_Descripcion ,C.Descripcion as Categoria, M.Id as Id_Marca,M.Descripcion as Marca,Precio from Articulos A inner join CATEGORIAS C ON A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id where A.Nombre like @filtro; ");
                    datos.setParametro("@filtro", "%" + filtro + "%");
                }
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

        public List<Articulo> busquedaFiltrada(string filtro, string v1, string v2)
        {
            List<Articulo> list = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select A.Id as Id, A.Codigo, Nombre, A.Descripcion as Descripcion, ImagenUrl,C.Id as Id_Descripcion ,C.Descripcion as Categoria, M.Id as Id_Marca,M.Descripcion as Marca,Precio from Articulos A inner join CATEGORIAS C ON A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id ";

                switch (v1)
                {
                    case "Codigo":
                        switch (v2)
                        {
                            case "Comienza con":
                                consulta += "where A.Codigo like @filtro";
                                datos.setParametro("@filtro", filtro + "%");
                                break;
                            case "Termina con":
                                consulta += "where A.Codigo like @filtro";
                                datos.setParametro("@filtro", "%" + filtro);
                                break;
                            case "Contiene":
                                consulta += "where A.Codigo like @filtro";
                                datos.setParametro("@filtro", "%" + filtro + "%");
                                break;
                            default: break;
                        }
                        break;
                    case "Nombre":
                        switch (v2)
                        {
                            case "Comienza con":
                                consulta += "where A.Nombre like @filtro";
                                datos.setParametro("@filtro", filtro + "%");
                                break;
                            case "Termina con":
                                consulta += "where A.Nombre like @filtro";
                                datos.setParametro("@filtro", "%" + filtro);
                                break;
                            case "Contiene":
                                consulta += "where A.Nombre like @filtro";
                                datos.setParametro("@filtro", "%" + filtro + "%");
                                break;
                            default: break;
                        }
                        break;
                    case "Precio":
                        switch (v2)
                        {
                            case "Mayor a":
                                consulta += "where A.Precio > @filtro";
                                datos.setParametro("@filtro", filtro);
                                break;
                            case "Menor a":
                                consulta += "where A.Precio < @filtro";
                                datos.setParametro("@filtro", filtro);
                                break;
                            case "Igual a":
                                consulta += "where A.Precio = @filtro";
                                datos.setParametro("@filtro", filtro);
                                break;
                            default: break;
                        }
                        break;

                    default:
                        break;
                }

                datos.setConsulta(consulta);
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

        public List<Articulo> busquedaCategoria(string categoria, string valor)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> list = new List<Articulo>();

            try
            {
                if(categoria == "Categoria")
                {
                    datos.setConsulta("select A.Id as Id, A.Codigo, Nombre, A.Descripcion as Descripcion, ImagenUrl, C.Id as Id_Descripcion, C.Descripcion as Categoria, M.Id as Id_Marca, M.Descripcion as Marca, Precio from Articulos A inner join CATEGORIAS C ON A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id where C.Descripcion = @valor");
                    datos.setParametro("@valor", valor);
                }
                else
                {
                    datos.setConsulta("select A.Id as Id, A.Codigo, Nombre, A.Descripcion as Descripcion, ImagenUrl, C.Id as Id_Descripcion, C.Descripcion as Categoria, M.Id as Id_Marca, M.Descripcion as Marca, Precio from Articulos A inner join CATEGORIAS C ON A.IdCategoria = C.Id inner join MARCAS M on A.IdMarca = M.Id where M.Descripcion = @valor");
                    datos.setParametro("@valor", valor);
                }
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
    }
}
