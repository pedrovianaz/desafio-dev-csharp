# Desafio Dev - C#

Solução dos três exercícios do desafio, feita em C# com .NET 10.

Autor: Pedro Viana

## Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)

## Como executar

Na pasta raiz do projeto:

```bash
dotnet run --project src/Comissao
dotnet run --project src/Estoque
dotnet run --project src/Juros
```

## Estrutura

```
src/
├── Comissao/   Exercício 1 - comissão dos vendedores
├── Estoque/    Exercício 2 - movimentações de estoque
└── Juros/      Exercício 3 - juros por atraso
```

## Exercício 1 - Comissão

Lê o arquivo `vendas.json` e calcula a comissão total de cada vendedor:

- vendas abaixo de R$ 100,00: sem comissão
- vendas abaixo de R$ 500,00: 1%
- vendas a partir de R$ 500,00: 5%

A regra fica isolada na classe `CalculadoraComissao`. Os valores usam `decimal` para evitar erros de arredondamento com dinheiro.

Resultado:

| Vendedor | Comissão |
|---|---|
| João Silva | R$ 495,68 |
| Maria Souza | R$ 465,95 |
| Carlos Oliveira | R$ 379,37 |
| Ana Lima | R$ 404,98 |

## Exercício 2 - Estoque

Menu interativo que lê os produtos de `estoque.json` e permite:

1. Listar os produtos e o estoque atual
2. Lançar uma movimentação de entrada ou saída
3. Ver o histórico de movimentações

Cada movimentação recebe um **ID único sequencial**, um **tipo** (Entrada/Saída), uma **descrição** obrigatória e a data/hora. Ao final, o programa mostra o estoque final do produto movimentado.

Validações:

- código de produto inexistente ou não numérico
- quantidade não numérica, zero ou negativa
- saída maior que o estoque disponível (o estoque nunca fica negativo)
- descrição vazia

Observação: as movimentações ficam em memória durante a execução e não são gravadas de volta no JSON.

## Exercício 3 - Juros

Recebe um valor e uma data de vencimento (`dd/MM/aaaa`) e calcula os juros até a data de hoje.

**Premissa adotada:** o enunciado fala em "juros" e "multa de 2,5% ao dia". Interpretei como **juros simples de 2,5% por dia de atraso**:

```
juros = valor × 0,025 × dias de atraso
```

Se a conta vence hoje ou ainda não venceu, os juros são zero.

A data de hoje é passada como parâmetro para a classe `CalculadoraJuros`, o que permite testar o cálculo com datas fixas.
