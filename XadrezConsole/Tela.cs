using System;
using Board;
using Board.Enums;
using Chess;

namespace XadrezConsole
{
    public class Tela
    {
        public static void ImprimirTabuleito(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (tabuleiro.Pecas[i, j] == null)
                        Console.Write("- ");
                    else
                    {
                        ImprimirPeca(tabuleiro.Pecas[i, j]);
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();                
            }
            Console.WriteLine("  a b c d e f g h");
        }

        private static void ImprimirPeca(Peca peca)
        {
            if (peca.Cor == Cor.Branco)
                Console.Write(peca);
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string pos = Console.ReadLine();
            char coluna = pos[0];
            int linha = int.Parse(pos[1].ToString());
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
