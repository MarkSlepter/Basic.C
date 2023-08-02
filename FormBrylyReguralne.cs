using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static OOP_PROJEKT.KlasyBrył_Geometrycznych;

namespace OOP_PROJEKT
{
    public partial class FormBrylyReguralne : Form
    {
        Graphics Rysownica, PowierzchniaGraficznaWziernikaLinii;

        
        List<BryłaAbstrakcyjna> LBG = new List<BryłaAbstrakcyjna>();

        Pen mbPióro;
        Point PunktLokalizacjiBryły = new Point(-1, -1);

        public Random Random { get; private set; }

        public FormBrylyReguralne()
        {
            InitializeComponent();


           

            // lokalizacja mbi zwymiarowanie formularza
          

            // ustalenie obramowania kontrolki PictureBox
            mbRysownica.BorderStyle = BorderStyle.FixedSingle;

            // utw. mapy bitowej mbi podpięcie jej do kontrolki PictureBox
            mbRysownica.Image = new Bitmap(mbRysownica.Width, mbRysownica.Height);

            // utw egz Rysownicy
            Rysownica = Graphics.FromImage(mbRysownica.Image);
            // utw egz Pióra

            mbPióro = new Pen(Color.Linen, 2F);
            mbPióro.DashStyle = DashStyle.Solid;

            // sformatowanie wziernikow

            pictureBoxWziernikKoloruWypełnienia.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxWziernikKoloruWypełnienia.BackColor = mbRysownica.BackColor;

            pictureBoxWziernikKoloruLinii.Image = new Bitmap(pictureBoxWziernikKoloruLinii.Width, pictureBoxWziernikKoloruLinii.Height);
            PowierzchniaGraficznaWziernikaLinii = Graphics.FromImage(pictureBoxWziernikKoloruLinii.Image);


            

            WykreślenieWziernikaLinii();


        }

        // deklaracja metody pomocniczej
        void WykreślenieWziernikaLinii()
        {
            const int mbOdstęp = 5;
            PowierzchniaGraficznaWziernikaLinii.Clear(pictureBoxWziernikKoloruLinii.BackColor);

            // wykreślenie linii
            PowierzchniaGraficznaWziernikaLinii.DrawLine(mbPióro, mbOdstęp, pictureBoxWziernikKoloruLinii.Height / 2, pictureBoxWziernikKoloruLinii.Width
                - 2 * mbOdstęp, pictureBoxWziernikKoloruLinii.Height / 2);

            pictureBoxWziernikKoloruLinii.Refresh();
        }

        private void buttonPowrótDoMenu_Click(object sender, EventArgs e)
        {
            // showanie formularzu
            Hide();

            FormMenu form1 = new FormMenu();


            form1.Show();
        }

