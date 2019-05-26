using Board.Exception;

namespace Board
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas { get; private set; }
        
        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca GetPeca(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public bool PosicaoValida(Posicao posicao)
        {
            return (posicao.Linha >= 0 && posicao.Linha < Linhas && posicao.Coluna >= 0 && posicao.Coluna < Colunas);
        }

        private bool ExistePeca(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
                throw new TabuleiroException("Posição inválida!");

            return GetPeca(posicao) != null;
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao))
                throw new TabuleiroException("Já existe peça nessa posição!");

            Pecas[posicao.Linha, posicao.Coluna] = peca;
            Pecas[posicao.Linha, posicao.Coluna].Posicao = posicao;
        }

        public Peca RetirarPeca(Posicao posicao)
        {
            if (GetPeca(posicao) == null)
                return null;
            else
            {
                Peca pecaAuxiliar = GetPeca(posicao);
                pecaAuxiliar.Posicao = null;
                Pecas[posicao.Linha, posicao.Coluna] = null;
                return pecaAuxiliar;
            }
        }
    }
}