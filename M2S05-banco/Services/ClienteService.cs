using System;
using M2S05_banco.Models;

namespace M2S05_banco.Services
{
	public class ClienteService
	{
        private static List<Cliente> _clientes = new List<Cliente>();

        public ClienteService()
        {
            _clientes.Add(new PessoaFisica(1, "Rua ", "123", "456", "Vitor", new DateTime(2005, 05, 5)));
          
        }
        public void CriarConta()
        {
            Console.WriteLine("Qual o tipo de conta que deseja Criar? ");
            Console.WriteLine("1 - Pessoa Física ");
            Console.WriteLine("2 - Pessoa Jurídica ");
            var opcao = Console.ReadLine();

            if (opcao == "1")
            {
                CriarContaPessoaFisica();
            }
            else if (opcao == "2")
            {
                //CriarContaPessoaJuridica();
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }
        }

        public Cliente BuscarClientePorNumeroDeConta(int numeroConta)
        {
            return _clientes.Find(cliente => cliente.NumeroConta == numeroConta);
        }

        public void ExibirClientes()
        {
            foreach (var cliente in _clientes)
            {
                Console.WriteLine(cliente.ResumoCliente());
            }
        }

        private void CriarContaPessoaFisica()
        {
            var clientePF = new PessoaFisica();
            Console.WriteLine("Digite a Data de Nascimento");
            clientePF.DataNascimento = DateTime.Parse(Console.ReadLine());
            if (!clientePF.maiorIdade())
            {
                Console.WriteLine("não é possivel criar conta para menor de idade");
                return;
            }
            Console.WriteLine("Digite o CPF");
            clientePF.CPF = Console.ReadLine();
            Console.WriteLine("Digite o Nome");
            clientePF.Nome = Console.ReadLine();


            clientePF = (PessoaFisica)PreencheClientePai(clientePF);

            _clientes.Add(clientePF);
        }

        //private void CriarContaPessoaJuridica()
        //{
        //    var clientePj = new PessoaJuridica();
        //    Console.WriteLine("Digite o CNPJ");
        //    clientePj.CNPJ = Console.ReadLine();
        //    Console.WriteLine("Digite o Razão Social");
        //    clientePj.RazaoSocial = Console.ReadLine();
        //    Console.WriteLine("Digite o Inscrição Estadual");
        //    clientePj.InscricaoEstadual = Console.ReadLine();

        //    clientePj = (PessoaJuridica)PreencheClientePai(clientePj);
        //    _clientes.Add(clientePj);
        //}
        private Cliente PreencheClientePai(Cliente cliente)
        {
            Console.WriteLine("Digite o Numero da conta ");
            cliente.NumeroConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Endereco");
            cliente.Endereco = Console.ReadLine();
            Console.WriteLine("Digite o Telefone");
            cliente.Telefone = Console.ReadLine();
            Console.WriteLine("Digite o Saldo");
            cliente.Saldo = Decimal.Parse(Console.ReadLine());
            return cliente;
        }
    }
}

