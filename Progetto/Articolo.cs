using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto
{
    public abstract class Articolo
    {

        public Articolo(string nome, string codice, decimal prezzo)
        {
            Nome = nome;
            Codice = codice;
            Prezzo = prezzo;

        }

        //Proprietà
        public string Nome { get; }

        public string Codice { get; }

        public decimal Prezzo { get; }


        public virtual decimal SumPrezzi()
        {
            decimal sum = 0;


            return sum;
        }


    }
}
