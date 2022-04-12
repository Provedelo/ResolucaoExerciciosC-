using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaContados
{
    public partial class frmAgendaContatos : Form
    {
        public frmAgendaContatos()
        {
            InitializeComponent();
        }
        private OperacaoEnum acao;

        private void frmAgendaContatos_Shown(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(false);
            AlterarBotoesIncluirAlterarExcluir(true);
            CarregarListaContatos();
            AlterarEstadoDosCampos(false);
            //lbxContatos.Items.AddRange(ManipuladorDeArquivos.LerArquivo().ToArray()); //Itens no box e adiciona quaisquer tipo de arquivos no box
        }
        private void AlterarBotoesSalvarECancelar(bool estado)
        {
            btnSalvar.Enabled = estado;
            btnCancelar.Enabled = estado;
        }
        private void AlterarBotoesIncluirAlterarExcluir(bool estado)
        {
            btnIncluir.Enabled = estado;
            btnAlterar.Enabled = estado;
            btnExcluir.Enabled = estado;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(true);
            AlterarBotoesIncluirAlterarExcluir(false);
            AlterarEstadoDosCampos(true);
            acao = OperacaoEnum.INCLUIR;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(true);
            AlterarBotoesIncluirAlterarExcluir(false);
            AlterarEstadoDosCampos(true);
            acao = OperacaoEnum.ALTERAR;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(false);
            AlterarBotoesIncluirAlterarExcluir(true);
            AlterarEstadoDosCampos(false);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato //vai criar o contato a parti do textbox
            {
                Nome = txbNome.Text,
                Email = txbEmail.Text,
                NmroTelefone = txbTelefone.Text,
            };
           
            List<Contato> contatosList = new List<Contato>(); //vai varrer a lista
            foreach (Contato contatosDaLista in lbxContatos.Items) //Entao vai criar uma nova lista e adicionar o novo contato e escrever na lista, sempre sendo sobrescrito
            {
                contatosList.Add(contatosDaLista);
            }
            if (acao == OperacaoEnum.INCLUIR)
            {
                contatosList.Add(contato);
            } 
            else 
            {
                int indice = lbxContatos.SelectedIndex;
                contatosList.RemoveAt(indice);
                contatosList.Insert(indice, contato);
            }
            ManipuladorDeArquivos.EscreverArquivos(contatosList);
            CarregarListaContatos();
            AlterarBotoesSalvarECancelar(false);
            AlterarBotoesIncluirAlterarExcluir(true);
            LimparCampos();
            AlterarEstadoDosCampos(false);
        }
        private void CarregarListaContatos()
        {
            lbxContatos.Items.Clear();
            lbxContatos.Items.AddRange(ManipuladorDeArquivos.LerArquivo().ToArray());
            lbxContatos.SelectedIndex = 0;
        }
        private void LimparCampos()
        {
            txbEmail.Text = "";
            txbNome.Text = "";
            txbTelefone.Text = "";
        }
        private void AlterarEstadoDosCampos(bool estado)
        {
            txbNome.Enabled = estado;
            txbEmail.Enabled = estado;
            txbTelefone.Enabled = estado;
        }

        private void lbxContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contato contato = (Contato)lbxContatos.Items[lbxContatos.SelectedIndex]; //fez um cast direto e com os itens da caixa, atraves do selectedIndex retorna o valor desejado 
            txbEmail.Text = contato.Email;
            txbNome.Text = contato.Nome;
            txbTelefone.Text = contato.NmroTelefone;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza?", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes) //adiciona botoes no messagebox etc...
            {
                int indiceExcluido = lbxContatos.SelectedIndex;
                lbxContatos.SelectedIndex = 0;
                lbxContatos.Items.RemoveAt(indiceExcluido); //remove a linha selecionada do list box
                List<Contato> contatosList = new List<Contato>();
                foreach (Contato contato in lbxContatos.Items)
                {
                    contatosList.Add(contato);
                }
                ManipuladorDeArquivos.EscreverArquivos(contatosList);
                CarregarListaContatos();
                LimparCampos();
            }
        }
    }
}
