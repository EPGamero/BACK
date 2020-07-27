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
    public class PedidoDetalle
    {
        public static PedidoDetalleResponse AddPedidoDetalle(int PedidoId,ML.Producto producto,ML.PedidoDetalle pedidoDetalle)
        {
            PedidoDetalleResponse response = new PedidoDetalleResponse();
            try
            {
                using (DL.ExamenTrupperEntities context = new DL.ExamenTrupperEntities())
                {
                    pedidoDetalle.Pedido = new ML.Pedido();
                    pedidoDetalle.Pedido.PedidoId = PedidoId;
                    pedidoDetalle.Producto = new ML.Producto();
                    pedidoDetalle.Producto.SKU = producto.SKU;
                    var Add = context.AddPedidoDetalle(pedidoDetalle.Pedido.PedidoId, pedidoDetalle.Producto.SKU, pedidoDetalle.Cantidad);
                    if (Add > 0)
                    {
                        response.Code = 100;
                        response.Message = "Éxito al agregar el detalle";
                        response.ListaPedidoDetalle = new List<ML.PedidoDetalle>();
                    }
                    else
                    {
                        response.Code = 50;
                        response.Message = "Error al agregar el detalle";
                        response.ListaPedidoDetalle = new List<ML.PedidoDetalle>();
                    }
                    return response;
                }

            }
            catch (Exception Ex)
            {
                response.Code = -100;
                response.Message = "Notifica este error a sistemas: " + Ex.ToString();
                response.ListaPedidoDetalle = new List<ML.PedidoDetalle>();
                return response;
            }
       
        }
        public static PedidoDetalleResponse DeletePedidoDetalle(ML.PedidoDetalle pedidoDetalle)
        {
            PedidoDetalleResponse response = new PedidoDetalleResponse();
            try
            {
                using (DL.ExamenTrupperEntities context = new DL.ExamenTrupperEntities())
                {
                    var delete = context.DeletePedidoDetalleById(pedidoDetalle.Pedido.PedidoId);
                    if (delete > 0)
                    {
                        response.Code = 100;
                        response.Message = "Éxito al eliminar el detalle del pedido";
                        response.ListaPedidoDetalle = new List<ML.PedidoDetalle>();
                        ML.Pedido pedido = new ML.Pedido();
                        pedido.PedidoId = pedidoDetalle.Pedido.PedidoId;
                        BL.Pedido.DeletePedido(pedido);
                    }
                    else
                    {
                        response.Code = 90;
                        response.Message = "Detalle de pedido no existente o no válido";
                        response.ListaPedidoDetalle = new List<ML.PedidoDetalle>();
                    }
                    return response;
                }
            }
            catch (Exception Ex)
            {
                response.Code = -100;
                response.Message = "No se pudo eliminar el detalle del pedido por el siguiente error: " + Ex.ToString();
                response.ListaPedidoDetalle = new List<ML.PedidoDetalle>();
                return response;
            }
            //using(DL.ExamenTrupperEntities context = new DL.ExamenTrupperEntities())
            //{

            //    var delete = context.DeletePedidoDetalleById(pedidoDetalle.Pedido.PedidoId);
            //    try
            //    {
            //        response.Code = 100;
            //        response.Message = "Éxito al eliminar el detalle del pedido";
            //        response.ListaPedidoDetalle = new List<ML.PedidoDetalle>();
            //        ML.Pedido pedido = new ML.Pedido();
            //        pedido.PedidoId = pedidoDetalle.Pedido.PedidoId;
            //        BL.Pedido.DeletePedido(pedido);
            //    }
            //    catch (Exception Ex)
            //    {
            //        response.Code = -100;
            //        response.Message = "No se pudo eliminar el detalle del pedido por el siguiente error: " + Ex.ToString();
            //        response.ListaPedidoDetalle = new List<ML.PedidoDetalle>();
            //    }
            //    return response;
            //}
        }
    }
}
