public static class CalculadoraComissao
{
    public static decimal Calcular(decimal valorVenda)
    {
        if (valorVenda < 100)
        {
            return 0;
        }
        else if (valorVenda < 500)
        {
            return (1m / 100) * valorVenda;
        }
        else
        {
            return (5m / 100) * valorVenda;
        }
    }
}