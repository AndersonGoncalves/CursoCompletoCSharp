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
        public Peca VulneravelEnPassant { get; private set; }

        public PartidaDeXadrez()    
        {
            Turno = 1;
            Tabuleiro = new Tabuleiro(8, 8);
            JogadorAtual = Cor.Branco;
            Terminada = false;
            VulneravelEnPassant = null;
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
            ColocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branco, this));
            ColocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('a', 2, new Peao(Tabuleiro, Cor.Branco, this));
            ColocarNovaPeca('b', 2, new Peao(Tabuleiro, Cor.Branco, this));
            ColocarNovaPeca('c', 2, new Peao(Tabuleiro, Cor.Branco, this));
            ColocarNovaPeca('d', 2, new Peao(Tabuleiro, Cor.Branco, this));
            ColocarNovaPeca('e', 2, new Peao(Tabuleiro, Cor.Branco, this));
            ColocarNovaPeca('f', 2, new Peao(Tabuleiro, Cor.Branco, this));
            ColocarNovaPeca('g', 2, new Peao(Tabuleiro, Cor.Branco, this));
            ColocarNovaPeca('h', 2, new Peao(Tabuleiro, Cor.Branco, this));
            ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 8, new Dama(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('a', 7, new Peao(Tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('b', 7, new Peao(Tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('c', 7, new Peao(Tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('d', 7, new Peao(Tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('e', 7, new Peao(Tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('f', 7, new Peao(Tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('g', 7, new Peao(Tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('h', 7, new Peao(Tabuleiro, Cor.Preto, this));
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
            foreach (Peca peca in PecasEmJogoDaCor(cor))
            {
                if (peca is Rei)
                    return peca;
            }
            return null;
        }
        private bool ReiEstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);
            if (rei == null)
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");

            foreach (Peca peca in PecasEmJogoDaCor(GetAdversario(cor)))
            {
                bool[,] matriz = peca.MovimentosPossiveis();
                if (matriz[rei.Posicao.Linha, rei.Posicao.Coluna])
                    return true;
            }
            return false;
        }
        private bool TesteXequeMate(Cor cor)
        {
            if (!ReiEstaEmXeque(cor))
                return false;

            foreach (Peca peca in PecasEmJogoDaCor(cor))
            {
                bool[,] matriz = peca.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (matriz[i, j])
                        {
                            Posicao origem = peca.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testaXeque = ReiEstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testaXeque)
                                return false;
                        }
                    }
                }
            }
            return true;
        }
        private void ExecutaRoquePequeno(Posicao origem)
        {
            Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
            Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
            Peca torre = Tabuleiro.RetirarPeca(origemTorre);
            torre.IncrementarQtdeMovimentos();
            Tabuleiro.ColocarPeca(torre, destinoTorre);
        }
        private void ExecutaRoqueGrande(Posicao origem)
        {
            Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
            Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
            Peca torre = Tabuleiro.RetirarPeca(origemTorre);
            torre.IncrementarQtdeMovimentos();
            Tabuleiro.ColocarPeca(torre, destinoTorre);
        }
        private void ExecutaEnPassant(Peca peca, Peca pecaCapturada, Posicao origem, Posicao destino)
        {
            if (origem.Coluna != destino.Coluna && pecaCapturada == null)
            {
                Posicao posPeca;
                if (peca.Cor == Cor.Branco)
                    posPeca = new Posicao(destino.Linha + 1, destino.Coluna);
                else
                    posPeca = new Posicao(destino.Linha - 1, destino.Coluna);
                pecaCapturada = Tabuleiro.RetirarPeca(posPeca);
                PecasCapturadas.Add(pecaCapturada);
            }
        }
        private Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQtdeMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
            if (pecaCapturada != null)
                PecasCapturadas.Add(pecaCapturada);

            if (peca is Rei && destino.Coluna == origem.Coluna + 2)
                ExecutaRoquePequeno(origem);

            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
                ExecutaRoqueGrande(origem);

            if (peca is Peao)
                ExecutaEnPassant(peca, pecaCapturada, origem, destino);

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
        private void DesfazRoquePequeno(Posicao origem)
        {
            Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
            Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
            Peca torre = Tabuleiro.RetirarPeca(destinoTorre);
            torre.DecrementarQtdeMovimentos();
            Tabuleiro.ColocarPeca(torre, origemTorre);
        }
        private void DesfazRoqueGrande(Posicao origem)
        {
            Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
            Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
            Peca torre = Tabuleiro.RetirarPeca(destinoTorre);
            torre.DecrementarQtdeMovimentos();
            Tabuleiro.ColocarPeca(torre, origemTorre);
        }
        private void DesfazEnPassant(Peca peca, Peca pecaCapturada, Posicao origem, Posicao destino)
        {
            if (origem.Coluna != destino.Coluna && pecaCapturada == VulneravelEnPassant)
            {
                Peca peao = Tabuleiro.RetirarPeca(destino);
                Posicao PosPeca;
                if (peca.Cor == Cor.Branco)
                    PosPeca = new Posicao(3, destino.Coluna);
                else
                    PosPeca = new Posicao(4, destino.Coluna);
                Tabuleiro.ColocarPeca(peao, PosPeca);
            }
        }
        private  void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca pecaDestino = Tabuleiro.RetirarPeca(destino);
            pecaDestino.DecrementarQtdeMovimentos();
            if (pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                PecasCapturadas.Remove(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(pecaDestino, origem);

            if (pecaDestino is Rei && destino.Coluna == origem.Coluna + 2)
                DesfazRoquePequeno(origem);

            if (pecaDestino is Rei && destino.Coluna == origem.Coluna - 2)
                DesfazRoqueGrande(origem);

            if (pecaDestino is Peao)
                DesfazEnPassant(pecaDestino, pecaCapturada, origem, destino);
        }
        private void PromocaoDoPeao(Peca peca, Posicao destino)
        {
            if ((peca.Cor == Cor.Branco && destino.Linha == 0) || (peca.Cor == Cor.Preto && destino.Linha == 7))
            {
                peca = Tabuleiro.RetirarPeca(destino);
                PecasEmJogo.Remove(peca);
                Peca Dama = new Dama(Tabuleiro, peca.Cor);
                Tabuleiro.ColocarPeca(Dama, destino);
                PecasEmJogo.Add(Dama);
            }
        }
        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (ReiEstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            Peca peca = Tabuleiro.GetPeca(destino);

            if (peca is Peao)
                PromocaoDoPeao(peca, destino);

            Xeque = ReiEstaEmXeque(GetAdversario(JogadorAtual));

            if (TesteXequeMate(GetAdversario(JogadorAtual)))
                Terminada = true;
            else
            {
                PassaTurno();
                MudaJogador();
            }
            
            if (peca is Peao && (destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2))
                VulneravelEnPassant = peca;
            else
                VulneravelEnPassant = null;
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
            foreach (Peca peca in PecasCapturadas)
            {
                if (peca.Cor == cor)
                    aux.Add(peca);
            }
            return aux;
        }
        public HashSet<Peca> PecasEmJogoDaCor(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in PecasEmJogo)
            {
                if (peca.Cor == cor)
                    aux.Add(peca);
            }
            aux.ExceptWith(PecasCapturadasDaCor(cor));
            return aux;
        }        
    }
}