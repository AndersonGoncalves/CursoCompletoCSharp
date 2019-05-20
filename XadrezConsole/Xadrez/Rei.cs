using Board;
using Board.Enums;

namespace Chess
{
    public class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor Cor) : base(tabuleiro, Cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}