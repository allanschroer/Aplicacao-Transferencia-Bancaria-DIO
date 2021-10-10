using System;
using System.Collections.Generic;
using Aplicacao_Transferencia_Bancaria_DIO.Conta;
using Aplicacao_Transferencia_Bancaria_DIO.Enums;

namespace Aplicacao_Transferencia_Bancaria_DIO
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ContaBancaria> contas = new();
            contas.Add(new ContaBancaria("Allan Schroer", 100, 300, Enums.TipoConta.Fisica));
            contas.Add(new ContaBancaria("João da Silva", 200, 300, Enums.TipoConta.Fisica));

            bool rodando = true;

            while (rodando)
            {
                ImprimirMenu();
                int opcao = VerificarEntrada(Console.ReadLine());
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        ListarContas(contas);
                        break;

                    case 2:
                        var conta = InserirConta();
                        if(conta != null)
                            contas.Add(conta);
                        break;

                    case 3:
                        ListarContas(contas);
                        Transferir(contas);
                        break;

                    case 4:
                        ListarContas(contas);
                        Sacar(contas);
                        break;

                    case 5:
                        ListarContas(contas);
                        Depositar(contas);
                        break;

                    case 99:
                        rodando = false;
                        break;

                    default:
                        Console.Write("Opção invalida, tente novamente!\n Aperte enter para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        private static void Depositar(List<ContaBancaria> contas)
        {
            Console.Write("Digite a conta para saque: > ");
            var contaDeposito = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser depositado: > ");
            contas[contaDeposito].Depositar(double.Parse(Console.ReadLine()));
            Console.WriteLine("Valor depositado com sucesso!");
            Console.ReadLine();
            Console.Clear();
        }

        private static void Sacar(List<ContaBancaria> contas)
        {
            Console.Write("Digite a conta para saque: > ");
            var contaSaque = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser sacado: > ");
            contas[contaSaque].Sacar(double.Parse(Console.ReadLine()));
            Console.ReadLine();
            Console.Clear();
        }

        private static void Transferir(List<ContaBancaria> contas)
        {
            Console.Write("Digite a conta de origem: ");
            var origem = int.Parse(Console.ReadLine());
            Console.Write("Digite a conta de destino: ");
            var destino = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantidade a ser transferida: ");
            contas[origem].Transferir(double.Parse(Console.ReadLine()), contas[destino]);
            Console.ReadLine();
        }

        private static ContaBancaria InserirConta()
        {
            Console.Write("Insira o seu nome: ");
            var nome = Console.ReadLine();
            Console.Write("1 para pessoa fisica e 2 para pessoa juridica:");
            var entradaTipoPessoa = Console.ReadLine();
            TipoConta tipoConta;

            if (entradaTipoPessoa == "1")
            {
                tipoConta = TipoConta.Fisica;
                Console.Write("Digite a quantidade para depósito inicial: ");
                var depositoInicial = double.Parse(Console.ReadLine());
                Console.Write("Seu cédito inicial é de 300 reais.");
                Console.ReadLine();
                return new(nome, depositoInicial, 300, tipoConta);
            }
            if (entradaTipoPessoa == "2")
            {
                tipoConta = TipoConta.Juridica;
                Console.Write("Digite a quantidade para depósito inicial: ");
                var depositoInicial = double.Parse(Console.ReadLine());
                Console.Write("Seu cédito inicial é de 300 reais.\n");
                Console.ReadLine();
                return new(nome, depositoInicial, 300, tipoConta);
            }
            else
            {
                Console.WriteLine("Opção digitada é invalida, selecione a opção novamente:\n");
                Console.ReadLine();
                Console.Clear();
                return null;
            }
        }

        static void ListarContas(List<ContaBancaria> contas)
        {
            for (var i = 0; i < contas.Count; i++)
            {
                Console.WriteLine($"Conta {i}:\n" +
                    contas[i].ToString());
            }
        }

        private static void ImprimirMenu()
        {
            Console.WriteLine(
                "Bem vindo ao Banco do BootCamo DIO, selecione uma opção abaixo:\n\n" +
                "1 - Listar Contas\n" +
                "2 - Inserir uma nova conta\n" +
                "3 - Transferir\n" +
                "4 - Sacar\n" +
                "5 - Depositar\n" +
                "99- Sair"
                );
        }

        private static int VerificarEntrada(string entrada)
        {
            try
            {
                return int.Parse(entrada);
            }
            catch
            {
                return 999;
            }
        }
    }
}
