using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        tabella[] riferimento = new tabella[16];
        tabella[] v = new tabella[16];
        int top;
        int left;
        int origine;

        struct tabella
        {
            public int Numero;
            public Button Bottone;
        }
       
        public Form1()
        {
            InitializeComponent();

            top = button5.Top - button1.Top;
            left = button2.Left - button1.Left;
            origine = button1.Top;

            Nonloso(riferimento);       //inizializza il record di riferimento
            Casual(riferimento, v);     //crea una serie casuale di 15 numeri su v
            Disponi(v);                 //dispone i bottoni secondo la serie casuale  
        }

        private void Disponi(tabella[] v)
        {
            v[0].Bottone.Location = new Point(origine, origine);
            v[1].Bottone.Location = new Point(origine + left, origine);
            v[2].Bottone.Location = new Point(origine + left * 2, origine);
            v[3].Bottone.Location = new Point(origine + left * 3, origine);
            v[4].Bottone.Location = new Point(origine, origine + top);
            v[5].Bottone.Location = new Point(origine + left, origine + top);
            v[6].Bottone.Location = new Point(origine + left * 2, origine + top);
            v[7].Bottone.Location = new Point(origine + left * 3, origine + top);
            v[8].Bottone.Location = new Point(origine, origine + top * 2);
            v[9].Bottone.Location = new Point(origine + left, origine + top * 2);
            v[10].Bottone.Location = new Point(origine + left * 2, origine + top * 2);
            v[11].Bottone.Location = new Point(origine + left * 3, origine + top * 2);
            v[12].Bottone.Location = new Point(origine, origine + top * 3);
            v[13].Bottone.Location = new Point(origine + left, origine + top * 3);
            v[14].Bottone.Location = new Point(origine + left * 2, origine + top * 3);
            v[15].Bottone.Location = new Point(origine + left * 3, origine + top * 3);
        }

        private void Nonloso(tabella[] riferimento)
        {                        
            riferimento[0].Bottone = button1;           
            riferimento[1].Bottone = button2;           
            riferimento[2].Bottone = button3;          
            riferimento[3].Bottone = button4;           
            riferimento[4].Bottone = button5;       
            riferimento[5].Bottone = button6;          
            riferimento[6].Bottone = button7;          
            riferimento[7].Bottone = button8;          
            riferimento[8].Bottone = button9;        
            riferimento[9].Bottone = button10;          
            riferimento[10].Bottone = button11;          
            riferimento[11].Bottone = button12;         
            riferimento[12].Bottone = button13;         
            riferimento[13].Bottone = button14;          
            riferimento[14].Bottone = button15;         
            riferimento[15].Bottone = invisibile_btn;
            for (int i = 0; i < riferimento.Length; i++)
                riferimento[i].Numero = i + 1;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int a = ((Button)sender).Top - invisibile_btn.Top;
            int b = ((Button)sender).Left - invisibile_btn.Left;

            if (a == top & b == 0 |         //controlla se la mossa è valida
                a == -top & b == 0 |
                a == 0 & b == left |
                a == 0 & b == -left)
            {
                int x = ((Button)sender).Top;
                int y = ((Button)sender).Left;
                ((Button)sender).Location = invisibile_btn.Location;
                invisibile_btn.Top = x;
                invisibile_btn.Left = y;

                if (button1.Top == origine & button1.Left == origine &
                    button2.Top == origine & button2.Left == origine + left &
                    button3.Top == origine & button3.Left == origine + left * 2 &
                    button4.Top == origine & button4.Left == origine + left * 3 &
                    button5.Top == origine + top & button5.Left == origine &
                    button6.Top == origine + top & button6.Left == origine + left &
                    button7.Top == origine + top & button7.Left == origine + left * 2 &
                    button8.Top == origine + top & button8.Left == origine + left * 3 &
                    button9.Top == origine + top * 2 & button9.Left == origine &
                    button10.Top == origine + top * 2 & button10.Left == origine + left &
                    button11.Top == origine + top * 2 & button11.Left == origine + left * 2 &
                    button12.Top == origine + top * 2 & button12.Left == origine + left * 3 &
                    button13.Top == origine + top * 3 & button13.Left == origine &
                    button14.Top == origine + top * 3 & button14.Left == origine + left &
                    button15.Top == origine + top * 3 & button15.Left == origine + left * 2)
                    MessageBox.Show("Complimenti, hai vinto!", "Powered by Falchi");
            }
        }

        void Casual(tabella [] riferimento,tabella [] v)
        {
            int control;
            v[15] = riferimento[15];
            for (int i = 0; i < v.Length - 1; i++)
                v[i].Numero = -1;
            Random asd = new Random();
            do
            {
                control = 0;
                for (int i = 0; i < v.Length - 1; i++)
                    if (v[i].Numero == -1)
                    {
                        int c = asd.Next(15);
                        v[i] = riferimento[c];
                    }
                for (int i = 0; i < v.Length - 1; i++)
                    for (int j = i + 1; j < v.Length - 1; j++)
                        if (v[j].Numero == v[i].Numero)
                        {
                            v[j].Numero = -1;
                            control++;
                        }
            }
            while (control > 0);
        }
    }
}
