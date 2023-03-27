using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CasseBriques {
	class Mur {
		private int nbBriques;
		private Brique[,] mur = new Brique[10, 20];
		private int nbTypeBrique = 4;

		//						 [nbLvl, nbTypeBrique]
		public int[][] levels = new int[2147483646][];
		
		public void construit(int lvl, String modeType) {
			lvl--;
	
			// def lvl       { retour, speed, tnt, ArrowH} // base = 100 - reste
			levels[0] = new int[]{25, 25, 10, 5};
			levels[1] = new int[]{27, 30, 17, 3};
			levels[2] = new int[]{30, 35, 20, 2};
			levels[3] = new int[]{27, 38, 23, 2};
			levels[4] = new int[]{25, 40, 20, 1};

			Random randStat = new Random();
			//mur random
			if(modeType=="inf")
            {
				int statRetour = randStat.Next(0, 30);				
				int statSpeed = randStat.Next(0, 100 - statRetour);
				int statTNT = randStat.Next(0, 100 - (statRetour + statSpeed));
				int statAH = randStat.Next(0, 100 - (statSpeed + statRetour + statTNT));

				int allStat = statTNT + statSpeed + statRetour + statAH;

				levels[lvl] = new int[] {statRetour, statSpeed, statTNT, statAH};
            }

			// Affectaion aléatoire de briques au mur
			Random R = new Random();
			for (int l=0; l<10; l++) {
				for(int c=0; c<20; c++) {
					int rand = R.Next(100);

					int p1 = levels[lvl][0]; //RETOUR
					int p2 = p1 + levels[lvl][1]; //speed
					int p3 = p2 + levels[lvl][2]; //TNT
					int p4 = p3 + levels[lvl][3]; //ARROWH
					int p5 = 100;

					if(0 <= rand && rand <= p1)
					{
						mur[l, c] = new BriqueRetourNorme();
					}
					if(p1 < rand && rand <= p2)
					{
						mur[l, c] = new BriqueBouleRapide();
					}
					if(p2 < rand && rand <= p3)
					{
						mur[l, c] = new BriqueTNT();
					}
					if(p3 < rand && rand <= p4)
                    {
						mur[l, c] = new BriqueArrowH();
                    }
					if (p4 < rand && rand <= p5)
					{
						mur[l, c] = new Brique();
					}

					mur[l,c].positionne(c*(mur[l,c].getLargeur()+1), l*(mur[l,c].getHauteur()+1));
				}
			}

			nbBriques = 200;
		}

		public int getX(int l, int c)
		{
			return c *(mur[l, c].getLargeur() + 1);
		}

		public int getY(int l, int c)
		{
			return l * (mur[l, c].getHauteur() + 1);
		}

		public bool percute(int l, int c) {

			// Coordonnées hors du mur ?
			if (l<0 || l > 9 || c<0 || c>19) {
				// Le mur n'a pas été percuté
				return false;
			}
			else
				// Si la brique à ces cordonnées était déjà détruite ...
				if (mur[l,c].isDetruite()) {
					// Le mur n'a pas été percuté
					return false;
				}
				else {
					// Le mur est percuté
					return true;
				}
		}

		public int casse(int l, int c) {
			int consequence=0;
			// Si les coordonnées sont dans le mur (pas de coordonnées hors tableau)
			if (l>=0 && l <10 && c>=0 && c<20) {
				// Si la brique à ces coordonnées n'était pas détruite ...
				if (!mur[l,c].isDetruite()) {
					// La brique reçoit un choc (qui peut avoir une conséquence)
					consequence=mur[l,c].choc();
					// Si le choc a détruit la brique ...
					if(mur[l,c].isDetruite()) {
						// Une brique en moins, une !
						nbBriques--;
					}

					BriqueArrowH briqueDemoAH = new BriqueArrowH();
					if (Type.GetType(mur[l, c].ToString()) == Type.GetType(briqueDemoAH.ToString()))
					{
						for (int i = 0; i < 20; i++)
						{
							if(mur[l, i].detruite==false)
                            {
								mur[l, i].detruite = true;
								nbBriques--;
                            }							
						}
					}

					BriqueTNT briqueDemo = new BriqueTNT();
					if (Type.GetType(mur[l, c].ToString()) == Type.GetType(briqueDemo.ToString()))
                    {
						#region Nord
						if(c-1 <= -1)
                        {
							c = 1;
                        }
						if(c+1 > 18)
                        {
							c = 18;
                        }
						if(l-1 <= 0)
                        {
							l = 1;
                        }

						//NO
						try
                        {
							if(!mur[l - 1, c - 1].isDetruite())
                            {
								mur[l - 1, c - 1].detruite = true;
								nbBriques--;
                            }
							
						}
						catch(IndexOutOfRangeException exception)
                        {
							MessageBox.Show("NO l = " + l + "      c = " + c);
                        }

						//N
						if(!mur[l - 1, c].isDetruite())
                        {
							mur[l-1, c].detruite = true;
							nbBriques--;
                        }
							

						//NE
						try
						{
							if(!mur[l - 1, c + 1].isDetruite())
                            {
								mur[l - 1, c + 1].detruite = true;
								nbBriques--;
							}
						}
						catch(IndexOutOfRangeException exception)
                        {
							MessageBox.Show(" NE l = " + (l-1) + "      c = " + (c+1));
						}
                        #endregion

                        #region Centre
                        //CO
						if(!mur[l, c - 1].isDetruite())
                        {
							mur[l, c - 1].detruite = true;
							nbBriques--;
						}

						//C
						if(!mur[l, c].isDetruite())
                        {
							mur[l, c].detruite = true;
							nbBriques--;
						}

						//CE
						if(!mur[l, c + 1].isDetruite())
                        {
							mur[l, c + 1].detruite = true;
							nbBriques--;
                        }
						#endregion

						#region Sud
						if (l+1>=10)
                        {
							l = 8;
                        }
						
						//SO
						if(!mur[l + 1, c - 1].isDetruite())
                        {
							mur[l + 1, c - 1].detruite = true;
							nbBriques--;
						}
						
						//S
						if(!mur[l + 1, c].isDetruite())
                        {
							mur[l + 1, c].detruite = true;
							nbBriques--;
						}

						//SE
						if(!mur[l + 1, c + 1].isDetruite())
                        {
							mur[l + 1, c + 1].detruite = true;
							nbBriques--;
						}
						#endregion
					}
				}
			}
			return consequence;
		}

		public int getNbBriques() {
			return nbBriques;
		}

		public int getLargeurBrique() {
			return mur[0,0].getLargeur();
		}

		public int getHauteurBrique() {
			return mur[0,0].getHauteur();
		}

		public void dessine(Graphics support) {
			// Dessin du mur de brique
			for(int l=0;l<10;l++) {
				for (int c=0; c<20; c++) {
					// Si la brique n'est pas détruite ...
					if (!mur[l,c].isDetruite())
						// On la dessine
						mur[l,c].dessine(support);
				}
			}
		}
	}
}
