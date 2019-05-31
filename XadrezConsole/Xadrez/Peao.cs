using Board;
using Board.Enums;

namespace Chess
{
    public class Peao : Peca
    {
        private PartidaDeXadrez _partidaDeXadrez;
        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partidaDeXadrez) : base(tabuleiro, cor)
        {
            _partidaDeXadrez = partidaDeXadrez;
        }
        private bool ExisteAdversario(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca != null && peca.Cor != Cor;
        }
        private bool Livre(Posicao posicao)
        {
            return Tabuleiro.GetPeca(posicao) == null;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicaoAux = new Posicao();

            #region Movimentos
            if (Cor == Cor.Branco)
            {
                posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicaoAux) && Livre(posicaoAux))
                    matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

                posicaoAux.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicaoAux) && QtdeMovimentos == 0)
                    matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

                posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicaoAux) && ExisteAdversario(posicaoAux))
                    matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

                posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicaoAux) && ExisteAdversario(posicaoAux))
                    matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

                #region en Passant
                if (Posicao.Linha == 3)
                {
                    Posicao posicaoEsquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(posicaoEsquerda) && ExisteAdversario(posicaoEsquerda) && Tabuleiro.GetPeca(posicaoEsquerda) == _partidaDeXadrez.VulneravelEnPassant)
                        matriz[posicaoEsquerda.Linha - 1, posicaoEsquerda.Coluna] = true;

                    Posicao posicaoDireita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(posicaoDireita) && ExisteAdversario(posicaoDireita) && Tabuleiro.GetPeca(posicaoDireita) == _partidaDeXadrez.VulneravelEnPassant)
                        matriz[posicaoDireita.Linha - 1, posicaoDireita.Coluna] = true;
                }
                
                #endregion
            }
            else
            {
                posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicaoAux) && Livre(posicaoAux))
                    matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

                posicaoAux.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicaoAux) && QtdeMovimentos == 0)
                    matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

                posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicaoAux) && ExisteAdversario(posicaoAux))
                    matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

                posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicaoAux) && ExisteAdversario(posicaoAux))
                    matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;

                #region en Passant
                if (Posicao.Linha == 4)
                {
                    Posicao posicaoEsquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(posicaoEsquerda) && ExisteAdversario(posicaoEsquerda) && Tabuleiro.GetPeca(posicaoEsquerda) == _partidaDeXadrez.VulneravelEnPassant)
                        matriz[posicaoEsquerda.Linha + 1, posicaoEsquerda.Coluna] = true;

                    Posicao posicaoDireita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(posicaoDireita) && ExisteAdversario(posicaoDireita) && Tabuleiro.GetPeca(posicaoDireita) == _partidaDeXadrez.VulneravelEnPassant)
                        matriz[posicaoDireita.Linha + 1, posicaoDireita.Coluna] = true;
                }
                #endregion
            }
            #endregion

            return matriz;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}