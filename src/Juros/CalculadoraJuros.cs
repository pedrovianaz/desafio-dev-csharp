public static class CalculadoraJuros
{
    public static decimal Calcular(decimal valor, DateTime vencimento, DateTime hoje)
    {
        int diasAtraso = (hoje - vencimento).Days;

        if (diasAtraso <= 0)
        {
            return 0;
        }

        return valor * 0.025m * diasAtraso;
    }
}
