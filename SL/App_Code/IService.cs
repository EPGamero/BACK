using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{

	[OperationContract]
	ProductoResponse GetProductos();

	[OperationContract]
	ClienteResponse AddCliente(Cliente cliente, List<ML.Producto> productos);

	[OperationContract]
	PedidoResponse AddPedido(int ClienteId,Pedido pedido,List<ML.Producto>productos);

	[OperationContract]
	PedidoDetalleResponse AddPedidoDetalle(int PedidoId, ML.Producto producto, ML.PedidoDetalle pedidoDetalle);

	[OperationContract]
	ConsultaPedidoResponse GetPedidoById(ML.Entities.ConsultaPedido consulta);

	[OperationContract]
	PedidoResponse DeletePedidoById(Pedido pedido);

	[OperationContract]
	PedidoDetalleResponse DeletePedidoDetalleById(PedidoDetalle pedidoDetalle);

}

[DataContract]
public class ProductoResponse
{
	[DataMember]
    public int Code { get; set; }
	[DataMember]
	public string Message { get; set; }
	[DataMember]
	public List<Producto> ListaProductos { get; set; }
}

[DataContract]
public class ClienteResponse
{
	[DataMember]
	public int Code { get; set; }
	[DataMember]
	public string Message { get; set; }
	[DataMember]
	public List<Cliente> ListaClientes { get; set; }
}


[DataContract]
public class PedidoResponse
{
	[DataMember]
	public int Code { get; set; }
	[DataMember]
	public string Message { get; set; }
	[DataMember]
	public List<Pedido> ListaPedidos { get; set; }
}

[DataContract]
public class PedidoDetalleResponse
{
	[DataMember]
	public int Code { get; set; }
	[DataMember]
	public string Message { get; set; }
	[DataMember]
	public List<PedidoDetalle> ListaPedidoDetalle { get; set; }
}


[DataContract]
public class ConsultaPedidoResponse
{
	[DataMember]
	public int Code { get; set; }
	[DataMember]
	public string Message { get; set; }
	[DataMember]
	public List<PedidoDetalle> ListaPedidoDetalle { get; set; }
	[DataMember]
	public List<Pedido> ListaPedido { get; set; }
}