        private void FormBrylyReguralne_Load(object sender, EventArgs e)
        {
            
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //wymazanie "punktu" lokalizacji dla nowej bryły

            using (SolidBrush Pędzel = new SolidBrush(mbRysownica.BackColor))
                Rysownica.FillEllipse(Pędzel, PunktLokalizacjiBryły.X - 3,
                                            PunktLokalizacjiBryły.Y - 3, 6, 6);


            //pobranie atrybutów ustawionych dla wybranej bryły
            int mbWysokośćBryły = trackBarWysokośćBryły.Value;
            int mbPromieńBryły = trackBarPromieńBryły.Value;
            int mbStopieńWielokąta = (int)numericUpDownStopieńWielokąta.Value;
            float mbKątPochylenia = trackBarPromieńBryły.Value;
            int XsP = PunktLokalizacjiBryły.X;
            int YsP = PunktLokalizacjiBryły.Y;
            Point środekPodłogi = new Point(XsP, YsP);
            //stan obrotu
            bool mbKierunekObrotu;
            mbKierunekObrotu = radioButtonWprawo.Checked == true ? false : true;
            //rozpoznanie wybranej bryły
            switch (comboBoxListaBrył.SelectedItem)
            {
                case "Walec":
                    Walec EgzemplarzWalca = new Walec(mbPromieńBryły,
                        mbWysokośćBryły, mbStopieńWielokąta, XsP,
                        YsP, mbPióro.Color, mbPióro.DashStyle, (int)mbPióro.Width, mbKierunekObrotu);
                    EgzemplarzWalca.Wykreśl(Rysownica);
                    //dodanie nowego egzemplarza Walca do listy LBG
                    LBG.Add(EgzemplarzWalca);
                    break;


                case "Stożek":
                   
                    Stożek EgzemplarzStożka = new Stożek(mbPromieńBryły,
                        mbWysokośćBryły, mbStopieńWielokąta, XsP,
                        YsP, mbPióro.Color, mbPióro.DashStyle, mbPióro.Width, mbKierunekObrotu);
                    //dodanie referencji egzemplarza Stożka do listy
                    EgzemplarzStożka.Wykreśl(Rysownica);
                    LBG.Add(EgzemplarzStożka);
                    break;
                case "Stożek pochylony":
                    StożekPochylony EgzemplarzStożkaPochylonego =
                        new StożekPochylony(mbPromieńBryły,
                        mbWysokośćBryły, mbStopieńWielokąta, XsP,
                        YsP, mbKątPochylenia, mbPióro.Color, mbPióro.DashStyle, mbPióro.Width, mbKierunekObrotu);
                    //wykreślenie
                    EgzemplarzStożkaPochylonego.Wykreśl(Rysownica);
                    //dodanie referencji egzemplarza Stożka do listy
                    LBG.Add(EgzemplarzStożkaPochylonego);
                    break;

                case "Graniastosłup":
                    Graniastosłup EgzemplarzGraniaStosłupa = new Graniastosłup(mbPromieńBryły, mbWysokośćBryły,
                        mbStopieńWielokąta, XsP, YsP, mbPióro.Color, mbPióro.DashStyle, (int)mbPióro.Width, mbKierunekObrotu);
                    EgzemplarzGraniaStosłupa.Wykreśl(Rysownica);
                    LBG.Add(EgzemplarzGraniaStosłupa);

                    break;
                case "Ostrosłup":
                    Ostrosłup EgzemplarzOstrosłupa = new Ostrosłup(mbPromieńBryły, mbWysokośćBryły, mbStopieńWielokąta, XsP, YsP,
                                        mbPióro.Color, mbPióro.DashStyle, mbPióro.Width, mbKierunekObrotu);
                    EgzemplarzOstrosłupa.Wykreśl(Rysownica);
                    LBG.Add(EgzemplarzOstrosłupa);
                    break;
                case "Kula":
                    Kula EgzemplarzKula = new Kula(mbPromieńBryły, środekPodłogi, mbPióro.Color, mbPióro.DashStyle, mbPióro.Width, mbKierunekObrotu);
                    EgzemplarzKula.Wykreśl(Rysownica);
                    LBG.Add(EgzemplarzKula);
                    break;

                case "Podwójny stożek":
                    StożekPodwójny EgzemplarzStożkaPodwójnego = new StożekPodwójny(mbPromieńBryły, mbWysokośćBryły, mbStopieńWielokąta, XsP, YsP,
                    mbPióro.Color, mbPióro.DashStyle, (int)mbPióro.Width, mbKierunekObrotu);
                    EgzemplarzStożkaPodwójnego.Wykreśl(Rysownica);
                    LBG.Add(EgzemplarzStożkaPodwójnego);
                    break;
              /*  case "Ostrosłup podwójny":
                    OstroslupPodwojny EgzemplarzOstroslupaPodwojnego = new OstroslupPodwojny(mbPromienbryly, mbWysokoscBryly, mbStopienWielokata, XsP, YsP, mbPioro.Color, mbPioro.DashStyle, mbGruboscLinii.Value);
                    //dodanie figury do listy
                    LBG.Add(EgzemplarzOstroslupaPodwojnego);
                    //wykreslenie kuli
                    EgzemplarzOstroslupaPodwojnego.dyWykresl(mbRysownica);*/

                default:
                    MessageBox.Show("Nad tą bryła jeszcze pracuję! Wybierz inną!");
                    break;
            }
            Refresh();
           // ZegarObrotu.Enabled = true;

        }

        private void ZegarObrotu_Tick(object sender, EventArgs e)
        {
            float mbKąt = trackBarSzybkośćObrotu.Value;
            float mbKątObrotu = radioButtonWprawo.Checked == true ? mbKąt : -mbKąt;
            //obramy wszystkie bryły w lBG w mbKąt mbKątObrotu
            for (int mbi = 0; mbi < LBG.Count; mbi++)
            {
                LBG[mbi].Obróć_i_Wykreśl(mbRysownica, Rysownica, mbKątObrotu);
            }
            mbRysownica.Refresh();
        }

