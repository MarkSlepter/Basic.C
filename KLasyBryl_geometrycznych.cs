using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace OOP_PROJEKT
{
    public class KlasyBrył_Geometrycznych
    {

        //deklaracja klasy abstrakcyjnej
        public abstract class BryłaAbstrakcyjna
        {
            //deklaracja klasy abstrakcyjnej
           
                protected float KątProsty = 90.0F;
                //deklaracja typu wyliczniewego, którego elemeny będą "znacznikami"
                //wpisanymi w egzemlarzy każdej bryły
                public enum TypyBrył
                {
                    BG_Walec,
                    BG_Kula,
                    BG_Ostrosłup,
                    BG_Graniastosłup,
                    BG_Sześcian,
                    BG_Stożek,
                    BG_StożekPochylony,
                    BG_StożekPodwójny
                };
                //deklaracja zmiennych dla wspólnych atrybutów geometrycznych
                protected int mbXsP, mbYsP;
                protected int mbWysokośćBryły;
                protected float mbKątPochylenia;
                //deklaracja zmiennych dla wspólnych atrybutów graficznych
                protected Color mbKolor_Linii;
                protected DashStyle mbStyl_Linii;
                protected int mbGrubość_Linii;
                //deklaracja zmiennych dla implementacji przyszłych funkcjonalności
                public TypyBrył RodzajBryły;
                protected bool mbKierunekObrotu; //false: w prawo, true: w lewo
                protected float PowierzchiaBryły;
                protected float ObjętnośćBryły;
                protected bool Widoczny;
                //deklaracja konstuktora
                public BryłaAbstrakcyjna(Color KolorLinii, DashStyle StylLinii, int GrubośćLinii, bool mbKierunekObrotu)
                {
                    this.mbKolor_Linii = KolorLinii;
                    this.mbStyl_Linii = StylLinii;
                    this.mbGrubość_Linii = GrubośćLinii;
                    this.mbKątPochylenia = KątProsty;
                    this.mbKierunekObrotu = mbKierunekObrotu;
                }
                //deklaracja metod abstakcyjnych 
                public abstract void Wykreśl(Graphics Rysownica);



                public abstract void Wymaż(Control Kontrolka, Graphics Rysownica);

                public abstract void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float mbKątObrotu);

                public abstract void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y);

                public void UstalAtrybutyGraficzne(Color KolorLinii, DashStyle StylLinii, int GrubośćLinii)
                {
                    this.mbKolor_Linii = KolorLinii;
                    this.mbStyl_Linii = StylLinii;
                    this.mbGrubość_Linii = GrubośćLinii;
                }

            }//od Klasy BryłaAbstrakcyjna
             //deklaracja klasy BryłyObrotowe
            public class BryłyObrotowe : BryłaAbstrakcyjna
            {
                protected int PromieńBryły;
                //deklaracja konstruktora
                public BryłyObrotowe(int R, Color KolorLinii, DashStyle StylLinii, int GrubośćLinii, bool mbKierunekObrotu) :
                    base(KolorLinii, StylLinii, GrubośćLinii, mbKierunekObrotu)
                {
                    //zapisanie (przechowanie) promienia R
                    PromieńBryły = R;
                }
                //nadpisanie wszystkich metod abstrakcyjnych z klasy BryłaAbstrakcyjna
                public override void Wykreśl(Graphics Rysownica)
                {

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {

                }
                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float mbKątObrotu)
                {

                }
                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {

                }

            }//od BryłyObrotowe
             //deklaracja klasy potomnej Walec
            public class Walec : BryłyObrotowe
            {
                //deklaracja uzupełniająca dla bryły Walec
                Point[] WielokątPodłogi;
                Point[] WielokątSufitu;
                int XsS, YsS;
                //stopień wielokąta podstawy i sufitu Walca
                int StopieńWielokątaPodstawy;
                float Oś_Duża, Oś_Mała;
                //kąta środkowy między wierzchołkami wielokąta podstawy
                float KątMiędzyWierzchołkami;
                //kąt połozenie pierwszego wierzcołka wielokąta podstwy
                float KątPołożenie;
                //wektor przesunięcia środka sufitu pochylonego Walca
                int WektorPrzesunięciaSrodkaSufituWalca;
                //deklaracja konstuktora
                public Walec(int R, int WysokośćWalca, int StopieńWielokątaPodstawy,
                    int mbXsP, int mbYsP,/* int KątPochyleniaWalca,*/ Color KolorLinii, DashStyle StylLinii,
                    int GrubośćLinii, bool mbKierunekObrotu) : base(R, KolorLinii, StylLinii, GrubośćLinii, mbKierunekObrotu)
                {

                    this.mbXsP = mbXsP; this.mbYsP = mbYsP;
                    //ustawienie rodzaju bryły
                    RodzajBryły = TypyBrył.BG_Walec;
                    mbWysokośćBryły = WysokośćWalca;
                    this.StopieńWielokątaPodstawy = StopieńWielokątaPodstawy;
                    //wyznaczenie osi elipsy wykreślonej w podłodze i suficie Walca
                    Oś_Duża = 2 * PromieńBryły;//   2 * R
                    Oś_Mała = PromieńBryły / 2;//   R / 2
                                               //sprawdyenie kąta pochylenia Walca
                                               //if (KątPochyleniaWalca == KątProsty)
                                               //{
                                               //    XsS = mbXsP;
                                               //}
                                               //else
                                               //    MessageBox.Show("Sorry: Pracuje nad taką możliwością");
                    XsS = mbXsP;
                    YsS = mbYsP - WysokośćWalca;
                    //wyznaczenie pozostałych współrzędnych
                    //KątPochyleniaWalca = 360;
                    KątPołożenie = 0F;
                    //wyznaczenie współrzędnych punktów w podłoże i suficie walca dla wykreślienia
                    //prążków  na ścianie bocznej Walca
                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy + 1];
                    WielokątSufitu = new Point[StopieńWielokątaPodstawy + 1];
                    //utworzenie egzemlarzy punktów w podłoże i suficie oraz wpisanie do
                    //nich wyznaczonych współrzędnych na obwodzie elipsy
                    for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();
                        WielokątSufitu[i] = new Point();

                        //podłoga
                        WielokątPodłogi[i].X = (int)(mbXsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (mbKątPochylenia + i * KątMiędzyWierzchołkami) / 180F));
                        WielokątPodłogi[i].Y = (int)(mbYsP + Oś_Mała / 2 * Math.Cos(Math.PI *
                            (mbKątPochylenia + i * KątMiędzyWierzchołkami) / 180F));

                        //sufit: Walca
                        WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 * Math.Cos(Math.PI *
                            (KątPołożenie + KątMiędzyWierzchołkami) / 180F));
                        WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 * Math.Cos(Math.PI *
                            (KątPołożenie + KątMiędzyWierzchołkami) / 180F));

                    }
                }

                public override void Wykreśl(Graphics Rysownica)
                {
                    //utworzenie i sformatowanie Pióra
                    using (Pen mbPióro = new Pen(mbKolor_Linii, mbGrubość_Linii))
                    {
                        //ustalenie stylu linii
                        mbPióro.DashStyle = mbStyl_Linii;
                        //wykreślenie podłogi Walca
                        Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2,
                            mbYsP - Oś_Mała / 2,
                            Oś_Duża, Oś_Mała);
                        //wykreślenie "sufitu" Walca
                        Rysownica.DrawEllipse(mbPióro, XsS - Oś_Duża / 2,
                            YsS - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        using (Pen PióroPrążków = new Pen(mbPióro.Color, mbGrubość_Linii))
                        {
                            PióroPrążków.DashStyle = mbStyl_Linii;
                            for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                    WielokątSufitu[i]);
                            }
                        }
                        //wykreślenie krawędzi bocznych Walca
                        Rysownica.DrawLine(mbPióro, mbXsP - Oś_Duża / 2,
                            mbYsP, XsS - Oś_Duża / 2, YsS);
                        //wykreślenie prawej Krawędzi bocznej Walca
                        Rysownica.DrawLine(mbPióro, mbXsP + Oś_Duża / 2,
                            mbYsP, XsS + Oś_Duża / 2, YsS);
                        //odnotowanie
                        Widoczny = true;
                    }//koniec using i zwilnienie mbPióro

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    //utworzenie i sformatowanie Pióra
                    using (Pen mbPióro = new Pen(Kontrolka.BackColor, mbGrubość_Linii))
                    {

                        //ustalenie stylu linii
                        mbPióro.DashStyle = mbStyl_Linii;
                        //wykreślenie podłogi Walca
                        Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2,
                            mbYsP - Oś_Mała / 2,
                            Oś_Duża, Oś_Mała);
                        //wykreślenie "sufitu" Walca
                        Rysownica.DrawEllipse(mbPióro, XsS - Oś_Duża / 2,
                            YsS - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        using (Pen PióroPrążków = new Pen(mbPióro.Color, mbGrubość_Linii))
                        {
                            PióroPrążków.DashStyle = mbStyl_Linii;
                            for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                    WielokątSufitu[i]);
                            }
                        }
                        //wykreślenie krawędzi bocznych Walca
                        Rysownica.DrawLine(mbPióro, mbXsP - Oś_Duża / 2,
                            mbYsP, XsS - Oś_Duża / 2, YsS);
                        //wykreślenie prawej Krawędzi bocznej Walca
                        Rysownica.DrawLine(mbPióro, mbXsP + Oś_Duża / 2,
                            mbYsP, XsS + Oś_Duża / 2, YsS);
                        //odnotowanie
                        Widoczny = true;




                        ////ustalenie stylu linii
                        //mbPióro.DashStyle = mbStyl_Linii;
                        ////wykreślenie podłogi Walca
                        //Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2,
                        //    mbYsP - Oś_Mała / 2,
                        //    Oś_Duża, Oś_Mała);
                        ////wykreślenie "sufitu" Walca
                        //Rysownica.DrawEllipse(mbPióro, XsS - Oś_Duża / 2,
                        //    YsS - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        ////wykreślenie krawędzi bocznych Walca
                        //Rysownica.DrawLine(mbPióro, mbXsP - Oś_Duża / 2,
                        //    mbYsP, XsS - Oś_Duża / 2, YsS);
                        ////wykreślenie prawej Krawędzi bocznej Walca
                        //Rysownica.DrawLine(mbPióro, mbXsP + Oś_Duża / 2,
                        //    mbYsP, XsS + Oś_Duża / 2, YsS);
                        ////wykreślenie "prążków" na ścianie bocznej Walca
                        //for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        //{
                        //    Rysownica.DrawLine(mbPióro, WielokątPodłogi[i],
                        //        WielokątSufitu[i]);
                        //}

                        //Widoczny = false;
                    }
                }
                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float mbKątObrotu)
                {

                    //wymazanie bryły Walca w aktualnym jej położeniu
                    //if (Widoczny)
                    {
                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie nowego położenie dla pierwszego wierzchołka wpisanego w "podłogę"
                        if (mbKierunekObrotu)
                        {
                            KątPołożenie -= mbKątObrotu;
                        }
                        else
                            KątPołożenie += mbKątObrotu;
                        //wyznaczenie nowych współrzędnych wierzchołków wielokąta "podłogi" oraz "sufitu"
                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            //wierzchołki wielokąta  "podłogi"
                            WielokątPodłogi[i].X = (int)(mbXsP + Oś_Duża / 2 * Math.Cos(Math.PI *
                                (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                            WielokątPodłogi[i].Y = (int)(mbYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180F));

                            //wierzchołkami wielokąta "sufitu" po obrócenie o mbKątObrotu
                            WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 * Math.Cos(Math.PI *
                                (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                            WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                        }
                        //wykreślenie
                        Wykreśl(Rysownica);
                    }

                }//Obróć i Wykreśl

                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    //deklaracja pomocnicze
                    int dX, dY;
                    //wymazanie bryły Walec w aktualnym położeniu
                    if (Widoczny)
                        Wymaż(Kontrolka, Rysownica);
                    //wyznaczenie przyrostów zmiana współrzędnej X oraz Y
                    dX = mbXsP < X ? X - mbXsP : -(mbXsP - X);
                    dY = mbYsP < Y ? Y - mbYsP : -(mbYsP - Y);

                    //ustalenie nowego położenia dla "środków" podłogi i sufitu
                    mbXsP = mbXsP + dX;
                    mbYsP = mbYsP + dY;
                    XsS = XsS + dX;
                    YsS = YsS + dY;
                    //wyznaczenie nowego położenia wierzchołków wielokąta podłogi i sufitu
                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        //wierzchołki wielokąta  "podłogi"
                        WielokątPodłogi[i].X = (int)(mbXsP + Oś_Duża / 2 * Math.Cos(Math.PI *
                            (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));

                        WielokątPodłogi[i].Y = (int)(mbYsP + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180F));
                        //wierzchołkami wielokąta "sufitu" po obrócenie o mbKątObrotu
                        WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 * Math.Cos(Math.PI *
                            (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                        WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                    }
                    //wykreślenie bryły Walec w nowym położeniu
                    Wykreśl(Rysownica);
                }


            }

            public class Stożek : BryłyObrotowe
            {
                protected int XsS;
                protected int YsS; //wierzchołek Stożka
                protected int StopieńWielokątaPodstawy;
                //osie elipsy
                protected float Oś_Duża, Oś_Mała;
                //kąt środowy między wierzchołkami wielokąta podstawy Stożka
                protected float KątMiędzyWierzchołkami;
                protected float KątPołożeniaPierwszegoWierzchołkamiWielokąta;
                //deklaracja zmiennej tablicowej dla przechowania referencji egzemplarzy wierzchołków wielokąta
                protected Point[] WielokątPodłogi;
                //protected bool mbKierunekObrotu;
                //deklaracja konstruktora

                public Stożek(int R, int WysokośćStożka, int StopieńWielokąta, int mbXsP, int mbYsP,
                    Color mbKolor_Linii, DashStyle mbStyl_Linii, float mbGrubość_Linii, bool mbKierunekObrotu) :
                    base(R, mbKolor_Linii, mbStyl_Linii, (int)mbGrubość_Linii, mbKierunekObrotu)
                {
                    RodzajBryły = TypyBrył.BG_Stożek;
                    Widoczny = false;
                    //mbKierunekObrotu = false;
                    StopieńWielokątaPodstawy = StopieńWielokąta;
                    mbWysokośćBryły = WysokośćStożka;
                    this.mbXsP = mbXsP;
                    this.mbYsP = mbYsP;
                    XsS = mbXsP; YsS = mbYsP - WysokośćStożka;
                    //wyznaczenie osi dużej, osi małej
                    Oś_Duża = 2 * R;
                    Oś_Mała = R / 2;
                    //wyznaczenie kąta środkowego
                    KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                    KątPołożeniaPierwszegoWierzchołkamiWielokąta = 0F;
                    //utworzenie egzemplarza tablicy wierzchołkami wielokąta podstawy Stożka
                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy];


                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();
                        WielokątPodłogi[i].X = (int)(this.mbXsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                        WielokątPodłogi[i].Y = (int)(this.mbYsP + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                    }
                    //obliczenie pola powierzchni Stożka
                    // .  .  .
                    //obliczenie objętności Stożka
                    // .  .  .



                }//od konstruktora klasy Stożek


                //nadpisanie metod abstrakcyjnych
                public override void Wykreśl(Graphics Rysownica)
                {

                    using (Pen mbPióro = new Pen(mbKolor_Linii, mbGrubość_Linii))
                    {
                        mbPióro.DashStyle = mbStyl_Linii;
                        //wykreślenie podstawy ("podłogi") Stożka
                        Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2,
                        mbYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        //wykreślenie prążków (cienkich linii) na ścianie bocznej Stożka
                        using (Pen PióroPrążków = new Pen(mbPióro.Color, mbGrubość_Linii))
                        {
                            PióroPrążków.DashStyle = mbStyl_Linii;
                            for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                    new Point(XsS, YsS));
                            }
                        }//koniec using, czyli zwolnienie PióroPrążków
                         //wykreślenie krawędzi bocznych Stożka
                         //Rysownica.DrawLine(mbPióro, mbXsP + Oś_Duża / 2,
                         //    mbYsP, XsS, YsS);
                         //Rysownica.DrawLine(mbPióro, mbXsP - Oś_Duża / 2,
                         //    mbYsP, XsS, YsS);
                        Widoczny = true;
                    }//koniec using, czyli zwolnienie Pióra

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    if (Widoczny)
                    {
                        using (Pen mbPióro = new Pen(Kontrolka.BackColor, mbGrubość_Linii))
                        {
                            mbPióro.DashStyle = mbStyl_Linii;
                            //wykreślenie podstawy ("podłogi") Stożka
                            Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2,
                            mbYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                            //wykreślenie prążków (cienkich linii) na ścianie bocznej Stożka
                            using (Pen PióroPrążków = new Pen(mbPióro.Color, mbGrubość_Linii))
                            {
                                PióroPrążków.DashStyle = mbStyl_Linii;
                                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                                {
                                    Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                        new Point(XsS, YsS));
                                }
                            }//koniec using, czyli zwolnienie PióroPrążków
                             //wykreślenie krawędzi bocznych Stożka
                             //Rysownica.DrawLine(mbPióro, mbXsP + Oś_Duża / 2,
                             //    mbYsP, XsS, YsS);
                             //Rysownica.DrawLine(mbPióro, mbXsP - Oś_Duża / 2,
                             //    mbYsP, XsS, YsS);
                            Widoczny = false;

                        }//koniec using, czyli zwolnienie Pióra
                    }
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float mbKątObrotu)
                {
                    if (Widoczny)
                    {

                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie nowego kąta położenia dla pierwszego wielokąta wpisanego w  elipse, czyli 
                        if (mbKierunekObrotu)
                        {
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta -= mbKątObrotu;
                        }
                        else
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta += mbKątObrotu;
                        //wyznaczenie nowych współrzędnych położenia wierzchołków 
                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.mbXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.mbYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        Wykreśl(Rysownica);
                    }
                }//Obróć i Wykreśl
                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    //if (Widoczny)
                    {
                        int dX, dY;
                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie przyrostu dX oraz dY przesunięcia Stożka
                        dX = mbXsP < X ? X - mbXsP : -(mbXsP - X);
                        dY = mbYsP < Y ? Y - mbYsP : -(mbYsP - Y);
                        //ustalenie nowej lokalizacji Stożka
                        mbXsP = mbXsP + dX;
                        mbYsP = mbYsP + dY;
                        XsS = XsS + dX;
                        YsS = YsS + dY;
                        //wyznaczenie nowych współrzędnych wielokąta podstawy

                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.mbXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.mbYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        //wykreślenie Stożka w nowej lokalizacji
                        Wykreśl(Rysownica);
                    }
                }//od PrzesuńDoNowegoXY
            }//od klasy Stożek

            public class StożekPochylony : Stożek
            {
                public StożekPochylony(int R, int WysokośćStożka, int StopieńWielokąta,
                    int mbXsP, int mbYsP, float KątPochyleniaStożka,
                    Color mbKolor_Linii, DashStyle mbStyl_Linii, float mbGrubość_Linii, bool mbKierunekObrotu)
                    : base(R, WysokośćStożka, StopieńWielokąta, mbXsP, mbYsP,
                         mbKolor_Linii, mbStyl_Linii, (int)mbGrubość_Linii, mbKierunekObrotu)
                {
                    RodzajBryły = TypyBrył.BG_StożekPochylony;
                    Widoczny = false;
                    // mbKierunekObrotu = false;

                    //wyznaczenie współrzędnych wierzchołka Stożka przesuniętego względem
                    //środka podłogi Stożka
                    XsS = mbXsP + (int)(WysokośćStożka / Math.Tan(Math.PI * KątPochyleniaStożka / 180F));
                    YsS = mbYsP - WysokośćStożka;
                    //wyznaczenie osi dużej, osi małej
                    Oś_Duża = 2 * R;
                    Oś_Mała = R / 2;
                    //wyznaczenie kąta środkowego
                    KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                    KątPołożeniaPierwszegoWierzchołkamiWielokąta = 0F;
                    //utworzenie egzemplarza tablicy wierzchołkami wielokąta podstawy Stożka
                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy];


                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();

                        WielokątPodłogi[i].X = (int)(this.mbXsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                        WielokątPodłogi[i].Y = (int)(this.mbYsP + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                    }
                    //obliczenie pola powierzchni Stożka
                    // .  .  .
                    //obliczenie objętności Stożka
                    // .  .  .



                }//od konstruktora klasy Stożek


                //nadpisanie metod abstrakcyjnych
                public override void Wykreśl(Graphics Rysownica)
                {

                    using (Pen mbPióro = new Pen(mbKolor_Linii, mbGrubość_Linii))
                    {
                        mbPióro.DashStyle = mbStyl_Linii;
                        //wykreślenie podstawy ("podłogi") Stożka
                        Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2,
                        mbYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                        //wykreślenie prążków (cienkich linii) na ścianie bocznej Stożka
                        using (Pen PióroPrążków = new Pen(mbPióro.Color, mbGrubość_Linii))
                        {
                            PióroPrążków.DashStyle = mbStyl_Linii;
                            for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                    new Point(XsS, YsS));
                            }
                        }//koniec using, czyli zwolnienie PióroPrążków
                         //wykreślenie krawędzi bocznych Stożka
                         //Rysownica.DrawLine(mbPióro, mbXsP + Oś_Duża / 2,
                         //    mbYsP, XsS, YsS);

                        Widoczny = true;
                    }//koniec using, czyli zwolnienie Pióra

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    //if (Widoczny)
                    {
                        using (Pen mbPióro = new Pen(Kontrolka.BackColor, mbGrubość_Linii))
                        {
                            mbPióro.DashStyle = mbStyl_Linii;
                            //wykreślenie podstawy ("podłogi") Stożka
                            Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2,
                            mbYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);
                            //wykreślenie prążków (cienkich linii) na ścianie bocznej Stożka
                            using (Pen PióroPrążków = new Pen(mbPióro.Color, mbGrubość_Linii))
                            {
                                PióroPrążków.DashStyle = mbStyl_Linii;
                                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                                {
                                    Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i],
                                        new Point(XsS, YsS));
                                }
                            }//koniec using, czyli zwolnienie PióroPrążków
                             //wykreślenie krawędzi bocznych Stożka
                             //Rysownica.DrawLine(mbPióro, mbXsP + Oś_Duża / 2,
                             //    mbYsP, XsS, YsS);

                            //Rysownica.DrawLine(mbPióro, mbXsP + Oś_Duża / 2, mbYsP, XsS, YsS);

                            Widoczny = false;

                        }//koniec using, czyli zwolnienie Pióra
                    }
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float mbKątObrotu)
                {
                    //if (Widoczny)
                    {

                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie nowego kąta położenia dla pierwszego wielokąta wpisanego w  elipse, czyli 
                        if (mbKierunekObrotu)
                        {
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta -= mbKątObrotu;
                        }
                        else
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta += mbKątObrotu;
                        //wyznaczenie nowych współrzędnych położenia wierzchołków 
                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.mbXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.mbYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        Wykreśl(Rysownica);
                    }
                }//Obróć i Wykreśl
                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    // if (Widoczny)
                    {
                        int dX, dY;
                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie przyrostu dX oraz dY przesunięcia Stożka
                        dX = mbXsP < X ? X - mbXsP : -(mbXsP - X);
                        dY = mbYsP < Y ? Y - mbYsP : -(mbYsP - Y);
                        //ustalenie nowej lokalizacji Stożka
                        mbXsP = mbXsP + dX;
                        mbYsP = mbYsP + dY;
                        XsS = XsS + dX;
                        YsS = YsS + dY;
                        //wyznaczenie nowych współrzędnych wielokąta podstawy

                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.mbXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.mbYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        //wykreślenie Stożka w nowej lokalizacji
                        Wykreśl(Rysownica);
                    }
                }//od PrzesuńDoNowegoXY
            }

            public class StożekPodwójny : Stożek
            {

                public StożekPodwójny(int R, int WysokośćStożka, int StopieńWielokąta, int mbXsP, int mbYsP, Color KolorLinii, DashStyle StylLinii, int GruboscLinii, bool mbKierunekObrotu)
                    : base(R, WysokośćStożka, StopieńWielokąta, mbXsP, mbYsP, KolorLinii, StylLinii, GruboscLinii, mbKierunekObrotu)
                {
                    RodzajBryły = TypyBrył.BG_StożekPodwójny;
                    //Widoczny = false;
                    StopieńWielokątaPodstawy = StopieńWielokąta;
                    mbWysokośćBryły = WysokośćStożka;
                    this.mbXsP = mbXsP;
                    this.mbYsP = mbYsP;

                    XsS = mbXsP; YsS = mbYsP - WysokośćStożka;

                    //os duza i mala
                    Oś_Duża = 2 * R;
                    Oś_Mała = R / 2;

                    KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                    KątPołożeniaPierwszegoWierzchołkamiWielokąta = 0F;

                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy];

                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();

                        //podloga Stozka
                        WielokątPodłogi[i].X = (int)(mbXsP + Oś_Duża / 2 * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta + i * KątMiędzyWierzchołkami) / 180F));
                        WielokątPodłogi[i].Y = (int)(mbYsP + Oś_Mała / 2 * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta + i * KątMiędzyWierzchołkami) / 180F));
                    }

                    //obliczenia pola powierchni stozka
                    this.PowierzchiaBryły = (float)(Math.PI * (R * R) + (Math.PI * R * WysokośćStożka));
                    //obliczenie objetnosci
                    this.ObjętnośćBryły = (float)((Math.PI * (R * R) * WysokośćStożka) / 3);
                }

                public override void Wykreśl(Graphics Rysownica)
                {
                    using (Pen Pioro = new Pen(mbKolor_Linii, mbGrubość_Linii))
                    {
                        Pioro.DashStyle = mbStyl_Linii;

                        Rysownica.DrawEllipse(Pioro, mbXsP - Oś_Duża / 2, mbYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);

                        using (Pen PióroPrążków = new Pen(Pioro.Color, Pioro.Width / 2))
                        {
                            PióroPrążków.DashStyle = Pioro.DashStyle;

                            for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            {
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, YsS));
                                Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, mbYsP + mbWysokośćBryły));

                            }
                        }

                        //lewa gorna krawedz bocznej Stozka
                        Rysownica.DrawLine(Pioro, mbXsP - Oś_Duża / 2, mbYsP, XsS, YsS);
                        //prawa gorna krawedz bocznej Stozka
                        Rysownica.DrawLine(Pioro, mbXsP + Oś_Duża / 2, mbYsP, XsS, YsS);

                        //lewa dolna krawedz bocznej Stozka
                        Rysownica.DrawLine(Pioro, mbXsP - Oś_Duża / 2, mbYsP, XsS, mbYsP + mbWysokośćBryły);
                        //prawa dolna krawedz bocznej Stozka
                        Rysownica.DrawLine(Pioro, mbXsP + Oś_Duża / 2, mbYsP, XsS, mbYsP + mbWysokośćBryły);

                        Widoczny = true;
                    }
                }

                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    if (Widoczny)
                    {
                        using (Pen Pioro = new Pen(Kontrolka.BackColor, mbGrubość_Linii))
                        {
                            Pioro.DashStyle = mbStyl_Linii;

                            Rysownica.DrawEllipse(Pioro, mbXsP - Oś_Duża / 2, mbYsP - Oś_Mała / 2, Oś_Duża, Oś_Mała);

                            using (Pen PióroPrążków = new Pen(Pioro.Color, Pioro.Width / 2))
                            {
                                PióroPrążków.DashStyle = Pioro.DashStyle;

                                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                                {
                                    Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, YsS));
                                    Rysownica.DrawLine(PióroPrążków, WielokątPodłogi[i], new Point(XsS, mbYsP + mbWysokośćBryły));
                                }
                            }

                            //lewa krawedz bocznej Stozka
                            Rysownica.DrawLine(Pioro, mbXsP - Oś_Duża / 2, mbYsP, XsS, YsS);
                            //prawa krawedz bocznej Stozka
                            Rysownica.DrawLine(Pioro, mbXsP + Oś_Duża / 2, mbYsP, XsS, YsS);

                            //lewa dolna krawedz bocznej Stozka
                            Rysownica.DrawLine(Pioro, mbXsP - Oś_Duża / 2, mbYsP, XsS, mbYsP + mbWysokośćBryły);
                            //prawa dolna krawedz bocznej Stozka
                            Rysownica.DrawLine(Pioro, mbXsP + Oś_Duża / 2, mbYsP, XsS, mbYsP + mbWysokośćBryły);

                            Widoczny = false;
                        }
                    }
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float KatObrotu)
                {
                    if (Widoczny)
                    {
                        Wymaż(Kontrolka, Rysownica);

                        if (mbKierunekObrotu)
                        {
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta -= KatObrotu;
                        }
                        else
                        {
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta += KatObrotu;
                        }

                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                        {
                            //podloga Stozka
                            WielokątPodłogi[i].X = (int)(mbXsP + Oś_Duża / 2 * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta + i * KątMiędzyWierzchołkami) / 180F));
                            WielokątPodłogi[i].Y = (int)(mbYsP + Oś_Mała / 2 * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta + i * KątMiędzyWierzchołkami) / 180F));
                        }

                        //wykreslenia stozka po obrocie
                        Wykreśl(Rysownica);
                    }
                }
            }







            public class Wielościany : BryłaAbstrakcyjna
            {
                //dodatkowe deklaracje zmiennych dla opisu wspólnych atrybutów dla Wielościanów
                protected Point[] WielokątPodłogi;//podstawy Wielościanu
                protected Point[] WielokątSufitu;//sufitu Wielościanu
                protected int XsS, YsS;//środek "sufitu" Wielościanu
                protected int StopieńWielokątaPodstawy;
                protected int PromieńPodstawyWielościanu;
                //deklaracja konstruktora
                public Wielościany(int R, int StopieńWielokąta,
                    Color KolorLinii, DashStyle StylLinii,
                                float GrubośćLinii, bool mbKierunekObrotu) : base(KolorLinii, StylLinii, (int)GrubośćLinii, mbKierunekObrotu)
                {
                    PromieńPodstawyWielościanu = R;
                    StopieńWielokątaPodstawy = StopieńWielokąta;
                }
                //nadpisanie metod abstrakcyjnych
                public override void Wykreśl(Graphics Rysownica)
                {
                }

                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float mbKątObrotu)
                {
                }

                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                }

            }//od class Wielościan

            public class Graniastosłup : Wielościany
            {

                //deklaracja uzupewnienia dla klass 
                float Oś_Duża, Oś_Mała;
                //kąta środkowy między wierzchołkami wielokąta podstawy
                float KątMiędzyWierzchołkami;
                //kąt połozenie pierwszego wierzcołka wielokąta podstwy
                float KątPołożenie;
                //wektor przesunięcia środka sufitu pochylonego Walca
                int WektorPrzesunięciaSrodkaSufituWalca;
                //deklaracja konstuktora
                public Graniastosłup(int R, int WysokośćGraniastosłupa, int StopieńWielokątaPodstawy,
                    int mbXsP, int mbYsP, Color KolorLinii, DashStyle StylLinii,
                    int GrubośćLinii, bool mbKierunekObrotu) : base(R, StopieńWielokątaPodstawy, KolorLinii, StylLinii, GrubośćLinii, mbKierunekObrotu)
                {
                    //ustawienie rodzaju bryły
                    RodzajBryły = TypyBrył.BG_Graniastosłup;
                    mbWysokośćBryły = WysokośćGraniastosłupa;
                    this.StopieńWielokątaPodstawy = StopieńWielokątaPodstawy;

                    this.mbXsP = mbXsP; this.mbYsP = mbYsP;

                    XsS = mbXsP;
                    YsS = mbYsP - WysokośćGraniastosłupa;
                    //wyznaczenie osi elipsy wykreślonej w podłodze i suficie Walca
                    Oś_Duża = 2 * R;//   2 * R
                    Oś_Mała = R / 2;//   R / 2
                                    //wyznaczenie kąta 
                    KątMiędzyWierzchołkami = 360 / StopieńWielokątaPodstawy;
                    //wyznaczenie pozostałych współrzędnych
                    KątPołożenie = 0F;
                    //wyznaczenie współrzędnych punktów w podłoże i suficie walca dla wykreślienia
                    //prążków  na ścianie bocznej Walca
                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy + 1];
                    WielokątSufitu = new Point[StopieńWielokątaPodstawy + 1];
                    //wyznaczenie współrzędnych wierzchołka wielokąta wpisanego w elipsę "podłogi"
                    for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();
                        WielokątSufitu[i] = new Point();

                        //podłoga GraniaStosłupa
                        WielokątPodłogi[i].X = (int)(mbXsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (mbKątPochylenia + i * KątMiędzyWierzchołkami) / 180F));
                        WielokątPodłogi[i].Y = (int)(mbYsP + Oś_Mała / 2 * Math.Cos(Math.PI *
                            (mbKątPochylenia + i * KątMiędzyWierzchołkami) / 180F));


                        WielokątSufitu[i].X = WielokątPodłogi[i].X;
                        WielokątSufitu[i].Y = WielokątPodłogi[i].Y - WysokośćGraniastosłupa;
                        //sufit: Walca
                        //WielokątSufitu[i].X = (int)(XsS + Oś_Duża / 2 * Math.Cos(Math.PI *
                        //    (KątPołożenie + KątMiędzyWierzchołkami)) / 180F);
                        //WielokątSufitu[i].Y = (int)(YsS + Oś_Mała / 2 * Math.Cos(Math.PI *
                        //    (KątPołożenie + KątMiędzyWierzchołkami)) / 180F);

                    }
                }

                public override void Wykreśl(Graphics Rysownica)
                {
                    //utworzenie i sformatowanie Pióra
                    using (Pen mbPióro = new Pen(mbKolor_Linii, mbGrubość_Linii))
                    {
                        mbPióro.DashStyle = mbStyl_Linii;
                        //wykreślenie "podłogi" Graniasłupa
                        for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                            Rysownica.DrawLine(mbPióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);


                        for (int i = 0; i < WielokątSufitu.Length - 1; i++)
                            Rysownica.DrawLine(mbPióro, WielokątSufitu[i], WielokątSufitu[i + 1]);

                        for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                            Rysownica.DrawLine(mbPióro, WielokątPodłogi[i], WielokątSufitu[i]);


                        Widoczny = true;

                    }//koniec using i zwilnienie mbPióro

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    if (Widoczny)
                    {
                        //utworzenie i sformatowanie Pióra
                        using (Pen mbPióro = new Pen(Kontrolka.BackColor, mbGrubość_Linii))
                        {
                            mbPióro.DashStyle = mbStyl_Linii;
                            //wykreślenie "podłogi" Graniasłupa
                            for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                                Rysownica.DrawLine(mbPióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);

                            //wykreślenie "sufitu" Graniasłupa
                            for (int i = 0; i < WielokątSufitu.Length - 1; i++)
                                Rysownica.DrawLine(mbPióro, WielokątSufitu[i], WielokątSufitu[i + 1]);

                            //krawędz
                            for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                                Rysownica.DrawLine(mbPióro, WielokątPodłogi[i], WielokątSufitu[i]);

                            Widoczny = false;
                        }
                    }
                }
                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float mbKątObrotu)
                {

                    //wymazanie bryły Graniastosłup w aktualnym jej położeniu
                    if (Widoczny)
                    {
                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie nowego położenie dla pierwszego wierzchołka wpisanego w "podłogę"
                        if (mbKierunekObrotu)
                        {
                            KątPołożenie -= mbKątObrotu;
                        }
                        else
                            KątPołożenie += mbKątObrotu;
                        //wyznaczenie nowych współrzędnych wierzchołków wielokąta "podłogi" oraz "sufitu"
                        for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                        {
                            //wierzchołki wielokąta  "podłogi"
                            WielokątPodłogi[i].X = (int)(mbXsP + Oś_Duża / 2 * Math.Cos(Math.PI *
                                (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                            WielokątPodłogi[i].Y = (int)(mbYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180F));

                            //wierzchołkami wielokąta "sufitu" po obrócenie o mbKątObrotu
                            WielokątSufitu[i].X = WielokątPodłogi[i].X;
                            WielokątSufitu[i].Y = WielokątPodłogi[i].Y - mbWysokośćBryły;
                        }
                        //wykreślenie
                        Wykreśl(Rysownica);
                    }
                }//Obróć i Wykreśl

                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    //deklaracja pomocnicze
                    int dX, dY;
                    //wymazanie bryły Walec w aktualnym położeniu
                    //if (Widoczny)
                    {
                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie przyrostów zmiana współrzędnej X oraz Y
                        dX = mbXsP < X ? X - mbXsP : -(mbXsP - X);
                        dY = mbYsP < Y ? Y - mbYsP : -(mbYsP - Y);

                        //ustalenie nowego położenia dla "środków" podłogi i sufitu
                        mbXsP = mbXsP + dX;
                        mbYsP = mbYsP + dY;
                        XsS = XsS + dX;
                        YsS = YsS + dY;
                        //wyznaczenie nowego położenia wierzchołków wielokąta podłogi i sufitu
                        for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                        {
                            //wierzchołki wielokąta  "podłogi"
                            WielokątPodłogi[i].X = (int)(mbXsP + Oś_Duża / 2 * Math.Cos(Math.PI *
                                (KątPołożenie + i * KątMiędzyWierzchołkami) / 180));
                            WielokątPodłogi[i].Y = (int)(mbYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożenie + i * KątMiędzyWierzchołkami) / 180F));

                            //wierzchołkami wielokąta "sufitu" po obrócenie o mbKątObrotu
                            WielokątSufitu[i].X = WielokątPodłogi[i].X;
                            WielokątSufitu[i].Y = WielokątPodłogi[i].Y - mbWysokośćBryły;
                        }
                        //wykreślenie bryły Graniastosłup w nowym położeniu
                        Wykreśl(Rysownica);
                    }
                }


            }//od GraniaStosłupa



            public class Ostrosłup : Wielościany
            {

                //osie elipsy
                protected int Oś_Duża, Oś_Mała;
                //kąt środowy między wierzchołkami wielokąta podstawy Stożka
                protected float KątMiędzyWierzchołkami;
                protected float KątPołożeniaPierwszegoWierzchołkamiWielokąta;

                //deklaracja konstruktora
                public Ostrosłup(int R, int WysokośćOstrosłupa, int StopieńWielokąta, int mbXsP, int mbYsP,
                    Color mbKolor_Linii, DashStyle mbStyl_Linii, float mbGrubość_Linii, bool mbKierunekObrotu) :
                    base(R, StopieńWielokąta, mbKolor_Linii, mbStyl_Linii, mbGrubość_Linii, mbKierunekObrotu)
                {
                    RodzajBryły = TypyBrył.BG_Ostrosłup;
                    Widoczny = false;
                    //mbKierunekObrotu = false;
                    StopieńWielokątaPodstawy = StopieńWielokąta;
                    mbWysokośćBryły = WysokośćOstrosłupa;
                    this.mbXsP = mbXsP;
                    this.mbYsP = mbYsP;
                    XsS = mbXsP; YsS = mbYsP - WysokośćOstrosłupa;
                    //wyznaczenie osi dużej, osi małej
                    Oś_Duża = 2 * R;
                    Oś_Mała = R / 2;
                    //wyznaczenie kąta środkowego
                    KątMiędzyWierzchołkami = 360 / StopieńWielokąta;
                    KątPołożeniaPierwszegoWierzchołkamiWielokąta = 0F;
                    //utworzenie egzemplarza tablicy wierzchołkami wielokąta podstawy Stożka
                    WielokątPodłogi = new Point[StopieńWielokątaPodstawy + 1];


                    for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                    {
                        WielokątPodłogi[i] = new Point();
                        WielokątPodłogi[i].X = (int)(this.mbXsP + Oś_Duża / 2 *
                            Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                        WielokątPodłogi[i].Y = (int)(this.mbYsP + Oś_Mała / 2 *
                            Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                            i * KątMiędzyWierzchołkami) / 180F));

                    }
                    //obliczenie pola powierzchni Ostrosłupa
                    // .  .  .
                    //obliczenie objętności Ostrosłupa
                    // .  .  .



                }//od konstruktora klasy Ostrosłupa


                //nadpisanie metod abstrakcyjnych
                public override void Wykreśl(Graphics Rysownica)
                {

                    using (Pen mbPióro = new Pen(mbKolor_Linii, mbGrubość_Linii))
                    {
                        mbPióro.DashStyle = mbStyl_Linii;
                        //wykreślenie podstawy ("podłogi") Ostrosłupa
                        for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                            Rysownica.DrawLine(mbPióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);

                        //wykreślenie prążków (cienkich linii) na ścianie bocznej Ostrosłupa

                        for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                            Rysownica.DrawLine(mbPióro, WielokątPodłogi[i],
                                new Point(XsS, YsS));

                        //koniec using, czyli zwolnienie PióroPrążków
                        //wykreślenie krawędzi bocznych Stożka
                        //Rysownica.DrawLine(mbPióro, mbXsP + Oś_Duża / 2,
                        //    mbYsP, XsS, YsS);

                        Widoczny = true;
                    }//koniec using, czyli zwolnienie Pióra

                }
                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    if (Widoczny)
                    {

                        using (Pen mbPióro = new Pen(Kontrolka.BackColor, mbGrubość_Linii))
                        {
                            mbPióro.DashStyle = mbStyl_Linii;
                            //wymazanie podstawy ("podłogi") Ostrosłupa
                            for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                                Rysownica.DrawLine(mbPióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);

                            //wymazanie prążków (cienkich linii) na ścianie bocznej Ostrosłupa

                            for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                                Rysownica.DrawLine(mbPióro, WielokątPodłogi[i],
                                    new Point(XsS, YsS));

                            Widoczny = false;
                        }//koniec using, czyli zwolnienie Pióra

                        //koniec using, czyli zwolnienie Pióra
                    }
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float mbKątObrotu)
                {
                    if (Widoczny)
                    {

                        Wymaż(Kontrolka, Rysownica);
                        //wyznaczenie nowego kąta położenia dla pierwszego wielokąta wpisanego w  elipse, czyli 
                        if (mbKierunekObrotu)
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta -= mbKątObrotu;
                        else
                            KątPołożeniaPierwszegoWierzchołkamiWielokąta += mbKątObrotu;
                        //wyznaczenie nowych współrzędnych położenia wierzchołków 
                        for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.mbXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.mbYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        Wykreśl(Rysownica);
                    }
                }//Obróć i Wykreśl
                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    //if (Widoczny)
                    {
                        Wymaż(Kontrolka, Rysownica);
                        //ustawienie nowych współrzędnych
                        mbXsP = X; mbYsP = Y;
                        XsS = mbXsP; YsS = mbYsP - mbWysokośćBryły;

                        //wyznaczenie nowych współrzędnych wielokąta podstawy

                        for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                        {
                            WielokątPodłogi[i].X = (int)(this.mbXsP + Oś_Duża / 2 *
                                Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                            WielokątPodłogi[i].Y = (int)(this.mbYsP + Oś_Mała / 2 *
                                Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołkamiWielokąta +
                                i * KątMiędzyWierzchołkami) / 180F));

                        }
                        //wykreślenie Stożka w nowej lokalizacji
                        Wykreśl(Rysownica);
                    }
                }//od PrzesuńDoNowegoXY
            }//od klasy Ostrosłup


            public class Kula : BryłyObrotowe
            {
                float Oś_Duża, Oś_Mała;
                int PrzesunięcieObręczy;
                float KątPołożeniaObręczy;
                //konstruktor klasy Kula
                public Kula(int R, Point środekPodłogi, Color KolorLinii, DashStyle StylLinii,
                    float GrubośćLinii, bool mbKierunekObrotu) : base(R, KolorLinii, StylLinii, (int)GrubośćLinii, mbKierunekObrotu)
                {
                    RodzajBryły = TypyBrył.BG_Kula;
                    Widoczny = false;
                    //mbKierunekObrotu = false;
                    mbXsP = środekPodłogi.X;
                    mbYsP = środekPodłogi.Y;
                    Oś_Duża = R * 2;
                    Oś_Mała = R / 2;
                    KątPołożeniaObręczy = 0;
                    PrzesunięcieObręczy = 0;
                    //obliczenie objętości i pola powierzchni kuli
                    //objętność Kuli = 4 / 3 * Pi * r^3

                    this.ObjętnośćBryły = 4 / 3 * (float)Math.PI * ((Oś_Duża / 2) * (Oś_Duża / 2)
                        * (Oś_Duża / 2));
                    // pole Kuli = 4 * Pi * r^2
                    this.PowierzchiaBryły = 4 * (float)Math.PI * ((Oś_Duża / 2) * (Oś_Duża / 2));
                }

                public override void Wykreśl(Graphics Rysownica)
                {
                    Pen mbPióro = new Pen(mbKolor_Linii, mbGrubość_Linii);
                    Pen PióroObręczy = new Pen(mbPióro.Color, mbGrubość_Linii);
                    PióroObręczy.DashStyle = mbStyl_Linii;
                    mbPióro.DashStyle = mbStyl_Linii;
                    //wykreślenie okręgu
                    Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2, mbYsP - Oś_Mała / 2,
                        Oś_Duża, Oś_Duża);
                    //wykreślenie przekroju (elipsy) kuli wzłuż jego średnicy poziomej
                    Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2, mbYsP + Oś_Mała, Oś_Duża,
                        Oś_Mała);
                    //wykreślenie "obręczy" (która będzie obracana) pionowej
                    Rysownica.DrawEllipse(PióroObręczy, PrzesunięcieObręczy / 2 + mbXsP - Oś_Duża / 2,
                        mbYsP - Oś_Mała / 2, Oś_Duża - PrzesunięcieObręczy, Oś_Duża);
                    Widoczny = true;
                    //PióroObręczy.Dispose();
                    //mbPióro.Dispose();
                }

                public override void Wymaż(Control Kontrolka, Graphics Rysownica)
                {
                    Pen mbPióro = new Pen(Kontrolka.BackColor, mbGrubość_Linii);

                    Pen PióroObręczy = new Pen(mbPióro.Color, mbGrubość_Linii);
                    PióroObręczy.DashStyle = mbStyl_Linii;
                    mbPióro.DashStyle = mbStyl_Linii;
                    //wykreślenie okręgu
                    Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2, mbYsP - Oś_Mała / 2,
                        Oś_Duża, Oś_Duża);
                    //wykreślenie przekroju (elipsy) kuli wzłuż jego średnicy poziomej
                    Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2, mbYsP + Oś_Mała, Oś_Duża,
                        Oś_Mała);
                    //wykreślenie "obręczy" (która będzie obracana) pionowej
                    Rysownica.DrawEllipse(PióroObręczy, PrzesunięcieObręczy / 2 + mbXsP - Oś_Duża / 2,
                        mbYsP - Oś_Mała / 2, Oś_Duża - PrzesunięcieObręczy, Oś_Duża);
                    Widoczny = false;

                    //PióroObręczy.Dispose();
                    //mbPióro.Dispose();




                    //mbPióro.DashStyle = mbStyl_Linii;

                    //Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2, mbYsP - Oś_Mała / 2,
                    //    Oś_Duża, Oś_Duża);
                    //Rysownica.DrawEllipse(mbPióro, mbXsP - Oś_Duża / 2, mbYsP + Oś_Mała,
                    //    Oś_Duża, Oś_Mała);
                    //Rysownica.DrawEllipse(mbPióro, PrzesunięcieObręczy / 2 + mbXsP - Oś_Duża / 2,
                    //    mbYsP - Oś_Mała / 2, Oś_Duża - PrzesunięcieObręczy, Oś_Duża);
                    //Widoczny = false;
                    //mbPióro.Dispose();
                }

                public override void Obróć_i_Wykreśl(Control Kontrolka, Graphics Rysownica, float mbKątObrotu)
                {
                    KątPołożeniaObręczy = (KątPołożeniaObręczy + mbKątObrotu) % 360;

                    Wymaż(Kontrolka, Rysownica);
                    PrzesunięcieObręczy = (int)(KątPołożeniaObręczy % (int)(Oś_Duża)) * 2;
                    Wykreśl(Rysownica);
                }

                public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
                {
                    Wymaż(Kontrolka, Rysownica);
                    mbXsP = X;
                    mbYsP = Y;
                    Wykreśl(Rysownica);
                }
            }

       /* public class OstroslupPodwojny : Ostrosłup
        {
            public OstroslupPodwojny(int R, int mbWysokoscOstroslupa, int mbStopienWielokata, int mbXsP, int mbYsP, Color mbKolorLinii, DashStyle mbStylLinii, int mbGruboscLinii)
                : base(R, mbWysokoscOstroslupa, mbStopienWielokata, mbXsP, mbYsP, mbKolorLinii, mbStylLinii, mbGruboscLinii)
            {
                mbRodzajBryly = TypBryły.BG_StozekPodwojny;
                Widoczny = false;
                mbKierunekObrotu = false;
                mbWysokoscBryly = mbWysokoscOstroslupa;
                vStopienWielokataPodstawy = mbStopienWielokata;
                this.mbXsP = mbXsP; this.mbYsP =mb YsP;

                //wyznaczeniewspolzednych wierzcholka Ostroslupa
                XsS = XsP; YsS = YsP - dyWysokoscOstroslupa;

                Os_duza = 2 * R;
                Os_mala = R / 2;
                dyKatPolozeniaPierwszegoWierchowka = 0F;
                dyKatSrodkowyMiedzyWierchowkami = 360 / dyStopienWielokata;
                dyWielokatPodlogi = new Point[dyStopienWielokataPodstawy + 1];
            }

            public override void Wykreśl(Graphics dyPowierchniaGraficzna)
            {
                using (Pen Pioro = new Pen(mbKolorLinii, mbGruboscLinii))
                {
                    Pioro.DashStyle = mbStylLinii;

                    //wykreslenie podwogi
                    for (int i = 0; i < dyWielokatPodlogi.Length - 1; i++)
                    {
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], dyWielokatPodlogi[i + 1]);
                    }

                    //wykresleni krawedzi bocznych
                    for (int i = 0; i <= dyStopienWielokataPodstawy; i++)
                    {
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], new Point(XsS, YsS));
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], new Point(XsS, YsP + dyWysokoscBryly));
                    }

                    dyWidoczny = true;
                }
            }

            public override void dyWymaz(Control dyKontrolka, Graphics dyPowierchniaGraficzna)
            {
                using (Pen Pioro = new Pen(dyKontrolka.BackColor, dyGruboscLinii))
                {
                    Pioro.DashStyle = dyStylLinii;

                    //wykreslenie podwogi
                    for (int i = 0; i < dyWielokatPodlogi.Length - 1; i++)
                    {
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], dyWielokatPodlogi[i + 1]);
                    }

                    //wykresleni krawedzi bocznych
                    for (int i = 0; i <= dyStopienWielokataPodstawy; i++)
                    {
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], new Point(XsS, YsS));
                        dyPowierchniaGraficzna.DrawLine(Pioro, dyWielokatPodlogi[i], new Point(XsS, YsP + dyWysokoscBryly));
                    }

                    Widoczny = true;
                }
            }

            public override void dyObroc_i_Wykresl(Control dyKontrolka, Graphics dyPowierchniaGraficzna, float dyKatObrotu, bool dyKierunekObrotu)
            {
                if (Widoczny)
                {
                    dyWymaz(dyKontrolka, dyPowierchniaGraficzna);

                    if (dyKierunekObrotu)
                    {
                        dyKatPolozeniaPierwszegoWierchowka -= dyKatObrotu;
                    }
                    else
                    {
                        dyKatPolozeniaPierwszegoWierchowka += dyKatObrotu;
                    }

                    for (int i = 0; i <= dyStopienWielokataPodstawy; i++)
                    {
                        dyWielokatPodlogi[i].X = (int)(XsP + Os_duza / 2 * Math.Cos(Math.PI * (dyKatPolozeniaPierwszegoWierchowka + i * dyKatSrodkowyMiedzyWierchowkami) / 180));
                        dyWielokatPodlogi[i].Y = (int)(YsP + Os_mala / 2 * Math.Sin(Math.PI * (dyKatPolozeniaPierwszegoWierchowka + i * dyKatSrodkowyMiedzyWierchowkami) / 180));
                    }

                    dyWykresl(dyPowierchniaGraficzna);
                }
            }
        }*/
    }
    }

