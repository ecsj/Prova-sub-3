using Application.Responses;
using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces;

public interface ICompraService
{
    void RegistrarCompra(int clienteId, int veiculoId);
    Compra ObterCompraPorId(int id);
    List<Compra> ObterComprasPorClienteId(int clienteId);
    List<CompraResponse> ObterTodasCompras(OrderBy orderDirection);
}