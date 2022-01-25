using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyMed
{
    class NrPacienti
    {
        private int nrPacientiTotal { get; set; }
        private int nrPacientiMinori { get; set; }
        private int nrPacientiAdulti { get; set; }

        public NrPacienti(int nrPacientiTotal, int nrPacientiMinori, int nrPacientiAdulti)
        {
            this.nrPacientiTotal = nrPacientiTotal;
            this.nrPacientiMinori = nrPacientiMinori;
            this.nrPacientiAdulti = nrPacientiAdulti;
        }
    }
}
