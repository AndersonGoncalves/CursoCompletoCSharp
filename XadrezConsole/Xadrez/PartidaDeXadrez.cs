using Board;
using Board.Enums;

namespace Chess
{
    public class PartidaDeXadrez
    {
        private int _turno;
        public Tabuleiro Tabuleiro { get; private set; }
        public Cor JogadorAtual { get; set; }
        public bool Terminada { get; set; }
        
        public PartidaDeXadrez()
        {
            _turno = 1;
            Tabuleiro = new Tabuleiro();
            JogadorAtual = Cor.Branco;
            Terminada = false;
            ColocarPecasNoTabuleiro();
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQtdeMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
        }

        private void ColocarPecasNoTabuleiro()
        {
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('a', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Tabuleiro, Cor.Branco), new PosicaoXadrez('b', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Dama(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Tabuleiro, Cor.Branco), new PosicaoXadrez('f', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Tabuleiro, Cor.Branco), new PosicaoXadrez('g', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('h', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Branco), new PosicaoXadrez('a', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Branco), new PosicaoXadrez('b', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Branco), new PosicaoXadrez('f', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Branco), new PosicaoXadrez('g', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Branco), new PosicaoXadrez('h', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('a', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Tabuleiro, Cor.Preto), new PosicaoXadrez('b', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Tabuleiro, Cor.Preto), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Dama(Tabuleiro, Cor.Preto), new PosicaoXadrez('d', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preto), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Tabuleiro, Cor.Preto), new PosicaoXadrez('f', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Tabuleiro, Cor.Preto), new PosicaoXadrez('g', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('h', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Preto), new PosicaoXadrez('a', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Preto), new PosicaoXadrez('b', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Preto), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Preto), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Preto), new PosicaoXadrez('e', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Preto), new PosicaoXadrez('f', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Preto), new PosicaoXadrez('g', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Tabuleiro, Cor.Preto), new PosicaoXadrez('h', 7).ToPosicao());

        }
    }
}