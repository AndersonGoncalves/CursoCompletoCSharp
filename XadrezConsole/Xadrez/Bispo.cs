using Board;
using Board.Enums;

namespace Chess
{
    public class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor Cor) : base(tabuleiro, Cor)
        {
        }

        public override string ToString()
        {
            return "B";
        }
    }
}