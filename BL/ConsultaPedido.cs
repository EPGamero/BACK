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
    public class ConsultaPedido
    {
        public static ConsultaPedidoResponse GetPedidoById(ML.Entities.ConsultaPedido consulta)
        {
            ConsultaPedidoResponse response = new ConsultaPedidoResponse();
            try
            {
                using (DL.ExamenTrupperEntities context = new DL.ExamenTrupperEntities())
                {
                    var GetPedido = context.GetPedidoById(consulta.Pedido.PedidoId).ToList();
                    if (GetPedido.Count >0)
                    {
                        response.Code = 100;
                        response.Message = "Éxito al mapear los datos";
                        response.ListaPedido = new List<ML.Pedido>();
                        foreach(var obj in GetPedido)
                        {
                            ML.Entities.ConsultaPedido ConsultaPedido = new ML.Entities.ConsultaPedido();
                            ConsultaPedido.Pedido = new ML.Pedido();
                            ConsultaPedido.Pedido.PedidoId = obj.PedidoId;
                            ConsultaPedido.Pedido.Cliente = new ML.Cliente();
                            ConsultaPedido.Pedido.Cliente.ClienteId = obj.Cliente;
                            response.ListaPedido.Add(ConsultaPedido.Pedido);
                        }
                       response.ListaPedidoDetalle = new List<ML.PedidoDetalle>();   
                        foreach(var obj in GetPedido)
                        {
                            ML.Entities.ConsultaPedido consultaPedido = new ML.Entities.ConsultaPedido();
                            consultaPedido.PedidoDetalle = new ML.PedidoDetalle();
                            consultaPedido.PedidoDetalle.Producto = new ML.Producto();
                            consultaPedido.PedidoDetalle.Producto.SKU = obj.SKU;
                            consultaPedido.PedidoDetalle.Cantidad = obj.Cantidad;
                            response.ListaPedidoDetalle.Add(consultaPedido.PedidoDetalle);
                        }
           
                    }
                    else
                    {
                        response.Code = 90;
                        response.Message = "No hay datos que mostrar";
                        response.ListaPedido = new List<ML.Pedido>();
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
                response.ListaPedido = new List<ML.Pedido>();
                return response;
            }
        }
    }
}
