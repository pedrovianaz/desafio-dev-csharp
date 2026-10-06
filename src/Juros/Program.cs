using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

// 1. Ler o valor da conta
Console.Write("Valor da conta: ");
if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor <= 0)
{
    Console.WriteLine("Valor inválido! Digite um número maior que zero (ex.: 1500,00).");
    return;
}

// 2. Ler a data de vencimento
Console.Write("Data de vencimento (dd/MM/aaaa): ");
if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime vencimento))
{
    Console.WriteLine("Data inválida! Use o formato dd/MM/aaaa (ex.: 25/09/2026).");
    return;
}

// 3. Calcular os juros
DateTime hoje = DateTime.Today;
decimal juros = CalculadoraJuros.Calcular(valor, vencimento, hoje);
int diasAtraso = Math.Max((hoje - vencimento).Days, 0);

// 4. Mostrar o resultado
Console.WriteLine();
Console.WriteLine($"Data de hoje:     {hoje:dd/MM/yyyy}");
Console.WriteLine($"Dias de atraso:   {diasAtraso}");
Console.WriteLine($"Valor original:   {valor:C}");
Console.WriteLine($"Juros (2,5%/dia): {juros:C}");
Console.WriteLine($"Total a pagar:    {valor + juros:C}");
