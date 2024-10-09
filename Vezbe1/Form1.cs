using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vezbe1
{
    public partial class Form1 : Form
    {

        private int redoviPrve;
        private int redoviDruge;
        private int kolonePrve;
        private int koloneDruge;
        private int[,] matrica1;
        private int[,] matrica2;
        private int zbir = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (redoviPrve != redoviDruge || kolonePrve != koloneDruge)
            {
                throw new ArgumentException("Redovi i kolone se moraju poklapati medjusobno");
            }

            redoviPrve = int.Parse(tbxRedoviPrve.Text);
            redoviDruge = int.Parse(tbxRedoviDruge.Text);
            kolonePrve = int.Parse(tbxKolonePrve.Text);
            koloneDruge = int.Parse(tbxKoloneDruge.Text);

            matrica1 = new int[redoviPrve, kolonePrve];
            matrica2 = new int[redoviDruge, koloneDruge];

            tbxElementiPrve.Enabled = true;
            tbxElementiDruge.Enabled = true;
            btnSubmitElements.Enabled = true;
        }

        private void btnSubmitElements_Click(object sender, EventArgs e)
        {
            string[] values = tbxElementiPrve.Text.Split(',');
            string[] values2 = tbxElementiDruge.Text.Split(',');

            if (values.Length != redoviPrve * kolonePrve && values2.Length != redoviDruge * koloneDruge)
            {
                throw new ArgumentException("Unesite dovoljno elemnata");
            }

            int k = 0;
            for (int i = 0; i < redoviPrve; i++)
            {
                for(int j = 0; j < kolonePrve; j++)
                {
                    matrica1[i, j] = int.Parse(values[k]);
                    matrica2[i, j] = int.Parse(values2[k]);
                    k++;
                }
            }

            for (int i = 0; i < redoviPrve; i++)
            {
                for (int j = 0; j < kolonePrve; j++)
                {
                    tbxPrikazPrve.AppendText(matrica1[i,j].ToString() + ", ");
                    tbxPrikazDruge.AppendText(matrica2[i, j].ToString() + ", ");
                }
                tbxPrikazPrve.AppendText("\r\n");
                tbxPrikazDruge.AppendText("\r\n");
            }

            
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < redoviPrve; i++)
            {
                for (int j = 0; j < kolonePrve; j++)
                {
                    zbir += matrica1[i, j] + matrica2[i, j];
                }
            }

            tbxZbir.AppendText(zbir.ToString());
        }
    }
}
