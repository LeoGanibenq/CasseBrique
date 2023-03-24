using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBriques
{
    class Effects
    {
		// x et y désignent les coordonnées du centre de la boule
		private int x, y, depX, depY, cote, vitesse;
		private Color couleur;
		public int type;
		public bool isPlaced = false;

		private const int NORME = 1;
		private const int RAPIDE = 2;

		public Effects(int typeE, int posx, int posy)
		{
			cote = 10;
			x = posx;
			y = posy;

			switch (type)
            {
				case NORME:
					couleur = Color.Yellow;
					break;
				case RAPIDE:
					couleur = Color.Green;
					break;
				default:
					couleur = Color.Blue;
					break;
            }

			vitesse = 1;
			type = typeE;
		}

		public void place(int newX, int newY)
		{
			x = newX;
			y = newY;
		}

		public int getTypeE()
        {
			return type;
        }

		public void deplace()
		{
			y = y + vitesse;
		}

		public int getRayon()
		{
			return cote;
		}

		public int getX()
		{
			return x;
		}

		public int getY()
		{
			return y;
		}

		public Color getCouleur()
		{
			return couleur;
		}

		public void dessine(Graphics motif)
		{
			switch(type)
            {
				case RAPIDE:
					//motif.FillRectangle(new SolidBrush(couleur), getX(), getY(), cote, cote);
					Image img = Image.FromFile("../../speedEffect.png");
					motif.DrawImage(img, getX(), getY());
					break;
				case NORME:
					//motif.FillRectangle(new SolidBrush(couleur), getX(), getY(), cote, cote);
					Image img2 = Image.FromFile("../../retourBrique.png");
					motif.DrawImage(img2, getX(), getY());
					break;
			}
			
		}
	}
}
