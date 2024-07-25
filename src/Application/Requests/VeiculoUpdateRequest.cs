namespace Application.Requests;

public class VeiculoUpdateRequest
{
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public int? Ano { get; set; }
    public string? Cor { get; set; }
    public decimal? Preco { get; set; }
}