using System;
using System.Collections.Generic;

namespace Accelerator
{
    public class Executar
    {

        static private List<Cliente> clientes = new List<Cliente>();
        private const float valorUnitarioEnergeticos = 4.50f;
        static private float totalImpostos = 0f;
        static private float totalMercadorias = 0f;
        static private float totalGeral = 0f;

        static public int MenuPrincipal()
        {
            int op = 0;

            while (true)
            {
                Console.WriteLine("\n*** Energéticos Accelerator ***\n" +
                                  "Escolha uma das opções abaixo: \n" +
                                  "1. Incluir cliente \n" +
                                  "2. Finalizar e gerar relatório \n" +
                                  "3. Sair \n");

                op = Teclado.LeInt("Código: ");

                if (op >= 1 && op <= 3)
                {
                    return op;
                }
                else
                {
                    Console.WriteLine("Essa opção não existe!");
                }
            }
        }

        static public void ExecutarProgram(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("\n\nDigite o nome do supermercado: ");
                    string nomeCliente = Teclado.LeString();
                    Console.WriteLine("\n\nDigite a quantidade de energéticos adquiridos pelo cliente " + nomeCliente.ToUpper() + ": ");
                    int quantidade = Teclado.LeInt();
                    clientes.Add(new Cliente { Nome = nomeCliente, Quantidade = quantidade });
                    break;
                case 2:
                    if (clientes.Count != 0)
                    {
                        for (int i = 0; i < clientes.Count; i++)
                        {
                            float valorMercadoria = clientes[i].Quantidade * valorUnitarioEnergeticos;
                            float Icms = 0.18f * valorMercadoria;
                            float Ipi = 0.04f * valorMercadoria;
                            float Pis = 0.0186f * valorMercadoria;
                            float Cofins = 0.0854f * valorMercadoria;
                            float valorTotal = Icms + Ipi + Pis + Cofins + valorMercadoria;
                            totalImpostos += Icms + Ipi + Pis + Cofins;
                            totalMercadorias += valorMercadoria;
                            totalGeral = totalImpostos + totalMercadorias;

                            Console.WriteLine("\nCliente: " + clientes[i].Nome);
                            Console.WriteLine("\nICMS: R$" + Icms + ";" + "\n" +
                                              "IPI: R$" + Ipi + ";" + "\n" +
                                              "PIS: R$" + Pis + ";" + "\n" +
                                              "COFINS: R$" + Cofins + ";" + "\n" +
                                              "Total: R$" + valorTotal + ";");
                        }

                        Console.WriteLine("\n\nTotal Impostos: R$" + totalImpostos + "\n" +
                                          "Total Mercadorias: R$" + totalMercadorias + "\n" +
                                          "Total Geral: R$" + totalGeral);
                    }
                    else                    
                        Console.WriteLine("\nNão existe cliente para gerar relatório.");          
                    break;
                case 3:
                    Environment.Exit(1);
                    break;
                default:
                    break;
            }
        }
    }
}
