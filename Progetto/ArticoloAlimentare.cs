using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto
{
    class ArticoloAlimentare : Articolo
    {


        public ArticoloAlimentare(string nome, string codice, decimal prezzo, string cucina, bool cotto) : base(nome, codice, prezzo)
        {
            Cucina = cucina;
            Cotto = cotto;
        }

        public ArticoloAlimentare(string nome, string codice, string cucina, bool cotto) : this(nome, codice, 0, cucina, cotto)
        { }

        //Proprietà
        public string Cucina { get; }

        public bool Cotto { get; }

        //Metodì
        public override string ToString()
        {
            return $"{Nome},{Codice},{Prezzo},{Cucina}";
        }


    }
}
