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
	    public int rangee, colonne;
        // public Couleur couleur;
        public Piece pieceActuelle;

	    // associations

	    public Case(int i, int j)
	    {
			this.rangee = i;
			this.colonne = j;
			/*
			this.couleur = (i + j) % 2 == 0
					? Couleur.Blanc
					: Couleur.Noir;
			*/
            this.pieceActuelle = null;
	    }


	    // methodes
	    public void Link(Piece newPiece)
	    {
            // 2. Connecter newPiece à cette case
            this.pieceActuelle = newPiece;
			newPiece.position = this;
	    }

        public void Unlink()
        {
            // 1. Deconnecter newPiece de l'ancienne case
            this.pieceActuelle = null;
        }
    }
}
