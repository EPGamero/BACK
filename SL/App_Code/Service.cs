using ML;
using ML.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    public ProductoResponse GetProductos()
    {
        ML.Response.ProductoResponse response = new ML.Response.ProductoResponse();
        response = BL.Producto.GetProductos();
        return new ProductoResponse { Code = response.Code, Message = response.Message, ListaProductos = response.ListaProductos };
    }
    public ClienteResponse AddCliente(Cliente cliente, List<Producto> productos)
    {
        ML.Response.ClienteResponse response = new ML.Response.ClienteResponse();
        response = BL.Cliente.AddCliente(cliente, productos);
        return new ClienteResponse { Code = response.Code, Message = response.Message, ListaClientes = response.ListaClientes };
    }
    public PedidoResponse AddPedido(int ClienteId, Pedido pedido, List<Producto> productos)
    {
        ML.Response.PedidoResponse response = new ML.Response.PedidoResponse();
        response = BL.Pedido.AddPedido(ClienteId, pedido, productos);
        return new PedidoResponse { Code = response.Code, Message = response.Message, ListaPedidos = response.ListaPedidos };

    }
    public PedidoDetalleResponse AddPedidoDetalle(int PedidoId, Producto producto, PedidoDetalle pedidoDetalle)
    {
        ML.Response.PedidoDetalleResponse response = new ML.Response.PedidoDetalleResponse();
        response = BL.PedidoDetalle.AddPedidoDetalle(PedidoId, producto, pedidoDetalle);
        return new PedidoDetalleResponse { Code = response.Code, Message = response.Message, ListaPedidoDetalle = response.ListaPedidoDetalle };
    }
    public ConsultaPedidoResponse GetPedidoById(ConsultaPedido consulta)
    {
        ML.Response.ConsultaPedidoResponse response = new ML.Response.ConsultaPedidoResponse();
        response = BL.ConsultaPedido.GetPedidoById(consulta);
        return new ConsultaPedidoResponse {Code = response.Code, Message = response.Message, ListaPedidoDetalle = response.ListaPedidoDetalle, ListaPedido=response.ListaPedido };
    }
    public PedidoResponse DeletePedidoById(Pedido pedido)
    {
        ML.Response.PedidoResponse response = new ML.Response.PedidoResponse();
        response = BL.Pedido.DeletePedido(pedido);
        return new PedidoResponse { Code = response.Code, Message = response.Message, ListaPedidos = response.ListaPedidos };
    }
    public PedidoDetalleResponse DeletePedidoDetalleById(PedidoDetalle pedidoDetalle)
    {
        ML.Response.PedidoDetalleResponse response = new ML.Response.PedidoDetalleResponse();
        response = BL.PedidoDetalle.DeletePedidoDetalle(pedidoDetalle);
        return new PedidoDetalleResponse { Code=response.Code, Message=response.Message,ListaPedidoDetalle=response.ListaPedidoDetalle};
    }
}
