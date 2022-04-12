using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContados
{
    public class ManipuladorDeArquivos
    {
        private static string EndereçoDoArquivo = AppDomain.CurrentDomain.BaseDirectory + "Contatos.txt";
        public static List<Contato> LerArquivo()  //Faz leitura e qndo nao houver mais linha ele retorna -1(peek), então ele pega cada linha e parte a cada ; e entao atribui as posiçoes para o contato e retorna o contado
        {
            List<Contato> contatosList = new List<Contato>();
            if (File.Exists(EndereçoDoArquivo))
            {
                using (StreamReader sr = File.OpenText(@EndereçoDoArquivo))
                {
                    while (sr.Peek() >= 0) //peek faz leitura e retorna se existe caractere a ser lido e quando acaba retorna valor -1
                    {
                        string linha = sr.ReadLine(); //cada linha sera retornada pelo read line
                        string[] linhaComSplit = linha.Split(';'); //split vai quebrar as linhas, quebrando por char nao split por isso o aspas simples '', retorna um array de strings
                        if (linhaComSplit.Count() == 3) //retorna o numero de casas do vetor
                        {
                            Contato contato = new Contato();
                            contato.Nome = linhaComSplit[0];
                            contato.Email = linhaComSplit[1];
                            contato.NmroTelefone = linhaComSplit[2];
                            contatosList.Add(contato);
                        }
                    }
                }
            }
            else
            {
                //throw new Exception("O arquivo não existe");
            }
            return contatosList;
        }

        public static void EscreverArquivos(List<Contato> contatosList)
        {

            using (StreamWriter sw = new StreamWriter(@EndereçoDoArquivo, false)) //Using chama os metodos para liberar o recurso externo, de forma automatica, e automaticamente usa o .close() entre outros metodos
            {
                foreach (Contato contato in contatosList)
                {
                    string Linha = string.Format("{0};{1};{2}", contato.Nome, contato.Email, contato.NmroTelefone);
                    sw.WriteLine(Linha); //cria a linha e adiciona as informações no arquivo de texto
                }
                sw.Flush(); //libera os buffers, descarregando eles
                            //sw.Close(); //fecha o recurso e libera o ponteiro do arquivo, usando o Using n tem necessidade de deixar implementado pois ele ja faz isso e usa mais recursos tambem
            }
        }
    }
}
