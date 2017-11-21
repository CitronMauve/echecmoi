using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    class Pion : Piece
    {
        public bool premierDeplacement = true;
        public Pion(Joueur joueur) : base(joueur, TypePiece.Pion)
        {
        }

        public override bool Deplacer(Case destination)
        {
            if (DeplacerSurAllie(destination)) return false;

            bool result = false;

            int diffRangee = destination.rangee - this.position.rangee;
            int diffColonne = destination.colonne - this.position.colonne;

            if (diffColonne != 0) {
                if (premierDeplacement && diffRangee <= 2)
                {
                    result = destination.pieceActuelle == null;
                }
                if (diffRangee == 1)
                {
                    result = destination.pieceActuelle == null;
                }
            }

            if (diffRangee == 1 && diffColonne == 1)
            {
                result = destination.pieceActuelle != null;
            }

            if (premierDeplacement) premierDeplacement = false;


            if (result)
            {
                destination.Link(this);
                this.position.Unlink();
            }

            return result;
        }
    }
}
