using Board.Enums;

namespace Board
{
    public abstract class Peca
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

        public void IncrementarQtdeMovimentos()
        {
            QtdeMovimentos++;
        }

        protected bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Pecas[posicao.Linha, posicao.Coluna];
            return peca == null || peca.Cor != Cor;
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
