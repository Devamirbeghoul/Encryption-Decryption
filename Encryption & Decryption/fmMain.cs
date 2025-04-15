using Encryption___Decryption.Decryption_Methods;
using Encryption___Decryption.Encryption_Methods;
using Encryption___Decryption.Global_Classes;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption___Decryption
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
            CustomWindow(Color.FromArgb(183, 75, 88), Color.Black, Color.FromArgb(183, 75, 88), Handle);

        }

        private string ToBgr(Color c) => $"{c.B:X2}{c.G:X2}{c.R:X2}";

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        const int DWWMA_CAPTION_COLOR = 35;
        const int DWWMA_BORDER_COLOR = 34;
        const int DWMWA_TEXT_COLOR = 36;
        public void CustomWindow(Color captionColor, Color fontColor, Color borderColor, IntPtr handle)
        {
            IntPtr hWnd = handle;
            //Change caption color
            int[] caption = new int[] { int.Parse(ToBgr(captionColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWWMA_CAPTION_COLOR, caption, 4);
            //Change font color
            int[] font = new int[] { int.Parse(ToBgr(fontColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWMWA_TEXT_COLOR, font, 4);
            //Change border color
            int[] border = new int[] { int.Parse(ToBgr(borderColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWWMA_BORDER_COLOR, border, 4);

        }

        void ResetTextBox(Guna2TextBox tb)
        {
            tb.Visible = true;
            tb.Clear();
            tbBasicKey.Focus();

        }

        private void cbMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetTextBox(tbBasicKey);
        }

        private void tbBasicKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbMethods.SelectedIndex == 0)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void PerfromBasic()
        {
            clsKeys.Key = Convert.ToInt32(tbBasicKey.Text);

            fmEncryptionDecryption EncryptionDecryption = new fmEncryptionDecryption(clsEncryption.BasicEncryption , clsDecryption.BasicDecryption , this);

            this.Hide();

            EncryptionDecryption.Show();
        }

        private void PerfromSymetric()
        {
            
            if (tbBasicKey.Text.Length != 16)
            {
                MessageBox.Show($"The Key must be 16 characters, not {tbBasicKey.Text.Length} character(s)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsKeys.Key128 = tbBasicKey.Text;

            fmEncryptionDecryption EncryptionDecryption = new fmEncryptionDecryption(clsEncryption.SymmetricEncrypt, clsDecryption.SymmetricDecrypt , this);

            this.Hide();

            EncryptionDecryption.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbBasicKey.Text))
            {
                MessageBox.Show("Enter a Key First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PerfromStart();
        }

        private void PerfromStart()
        {
            switch (cbMethods.SelectedIndex)
            {
                case 0:
                    {
                        PerfromBasic();
                        break;
                    }

                case 1:
                    {
                        PerfromSymetric();
                        break;
                    }
            }
        }
    }
}
