using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    public class Joueur
    {
        // attributs
        public CouleurCamp couleur;

        // associations
        public Partie partie;
        public List<Piece> pieces = new List<Piece>();

        // methodes
        public Joueur(Partie partie, CouleurCamp couleur)
        {
            this.couleur = couleur;
            this.partie = partie;

            // TODO : creation des pieces du joueur
            pieces.Add(new Roi(this));
            pieces.Add(new Dame(this));

            for (int i = 0; i < 8; ++i)
            {
                pieces.Add(new Pion(this));
            }

            for (int i = 0; i < 2; ++i)
            {
                pieces.Add(new Tour(this));
                pieces.Add(new Fou(this));
                pieces.Add(new Cavalier(this));
            }
        }

        // TODO : décommentez lorsque vous auriez implementé les methode Unlink et Link de la classe Case
        public void PlacerPieces(Echiquier echiquier)
        {
            if( couleur == CouleurCamp.Noire )
            {
                echiquier.cases[3, 0].Link( pieces[0] );
            }
            else
            {
                echiquier.cases[3, 7].Link( pieces[0] );
            }
        }
    }
}
