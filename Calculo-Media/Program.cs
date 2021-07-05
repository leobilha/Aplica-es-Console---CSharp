/* 
    Programa feito para fins didáticos no Bootcamp da DIO
    Autor: Leonardo Bilha Terragno
*/

using System;

namespace appConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array de alunos
            Aluno[] alunos = new Aluno[5];
            int i = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            // Faz a repetição do menu enquanto o mesmo não digita X.
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //TODO: adicionar aluno
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        // var é uma funcionalidade de inferencia de tipo
                        // Parse, transforma o que vem do usuario para decimal
                        // var nota = decimal.Parse(Console.ReadLine());
                        // TryParse retorna um valor bool, ele consegue ou nao transformar para decimal
                        Console.WriteLine("Informe a nota do aluno: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal!");
                        }
                        

                        alunos[i] = aluno;
                        i++;
                        Console.WriteLine();
                        Console.WriteLine("O nome " + aluno.Nome + " foi adicionado com a nota: " + aluno.Nota);

                        break;
                    case "2":
                        //TODO: listar aluno
                        // percorre cada a (Alunos) dentro de alunos
                        foreach(var a in alunos)
                        {   
                            // se o nome não for vazio, imprime o nome e a nota
                            //if (!a.Nome.Equals("")) 
                            // se o nome não for null ou vazio, escreve a linha 62
                            if (!string.IsNullOrEmpty(a.Nome)) 
                            {
                                // $ = faz com que não precise concatenar strings
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                            
                        }
                        break;

                    case "3":
                        //TODO: calcular media geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for (int indice = 0; indice < alunos.Length; indice++) 
                        {
                            if (!string.IsNullOrEmpty(alunos[indice].Nome)) 
                            {
                                notaTotal = notaTotal + alunos[indice].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;
                        if (mediaGeral < 2) {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4) {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6) {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8) {
                            conceitoGeral = Conceito.B;
                        }
                        else 
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");
                        break;
                    default:
                        // dispara excessão, caso o valor não esteja informado no range (1 a 3)
                        throw new ArgumentOutOfRangeException();

                }

                // Le o valor digitado pelo usuario
                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir nome e nota do aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            // Le o valor digitado pelo usuario
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
