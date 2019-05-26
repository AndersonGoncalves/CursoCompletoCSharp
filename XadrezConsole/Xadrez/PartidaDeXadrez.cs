using Board;
using Board.Enums;
using Board.Exception;
using System.Collections.Generic;

namespace Chess
{
    public class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public int Turno { get; private set; }        
        public HashSet<Peca> PecasEmJogo { get; private set; } = new HashSet<Peca>();
        public HashSet<Peca> PecasCapturadas { get; private set; } = new HashSet<Peca>();
        public bool Xeque { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Turno = 1;
            Tabuleiro = new Tabuleiro(8, 8);
            JogadorAtual = Cor.Branco;
            Terminada = false;            
            ColocarPecasNoTabuleiro();
        }
        private void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            PecasEmJogo.Add(peca);
        }
        private void ColocarPecasNoTabuleiro()
        {
            ColocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 1, new Dama(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('a', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('b', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('c', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('f', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('g', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('h', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 8, new Dama(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('a', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('b', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('c', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('f', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('g', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('h', 7, new Peao(Tabuleiro, Cor.Preto));
        }
        private Cor GetAdversario(Cor cor)
        {
            if (cor == Cor.Branco)
                return Cor.Preto;
            else
                return Cor.Branco;
        }
        private Peca Rei(Cor cor)
        {
            foreach (Peca item in PecasEmJogoDaCor(cor))
            {
                if (item is Rei)
                    return item;
            }
            return null;
        }
        public bool ReiEstaEmCheque(Cor cor)
        {
            Peca rei = Rei(cor);
            if (rei == null)
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");

            foreach (Peca item in PecasEmJogoDaCor(GetAdversario(cor)))
            {
                bool[,] matriz = item.MovimentosPossiveis();
                if (matriz[rei.Posicao.Linha, rei.Posicao.Coluna])
                    return true;
            }
            return false;
        }
        public bool TesteXequeMate(Cor cor)
        {
            if (!ReiEstaEmCheque(cor))
                return false;

            foreach (Peca item in PecasEmJogoDaCor(cor))
            {
                bool[,] matriz = item.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (matriz[i, j])
                        {
                            Posicao origem = item.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testaXeque = ReiEstaEmCheque(cor);
                            DesFazMovimento(origem, destino, pecaCapturada);
                            if (!testaXeque)
                                return false;
                        }
                    }
                }
            }
            return true;
        }
        private Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQtdeMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
            if (pecaCapturada != null)
                PecasCapturadas.Add(pecaCapturada);

            return pecaCapturada;
        }
        private void PassaTurno()
        {
            Turno++;
        }
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branco)
                JogadorAtual = Cor.Preto;
            else
                JogadorAtual = Cor.Branco;
        }
        private void DesFazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca pecaDestino = Tabuleiro.RetirarPeca(destino);
            pecaDestino.DecrementarQtdeMovimentos();
            if (pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                PecasCapturadas.Remove(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(pecaDestino, origem);
        }
        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (ReiEstaEmCheque(JogadorAtual))
            {
                DesFazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            Xeque = ReiEstaEmCheque(GetAdversario(JogadorAtual));

            if (TesteXequeMate(GetAdversario(JogadorAtual)))
                Terminada = true;
            else
            {
                PassaTurno();
                MudaJogador();
            }
        }
        public void ValidarPosicaoDeOrigem(Posicao posicao)
        {
            if (Tabuleiro.GetPeca(posicao) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");

            if (JogadorAtual != Tabuleiro.GetPeca(posicao).Cor)
                throw new TabuleiroException("A peça de origem escolhida não é sua!");

            if (!Tabuleiro.GetPeca(posicao).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para peça de origem escolhida!");
        }
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.GetPeca(origem).MovimentoPossivel(destino))
                throw new TabuleiroException("Posição de destino inválida!");
        }
        public HashSet<Peca> PecasCapturadasDaCor(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca item in PecasCapturadas)
            {
                if (item.Cor == cor)
                    aux.Add(item);
            }
            return aux;
        }
        public HashSet<Peca> PecasEmJogoDaCor(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca item in PecasEmJogo)
            {
                if (item.Cor == cor)
                    aux.Add(item);
            }
            aux.ExceptWith(PecasCapturadasDaCor(cor));
            return aux;
        }        
    }
}