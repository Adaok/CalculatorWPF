using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceWPF
{
    public class ItemHistory
    {
        public string Calcul { get; set; }
        public string Result { get; set; }

        public ItemHistory(string calcul, string resultat)
        {
            this.Calcul = calcul;
            this.Result = resultat;
        }
    }
}
