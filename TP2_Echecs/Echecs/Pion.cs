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
            if (destination.colonne != this.position.colonne) {
                if (!premierDeplacement &&
                    destination.rangee - this.position.rangee <= 2)
                {
                    premierDeplacement = false;
                    return destination.pieceActuelle == null;
                }
                if (destination.rangee - this.position.rangee == 1)
                {
                    return destination.pieceActuelle == null;
                }
            }

            if(destination.rangee - this.position.rangee == 1 &&
                destination.colonne - this.position.colonne == 1)
            {
                return destination.pieceActuelle != null;
            }
            return false;
        }
    }
}
