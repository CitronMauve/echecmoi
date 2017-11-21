using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    class Roi : Piece
    {
        public Roi(Joueur joueur) : base(joueur, TypePiece.Roi)
        {
        }

        public override bool Deplacer(Case destination)
        {

            int diffColonne = Math.Abs(destination.colonne - this.position.colonne);
            int diffRangee = Math.Abs(destination.rangee - this.position.rangee);

            // May not work
            if (diffColonne <= 1 && diffRangee <= 1)
            {
                destination.Link(this);
                this.position.Unlink();
                return true;
            }

            /*
            if (diffColonne == 1 && diffRangee == 1 ||
                diffColonne == 1 && diffRangee == 0 ||
                diffColonne == 0 && diffRangee == 1) {
            }
            */

            /* TODO: ROQUE */

            return false;            
        }
    }
}
