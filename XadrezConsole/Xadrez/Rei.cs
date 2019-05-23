using Board;
using Board.Enums;

namespace Chess
{
    public class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor Cor) : base(tabuleiro, Cor)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            //TODO:
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "R";
        }
    }
}