using Domain.Entities;

namespace Application.Requests;

public class VeiculoRequest
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }
    public decimal Preco { get; set; }
    public int QtdEstoque { get; set; }

    public Veiculo ToEntity() => new(Marca, Modelo, Ano, Cor, Preco);
}