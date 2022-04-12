using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
     
        public Calculadora()
        {
            InitializeComponent();
        }
  /*      abstract void Checagem();
         try
        {
        StringComparer check = new StringComparer(txbNumero1.Text, txbNumero2.Text);
        string numero;
        while ((numero = StringComparer.ReadLine()) != null && != char) 
            {
            return (void)
            }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Erro desconhecido: " + ex.Message);
            }
return void */


private void btnSoma_Click(object sender, EventArgs e) 
        {
            int numero1 = Convert.ToInt32(txbNumero1.Text);
            int numero2 = Convert.ToInt32(txbNumero2.Text);
            txbResultado.Text = Somar(numero1, numero2).ToString();
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            int numero1 = Convert.ToInt32(txbNumero1.Text);
            int numero2 = Convert.ToInt32(txbNumero2.Text);
            txbResultado.Text = Subtrair(numero1, numero2).ToString();
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            int numero1 = Convert.ToInt32(txbNumero1.Text);
            int numero2 = Convert.ToInt32(txbNumero2.Text);
            txbResultado.Text = Multiplicar(numero1, numero2).ToString();
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            float numero1 = Convert.ToInt32(txbNumero1.Text);
            float numero2 = Convert.ToInt32(txbNumero2.Text);
            txbResultado.Text = Dividir(numero1, numero2).ToString();
        }

        int Somar(params int[] numeros) //usado para adicionar inumeros valores para somar
        {
            int resultado = 0;
            foreach (int numero in numeros)
            {
                resultado += numero;
            }

            return resultado;
        }
        
        int Subtrair (params int[] numeros)
        {
            int resultado = 0;
            foreach (int numero in numeros)
            {
                resultado = -resultado - numero;
            }
            return resultado;
        }
        int Multiplicar(params int[] numeros)
        {
            int resultado = 1;
            foreach (int numero in numeros)
            {
                resultado = resultado * numero;
            }
            return resultado;
        }
        float Dividir(params float[] numeros) 
        {
            float resultado = 0F;
            foreach (int numero in numeros)
            {
                if (resultado == 0)
                {
                    resultado = numero;
                }else
             resultado = resultado / numero; 
            
            }
            return resultado;

     /* private void btnSoma_Click(object sender, EventArgs e) //com conotação normal
       {
           int numero1 = Convert.ToInt32(txbNumero1.Text);
           int numero2 = Convert.ToInt32(txbNumero2.Text);
           int resultado = numero1 + numero2;
           txbResultado.Text =Convert.ToString(resultado);
       }

       private void btnSubtracao_Click(object sender, EventArgs e)
       {
           int numero1 = Convert.ToInt32(txbNumero1.Text);
           int numero2 = Convert.ToInt32(txbNumero2.Text);
           int resultado = numero1 - numero2;
           txbResultado.Text = Convert.ToString(resultado);
       }

       private void btnMultiplicacao_Click(object sender, EventArgs e)
       {
           int numero1 = Convert.ToInt32(txbNumero1.Text);
           int numero2 = Convert.ToInt32(txbNumero2.Text);
           int resultado = numero1 * numero2;
           txbResultado.Text = Convert.ToString(resultado);
       }

       private void btnDivisao_Click(object sender, EventArgs e)
       {
           float numero1 = Convert.ToInt32(txbNumero1.Text);
           float numero2 = Convert.ToInt32(txbNumero2.Text);
           float resultado = numero1 / numero2;
           txbResultado.Text = Convert.ToString(resultado);
       }*/
        }
    }
}
