using Domain.Exceptions;

namespace Domain.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public List<Compra> Compras { get; set; } = new List<Compra>();

    public Cliente(string nome, string email, string telefone)
    {
        Validacoes(nome, email, telefone);

        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    private static void Validacoes(string nome, string email, string telefone)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new ClienteException("Nome é obrigatório.");
        if (string.IsNullOrWhiteSpace(email)) throw new ClienteException("Email é obrigatório.");
        if (string.IsNullOrWhiteSpace(telefone)) throw new ClienteException("Telefone é obrigatório.");
    }
}