        private void comboBoxListaBrył_SelectedIndexChanged(object sender, EventArgs e)
        {


            if ((comboBoxListaBrył.SelectedItem == "Walec") || (comboBoxListaBrył.SelectedItem == "Stożek")
                || (comboBoxListaBrył.SelectedItem == "Graniastosłup") || (comboBoxListaBrył.SelectedItem == "Ostrosłup" || (comboBoxListaBrył.SelectedItem == "Podwójny stożek")))
            {
                //uaktywnienie kontrolek dla ustawienie atrybutów geometrycznych
                trackBarWysokośćBryły.Enabled = true;
                trackBarPromieńBryły.Enabled = true;
                numericUpDownStopieńWielokąta.Enabled = true;
            }
            else
            if (comboBoxListaBrył.SelectedItem == "Kula")
            {
                trackBarPromieńBryły.Enabled = true;
            }
            else//np. dla brył pochyłych powinniśmy uaktywnić kontrolkę ustawienie kąta pochylenie
            if (comboBoxListaBrył.SelectedItem == "Stożek pochylony")
            {
                trackBarWysokośćBryły.Enabled = true;
                trackBarPromieńBryły.Enabled = true;
                numericUpDownStopieńWielokąta.Enabled = true;
                trackBarKątPochylenia.Enabled = true;
                trackBarKątPochylenia.Value = 90;
            }
            comboBoxListaBrył.Text = "Wybierz nową bryłę";
            numericUpDownStopieńWielokąta.Value = 3;
            trackBarWysokośćBryły.Value = trackBarWysokośćBryły.Maximum / 2;
            trackBarPromieńBryły.Value = trackBarPromieńBryły.Maximum / 2;
            trackBarKątPochylenia.Value = 90; //hz
        }

        private void mbRysownica_MouseClick(object sender, MouseEventArgs e)
        {
            //zaznaczony punkt wykreślamy o możliwie małych rozmiarach
            using (SolidBrush Pędzel = new SolidBrush(Color.Red))
            {
                if (PunktLokalizacjiBryły.X != -1)
                {
                    //wymazanie ustalonego wcześniej położenia bryły
                    Pędzel.Color = mbRysownica.BackColor;
                    //wykreślenie punktu "kontrolnego"
                    Rysownica.FillEllipse(Pędzel, PunktLokalizacjiBryły.X - 3,
                        PunktLokalizacjiBryły.Y - 3, 6, 6);

                    //przywrócenie "pirwotnego" (ustawionego w nagłówku instrukcji "using")
                    //koloru Pędzla
                    Pędzel.Color = Color.DarkSlateBlue;

                }
                //przechowanie współrzędnych miejsca kliknięcia lewym przyciskiem
                PunktLokalizacjiBryły = e.Location;
                //wykreślenie punktu "kontrolnego"
                Rysownica.FillEllipse(Pędzel, PunktLokalizacjiBryły.X - 3,
                    PunktLokalizacjiBryły.Y - 3, 6, 6);
                //uaktywnie przycisku Dodaj Nową Bryłę
                buttonDodajNowąBryłę.Enabled = true;
                mbRysownica.Refresh();
            }
        }

        private void trackBarSzybkośćObrotu_Scroll(object sender, EventArgs e)
        {
            labelSzybkość.Text = trackBarSzybkośćObrotu.Value.ToString();
        }

        private void buttonConfijOstatniąFigurę_Click(object sender, EventArgs e)
        {
            if (LBG.Count == 0)
            {
                MessageBox.Show("Nic nie masz w liscie figur. Najpierw dodaj figurę");
                return;
            }
            LBG[LBG.Count - 1].Wymaż(mbRysownica, Rysownica);
            LBG.RemoveAt(LBG.Count - 1);
            mbRysownica.Refresh();
        }

