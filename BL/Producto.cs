using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ML.Response;

namespace BL
{
    public class Producto
    {
     public static ProductoResponse GetProductos()
        {
            ProductoResponse response = new ProductoResponse();
            try
            {
                using(DL.ExamenTrupperEntities context = new DL.ExamenTrupperEntities())
                {
                    var get = context.GetProductos().ToList();
                    if (get != null)
                    {
                        response.Code = 100;
                        response.Message = "Éxito al mapear los datos";
                        response.ListaProductos = new List<ML.Producto>();
                        foreach(var obj in get)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.SKU = obj.SKU;
                            producto.Nombre = obj.NOMBRE;
                            producto.Precio = obj.PRECIO;
                            response.ListaProductos.Add(producto);
                        }
                    }
                    else
                    {
                        response.Code = 90;
                        response.Message = "No hay datos que mostrar";
                        response.ListaProductos = new List<ML.Producto>();
                    }
                    return response;
                }
            }
            catch (Exception Ex)
            {

                response.Code = -100;
                response.Message = "Reporta este error a sistemas: "+Ex.ToString();
                response.ListaProductos = new List<ML.Producto>();
                return response;
            }
        }

    }
}
