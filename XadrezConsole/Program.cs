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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(PartidaDeXadrez);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        PartidaDeXadrez.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = PartidaDeXadrez.Tabuleiro.GetPeca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleito(PartidaDeXadrez.Tabuleiro, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        PartidaDeXadrez.ValidarPosicaoDeDestino(origem, destino);

                        PartidaDeXadrez.RealizarJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}