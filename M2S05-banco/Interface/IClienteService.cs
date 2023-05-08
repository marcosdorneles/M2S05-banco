using System;
using M2S05_banco.Models;

namespace M2S05_banco.Interface
{
	public interface IClienteService
	{
        void CriarConta();
        Cliente BuscarClientePorNumeroDeConta(int numeroConta);
        void ExibirClientes();
    }
}

