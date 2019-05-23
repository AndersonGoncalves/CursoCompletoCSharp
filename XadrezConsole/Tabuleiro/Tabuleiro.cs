using Board.Exception;

namespace Board
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas { get; private set; }

        public Tabuleiro()
        {
            Linhas = 8;
            Colunas = 8;
            Pecas = new Peca[Linhas, Colunas];
        }
        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
                throw new TabuleiroException("Posição inválida!");
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return Pecas[posicao.Linha, posicao.Coluna] != null;
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
            if (Pecas[posicao.Linha, posicao.Coluna] == null)
                return null;

            Peca pecaAuxiliar = Pecas[posicao.Linha, posicao.Coluna];
            pecaAuxiliar.Posicao = null;
            Pecas[posicao.Linha, posicao.Coluna] = null;
            return pecaAuxiliar;
        }
    }
}