        private void buttonWłaczPokazFigur_Click(object sender, EventArgs e)
        {
            if (LBG.Count == 0)
            {
                MessageBox.Show("Nie masz brył na Rysownicę");
                return;
            }



            if (radioButtonManual.Checked)

                //wpisanie do pola timer.Tag indeksu figury do prezentacji
                ZegarPokazu.Tag = 0;
            //wyczyszczenie Rysownicy
            //Rysownica.Clear(pbRysownica.BackColor);
            for (int mbi = 0; mbi < LBG.Count; mbi++)
                LBG[mbi].Wymaż(mbRysownica, Rysownica);

            ZegarObrotu.Enabled = false;
            //sprawdzenie wybranego trybu prezentacji figur geometrycznych
            if (radioButtonAuto.Checked)
            {
                //włączenie zegarа
                ZegarPokazu.Enabled = true;
                radioButtonManual.Enabled = false;

            }
            else
            {
                //określenie rozmiarów Rysownicy
                int mbXmax = mbRysownica.Width;
                int mbYmax = mbRysownica.Height;
                //wykreślenie pośrodku Rysownicy figury geometrycznej, której indeks
                // w tablicy LFG został wpisany do pola Tag zegara: timer1
                LBG[0].PrzesuńDoNowegoXY(mbRysownica, Rysownica,
                                                        mbXmax / 2, mbYmax / 2);
                // 0 to zawartość pola edycyjnego kontrolki txtIndexFigury
                //uaktywnienie przycisków poleceń dla prezentacji Manualnej
                buttonNastępny.Enabled = true;
                buttonPoprzedni.Enabled = true;
                radioButtonAuto.Enabled = false;
            }
            //odswizenie Rys
            mbRysownica.Refresh();
            //ustawienie stanu braku aktywności dla obsługiwanego przycisku poleceń
            buttonWłaczPokazFigur.Enabled = false;
            //ustawienie stanu braku aktywności dla przycisku poleceń
            buttonWyłaczPokazFigur.Enabled = true;
            buttonConfijOstatniąFigurę.Enabled = false;
            buttonDodajNowąBryłę.Enabled = false;
        }

        private void buttonWyłaczPokazFigur_Click(object sender, EventArgs e)
        {

            ZegarObrotu.Enabled = true;
            Rysownica.Clear(mbRysownica.BackColor);
            ZegarPokazu.Enabled = false;
            int mbXmax = mbRysownica.Width;
            int mbYmax = mbRysownica.Height;
            int Xp, Yp;
            Random rsLiczbaLosowa = new Random();
            for (int mbi = 0; mbi < LBG.Count; mbi++)
            {
                Xp = rsLiczbaLosowa.Next(20, mbXmax - 20);
                Yp = rsLiczbaLosowa.Next(20, mbYmax - 20);
                LBG[mbi].PrzesuńDoNowegoXY(mbRysownica, Rysownica, Xp, Yp);
            }
            mbRysownica.Refresh();
            buttonWłaczPokazFigur.Enabled = true;
            buttonWyłaczPokazFigur.Enabled = false;
            textBoxNumerBryły.ReadOnly = false;
            buttonNastępny.Enabled = false;
            buttonPoprzedni.Enabled = false;
            textBoxNumerBryły.Text = "0";
            errorProvider1.Dispose();
            radioButtonAuto.Enabled = true;
            radioButtonManual.Enabled = true;
            buttonConfijOstatniąFigurę.Enabled = true;
            buttonDodajNowąBryłę.Enabled = true;
        }

