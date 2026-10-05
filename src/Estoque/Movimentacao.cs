public enum TipoMovimentacao
{
    Entrada,
    Saida
}
public class Movimentacao
{
    public int id { get; set; }
    public int CodigoProduto { get; set; }
    public TipoMovimentacao Tipo { get; set; }
    public int Quantidade { get; set; }
    public DateTime Data { get; set; }
}