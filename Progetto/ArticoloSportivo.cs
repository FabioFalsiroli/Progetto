using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto
{
    class ArticoloSportivo : Articolo
    {

        public ArticoloSportivo(string nome, string codice, decimal prezzo, string sport) : base(nome, codice, prezzo)
        {
            Sport = sport;
        }

        //Proprietà
        public string Sport{ get; }


        //Metodì
        public override string ToString()
        {
            return $"{Nome},{Codice},{Sport},{Prezzo}";
        }

    }
}
