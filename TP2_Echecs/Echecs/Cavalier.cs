using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    class Cavalier : Piece
    {
        public Cavalier(Joueur joueur, TypePiece type) : base(joueur, type)
        {
        }

        public override bool Deplacer(Case destination)
        {
            throw new NotImplementedException();
        }
    }
}
