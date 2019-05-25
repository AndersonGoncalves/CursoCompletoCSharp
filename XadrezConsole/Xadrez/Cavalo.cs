using Board;
using Board.Enums;

namespace Chess
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) :base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            //TODO:            
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            matriz[0, 0] = true;
            return matriz;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}