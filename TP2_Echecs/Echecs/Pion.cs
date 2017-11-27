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

			// White side
			if (this.info.couleur == CouleurCamp.Blanche)
			{
				// Check if first move, if so allow distance 2
				if ((destination.colonne - this.position.colonne == -2 && premierDeplacement) ||
					destination.colonne - this.position.colonne == -1)
				{
					// Check if an ennemi is present when moving from anoter column
					if ((Math.Abs(destination.rangee - this.position.rangee) == 1 && DeplacerSurEnnemi(destination)) ||
						destination.rangee - this.position.rangee == 0) {
						result = true;
					}
				}
			}
			// Black side
			else
			{
				// Check if first move, if so allow distance 2
				if ((destination.colonne - this.position.colonne == 2 && premierDeplacement) ||
					destination.colonne - this.position.colonne == 1)
				{
					// Check if an ennemi is present when moving from anoter column
					if ((Math.Abs(destination.rangee - this.position.rangee) == 1 && DeplacerSurEnnemi(destination)) ||
						destination.rangee - this.position.rangee == 0)
					{
						result = true;
					}
				}
			}
			/*
            int diffRangee = destination.rangee - this.position.rangee;
            int diffColonne = destination.colonne - this.position.colonne;

			// Déplacement simple: sans ennemi
            if (diffColonne == 0) {
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
			*/
			if (result)
            {
                destination.Link(this);
                this.position.Unlink();
				this.premierDeplacement = false;
			}
			
			return result;
        }
    }
}
