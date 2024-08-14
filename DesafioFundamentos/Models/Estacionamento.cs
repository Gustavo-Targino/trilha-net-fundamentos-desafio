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

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()?.Trim();

            if (!ValidarPlaca(placa))
            {
                Console.WriteLine("Padrão da placa incorreto.");
                return;
            }

            if (HasVeiculo(placa))
            {
                Console.WriteLine("Veículo já adicionado.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine($"Veículo de placa {placa} adicionado com sucesso!");
        }


        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (HasVeiculo(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                decimal horas = Convert.ToDecimal(Console.ReadLine());

                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

                return;
            }

            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");

        }

        public void ListarVeiculos()
        {

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }

                return;
            }

            Console.WriteLine("Não há veículos estacionados.");

        }


        private bool ValidarPlaca(string placa)
        {
            string padraoNormal = @"^[A-Za-z]{3}-\d{4}$|^[A-Za-z]{3}\d{4}$|^[A-Za-z]{2}\d{1}[A-Za-z]\d{2}$";
            string padraoMercosul = @"^[A-Za-z]{3}\d{1}[A-Za-z]{1}\d{2}$";

            return Regex.IsMatch(placa, padraoNormal) || Regex.IsMatch(placa, padraoMercosul);
        }

        private bool HasVeiculo(string placa)
        {
            return veiculos.Any(item => item.ToUpper() == placa.ToUpper());
        }


    }



}
