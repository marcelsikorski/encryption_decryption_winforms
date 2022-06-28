using System;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Laboratoria1WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openFileDialog1.FileName;

                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
                label4.Text = saveFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Lower;
            textBox2.Text = textBox1.Text;
            string encryptedFile = Encipher(textBox2.Text, 3);
            textBox2.Text = encryptedFile;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
            string decryptedFile = Decipher(textBox2.Text, 3);
            textBox2.Text = decryptedFile;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
            textBox2.Text = EncryptDecrypt(textBox2.Text, 200);

        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
            textBox2.Text = EncryptDecrypt(textBox2.Text, 200);
        }
    }
}
