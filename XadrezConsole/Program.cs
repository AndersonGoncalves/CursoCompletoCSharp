using System;
using Board;
using Chess;
using Board.Enums;
using Board.Exception;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro Tabuleiro = new Tabuleiro();

                Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preto), new Posicao(0, 0));
                Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preto), new Posicao(1, 3));
                Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branco), new Posicao(2, 4));
                Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preto), new Posicao(5, 2));

                Tela.ImprimirTabuleito(Tabuleiro);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}