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
        public Pion(Joueur joueur) : base(joueur, TypePiece.Pion)
        {
        }

        public override bool Deplacer(Case destination)
        {
            throw new NotImplementedException();
        }
    }
}
