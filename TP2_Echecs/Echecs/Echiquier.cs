using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Echecs.Echecs
{
    public class Echiquier
    {
        const int NB_CASES = 8;
        public Case[,] cases = new Case[NB_CASES, NB_CASES];

        public Echiquier()
        {
            for(int i = 0; i < NB_CASES; ++i)
            {
                for(int j = 0; j < NB_CASES; ++j)
                {
                    cases[i, j] = new Case(i, j);
                }
            }
        }
    }
}
