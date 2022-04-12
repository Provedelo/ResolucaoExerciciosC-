using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContados
{
   public class  Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NmroTelefone { get; set; }

        public Contato (string nome = "", string email = "", string nmroTelefone = "")
        {
            this.Nome = nome;
            this.Email = email;
            this.NmroTelefone = nmroTelefone;
            return;
        }

        public override string ToString() //sobrescreve o metodo tostring para mostrar as informações
        {
            //return base.ToString();
            return string.Format("{0} - {1}, {2}", this.Nome, this.Email, this.NmroTelefone);
        }

    }
}
