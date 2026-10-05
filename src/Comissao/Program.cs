using System.Text.Json;
// 1. Ler o arquivo inteiro como texto
string caminho = Path.Combine(AppContext.BaseDirectory, "vendas.json");
string json = File.ReadAllText(caminho);

// 2. Configurar a leitura para ignorar maiúsculas/minúsculas
var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

// 3. Converter o texto em objetos
RegistroVendas? registro = JsonSerializer.Deserialize<RegistroVendas>(json, opcoes);

// 4. Mostrar cada venda
foreach (Venda venda in registro!.Vendas)
{
    Console.WriteLine($"{venda.Vendedor} - {venda.Valor}");
}