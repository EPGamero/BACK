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
    public class Cliente
    {
        public static ClienteResponse AddCliente(ML.Cliente cliente, List<ML.Producto> productos)
        {
            ClienteResponse response = new ClienteResponse();
            try
            {
                using (DL.ExamenTrupperEntities context = new DL.ExamenTrupperEntities())
                {
                    int ClienteId = Convert.ToInt32(context.AddCliente(cliente.Nombre, cliente.APaterno, cliente.AMaterno).FirstOrDefault());

                    if (ClienteId > 0)
                    {
                        response.Code = 100;
                        response.Message = "Éxito al ingresar nuevo cliente";
                        response.ListaClientes = new List<ML.Cliente>();
                        ML.Pedido pedido = new ML.Pedido();
                        BL.Pedido.AddPedido(ClienteId, pedido, productos);
                    }
                    else
                    {
                        response.Code = 50;
                        response.Message = "Error al agregar cliente";
                        response.ListaClientes = new List<ML.Cliente>();
                    }
                    return response;
                }
            }
            catch (Exception Ex)
            {
                response.Code = -100;
                response.Message = "No se pudo agregar el cliente por el siguiente error: " + Ex.ToString();
                response.ListaClientes = new List<ML.Cliente>();
                return response;
            }                 
        }
    }
}
