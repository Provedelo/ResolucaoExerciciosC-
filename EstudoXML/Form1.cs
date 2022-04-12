using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EstudoXML
{
    public partial class Agenda : Form
    {
        public Agenda()
        {
            InitializeComponent();
        }

        private void Agenda_Load(object sender, EventArgs e)
        {
            CriarContato();
            lblTitulo.Text = CarregarTitulo();
            CarregarContatos();
        }
        private void CarregarContatos()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"\\vmware-host\Shared Folders\Desenvolvimento\Projetos e Estudos\Estudo Treina Web\C#\Exercicios\TreinaWebPleno\CalculadoraDelegate\EstudoXML\Agenda.xml");//Adicionado o @ para o caracter especial \ que mostra o caminho do diretório "nó"
            XmlNodeList nodeContato = documentoXml.SelectNodes("/agenda/contatos/contato"); //atravez do caminho xpath retornar uma espressao ou nó, onde /agenda/titulo seleciona o nó que vc deseja no caso o nó do titulo
            foreach(XmlNode contato in nodeContato) //node de nó -> nóContato
            {
                string representarContato = "";
                string id = contato.Attributes["id"].Value;
                string nome = contato.Attributes["nome"].Value;
                string idade = contato.Attributes["idade"].Value;
                representarContato = nome +", "+ idade + ", "+id;
                lbxContatos.Items.Add(representarContato);
            }
            
        }
        private string CarregarTitulo()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"\\vmware-host\Shared Folders\Desenvolvimento\Projetos e Estudos\Estudo Treina Web\C#\Exercicios\TreinaWebPleno\CalculadoraDelegate\EstudoXML\Agenda.xml");//Adicionado o @ para o caracter especial \ que mostra o caminho do diretório "nó"
            XmlNode noTitulo = documentoXml.SelectSingleNode("/agenda/titulo"); //atravez do caminho xpath retornar uma espressao ou nó, onde /agenda/titulo seleciona o nó que vc deseja no caso o nó do titulo
            return noTitulo.InnerText;
        }
        private void CriarContato()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"\\vmware-host\Shared Folders\Desenvolvimento\Projetos e Estudos\Estudo Treina Web\C#\Exercicios\TreinaWebPleno\CalculadoraDelegate\EstudoXML\Agenda.xml");//Adicionado o @ para o caracter especial \ que mostra o caminho do diretório "nó"
            
            XmlAttribute atributoId = documentoXml.CreateAttribute("id"); //cria-se os atributos para o elemento
            atributoId.Value = "teste 5";

            XmlAttribute atributoNome = documentoXml.CreateAttribute("nome");
            atributoNome.Value = "teste jose";

            XmlAttribute atributoIdade = documentoXml.CreateAttribute("idade");
            atributoIdade.Value = "teste 25";

            XmlNode novoContato = documentoXml.CreateElement("contato"); //criase o nó contato para ser passado os atributos
            novoContato.Attributes.Append(atributoId);// faz o vinculo do atributo ao nó contato
            novoContato.Attributes.Append(atributoNome);
            novoContato.Attributes.Append(atributoIdade);
           
            XmlNode contatos = documentoXml.SelectSingleNode("/agenda/contatos");//seleciona o nó a ser inserido a informação criada
            contatos.AppendChild(novoContato);//adiciona o filho ao nó

            documentoXml.Save(@"\\vmware-host\Shared Folders\Desenvolvimento\Projetos e Estudos\Estudo Treina Web\C#\Exercicios\TreinaWebPleno\CalculadoraDelegate\EstudoXML\Agenda.xml");//vai salvar no documento as alterações feitas

        }
    }
}
