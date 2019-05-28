using Board;
using Board.Enums;

namespace Chess
{
    public class Rei : Peca
    {
        private PartidaDeXadrez _partidaDeXadrez;

        public Rei(Tabuleiro tabuleiro, Cor Cor, PartidaDeXadrez partidaDeXadrez) : base(tabuleiro, Cor)
        {
            _partidaDeXadrez = partidaDeXadrez;
        }
        private bool TesteTorreParaRoque(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca != null && peca is Torre && peca.Cor == Cor && peca.QtdeMovimentos == 0;
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

            #region Roque
            if (QtdeMovimentos == 0 && !_partidaDeXadrez.Xeque)
            {
                //roque pequeno
                Posicao posicaoTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posicaoTorre1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tabuleiro.GetPeca(p1) == null && Tabuleiro.GetPeca(p2) == null)
                        matriz[Posicao.Linha, Posicao.Coluna + 2] = true;
                }

                //roque grande
                Posicao posicaoTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(posicaoTorre2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiro.GetPeca(p1) == null && Tabuleiro.GetPeca(p2) == null && Tabuleiro.GetPeca(p3) == null)
                        matriz[Posicao.Linha, Posicao.Coluna - 2] = true;
                }
            }
            #endregion

            return matriz;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}