using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace BinsouboryUkol3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            FileStream tok = new FileStream("texty.dat", FileMode.Open, FileAccess.Read);
            FileStream tok2 = new FileStream("textyopraveny.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader cteni = new BinaryReader(tok,Encoding.UTF8);
            BinaryWriter prepis = new BinaryWriter(tok2,Encoding.UTF8);
            /*prepis.Write("Ahoj.");
            prepis.Write("Přeji hezký den.");
            prepis.Write("Dnes je krásný den.");
            prepis.Write("Nevím++.");*/
            cteni.BaseStream.Position = 0;
            while(cteni.BaseStream.Position<cteni.BaseStream.Length)
            {
                string text = cteni.ReadString();
                listBox1.Items.Add(text);
                text = text.Replace('.', '!');
                prepis.Write(text);
            }
            cteni = new BinaryReader(tok2, Encoding.UTF8);
            cteni.BaseStream.Position = 0;
            while (cteni.BaseStream.Position < cteni.BaseStream.Length)
            {
                string text = cteni.ReadString();
                listBox2.Items.Add(text);
            }
            tok.Close();
            tok2.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Na disku je binární soubor texty.dat obsahující řetězce. Každý řetězec obsahuje věty ukončené tečkou. Opravte soubor texty.dat tak, aby všechny věty v jednotlivých řetězcích končily místo tečky znakem vykřičník. (Předpokládejte, že jiné tečky, než na konci vět se v řetězcích nevyskytují.) Původní i opravený soubor zobrazte.", "INFO");
        }
    }
}
