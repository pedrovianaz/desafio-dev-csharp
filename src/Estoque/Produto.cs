public class Produto
{
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; } = "";
    public int Estoque { get; set; }
}

public class RegistroEstoque
{
    public List<Produto> Estoque { get; set; } = new();
}