        private void ZegarPokazu_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ZegarPokazu.Tag) == LBG.Count)
                ZegarPokazu.Tag = 0;

            int mbXmax = mbRysownica.Width;
            int mbYmax = mbRysownica.Height;

            for (int mbi = 0; mbi < LBG.Count; mbi++)
                LBG[mbi].Wymaż(mbRysownica, Rysownica);


            LBG[Convert.ToInt32(ZegarPokazu.Tag)].Wykreśl(Rysownica);
            LBG[Convert.ToInt32(ZegarPokazu.Tag)].PrzesuńDoNowegoXY(mbRysownica, Rysownica, mbXmax / 2, mbYmax / 2);

            ZegarPokazu.Tag = (Convert.ToInt32(ZegarPokazu.Tag) + 1);

            mbRysownica.Refresh();

        }

        private void buttonPoprzedni_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            int mbIndexFigury = int.Parse(textBoxNumerBryły.Text);
            mbIndexFigury--;
            textBoxNumerBryły.Text = mbIndexFigury.ToString();
            LBG[mbIndexFigury + 1].Wymaż(mbRysownica, Rysownica);
            if (mbIndexFigury < 0)
            {
                errorProvider1.SetError(textBoxNumerBryły, "Niedostępna bryła");
                mbIndexFigury++;
                textBoxNumerBryły.Text = mbIndexFigury.ToString();
                return;
            }
            int mbXmax = mbRysownica.Width;
            int mbYmax = mbRysownica.Height;
            //mbIndexFigury = int.Parse(txtNumerBryły.Text);
            LBG[mbIndexFigury].PrzesuńDoNowegoXY(mbRysownica, Rysownica, mbXmax / 2, mbYmax / 2);
            //txtIndexFigury.Text = timer1.Tag.ToString();
            mbRysownica.Refresh();
        }

        private void buttonNastępny_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            int mbIndexFigury = int.Parse(textBoxNumerBryły.Text);
            mbIndexFigury++;
            textBoxNumerBryły.Text = mbIndexFigury.ToString();
            LBG[mbIndexFigury - 1].Wymaż(mbRysownica, Rysownica);
            if (mbIndexFigury > LBG.Count - 1)
            {
                errorProvider1.SetError(textBoxNumerBryły, "Niedostępna bryła");
                mbIndexFigury--;
                textBoxNumerBryły.Text = mbIndexFigury.ToString();
                return;
            }
            int mbXmax = mbRysownica.Width;
            int mbYmax = mbRysownica.Height;
            //mbIndexFigury = int.Parse(txtNumerBryły.Text);
            LBG[mbIndexFigury].PrzesuńDoNowegoXY(mbRysownica, Rysownica, mbXmax / 2, mbYmax / 2);
            //txtIndexFigury.Text = timer1.Tag.ToString();
            mbRysownica.Refresh();
        }
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (LBG.Count == 0)
            {
                MessageBox.Show("Nic nie masz w liscie figur. Najpierw dodaj figurę");
                return;
            }
            LBG[0].Wymaż(mbRysownica, Rysownica);
            LBG.RemoveAt(0);
            mbRysownica.Refresh();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            int mbIndexFigury = int.Parse(textBoxCofnijWybranąBryłę.Text);
            mbIndexFigury++;
            textBoxCofnijWybranąBryłę.Text = mbIndexFigury.ToString();

            if (mbIndexFigury > LBG.Count - 1)
            {
                btnPlus.Enabled = true;
                mbIndexFigury--;
                textBoxCofnijWybranąBryłę.Text = mbIndexFigury.ToString();
                return;
            }
            if (buttonMinus.Enabled == false)
                btnPlus.Enabled = true;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            int mbIndexFigury = int.Parse(textBoxCofnijWybranąBryłę.Text);
            mbIndexFigury--;
            textBoxCofnijWybranąBryłę.Text = mbIndexFigury.ToString();
            if (mbIndexFigury < 0)
            {
                mbIndexFigury++;
                textBoxCofnijWybranąBryłę.Text = mbIndexFigury.ToString();
                return;
            }
            if (mbIndexFigury > LBG.Count - 1)
            {
                btnPlus.Enabled = true;
                mbIndexFigury++;
                textBoxCofnijWybranąBryłę.Text = mbIndexFigury.ToString();
                return;
            }

            if (btnPlus.Enabled == false)
                buttonMinus.Enabled = true;
        }

        private void buttonCofnijWybranąBryłę_Click(object sender, EventArgs e)
        {
            if (LBG.Count == 0)
            {
                MessageBox.Show("Nie masz żadnej bryły na Rysownicę!");
                return;
            }

            LBG[int.Parse(textBoxCofnijWybranąBryłę.Text)].Wymaż(mbRysownica, Rysownica);
            LBG.RemoveAt(int.Parse(textBoxCofnijWybranąBryłę.Text));

            textBoxCofnijWybranąBryłę.Text = "0";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult Wynik = MessageBox.Show("Czy chczesz zamknić program ?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (Wynik == DialogResult.Yes)
                Application.Exit();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int dl_GruboscLinii;
            Color dl_KolorLinii;
            DashStyle dl_StylLinii;
            Rysownica.Clear(mbRysownica.BackColor);
            Random = new Random();
            for (int mbi = 0; mbi < LBG.Count; mbi++)
            {
                dl_KolorLinii = Color.FromArgb(Random.Next(0, 255), Random.Next(0, 255), Random.Next(0, 255));
                switch (Random.Next(1, 6))
                {
                    case 1:
                        dl_StylLinii = DashStyle.Dash;
                        break;
                    case 2:
                        dl_StylLinii = DashStyle.Dot;
                        break;
                    case 3:
                        dl_StylLinii = DashStyle.Solid;
                        break;
                    case 4:
                        dl_StylLinii = DashStyle.DashDot;
                        break;
                    case 5:
                        dl_StylLinii = DashStyle.DashDotDot;
                        break;
                    default:
                        dl_StylLinii = DashStyle.Solid;
                        break;
                }
                dl_GruboscLinii = Random.Next(1, 6);
                LBG[mbi].UstalAtrybutyGraficzne(dl_KolorLinii, dl_StylLinii, dl_GruboscLinii);
            }
            for (int dl_i = 0; dl_i < LBG.Count; dl_i++)
            {
                LBG[dl_i].Wykreśl(Rysownica);
            }
            mbRysownica.Refresh();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int mbXmax = mbRysownica.Width;
            int mbYmax = mbRysownica.Height;
            Random = new Random();
            Rysownica.Clear(mbRysownica.BackColor);
            for (int mbi = 0; mbi < LBG.Count; mbi++)
            {
                int dl_WspolrzednaXPodlogiBryly = Random.Next(0, mbXmax);
                int dl_WspolrzednaYPodlogiBryly = Random.Next(0, mbYmax);

                LBG[mbi].PrzesuńDoNowegoXY(mbRysownica, Rysownica, dl_WspolrzednaXPodlogiBryly, dl_WspolrzednaYPodlogiBryly);
            }
            mbRysownica.Refresh();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LBG.Count == 0)
            {
                MessageBox.Show("Nie masz żadnej bryły na Rysownicę!");
                return;
            }

            for (int mbi = 0; mbi < LBG.Count; mbi++)
            {
                LBG[mbi].Wymaż(mbRysownica, Rysownica);
            }

            LBG.RemoveRange(0, LBG.Count);
            Refresh();
        }

        private void kolorLiniibryłyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog PaletaKolorów = new ColorDialog();
            PaletaKolorów.Color = mbPióro.Color;
            if (PaletaKolorów.ShowDialog() == DialogResult.OK)
            {
                mbPióro.Color = PaletaKolorów.Color;
            }
            //uaktualnienie Wziernika linii
            WykreślenieWziernikaLinii();
            //zwolnienie okna Dialogowego
            PaletaKolorów.Dispose();
        }

        private void dotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mbPióro.DashStyle = DashStyle.Dot;
            WykreślenieWziernikaLinii();
        }

        private void dashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mbPióro.DashStyle = DashStyle.Dash;
            WykreślenieWziernikaLinii();
        }

        private void dashDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mbPióro.DashStyle = DashStyle.DashDot;
            WykreślenieWziernikaLinii();
        }

        private void dashDotDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mbPióro.DashStyle = DashStyle.DashDotDot;
            WykreślenieWziernikaLinii();
        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mbPióro.DashStyle = DashStyle.Solid;
            WykreślenieWziernikaLinii();
        }

        private void zapiszBitmapWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    mbRysownica.Image.Save(saveFileDialog.FileName);
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            mbPióro.Width = 1F;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            mbPióro.Width = 2F;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            mbPióro.Width = 3F;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            mbPióro.Width = 4F;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            mbPióro.Width = 5F;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            mbPióro.Width = 6F;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            mbPióro.Width = 7F;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            mbPióro.Width = 8F;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            mbPióro.Width = 9F;
            WykreślenieWziernikaLinii();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            mbPióro.Width = 10F;
            WykreślenieWziernikaLinii();
        }

        private void kolortłaRysownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog PaletaKolorów = new ColorDialog();
            //PaletaKolorów = mbPióro.Color;
            if (PaletaKolorów.ShowDialog() == DialogResult.OK)
            {
                mbRysownica.BackColor = PaletaKolorów.Color;
                pictureBoxWziernikKoloruWypełnienia.BackColor = PaletaKolorów.Color;
            }

            //zwolnienie okna Dialogowego
            PaletaKolorów.Dispose();
            mbRysownica.Refresh();
        }

        private void trackBarWysokośćBryły_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBarPromieńBryły_Scroll(object sender, EventArgs e)
        {

        }

        private void mbRysownica_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNumerBryły_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
