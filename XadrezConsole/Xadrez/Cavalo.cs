using Board;
using Board.Enums;

namespace Chess
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) :base(tabuleiro, cor)
        {
        }
        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicaoAux = new Posicao();

            #region Movimentos 
            posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
            #endregion

            return matriz;
        }
        public override string ToString()
        {
            return "C";
        }
    }
}