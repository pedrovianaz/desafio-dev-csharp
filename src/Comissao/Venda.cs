public class Venda
{
    public string Vendedor { get; set; } = "";
    public decimal Valor { get; set; }
}
public class RegistroVendas
{
    public List<Venda> Vendas { get; set; } = new();
}