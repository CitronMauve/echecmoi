using System;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs {
	public class Dame : Piece {
		public Dame(Joueur joueur) : base(joueur, TypePiece.Dame) { }

		public override bool Deplacer(Case destination) {
			if (DeplacerSurAllie(destination)) return false;

			bool result = false;

			int diffColonne = destination.colonne - this.position.colonne;
			int diffRangee = destination.rangee - this.position.rangee;
			int rangeeToCheck = this.position.rangee;
			int colonneToCheck = this.position.colonne;
			int i = 0;

			//-------------------------------------------------------------------------------------------------------------------
			// Movement of the Tour.cs
			if (diffColonne == 0 && diffRangee != 0) {
				rangeeToCheck = this.position.rangee;
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
				colonneToCheck = this.position.colonne;
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
			// Movement of the Tour.cs
			//-------------------------------------------------------------------------------------------------------------------

			//-------------------------------------------------------------------------------------------------------------------
			// Movement of the Fou.cs
			if (Math.Abs(diffColonne) == Math.Abs(diffRangee)) {
				do {
					if (diffRangee < 0) {
						--rangeeToCheck;
					} else if (diffRangee > 0) {
						++rangeeToCheck;
					}

					if (diffColonne < 0) {
						--colonneToCheck;

					} else if (diffColonne > 0) {
						++colonneToCheck;
					}

					result = joueur.partie.echiquier.cases[rangeeToCheck, colonneToCheck].pieceActuelle == null;

					++i;
				} while (result && i < Math.Abs(diffColonne));

				// Check the case where the move is authorized but there is an enemy at the Destination
				if (i == Math.Abs(diffColonne)) {
					result = (null == joueur.partie.echiquier.cases[destination.rangee, destination.colonne].pieceActuelle || DeplacerSurEnnemi(destination));
				}
			}
			// Movement of the Fou.cs
			//-------------------------------------------------------------------------------------------------------------------

			return result;
		}
	}
}
