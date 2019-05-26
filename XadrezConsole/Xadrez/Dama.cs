﻿using Board;
using Board.Enums;

namespace Chess
{
    public class Dama : Peca
    {
        public Dama(Tabuleiro tabuleiro, Cor Cor) : base(tabuleiro, Cor)
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

            #region Movimentos iguais da torre
            posicaoAux.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;
                posicaoAux.Coluna -= 1;
            }
            
            posicaoAux.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;
                posicaoAux.Coluna += 1;
            }

            posicaoAux.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;
                posicaoAux.Linha -= 1;
            }
            
            posicaoAux.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                matriz[posicaoAux.Linha, posicaoAux.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoAux) != null && Tabuleiro.GetPeca(posicaoAux).Cor != Cor)
                    break;
                posicaoAux.Linha += 1;
            }
            #endregion

            #region  Movimentos iguais do bispo
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
            return "D";
        }
    }
}