using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs {
	class Pion : Piece {
		public bool premierDeplacement = true;

		public Pion(Joueur joueur) : base(joueur, TypePiece.Pion) {
		}

		public override bool Deplacer(Case destination) {
			if (DeplacerSurAllie(destination)) return false;

			bool result = false;

			// White side
			if (this.info.couleur == CouleurCamp.Blanche) {
				// Check if first move, if so allow distance 2
				if (premierDeplacementPossible(destination) ||
					destination.colonne - this.position.colonne == -1) {
					// Check if an ennemi is present when moving from anoter column
					// Normal movement expected from a Pion
					if (destination.rangee - this.position.rangee == 0 && !DeplacerSurEnnemi(destination)) {
						result = true;
					} // Movement with an enemy
					else if (Math.Abs(destination.rangee - this.position.rangee) == 1 && DeplacerSurEnnemi(destination)) {
						result = true;
					}
				}
			}
			// Black side
			else {
				// Check if first move, if so allow distance 2
				if (premierDeplacementPossible(destination) ||
					destination.colonne - this.position.colonne == 1) {
					// Check if an ennemi is present when moving from anoter column
					// Normal movement expected from a Pion
					if (destination.rangee - this.position.rangee == 0 && !DeplacerSurEnnemi(destination)) {
						result = true;
					}
					// Movement with an enemy
					else if (Math.Abs(destination.rangee - this.position.rangee) == 1 && DeplacerSurEnnemi(destination)) {
						result = true;
					}
				}
			}

			if (this.premierDeplacement && result) {
				this.premierDeplacement = false;
			}

			return result;
		}

		private bool premierDeplacementPossible(Case destination) {
			bool result = false;

			Case caseEnFace;

			if (this.info.couleur == CouleurCamp.Blanche) {
				caseEnFace = joueur.partie.echiquier.cases[this.position.rangee, this.position.colonne - 1];

				result = premierDeplacement &&
					destination.colonne - this.position.colonne == -2 &&
					caseEnFace.pieceActuelle == null;
			} else {
				caseEnFace = joueur.partie.echiquier.cases[this.position.rangee, this.position.colonne + 1];

				result = premierDeplacement &&
					destination.colonne - this.position.colonne == 2 &&
					caseEnFace.pieceActuelle == null;
			}

			return result;
		}
	}
}
