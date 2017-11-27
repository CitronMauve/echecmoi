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
		public int rangee; 
		public int colonne;
        public Piece pieceActuelle;

	    // associations

	    public Case(int x, int y)
	    {
			this.rangee = x;
			this.colonne = y;
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

		public String ToString() {
			return ((char) (this.rangee + 97)) + (8 - this.colonne).ToString();
		}
    }
}
