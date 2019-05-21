using Board;
using Board.Enums;

namespace Chess
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) :base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
