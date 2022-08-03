using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BibliotecaAgil
{
    public class Utils
    {
        static public List<Livro> LerArquivoDb()
        {
            return JsonConvert.DeserializeObject<List<Livro>>(System.IO.File.ReadAllText(@"C:\BibliotecaAgil\BibliotecaAgil\db.txt"));
        }

        static public void GravarArquivoDb(List<Livro> livros)
        {
            string content = JsonConvert.SerializeObject(livros);
            System.IO.File.WriteAllText(@"C:\BibliotecaAgil\BibliotecaAgil\db.txt", content);
        }

        static public string MensagemRetorno(string mensagem)
        {
            return "\n" +
                    "\n" +
                    "*********************************************************************************************************\n" +
                    "\n" +
                    "-> " + mensagem + "\n" +
                    "\n" +
                    "*********************************************************************************************************\n" +
                    "\n" +
                    "\n";
        }

        static public string MensagemRetorno(Livro livro, Status status)
        {
            if (status.Equals(Status.Indisponivel))
                return "\n" +
                        "\n" +
                        "*********************************************************************************************************\n" +
                        "Retirado com sucesso!\n" +
                        "Código do Livro: " + livro.Numero + "\n" +
                        "Livro: " + livro.Titulo + "\n" +
                        "Autor: " + livro.Autor + "\n" +
                        "Retirado por: " + livro.EmprestadoPara + "\n" +
                        "*********************************************************************************************************\n" +
                        "\n" +
                        "\n";
            else
                return "\n" +
                        "\n" +
                        "*********************************************************************************************************\n" +
                        livro.EmprestadoPara.ToUpper() + ", muito obrigado pela devolução!\n" +
                        "Código do Livro Devolvido: " + livro.Numero + "\n" +
                        "Livro Devolvido: " + livro.Titulo +
                        "*********************************************************************************************************\n" +
                        "\n" +
                        "\n";
        }

        static public int MenuPrincipal()
        {
            int op = 0;

            while (true)
            {
                Console.WriteLine("\n*** Biblioteca Ágil ***\n" +
                                  "Escolha uma das opções abaixo: \n" +
                                  "1. Retirar um livro \n" +
                                  "2. Devolver um livro \n" +
                                  "3. Doar um livro \n" +
                                  "4. Mostrar Livros \n" +
                                  "5. Sair do programa \n\n\n");

                op = Teclado.LeInt("Código: ");

                if (op >= 1 && op <= 5)
                {
                    return op;
                }
                else
                {
                    Console.WriteLine("Essa opção não existe!");
                }
            }
        }

        static public void Executar(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    Livro.MostrarLivros();
                    Console.WriteLine("\n\nDigite o número do livro que queres retirar: ");
                    var numeroRetirado = Teclado.LeInt();
                    Console.WriteLine("\n\nDigite seu nome: ");
                    var nomePessoaParaRetirar = Teclado.LeString();
                    Console.WriteLine(Livro.RetirarLivro(numeroRetirado, nomePessoaParaRetirar));
                    break;
                case 2:
                    Livro.MostrarLivros();
                    Console.WriteLine("\n\nDigite o número do livro que queres devolver: ");
                    var numeroDevolvido = Teclado.LeInt();
                    Console.WriteLine("\n\nDigite seu nome: ");
                    var nomePessoaParaDevolver = Teclado.LeString();
                    Console.WriteLine(Livro.DevolverLivro(numeroDevolvido, nomePessoaParaDevolver));
                    break;
                case 3:
                    Livro livro = new Livro();
                    Console.WriteLine("\n\nDigite o titulo do livro que queres doar: ");
                    livro.Titulo = Teclado.LeString();
                    Console.WriteLine("\n\nDigite o autor do livro que queres doar: ");
                    livro.Autor = Teclado.LeString();
                    Console.WriteLine("\n\nDigite o ano do livro que queres doar: ");
                    livro.Ano = Teclado.LeInt();
                    Console.WriteLine(Livro.DoarLivro(livro));
                    break;
                case 4:
                    Livro.MostrarLivros();
                    break;
                case 5:
                    Environment.Exit(1);
                    break;
                default:
                    break;
            }
        }
    }
}
