using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CasseBriques {
	class Brique {
		private const int SIMPLE=0;
		private int x, y, largeur, hauteur;
		protected Color couleur;
		public bool detruite;
		protected Image image;

		/*
			Normal: 0
			speed: 2
			TNT: 3
		*/

		public Brique() {
			largeur=17;
			hauteur=14;
            couleur = Color.FromArgb(0, 250, 0);
			detruite=false;
			image = Image.FromFile("../../baseBrique.png");
		}

		public void setColor(Color color)
        {
			couleur = color;
        }

		public virtual int choc() {
			// Si la brique n'est pas déjà détruite
			if (!detruite) {
				detruite=true;
			}
			return SIMPLE;
		}
		public int getX()
		{
			return largeur;
		}

		public int getY()
		{
			return hauteur;
		}

		public bool isDetruite() {
			return detruite;
		}

		public void positionne(int newX, int newY) {
			x=newX;
			y=newY;
		}

		public int getHauteur() {
			return hauteur;
		}

		public int getLargeur() {
			return largeur;
		}

		public void dessine(Graphics motif){
			// Dessin de la brique
			motif.FillRectangle(new SolidBrush(couleur),x,y,largeur,hauteur);
			motif.DrawImage(image, x, y);
		}
	}

	class BriqueRetourNorme : Brique {
	    private const int NORME=1;

		public BriqueRetourNorme() : base() {
		  couleur=Color.Pink;
			image = Image.FromFile("../../retourBrique.png");
		}

		public override int choc() {
		  base.choc();
		  return NORME;
		}

    }

    class BriqueBouleRapide : Brique
    {
        private const int RAPIDE = 2;

        public BriqueBouleRapide() : base()
        {
            couleur = Color.Yellow;
			image = Image.FromFile("../../speedBrique.png");
        }

        public override int choc()
        {
            base.choc();
            return RAPIDE;
        }

	}

	class BriqueTNT : Brique
	{
		private const int TNT = 3;

		public BriqueTNT() : base()
		{
			couleur = Color.Yellow;
			image = Image.FromFile("../../tnt.png");
		}

		public override int choc()
		{
			base.choc();
			return TNT;
		}

	}

	class BriqueArrowH : Brique
	{
		private const int ARROWH = 4;

		public BriqueArrowH() : base()
		{
			couleur = Color.Yellow;
			image = Image.FromFile("../../arrowH.png");
		}

		public override int choc()
		{
			base.choc();
			return ARROWH;
		}

	}
}
