using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Restaurante
    {
        public static ML.Result Delete(int idRestaurante)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.CalifadeLeonEntities context = new DL.CalifadeLeonEntities())
                {

                    try
                    {
                        ML.Restaurante restaurante = new ML.Restaurante();

                        restaurante.IdRestaurante = idRestaurante;

                        var query = context.DeleteRestaurant(restaurante.IdRestaurante);

                        if (query > 0)
                        {
                            result.Correct = true;
                            result.Messages = "Restaurante ELiminado Correctamente";
                        }
                        else
                        {
                            result.Correct = false;
                            result.Messages = "No se encontro el Restaurante a Eliminar";
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        result.Correct = false;
                        result.Messages = "Error en SQL al ejecutar RestauranteDelete";
                        result.Ex = sqlEx;
                    }
                    catch (InvalidOperationException invEx)
                    {
                        result.Correct = false;
                        result.Messages = "Error al abrir la conexion";
                        result.Ex = invEx;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Messages = "Error General";
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Restaurante restaurante)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.CalifadeLeonEntities context = new DL.CalifadeLeonEntities())
                {
                    try
                    {
                        var query = context.AddRestaurant(restaurante.Nombre, restaurante.Logo, restaurante.Capacidad);

                        if (query != null)
                        {
                            result.Correct = true;
                            result.Messages = "Restaurante agregado correctamente";
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        result.Correct = false;
                        result.Messages = sqlEx.Message;
                        result.Ex = sqlEx;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Messages = "Ingresaste algo mal o no se pudo insertar el restaurante";
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            try
            {
                using (DL.CalifadeLeonEntities context = new DL.CalifadeLeonEntities())
                {
                    try
                    {
                        var query = context.GetAllRestaurant().ToList();

                        if (query.Count > 0)
                        {
                            foreach (var item in query)
                            {
                                ML.Restaurante restaurante = new ML.Restaurante();

                                restaurante.IdRestaurante = item.IdRestaurante;
                                restaurante.Nombre = item.Nombre;
                                restaurante.Logo = item.Logo;
                                restaurante.Capacidad = item.Capacidad ?? 0;

                                result.Objects.Add(restaurante);
                                result.Correct = true;
                            }
                        }
                        else
                        {
                            result.Correct = false;
                            result.Messages = "Error al mapear los datos";
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        result.Correct = false;
                        result.Messages = sqlEx.Message;
                        result.Ex = sqlEx;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Messages = "Hubo un error de conexion en la base de datos";
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Restaurante restaurante)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.CalifadeLeonEntities context = new DL.CalifadeLeonEntities())
                {
                    try
                    {
                        var query = context.UpdateRestaurante(restaurante.IdRestaurante, restaurante.Nombre, restaurante.Logo, restaurante.Capacidad);

                        if (query != null)
                        {
                            result.Correct = true;
                            result.Messages = "Restaurante agregado correctamente";
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        result.Correct = false;
                        result.Messages = sqlEx.Message;
                        result.Ex = sqlEx;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Messages = "Ingresaste algo mal o no se pudo insertar el restaurante";
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetById(int idRestaurante)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            try
            {
                using (DL.CalifadeLeonEntities context = new DL.CalifadeLeonEntities())
                {
                    try
                    {
                        var query = context.GetByIdRestaurante(idRestaurante).SingleOrDefault();

                        if (query != null )
                        {
                            
                                ML.Restaurante restaurante = new ML.Restaurante();

                                restaurante.IdRestaurante = query.idRestaurante;
                                restaurante.Nombre = query.Nombre;
                                restaurante.Logo = query.Logo;
                                restaurante.Capacidad = query.capacidad ?? 0;

                                result.Objects.Add(restaurante);
                                result.Correct = true;
                            
                        }
                        else
                        {
                            result.Correct = false;
                            result.Messages = "Error al mapear los datos";
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        result.Correct = false;
                        result.Messages = sqlEx.Message;
                        result.Ex = sqlEx;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Messages = "Hubo un error de conexion en la base de datos";
                result.Ex = ex;
            }

            return result;
        }
    }
}
