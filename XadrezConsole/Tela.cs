using System;
using Board;
using Board.Enums;
using Chess;
using System.Collections.Generic;

namespace XadrezConsole
{
    public class Tela
    {
        private static void ImprimirConjunto(HashSet<Peca> pecas)
        {
            Console.Write("[");
            foreach (Peca item in pecas)
                Console.Write(item + " ");
            Console.Write("]");
            Console.WriteLine();            
        }
        private static void ImprimirPecasCapturadas(PartidaDeXadrez partidaXadrez)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partidaXadrez.PecasCapturadasNaCor(Cor.Branco));
            Console.Write("Pretas: ");

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            ImprimirConjunto(partidaXadrez.PecasCapturadasNaCor(Cor.Preto));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void ImprimirPartida(PartidaDeXadrez partidaXadrez)
        {
            ImprimirTabuleito(partidaXadrez.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partidaXadrez);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partidaXadrez.Turno);
            if (!partidaXadrez.Terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partidaXadrez.JogadorAtual);
                if (partidaXadrez.Xeque)
                    Console.WriteLine("XEQUE!");
            }
            else
            {
                Console.WriteLine("XEQUE-MATE");
                Console.WriteLine("Vencedor: " + partidaXadrez.JogadorAtual);
            }
        }
        public static void ImprimirTabuleito(Tabuleiro tabuleiro)
        {
            ConsoleColor aux = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   a b c d e f g h");            
            Console.ForegroundColor = aux;

            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(8 - i + "  ");
                Console.ForegroundColor = aux;

                for (int j = 0; j < tabuleiro.Colunas; j++)
                    ImprimirPeca(tabuleiro.Pecas[i, j]);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
                Console.Write(8 - i);
                Console.ForegroundColor = aux;

                Console.WriteLine();                
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   a b c d e f g h");
            Console.ForegroundColor = aux;
        }

        public static void ImprimirTabuleito(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            ConsoleColor aux = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   a b c d e f g h");
            Console.ForegroundColor = aux;

            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(8 - i + "  ");
                Console.ForegroundColor = aux;
                
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOriginal;

                    ImprimirPeca(tabuleiro.Pecas[i, j]);
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
                Console.Write(8 - i);
                Console.ForegroundColor = aux;

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
            Console.ForegroundColor = aux;
        }

        private static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
                Console.Write("- ");
            else
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
                Console.Write(" ");
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