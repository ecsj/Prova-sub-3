namespace Application.Interfaces;

public interface IEstoqueService
{
    void IncrementarEstoque(int veiculoId, int quantidade);
    void DecrementarEstoque(int veiculoId, int quantidade);
    int ObterQuantidadeEstoque(int veiculoId);
}