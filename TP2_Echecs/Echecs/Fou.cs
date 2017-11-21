using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    class Fou : Piece
    {
        public Fou(Joueur joueur) : base(joueur, TypePiece.Fou)
        {
        }

        public override bool Deplacer(Case destination)
        {
            bool result = false;

            int diffColonne = destination.colonne - this.position.colonne;
            int diffRangee = destination.rangee - this.position.rangee;
            int i = 0;

            if (diffColonne == diffRangee)
            {
                while(Math.Abs(diffColonne) != i)
                {
                    if (joueur.partie.echiquier.cases[i + this.position.rangee, i + this.position.colonne] != null)
                    {
                        return false;
                    }
                    ++i;
                }
                result = true;
            }


            if (result)
            {
                destination.Link(this);
                this.position.Unlink();
            }

            return result;
        }
    }
}
