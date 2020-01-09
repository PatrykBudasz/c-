using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kolko_krzyzyk
{
    public partial class kolko : Form
    {
        //TURA
        bool turn = true;

        //POCZĄTKOWA LICZBA KLIKNIĘĆ W PRZYCISK JEŚLI KLIKNIEMY WSZYSTKIE 9 W PÓŹNIEJSZYM ETAPIE ZOSTAJE POKAZANA WIADOMOŚĆ O TYM ŻE NIKT NIE WYGRAŁ
        int liczenie = 0;
        public kolko()
        {
            InitializeComponent();
        }

        //GRA ROZPOCZYNA SIĘ KOMUNIKATEM KOGO KOLEJ
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Tura gracza X", "Tura");
        }

     
        //OBSŁUGA W MENU OPCJI INFO
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stworzone przez: Patryk Budasz, Mikołaj Bosiacki", "Informacje");
        }

        //OBSŁUGA W MENU OPCJI EXIT
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //OBSŁUGA W MENU OPCJI NOWA GRA
        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

      

        private void klikniecie_przycisku(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            //WIADOMOŚĆ W MESSAGEBOXIE KOGO KOLEJ
            if (turn == true)
                MessageBox.Show("Tura gracza O", "Tura");
            else
                MessageBox.Show("Tura gracza X", "Tura");

            //ZMIANA GRACZA
            if (turn)       
                b.Text = "x";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            liczenie++;

            sprawdzanieZwyciezcy();
        }

        private void sprawdzanieZwyciezcy()
        {
            bool toZwyciezca = false;
            //WARIANTY KIEDY MOŻNA WYGRAĆ
            //POZIOMO
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                toZwyciezca = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                toZwyciezca = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                toZwyciezca = true;

            //PIONOWO
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                toZwyciezca = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                toZwyciezca = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                toZwyciezca = true;

            //NA SKOS
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                toZwyciezca = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                toZwyciezca = true;
            
            //SPRAWDZENIE KTÓRY GRACZ ZWYCIĘŻYŁ I CZY W OGÓLE KTOŚ WYGRAŁ
            if (toZwyciezca)
            {
                wylaczeniePrzyciskow();

                string zwyciezca = "";
                if (turn)
                    zwyciezca = "O";
                else
                    zwyciezca = "X";

                MessageBox.Show(zwyciezca + " wygrywa!", "Brawo");
            }
            else
            {
                if(liczenie == 9)
                    MessageBox.Show("Koniec gry, brak zwycięzcy :(", "Koniec");
            }


            //PO SKOŃCZENIU GRY RESZTA PRZYCISKÓW STAJE SIĘ NIEDOSTĘPNA
             void wylaczeniePrzyciskow()
            {
                try
                {
                    foreach (Control c in Controls)
                    {
                        Button b = (Button)c;
                        b.Enabled = false;

                    }
                }
                catch { }
            }
        }

    }
}
