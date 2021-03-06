﻿using TP2_Echecs.IHM;

namespace TP2_Echecs.Echecs
{
    abstract public class Piece
    {
        // attributs
        public InfoPiece info;

        public bool premierDeplacement = true;

        // associations
        public Joueur joueur;
        public Case position;

        // methodes
        public Piece(Joueur joueur, TypePiece type)
        {
			this.joueur = joueur;
            info = InfoPiece.GetInfo(joueur.couleur, type);
        }

        public abstract bool Deplacer(Case destination);

        public bool DeplacerSurAllie(Case destination)
        {
            return destination.pieceActuelle != null && destination.pieceActuelle.joueur.couleur == this.joueur.couleur;
        }

		public bool DeplacerSurEnnemi(Case destination)
		{
			return destination.pieceActuelle != null && destination.pieceActuelle.joueur.couleur != this.joueur.couleur;
		}
    }
}
