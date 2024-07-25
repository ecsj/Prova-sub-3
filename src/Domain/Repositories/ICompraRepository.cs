using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories;

public interface ICompraRepository
{
    void Adicionar(Compra compra);
    Compra ObterPorId(int id);
    List<Compra> ObterComprasPorClienteId(int clienteId);
    List<Compra> ObterTodasCompras(OrderBy orderDirection);
}
