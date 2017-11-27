using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs {
	class Tour : Piece {
		public Tour(Joueur joueur) : base(joueur, TypePiece.Tour) {
		}

		public override bool Deplacer(Case destination) {
			if (DeplacerSurAllie(destination)) return false;

			bool result = false;

			int diffColonne = destination.colonne - this.position.colonne;
			int diffRangee = destination.rangee - this.position.rangee;
			int i = 0;

			if (diffColonne == 0 && diffRangee != 0) {
				int rangeeToCheck = this.position.rangee;
				do {
					if (diffRangee < 0) {
						--rangeeToCheck;
					} else if (diffRangee > 0) {
						++rangeeToCheck;
					}
					
					result = joueur.partie.echiquier.cases[rangeeToCheck, this.position.colonne].pieceActuelle == null;

					++i;
				} while (result && i < Math.Abs(diffRangee));

				// Check the case where the move is authorized but there is an enemy at the Destination
				if (i == Math.Abs(diffRangee)) {
					result = (null == joueur.partie.echiquier.cases[destination.rangee, destination.colonne].pieceActuelle || DeplacerSurEnnemi(destination));
				}
			} else if (diffColonne != 0 && diffRangee == 0) {
				int colonneToCheck = this.position.colonne;
				do {
					if (diffColonne < 0) {
						--colonneToCheck;

					} else if (diffColonne > 0) {
						++colonneToCheck;
					}
					
					result = joueur.partie.echiquier.cases[this.position.rangee, colonneToCheck].pieceActuelle == null;

					++i;
				} while (result && i < Math.Abs(diffColonne));

				// Check the case where the move is authorized but there is an enemy at the Destination
				if (i == Math.Abs(diffColonne)) {
					result = (null == joueur.partie.echiquier.cases[destination.rangee, destination.colonne].pieceActuelle || DeplacerSurEnnemi(destination));
				}
			}

			return result;
		}
	}
}
