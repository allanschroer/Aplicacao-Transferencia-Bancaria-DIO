using Aplicacao_Transferencia_Bancaria_DIO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao_Transferencia_Bancaria_DIO.Conta
{
    class ContaBancaria
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Cretido { get; set; }
        private TipoConta TipoConta { get; set; }

        public ContaBancaria(string nome, double saldo, double cretido, TipoConta tipoConta)
        {
            Nome = nome;
            Saldo = saldo;
            Cretido = cretido;
            TipoConta = tipoConta;
        }

        public bool Sacar(double valorSque)
        {
            if(valorSque > (Saldo + Cretido))
            {
                Console.WriteLine("Saldo insuficiente para efetuar o saque");
                Console.ReadLine();
                return false;
            }

            return DescontarValorSaque(valorSque);
        }

        public void Depositar(double valorEntrada)
        {
            Saldo = valorEntrada + Saldo;
        }

        public void Transferir(double valorTransferencia, ContaBancaria contaDestino)
        {
            Sacar(valorTransferencia);
            contaDestino.Depositar(valorTransferencia);
        }

        private bool DescontarValorSaque(double valorSque)
        {
            if (valorSque > Saldo)
            {
                Saldo -= valorSque;
                Cretido += Saldo;
                Saldo = 0;
                Console.WriteLine($"{Nome} - Seu saldo atual é de {Saldo}");
                return true;
            }
            else
            {
                Saldo = Saldo - valorSque;
                Console.WriteLine($"{Nome} - Seu saldo atual é de {Saldo}");
                return true;
            }
        }

        public override string ToString()
        {
            return  $"Nome = {Nome} Conta {TipoConta}\n" +
                    $"Saldo = {Saldo}\n" +
                    $"Credito = {Cretido}\n\n";
        }
    }
}
