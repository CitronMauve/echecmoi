using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
		public class Case
		{
				// attributs
				enum Couleur { Blanc, Noir };
				int rangee, colonne;
                Couleur couleur;

				// associations

				Case(int i, int j)
				{
						this.rangee = i;
						this.colonne = j;
						this.couleur = (i + j) % 2 == 0
								? Couleur.Blanc
								: Couleur.Noir; 
				}


				// methodes
				public void Link(Piece newPiece)
				{
						// 1. Deconnecter newPiece de l'ancienne case

						// 2. Connecter newPiece à cette case
				}
		}
}
