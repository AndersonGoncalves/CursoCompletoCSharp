using Board;
using Board.Enums;

namespace Chess
{
    public class Dama : Peca
    {
        public Dama(Tabuleiro tabuleiro, Cor Cor) : base(tabuleiro, Cor)
        {
        }

        public override string ToString()
        {
            return "D";
        }
    }
}