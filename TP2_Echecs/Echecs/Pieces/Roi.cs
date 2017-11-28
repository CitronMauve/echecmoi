using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs {
	class Roi : Piece
    {
        public Roi(Joueur joueur) : base(joueur, TypePiece.Roi) {
		}

		public override bool Deplacer(Case destination) {
			if (DeplacerSurAllie(destination)) return false;

            bool result = false;

			int diffColonne = destination.colonne - this.position.colonne;
			int diffRangee = destination.rangee - this.position.rangee;
			
            if (Math.Abs(diffColonne) <= 1 && Math.Abs(diffRangee) <= 1)
            {
                result = true;
            } else if (this.premierDeplacement && 
                diffColonne == 0 && Math.Abs(diffRangee) == 2)
            {
                Piece tour;
                int currentRangee = this.position.rangee;
                int currentColonne = this.position.colonne;

                if (diffRangee == 2)
                {
                    tour = joueur.partie.echiquier.cases[7, currentColonne].pieceActuelle;

                    result = tour != null && tour.GetType() == typeof(Tour) && tour.premierDeplacement &&
                        joueur.partie.echiquier.cases[currentRangee + 1, currentColonne].pieceActuelle == null &&
                        joueur.partie.echiquier.cases[currentRangee + 2, currentColonne].pieceActuelle == null;
                } else if (diffRangee == -2)
                {
                    tour = joueur.partie.echiquier.cases[0, currentColonne].pieceActuelle;

                    result = tour != null && tour.GetType() == typeof(Tour) && tour.premierDeplacement &&
                        joueur.partie.echiquier.cases[currentRangee - 1, currentColonne].pieceActuelle == null &&
                        joueur.partie.echiquier.cases[currentRangee - 2, currentColonne].pieceActuelle == null &&
                        joueur.partie.echiquier.cases[currentRangee - 3, currentColonne].pieceActuelle == null;
                }
            }


            if (this.premierDeplacement && result)
            {
                this.premierDeplacement = false;
            }
            

            return result;
        }

        private bool Roque(Case destination)
        {
            bool result = false;



            return result;
        }
	}
}
