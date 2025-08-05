using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;
string inputMain = string.Empty;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n");
do
{
    Console.Write("Digite o preço inicial: ");
    inputMain = Console.ReadLine();
    if (!string.IsNullOrEmpty(inputMain) && decimal.TryParse(inputMain, out decimal errado))
    {
        precoInicial = Convert.ToDecimal(inputMain);
        inputMain = string.Empty; // Tirando o número de inputMain para que possa ser usado no próximo do while
    }
    else
        Console.WriteLine("Digite um valor monetário válido.\n");
} while (precoInicial <= 0);

do
{
    Console.Write("Digite o preço por hora: ");
    inputMain = Console.ReadLine();
    if (!string.IsNullOrEmpty(inputMain) && decimal.TryParse(inputMain, out decimal errado))
        precoPorHora = Convert.ToDecimal(inputMain);
    else
        Console.WriteLine("Digite um valor monetário válido.\n");
} while (precoPorHora <= 0);

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
