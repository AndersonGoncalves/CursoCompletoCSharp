using Board;
using Board.Enums;

namespace Chess
{
    public class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor Cor) : base(tabuleiro, Cor)
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

            #region Todos Movimentos
            posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;                
                posicaoAux.DefinirValores(posicaoAux.Linha - 1, posicaoAux.Coluna - 1);
            }

            posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;
                posicaoAux.DefinirValores(posicaoAux.Linha - 1, posicaoAux.Coluna + 1);
            }

            posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;
                posicaoAux.DefinirValores(posicaoAux.Linha + 1, posicaoAux.Coluna + 1);
            }

            posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;
                posicaoAux.DefinirValores(posicaoAux.Linha + 1, posicaoAux.Coluna - 1);
            }
            #endregion

            return matriz;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}