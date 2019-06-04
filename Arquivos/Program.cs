using System;
using System.IO;

namespace Arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Copiando um arquivo
            try
            {
                string arquivoOrigem = @"D:\fileOrigem.txt";
                string arquivoDestino = @"D:\fileDestino.txt";

                FileInfo fileInfo = new FileInfo(arquivoOrigem);
                fileInfo.CopyTo(arquivoDestino);
                //ou somente => File.Copy(arquivoOrigem, arquivoDestino);
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            #endregion


            #region Percorrer um arquivo
            try
            {
                string arquivo = @"D:\file.txt";
                using (StreamReader streamReader = File.OpenText(arquivo))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string linha = streamReader.ReadLine();
                        Console.WriteLine(linha);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            #endregion

        }
    }
}