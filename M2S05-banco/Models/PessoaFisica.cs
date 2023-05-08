using System;
namespace M2S05_banco.Models
{
	public class PessoaFisica : Cliente
	{
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }


        public PessoaFisica(int numeroConta, string endereco, string telefone,
                            string cpf, string nome, DateTime dataNascimento)
                            : base(numeroConta, endereco, telefone)
        {
            CPF = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public PessoaFisica()
        {
        }

        public bool maiorIdade()
        {
            var idade = DateTime.Now.Year - DataNascimento.Year;
            if (!(DateTime.Now.Month >= DataNascimento.Month
                && DateTime.Now.Day >= DataNascimento.Day))
            {
                idade--;
            }
            return idade >= 18;
        }

        public override string ResumoCliente()
        {
            return $"{base.ResumoCliente()} | Cpf: {CPF} | Nome: {Nome} | DataNascimento: {DataNascimento.ToShortDateString()}";
        }
    }
}

