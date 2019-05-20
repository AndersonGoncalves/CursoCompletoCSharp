using Board.Enums;

namespace Board
{
    public class Peca
    {
        public Tabuleiro Tabuleiro { get; protected set; }
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QtdeMovimentos { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Tabuleiro = tabuleiro;
            Posicao = null;
            Cor = cor;
            QtdeMovimentos = 0;
        }
    }
}
