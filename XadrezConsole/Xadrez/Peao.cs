using Board;
using Board.Enums;

namespace Chess
{
    public class Peao : Peca
    {
        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
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
            }            

            return matriz;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}