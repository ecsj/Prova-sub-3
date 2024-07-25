using Domain.Entities;

namespace Application.Requests;

public class ClienteRequest
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    public Cliente ToEntity() => new(Nome, Email, Telefone);
}