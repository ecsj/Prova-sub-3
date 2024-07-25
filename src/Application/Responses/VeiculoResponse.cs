using Domain.Entities;

namespace Application.Responses;

public class VeiculoResponse
{

    public VeiculoResponse(Veiculo veiculo)
    {
        Id = veiculo.Id;
        Marca = veiculo.Marca;
        Modelo = veiculo.Modelo;
        Ano = veiculo.Ano;
        Cor = veiculo.Cor;
        Preco = veiculo.Preco;
        Estoque = veiculo.Estoque.Quantidade;
    }

    public int Id { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}