using System.Text.Json;
using System.Globalization;
CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
// 1. Ler o arquivo inteiro como texto
string caminho = Path.Combine(AppContext.BaseDirectory, "estoque.json");
string json = File.ReadAllText(caminho);

// 2. Configurar a leitura para ignorar maiúsculas/minúsculas
var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

// 3. Converter o texto em objetos
RegistroEstoque? registro = JsonSerializer.Deserialize<RegistroEstoque>(json, opcoes);
if (registro is null)
{
    Console.WriteLine("Não foi possível ler os produtos do arquivo.");
    return;
}

// 4. Mostrar os produtos
foreach (Produto produto in registro.Estoque)
{
    Console.WriteLine($"{produto.CodigoProduto} - {produto.DescricaoProduto} - Estoque: {produto.Estoque}");
}