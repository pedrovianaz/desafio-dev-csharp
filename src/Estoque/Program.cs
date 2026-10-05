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

// 4. Menu principal
bool continuar = true;

while (continuar)
{
    Console.WriteLine();
    Console.WriteLine("===== CONTROLE DE ESTOQUE =====");
    Console.WriteLine("1 - Listar produtos");
    Console.WriteLine("2 - Lançar movimentação");
    Console.WriteLine("3 - Ver histórico");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            foreach (Produto produto in registro.Estoque)
            {
                Console.WriteLine($"{produto.CodigoProduto} - {produto.DescricaoProduto} - Estoque: {produto.Estoque}");
            }
            break;

        case "2":
            Console.WriteLine("Em construção...");
            break;

        case "3":
            Console.WriteLine("Em construção...");
            break;

        case "0":
            continuar = false;
            Console.WriteLine("Até logo!");
            break;

        default:
            Console.WriteLine("Opção inválida! Tente novamente.");
            break;
    }
}
