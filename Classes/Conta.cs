using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Transferencia_Bancaria
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Validação de Saldo Suficiente
            if(this.Saldo - valorSaque < (this.Credito * -1)){
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            

            Console.WriteLine($"Saque realizado no valor de {valorSaque.ToString("C", CultureInfo.CurrentCulture)}. Saldo atual da conta {this.Nome} é {this.Saldo.ToString("C", CultureInfo.CurrentCulture)}.");

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine($"Deposito realizado no valor de {valorDeposito.ToString("C", CultureInfo.CurrentCulture)}. Saldo atual da conta de {this.Nome} é {this.Saldo.ToString("C", CultureInfo.CurrentCulture)}.");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia); 
                
            }
        }

        public override string ToString()
        {
            string retorno = " ";
            retorno += "Tipo Conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo.ToString("C", CultureInfo.CurrentCulture) + " | ";
            retorno += "Crédito: " + this.Credito.ToString("C", CultureInfo.CurrentCulture);
            return retorno;
        }

    }
}