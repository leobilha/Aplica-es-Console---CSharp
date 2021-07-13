using System;

namespace Dio.Bank
{
    public class Conta
    {
        // Atributos
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        // Construtor
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        //Métodos
        public bool Sacar(double valorSaque) 
        {
            if (this.Saldo - valorSaque <(this.Credito *-1)) 
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo = this.Saldo - valorSaque;

            // Entre {} indica cada valor
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo = this.Saldo + valorDeposito;

            Console.WriteLine("Saldo atual da conta com o deposito de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferencia(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        // override sobreescreve ToString, é usado para registrar em um log em um txt
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta: " + this.TipoConta + " - ";
            retorno += "Nome: " + this.Nome + " - ";
            retorno += "Saldo: " + this.Saldo + " - ";
            retorno += "Credito: " + this.Credito;
            return retorno;
        }

    }
}