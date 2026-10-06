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
var historico = new List<Movimentacao>();
int proximoId = 1;

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
            Console.Write("Código do produto: ");
            if (!int.TryParse(Console.ReadLine(), out int codigo))
            {
                Console.WriteLine("Código inválido! Digite apenas números.");
                break;
            }

            Produto? produtoEncontrado = null;

            foreach (Produto p in registro.Estoque)
            {
                if (p.CodigoProduto == codigo)
                {
                    produtoEncontrado = p;
                    break;
                }
            }

            if (produtoEncontrado is null)
            {
                Console.WriteLine("Produto não encontrado!");
                break;
            }

            Console.WriteLine($"Produto encontrado: {produtoEncontrado.DescricaoProduto} (estoque atual: {produtoEncontrado.Estoque})");

            // 1. - Tipo
            Console.Write("Tipo (1 - Entrada / 2 - Saída): ");
            string? opcaoTipo = Console.ReadLine();

            TipoMovimentacao tipo;

            if (opcaoTipo == "1")
            {
                tipo = TipoMovimentacao.Entrada;
            }
            else if (opcaoTipo == "2")
            {
                tipo = TipoMovimentacao.Saida;
            }
            else
            {
                Console.WriteLine("Tipo inválido!");
                break;
            }

            // 2. - Quantidade
            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida! Digite um número maior que zero.");
                break;
            }
            if (tipo == TipoMovimentacao.Saida && quantidade > produtoEncontrado.Estoque)
            {
                Console.WriteLine($"Estoque insuficiente! Disponível: {produtoEncontrado.Estoque}");
                break;
            }

            // 3 - Descrição
            Console.Write("Descrição: ");
            string? descricao = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(descricao))
            {
                Console.WriteLine("A descrição é obrigatoria!");
                break;
            }

            // 4 - Atualizar o estoque
            if (tipo == TipoMovimentacao.Entrada)
            {
                produtoEncontrado.Estoque += quantidade;
            }
            else
            {
                produtoEncontrado.Estoque -= quantidade;
            }

            // 5 - Registrar no histórico
            var movimentacao = new Movimentacao
            {
                Id = proximoId,
                CodigoProduto = produtoEncontrado.CodigoProduto,
                Tipo = tipo,
                Quantidade = quantidade,
                Descricao = descricao,
                Data = DateTime.Now
            };

            historico.Add(movimentacao);
            proximoId++;

            // 6 - Resultado
            Console.WriteLine();
            Console.WriteLine($"✅ Movimentação nº {movimentacao.Id} registrada!");
            Console.WriteLine($"Estoque final de {produtoEncontrado.DescricaoProduto}: {produtoEncontrado.Estoque}");

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
