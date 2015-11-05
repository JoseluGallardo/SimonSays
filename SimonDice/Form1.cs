// //  Copyright (c) 2015 José Luis del Pino Gallardo
// //  Nombre: SimonSays
// //  Versión: 1.0.1
// //  Fecha: 04/11/2015
// //  This program is free software: you can redistribute it and/or modify
// //  it under the terms of the GNU Lesser General Public License as published by
// //  the Free Software Foundation, either version 3 of the License, or
// //  (at your option) any later version.
// //
// //  This program is distributed in the hope that it will be useful,
// //  but WITHOUT ANY WARRANTY; without even the implied warranty of
// //  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// //  GNU Lesser General Public License for more details.
// //
// //  You should have received a copy of the GNU Lesser General Public License
// //  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace SimonDice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string cadena;
        public string usuario;
        int retardo = 500;
        int dificultad = 5;
        int level = 1;

        private void Generar()
        {
            cadena = string.Empty;
            usuario = string.Empty;

            lbl_Nivel.Text = "Nivel: " + level;
            start.Enabled = false;
            Random rnd = new Random();
            int num = 0;

            for (int i = 0; i < dificultad ; i++)
		    {
                num = rnd.Next(0, 4);
                cadena += num;

                switch (num)
                {
                    case 0:
                        Colorear(Color.DarkRed, Color.LightSalmon, button1);
                        break;
                    case 1:
                        Colorear(Color.DarkGreen, Color.LightGreen, button2);
                        break;
                    case 2:
                        Colorear(Color.MidnightBlue, Color.LightBlue, button3);
                        break;
                    case 3:
                        Colorear(Color.Gold, Color.Khaki, button4);
                        break;
                }
		    }

            Acertar();
        }

        private void Colorear(Color origen, Color nuevo, Button nBut)
        {
            Thread.Sleep(100);
            nBut.BackColor = nuevo;
            Application.DoEvents();
            Thread.Sleep(retardo);
            nBut.BackColor = origen;
            Application.DoEvents();
        }

        private void Acertar()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void DesactivarBot()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuario += 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuario += 1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            usuario += 2;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            usuario += 3;

        }

        private void start_Click(object sender, EventArgs e)
        {
            Generar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DesactivarBot();
            if (cadena == usuario)
            {
                MessageBox.Show("Has acertado! Enhorabuena");
                start.Enabled = true;
                button5.Enabled = false;
                dificultad++;
                retardo -= 50;
                level++;

            }
            else
            {
                MessageBox.Show("Has fallado! Inténtalo otra vez");
                start.Enabled = true;
                button5.Enabled = false;
                if (level > 1)
                {
                    dificultad--;
                    retardo += 50;
                    level--;
                }
                               
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Programa creado por José Luis del Pino Gallardo \nV1.0.1");
        }
    }
}
