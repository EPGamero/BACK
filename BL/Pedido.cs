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
    public class Pedido
    {
        public static PedidoResponse AddPedido(int ClienteId,ML.Pedido pedido, List<ML.Producto> productos)
        {
            PedidoResponse response = new PedidoResponse();
            try
            {
                using (DL.ExamenTrupperEntities context = new DL.ExamenTrupperEntities())
                {
                    pedido.Cliente = new ML.Cliente();
                    pedido.Cliente.ClienteId = ClienteId;
                    int PedidoId = Convert.ToInt32(context.AddPedido(pedido.Cliente.ClienteId, pedido.MontoPedido).FirstOrDefault());
                    if (PedidoId > 0)
                    {
                        response.Code = 100;
                        response.Message = "Éxito al ingresar pedido";
                        response.ListaPedidos = new List<ML.Pedido>();
                        ML.PedidoDetalle pedidoDetalle = new ML.PedidoDetalle();
                        foreach (ML.Producto producto in productos)
                        {
                            BL.PedidoDetalle.AddPedidoDetalle(PedidoId, producto, pedidoDetalle);
                        }
                    }
                    else
                    {
                        response.Code = 50;
                        response.Message = "Error al agregar pedido";
                        response.ListaPedidos = new List<ML.Pedido>();
                    }
                    return response;
                }

            }
            catch (Exception Ex)
            {
                response.Code = -100;
                response.Message = "No se pudo agregar el pedido por el siguiente error:  " + Ex.ToString();
                response.ListaPedidos = new List<ML.Pedido>();
                return response;
            }
        }
        public static PedidoResponse DeletePedido(ML.Pedido pedido)
        {
            PedidoResponse response = new PedidoResponse();
            try
            {
                using (DL.ExamenTrupperEntities context = new DL.ExamenTrupperEntities())
                {
                    var delete = context.DeletePedidoById(pedido.PedidoId);
                    if (delete >0)
                    {
                        response.Code = 100;
                        response.Message = "Éxito al eliminar el pedido";
                        response.ListaPedidos = new List<ML.Pedido>();
                    }
                    else
                    {
                        response.Code = 90;
                        response.Message = "Pedido no existente o no válido";
                        response.ListaPedidos = new List<ML.Pedido>();
                    }
                    return response;
                }

            }
            catch (Exception Ex)
            {
                response.Code = -100;
                response.Message = "No se pudo eliminar el pedido por el siguiente error: " + Ex.ToString();
                response.ListaPedidos = new List<ML.Pedido>();
                return response;
            }
        }
    }
}
