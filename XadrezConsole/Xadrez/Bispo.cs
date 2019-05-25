using Board;
using Board.Enums;

namespace Chess
{
    public class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor Cor) : base(tabuleiro, Cor)
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
            return "B";
        }
    }
}