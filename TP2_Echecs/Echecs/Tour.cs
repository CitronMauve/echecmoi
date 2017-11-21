using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    class Tour : Piece
    {
        public Tour(Joueur joueur) : base(joueur, TypePiece.Tour)
        {
        }

        public override bool Deplacer(Case destination)
        {
            bool result = true;

            int diffColonne = destination.colonne - this.position.colonne;
            int diffRangee = destination.rangee - this.position.rangee;
            int i = 0;

            if (diffColonne != 0 && diffRangee == 0)
            {
                while (Math.Abs(diffColonne) != i)
                {
                    if (joueur.partie.Echiquier.cases[this.position.rangee, i + this.position.colonne] != null)
                    {
                        return false;
                    }
                    ++i;
                }
            }

            if (diffColonne == 0 && diffRangee != 0)
            {
                while (Math.Abs(diffRangee) != i)
                {
                    if (joueur.partie.Echiquier.cases[this.position.rangee, this.position.colonne] != null)
                    {
                        return false;
                    }
                    ++i;
                }
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
