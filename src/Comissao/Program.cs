using System.Text.Json;
// 1. Ler o arquivo inteiro como texto
string caminho = Path.Combine(AppContext.BaseDirectory, "vendas.json");
string json = File.ReadAllText(caminho);

// 2. Configurar a leitura para ignorar maiúsculas/minúsculas
var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

// 3. Converter o texto em objetos
RegistroVendas? registro = JsonSerializer.Deserialize<RegistroVendas>(json, opcoes);

// 4. Criar o dicionário que vai guardar o total de cada vendedor
var comissoes = new Dictionary<string, decimal>();
foreach (Venda venda in registro!.Vendas)
{
    decimal comissao = CalculadoraComissao.Calcular(venda.Valor);
    if (comissoes.ContainsKey(venda.Vendedor))
    {
        comissoes[venda.Vendedor] += comissao;
    }
    else
    {
        comissoes[venda.Vendedor] = comissao;
    }
}

// 5. Mostrar o total de cada vendedor
foreach (var item in comissoes)
{
    Console.WriteLine($"{item.Key}: {item.Value:C}");
}