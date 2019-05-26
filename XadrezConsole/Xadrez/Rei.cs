using Board;
using Board.Enums;

namespace Chess
{
    public class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor Cor) : base(tabuleiro, Cor)
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

            #region Movimentos uma linha acima
            posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
            #endregion

            #region Movimentos na mesma linha
            posicaoAux.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
            #endregion

            #region Movimentos uma linha abaixo
            posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

            posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
            #endregion

            return matriz;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}