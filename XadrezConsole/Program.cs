using System;
using Chess;
using Board;
using Board.Exception;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez PartidaDeXadrez = new PartidaDeXadrez();
               
               while (!PartidaDeXadrez.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleito(PartidaDeXadrez.Tabuleiro);

                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    PartidaDeXadrez.ExecutarMovimento(origem, destino);
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}