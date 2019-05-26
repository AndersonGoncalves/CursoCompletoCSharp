using Board;
using Board.Enums;

namespace Chess
{
    public class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
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

            #region Movimentos para esquerda
            posicaoAux.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;
                posicaoAux.Coluna -= 1;
            }
            #endregion

            #region Movimentos para direita
            posicaoAux.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;
                posicaoAux.Coluna += 1;
            }
            #endregion

            #region Movimentos para cima
            posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;
                posicaoAux.Linha -= 1;
            }
            #endregion

            #region Movimentos para baixo
            posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;
                posicaoAux.Linha += 1;
            }
            #endregion

            return matriz;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}