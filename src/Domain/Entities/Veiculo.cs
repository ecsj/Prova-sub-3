using System.Text;
using Domain.Exceptions;

namespace Domain.Entities;
public class Veiculo
{
    public int Id { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }
    public decimal Preco { get; set; }
    public Estoque Estoque { get; set; }

    public Veiculo(string marca, string modelo, int ano, string cor, decimal preco)
    {
        Validacoes(marca, modelo, ano, cor, preco);

        Marca = marca;
        Modelo = modelo;
        Ano = ano;
        Cor = cor;
        Preco = preco;
        Estoque = new Estoque(this);
    }

    private static void Validacoes(string marca, string modelo, int ano, string cor, decimal preco)
    {
        if (string.IsNullOrWhiteSpace(marca)) throw new VeiculoException("Marca é obrigatória.");
        if (string.IsNullOrWhiteSpace(modelo)) throw new VeiculoException("Modelo é obrigatório.");
        if (ano <= 0) throw new VeiculoException("Ano deve ser maior que zero.");
        if (string.IsNullOrWhiteSpace(cor)) throw new VeiculoException("Cor é obrigatória.");
        if (preco <= 0) throw new VeiculoException("Preço deve ser maior que zero.");
    }

    public void Editar(string? marca, string? modelo, int? ano, string? cor, decimal? preco)
    {
        Marca = marca ?? Marca;
        Modelo = modelo ?? Modelo;
        Ano = ano ?? Ano;
        Cor = cor ?? Cor;
        Preco = preco ?? Preco;

        var logAuditoria = new StringBuilder();
        logAuditoria.Append("Dados atualizados: ");

        if(marca is not null)
            logAuditoria.Append($" Marca atualizado para {marca}");

        if (modelo is not null)
            logAuditoria.Append($" modelo atualizado para {modelo}");

        if (ano is not null)
            logAuditoria.Append($" ano atualizado para {ano}");

        if (cor is not null)
            logAuditoria.Append($" cor atualizado para {cor}");


        Console.WriteLine(logAuditoria);



        Validacoes(Marca, Modelo, Ano, Cor, Preco);

        
    }

    public void VenderPara(Cliente? cliente)
    {
        if (cliente == null) throw new VeiculoException("Comprador não pode ser nulo.");
        if (Estoque.Quantidade <= 0) throw new VeiculoException("Veículo fora de estoque.");

        Estoque.DecrementarEstoque(1);
    }

    public void IncrementarEstoque(int quantidade)
    {
        Estoque.IncrementarEstoque(quantidade);
    }
}
