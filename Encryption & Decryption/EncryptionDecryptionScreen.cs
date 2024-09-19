using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption___Decryption
{
    public partial class fmEncryptionDecryption : Form
    {
        public fmEncryptionDecryption()
        {
            InitializeComponent();
            CustomWindow(Color.FromArgb(153, 0, 18), Color.Black, Color.FromArgb(153, 0, 18), Handle);
            cbEncryptionLanguages.SelectedIndex = 0;
            cbDecryptionLanguages.SelectedIndex = 0;
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

        void SaveInFile(string fileName , TextBox Text)
        {
            string Data = Text.Text;

            StreamWriter Writer = new StreamWriter(fileName);
            Writer.Write(Data);

            Writer.Close();
        }

        void ReadData(string fileName, ref TextBox Text)
        {
            string Data = Text.Text;


            StreamReader Reader = new StreamReader(fileName);

            StartWrite(Text);

            Text.Text = Reader.ReadToEnd();

            
        }

        void StartWrite(TextBox Text)
        {
            Text.Clear();
            Text.ForeColor = Color.Black;
        }

        void ChangeTextBoxContentEncryption()
        {
            switch (cbEncryptionLanguages.SelectedIndex)
            {
                case 0:
                    {
                        tbEncryptionRead.Text = "Enter text encrypted or choose file encrypted...";
                        tbEncryptionRead.RightToLeft = RightToLeft.No;
                        break;
                    }
                case 1:
                    {
                        tbEncryptionRead.Text = "ادخل النص الاصلي او ملف النص";
                        tbEncryptionRead.RightToLeft = RightToLeft.Yes;
                        break;
                    }
            }

            tbEncryptionRead.ForeColor = Color.Silver;
        }

        void ChangeTextBoxContentDecryption()
        {
            switch (cbDecryptionLanguages.SelectedIndex)
            {
                case 0:
                    {
                        tbDecryptionRead.Text = "Enter text decrypted or choose file decrypted...";
                        tbDecryptionRead.RightToLeft = RightToLeft.No;
                        break;
                    }
                case 1:
                    {
                        tbDecryptionRead.Text = "ادخل النص المشفر او ملف المشفر";
                        tbDecryptionRead.RightToLeft = RightToLeft.Yes;
                        break;
                    }
            }

            tbDecryptionRead.ForeColor = Color.Silver;
        }

        private void tbRead_Leave(object sender, EventArgs e)
        {
            if (sender == tbEncryptionRead)
            {
                if (tbEncryptionRead.Text == string.Empty)
                    ChangeTextBoxContentEncryption();
                
                return;
            }

            if (sender == tbDecryptionRead)
            {
                if (tbDecryptionRead.Text == string.Empty)
                ChangeTextBoxContentDecryption();
                
                return;
            }
        }

        private void cbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == cbEncryptionLanguages)
            {
                tbEncryptionRead.Clear();
                ResetEncryptoin();
                ChangeTextBoxContentEncryption();
                return;
            }

            if (sender == cbDecryptionLanguages)
            {
                tbDecryptionRead.Clear();
                ResetDecryption();
                ChangeTextBoxContentDecryption();
                return;
            }
        }

        private void tbRead_Click(object sender, EventArgs e)
        {
            if (sender == tbDecryptionRead)
            {
                if (tbDecryptionRead.Text == "Enter text decrypted or choose file decrypted..." || tbDecryptionRead.Text == "ادخل النص المشفر او ملف المشفر")
                {
                    StartWrite(tbDecryptionRead);
                }
                
                return;
            }

            if (sender == tbEncryptionRead)
            {
                if (tbEncryptionRead.Text == "Enter text encrypted or choose file encrypted..." || tbEncryptionRead.Text == "ادخل النص الاصلي او ملف النص")
                {
                    StartWrite(tbEncryptionRead);
                }

                return;
            }
        }

        bool IsArabic(string strCompare)
        {
            char[] chars = strCompare.ToCharArray();
            foreach (char ch in chars)
                if (ch >= '\u0627' && ch <= '\u0649') return true;
            return false;
        }

        bool CheckLanguage(TextBox Text , ref string Language)
        {
            if ((!IsArabic(Text.Text.Trim()) && Text.RightToLeft == RightToLeft.Yes))
            {
                Language = "English";
                return true;
            }
                

            if ((IsArabic(Text.Text.Trim()) && Text.RightToLeft == RightToLeft.No))
            {
                Language = "Arabic";
                return true;
            }

            return false;
        }

        string Encryption(string OriginalText, int Key = 2)
        {
            string DecryptedText = "";

            foreach (char c in OriginalText)
            {
                if (char.IsLetter(c))
                {
                    char Shifted = (char)(c + Key);
                    DecryptedText += Shifted;
                }
                else
                {
                    DecryptedText += c;
                }

            }

            return DecryptedText;
        }

        string Decryption(string DecryptedText , int Key = 2)
        {
            string OriginalText = "";

            foreach (char c in DecryptedText)
            {
                if (char.IsLetter(c))
                {
                    
                    char Shifted = (char)(c - Key);
                    OriginalText += Shifted;
                }
                else
                {
                    OriginalText += c;
                }

            }

            return OriginalText;
        }


        private void Perform_Click(object sender, EventArgs e)
        {
            string Language = string.Empty;

            string Result = string.Empty;

            if (sender == btnEncryption)
            {
                

                if (CheckLanguage(tbEncryptionRead , ref Language))
                {
                    MessageBox.Show("Change the language to " + Language, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tbEncryptionRead.Text.Trim() == "Enter text encrypted or choose file encrypted..." || tbEncryptionRead.Text.Trim() == "ادخل النص الاصلي او ملف النص")
                {
                    ErrorProviderOfProject.SetError(tbEncryptionRead, "Enter a value first!!");
                    return;
                }

                ErrorProviderOfProject.SetError(tbEncryptionRead, "");

                Result = Encryption(tbEncryptionRead.Text.Trim());

                tbEncryptionResult.Text = Result;
                btnEncryptionSave.Enabled = true;
                btnEncryptionCopy.Enabled = true;

                return;
                
            }

            if (sender == btnDecryption)
            {
                if (CheckLanguage(tbDecryptionRead, ref Language))
                {
                    MessageBox.Show("Change the language to " + Language, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tbDecryptionRead.Text == "Enter text decrypted or choose file decrypted..." || tbDecryptionRead.Text == "ادخل النص المشفر او ملف المشفر")
                {
                    ErrorProviderOfProject.SetError(tbDecryptionRead, "Enter a value first!!");
                    return;
                }

                ErrorProviderOfProject.SetError(tbDecryptionRead, "");

                Result = Decryption(tbDecryptionRead.Text.Trim());

                tbDecryptionResult.Text = Result;
                btnDecryptionSave.Enabled = true;
                btnDecryptionCopy.Enabled = true;

                return;

            }

        }

        void ResetDecryption()
        {
            btnDecryptionSave.Enabled = false;
            btnDecryptionCopy.Enabled = false;
            tbDecryptionResult.Clear();
        }

        void ResetEncryptoin()
        {
            btnEncryptionSave.Enabled = false;
            btnEncryptionCopy.Enabled = false;
            tbEncryptionResult.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (sender == btnEncryptionReset)
            {
                ChangeTextBoxContentEncryption();
                ResetEncryptoin();
                return;
            }

            if (sender == btnDecryptionReset)
            {
                ChangeTextBoxContentDecryption();
                ResetDecryption();
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile.Title = string.Empty;

            if (sender == btnEncryptionSave)
            {
                if (SaveFile.ShowDialog() == DialogResult.OK)
                    SaveInFile(SaveFile.FileName, tbEncryptionResult);
                return;
            }

            if (sender == btnDecryptionSave)
            {
                if (SaveFile.ShowDialog() == DialogResult.OK)
                    SaveInFile(SaveFile.FileName, tbDecryptionResult);
                return;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (sender == btnEncryptionCopy)
            {
                Clipboard.SetText(tbEncryptionResult.Text);
                return;
            }

            if ( sender == btnDecryptionCopy)
            {
                Clipboard.SetText(tbDecryptionResult.Text);
                return;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFile.Title = string.Empty;

            if (sender == btnEncryptionOpen)
            {
                if (OpenFile.ShowDialog() == DialogResult.OK)
                    ReadData(OpenFile.FileName, ref tbEncryptionRead);
                return;
            }

            if (sender == btnDecryptionOpen)
            {
                if (OpenFile.ShowDialog() == DialogResult.OK)
                    ReadData(OpenFile.FileName, ref tbDecryptionRead);
                return;
            }
        }
    }
}
