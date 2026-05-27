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
                            result.Messages = "Restaurante agregado correctamente"
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
