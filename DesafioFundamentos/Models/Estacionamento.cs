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

        public void AdicionarVeiculo()
        {
            string verificacao;
            do
            {
                Console.Write("Digite a placa do veículo para estacionar: ");
                verificacao = Console.ReadLine();

                if (verificacao.Length != 8)
                    Console.WriteLine("Digite uma placa válida. Formato de exemplo: ABC-1234\n");

            } while (verificacao.Length != 8);  // Verifica se a placa tem 8 digitos
                                                // Apenas o mínimo de garantia
                                                
            if (!veiculos.Contains(verificacao))
                veiculos.Add(verificacao);

            else
                Console.WriteLine("Esse carro já está cadastrado como estacionado.");
        }

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
                            {
                                Console.WriteLine("Digite uma quantidade de horas válida.\n");
                            }
                } while (horas < 1);

                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculosEstacionados in veiculos)
                {
                    Console.WriteLine(veiculosEstacionados);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
