using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    public class Partie : IJeu
    {
        public IEvenements vue
        {
            get { return _vue; }
            set {_vue = value; }
        }

        StatusPartie status
        {
            get { return _status; }
            set
            {
                _status = value;
                vue.ActualiserPartie(_status);
            }
        }
       
        /* attributs */

        StatusPartie _status = StatusPartie.Reset;


        /* associations */
        
        IEvenements _vue;
        Joueur blancs;
        Joueur noirs;
        public Echiquier echiquier;
		int nombreCoups;


        /* methodes */

        public void CommencerPartie()
        {
            // creation des joueurs
            blancs = new Joueur(this, CouleurCamp.Blanche);
            noirs = new Joueur(this, CouleurCamp.Noire);

            // creation de l'echiquier
            echiquier = new Echiquier(this);

            // placement des pieces
            blancs.PlacerPieces(echiquier);  // TODO : décommentez lorsque vous auriez implementé les methode Unlink et Link de la classe Case
			foreach (Piece piece in blancs.pieces)
				vue.ActualiserCase(piece.position.rangee, piece.position.colonne, piece.info);

			noirs.PlacerPieces(echiquier);  // TODO : décommentez lorsque vous auriez implementé les methode Unlink et Link de la classe Case
			foreach (Piece piece in noirs.pieces)
				vue.ActualiserCase(piece.position.rangee, piece.position.colonne, piece.info);

			nombreCoups = 0;

			// initialisation de l'état
			status = StatusPartie.TraitBlancs;         
        }

        public void DeplacerPiece(int x_depart, int y_depart, int x_arrivee, int y_arrivee)
        {
            // case de départ
            Case depart = echiquier.cases[x_depart, y_depart];

            // case d'arrivée
            Case destination = echiquier.cases[x_arrivee, y_arrivee];

            // deplacer
            bool ok = depart.pieceActuelle.Deplacer(destination);

			// changer d'état
			if (ok)
			{
				String moveOrTake = destination.pieceActuelle != null ? "x" : "-";

				destination.Unlink();
				destination.Link(depart.pieceActuelle);
				destination.pieceActuelle.position = destination;

				String promotion = depart.pieceActuelle.info.type == TypePiece.Pion && 
					destination.pieceActuelle.info.type != TypePiece.Pion ? 
						destination.pieceActuelle.info.type.ToString()[0].ToString() : 
						"";

				depart.Unlink();

				vue.ActualiserCase(destination.rangee, destination.colonne, destination.pieceActuelle.info);
				vue.ActualiserCase(depart.rangee, depart.colonne, null);

				nombreCoups++;
				String movement;

				String piece = destination.pieceActuelle.info.type == TypePiece.Pion ? "" : destination.pieceActuelle.info.type.ToString()[0].ToString();

				// Notation algébrique
				movement = piece + depart.ToString() + moveOrTake + destination.ToString() + promotion;
				vue.ActualiserHistorique(nombreCoups, movement);

				ChangerEtat();
			}
        }

        void ChangerEtat(bool echec = false, bool mat = false)
        {
            if (status == StatusPartie.TraitBlancs)
            {
                status = StatusPartie.TraitNoirs;
            }
            else
            {
                status = StatusPartie.TraitBlancs;
            }

        }
    }
}
