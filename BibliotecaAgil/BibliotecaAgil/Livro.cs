using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BibliotecaAgil
{
    public class Livro
    {
        private static int idIncrement;

        public int Numero { get; set; } = Interlocked.Increment(ref idIncrement);
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public Status Status { get; set; }
        public string EmprestadoPara { get; set; }

        static public void MostrarLivros()
        {
            List<Livro> livros = Utils.LerArquivoDb();

            for (int i = 0; i < livros.Count; i++)
            {
                Console.WriteLine("\nNúmero: " + livros[i].Numero);
                Console.WriteLine("Título: " + livros[i].Titulo);
                Console.WriteLine("Autor: " + livros[i].Autor);
                Console.WriteLine("Ano: " + livros[i].Ano);
                Console.WriteLine("Status: " + livros[i].Status);
                Console.WriteLine("Emprestado para: " + livros[i].EmprestadoPara);
                Console.WriteLine("\n******************************");
            }
        }

        static public string RetirarLivro(int numeroLivroParaRetirar, string nomePessoa)
        {
            try
            {
                List<Livro> livros = Utils.LerArquivoDb();

                if (livros.Exists(l => l.Numero.Equals(numeroLivroParaRetirar)))
                {
                    Livro livroSelecionado = livros.First(l => l.Numero.Equals(numeroLivroParaRetirar));

                    if (livroSelecionado.Status.Equals(Status.Disponivel))
                    {
                        livroSelecionado.Status = Status.Indisponivel;
                        livroSelecionado.EmprestadoPara = nomePessoa;

                        Utils.GravarArquivoDb(livros);

                        return Utils.MensagemRetorno(livroSelecionado, Status.Indisponivel);
                    }
                    else
                    {
                        return Utils.MensagemRetorno("Não foi possível retirar o livro número " + numeroLivroParaRetirar + ". O mesmo não está disponível para retirada.");
                    }
                }
                else
                {
                    return Utils.MensagemRetorno("Não foi possível retirar o livro número " + numeroLivroParaRetirar + ". Não foi encontrado no banco de dados.");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public string DevolverLivro(int numeroLivroParaDevolver, string nomePessoa)
        {
            try
            {
                List<Livro> livros = Utils.LerArquivoDb();

                if (livros.Exists(l => l.Numero.Equals(numeroLivroParaDevolver)))
                {
                    Livro livroSelecionado = livros.First(l => l.Numero.Equals(numeroLivroParaDevolver));

                    if (livroSelecionado.Status.Equals(Status.Indisponivel))
                    {
                        livroSelecionado.Status = Status.Disponivel;
                        livroSelecionado.EmprestadoPara = null;

                        Utils.GravarArquivoDb(livros);

                        livroSelecionado.EmprestadoPara = nomePessoa;

                        return Utils.MensagemRetorno(livroSelecionado, Status.Disponivel);
                    }
                    else
                    {
                        return Utils.MensagemRetorno("Não foi possível devolver o livro número " + numeroLivroParaDevolver + ". O mesmo está disponível para retirada.");
                    }
                }
                else
                {
                    return Utils.MensagemRetorno("Não foi possível devolver o livro número " + numeroLivroParaDevolver + ". Não existe no banco de dados.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static public string DoarLivro(Livro livroNovo)
        {
            List<Livro> livros = Utils.LerArquivoDb();

            int indiceAtualLivros = livros.Count;

            indiceAtualLivros++;

            livroNovo.Numero = indiceAtualLivros;
            livroNovo.Status = Status.Disponivel;
            livroNovo.EmprestadoPara = null;

            livros.Add(livroNovo);

            Utils.GravarArquivoDb(livros);

            return "\n" +
                    "\n" +
                    "Muito Obrigado por doar!\n" +
                    "Livro Doado: " + livroNovo.Titulo +
                    "\n" +
                    "\n";
        }
    }
}
