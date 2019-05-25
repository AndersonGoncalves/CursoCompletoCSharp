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

        protected bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public void IncrementarQtdeMovimentos()
        {
            QtdeMovimentos++;
        }        

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] matriz = MovimentosPossiveis();
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (matriz[i, j])
                        return true;
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao posicao)
        {
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }            

        public abstract bool[,] MovimentosPossiveis();
    }
}
