using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    class Cavalier : Piece
    {
        public Cavalier(Joueur joueur) : base(joueur, TypePiece.Cavalier)
        {
        }

        public override bool Deplacer(Case destination)
        {
            if (DeplacerSurAllie(destination)) return false;

            bool result = false;

            int diffColonne = Math.Abs(destination.colonne - this.position.colonne);
            int diffRangee = Math.Abs(destination.rangee - this.position.rangee);

            if (diffColonne == 2 && diffRangee == 1 ||
                diffRangee == 1 && diffColonne == 2)
            {
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
