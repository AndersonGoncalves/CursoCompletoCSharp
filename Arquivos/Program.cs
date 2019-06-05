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

            #region Percorrendo um arquivo para leitura
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

            #region Percorrendo um arquivo para gravação (versão 1)
            try
            {
                string arquivoLeitura = @"D:\file.txt";
                string arquivoEscrita = @"D:\file2.txt";

                using (StreamReader sr = File.OpenText(arquivoLeitura))
                {
                    using (StreamWriter sw = File.AppendText(arquivoEscrita))
                    {
                        while (!sr.EndOfStream)
                        {
                            string linha = sr.ReadLine();
                            sw.WriteLine(linha.ToUpper());
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            #endregion

            #region Percorrendo um arquivo para gravação (versão 2)
            string arquivo1 = @"D:\file.txt";
            string arquivo2 = @"D:\file3.txt";
            
            string[] linhas = File.ReadAllLines(arquivo1);
            using (StreamWriter streamWriter = File.AppendText(arquivo2))
            {
                foreach (string linha in linhas)
                    streamWriter.WriteLine(linha.ToLower());
            }
            #endregion
        }
    }
}