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

		List<InfoPiece> piecesPerdues;


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

			piecesPerdues = new List<InfoPiece>();

			// initialisation de l'état
			status = StatusPartie.TraitBlancs;

            status.paused = false;
        }

        public void DeplacerPiece(int x_depart, int y_depart, int x_arrivee, int y_arrivee)
        {
            if (!status.paused)
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
                    String movement;

                    // Roque
                    if (depart.pieceActuelle.GetType() == typeof(Roi) &&
                        Math.Abs(depart.rangee - destination.rangee) == 2 && depart.colonne - destination.colonne == 0)
                    {
                        destination.Link(depart.pieceActuelle);
                        destination.pieceActuelle.position = destination;
                        depart.Unlink();

                        vue.ActualiserCase(destination.rangee, destination.colonne, destination.pieceActuelle.info);
                        vue.ActualiserCase(depart.rangee, depart.colonne, null);

                        // move tour
                        Case tourDepart;
                        int ancienneRangeeTour;
                        int ancienneColonneTour = destination.colonne;

                        int nouvelleRangeeTour;
                        int nouvelleColonneTour = destination.colonne;
                        Case tourDestination;
                        if (destination.rangee - depart.rangee == 2)
                        {
                            ancienneRangeeTour = 7;
                            nouvelleRangeeTour = 5;
                            movement = "0-0";
                        }
                        else
                        {
                            ancienneRangeeTour = 0;
                            nouvelleRangeeTour = 3;
                            movement = "0-0-0";
                        }
                        tourDepart = echiquier.cases[ancienneRangeeTour, ancienneColonneTour];
                        // tourDepart = new Case(ancienneRangeeTour, ancienneColonneTour);
                        tourDestination = echiquier.cases[nouvelleRangeeTour, nouvelleColonneTour];
                        // tourDestination  = new Case(nouvelleRangeeTour, nouvelleColonneTour);

                        tourDestination.Link(tourDepart.pieceActuelle);
                        tourDestination.pieceActuelle.position = tourDestination;
                        tourDepart.Unlink();

                        vue.ActualiserCase(tourDestination.rangee, tourDestination.colonne, tourDestination.pieceActuelle.info);
                        vue.ActualiserCase(tourDepart.rangee, tourDepart.colonne, null);

                        // # of moves so far during this game
                        nombreCoups++;
                    }
                    else
                    {

                        // Is it a simple move or a piece has been eaten
                        String moveOrTake = destination.pieceActuelle != null ? "x" : "-";

                        // Actualiser Captures
                        if (destination.pieceActuelle != null)
                        {
                            piecesPerdues.Add(destination.pieceActuelle.info);
                        }

                        destination.Unlink();
                        destination.Link(depart.pieceActuelle);
                        destination.pieceActuelle.position = destination;

                        // Has a Pawn got a promotion ?
                        String promotion = depart.pieceActuelle.info.type == TypePiece.Pion &&
                            destination.pieceActuelle.info.type != TypePiece.Pion ?
                                destination.pieceActuelle.info.type.ToString()[0].ToString() :
                                "";

                        depart.Unlink();

                        vue.ActualiserCase(destination.rangee, destination.colonne, destination.pieceActuelle.info);
                        vue.ActualiserCase(depart.rangee, depart.colonne, null);

                        // # of moves so far during this game
                        nombreCoups++;
                        // Name of the Piece that moved, if it was a Pawn, it is not logged
                        String piece = destination.pieceActuelle.info.type == TypePiece.Pion ? "" : destination.pieceActuelle.info.type.ToString()[0].ToString();
                        // Standard Algebraic Notation (SAN)
                        movement = piece + depart.ToString() + moveOrTake + destination.ToString() + promotion;
                    }
                    vue.ActualiserCaptures(piecesPerdues);
                    vue.ActualiserHistorique(nombreCoups, movement);
                    ChangerEtat();
                }
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
