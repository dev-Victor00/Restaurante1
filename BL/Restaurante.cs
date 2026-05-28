using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class Restaurante
    {
        public ML.Result Add (ML.Restaurante restaurante)
        {
            ML.Result result = new ML.Result ();

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
                    catch (SqlException sqlEx) {
                        result.Correct = false;
                        result.Messages = sqlEx.Message;
                        result.Ex = sqlEx;
                    }
                }
            }
            catch (Exception ex) {
                result.Correct = false;
                result.Messages = "Ingresaste algo mal o no se pudo insertar el restaurante";
                result.Ex = ex;
            }

            return result;
        }

        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.CalifadeLeonEntities context = new DL.CalifadeLeonEntities())
                {
                    try
                    {
                        var query = context.GetAllRestaurant().ToList();

                        if (query.Count > 0)
                        {
                            foreach(var item in query)
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

        public ML.Result Update(ML.Restaurante restaurante)
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
    }
}
