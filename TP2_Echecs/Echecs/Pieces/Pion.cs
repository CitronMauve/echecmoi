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
				if ((destination.colonne - this.position.colonne == -2 && premierDeplacement) ||
					destination.colonne - this.position.colonne == -1) {
					// Check if an ennemi is present when moving from anoter column
					// Normal movement expected from a Pion: no enemy
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
				if ((destination.colonne - this.position.colonne == 2 && premierDeplacement) ||
					destination.colonne - this.position.colonne == 1) {
					// Check if an ennemi is present when moving from anoter column
					// Normal movement expected from a Pion: no enemy
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
	}
}
