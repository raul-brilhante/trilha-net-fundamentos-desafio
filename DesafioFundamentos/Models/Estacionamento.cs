using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        /// <summary>
        /// Adiciona o veículo, informando a placa no formato ABC-1234.
        /// </summary>
        public void AdicionarVeiculo()
        {
            bool ok = false;
            string verificacao;
            do
            {
                Console.Write("Digite a placa do veículo para estacionar: ");
                verificacao = Console.ReadLine();

                // Utilizando regex com o formato de placa que é válido.
                Regex regex = new Regex(@"^[A-Z]{3}-[0-9]{4}$");

                if (regex.Match(verificacao).Success)
                    ok = true;
                else
                    Console.WriteLine("Digite uma placa válida.\n");

            } while (!ok);

            if (!veiculos.Contains(verificacao.ToUpper()))
                veiculos.Add(verificacao.ToUpper());

            else
                Console.WriteLine("Esse carro já está cadastrado como estacionado.");
        }

        /// <summary>
        /// Remove um veiculo estacionado, informado pela placa.
        /// Informa o preço a se pagar dependendo das horas informadas.
        /// </summary>
        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                do
                {
                    Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                    string input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int hora))
                        horas = Convert.ToInt32(input);

                    if (horas < 1)
                        Console.WriteLine("Digite uma quantidade de horas válida.\n");
                } while (horas < 1);

                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa.ToUpper());

                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }

        /// <summary>
        /// Lista os veículos que estão estacionados no momento.
        /// </summary>
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculosEstacionados in veiculos)
                    Console.WriteLine(veiculosEstacionados);
            }
            else
                Console.WriteLine("Não há veículos estacionados.");
        }
    }
}
