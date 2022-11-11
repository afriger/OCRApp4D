using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace OCRApp4D
{
    public partial class Form1 : Form
    {
        private OpenFileDialog m_openFileDialog1;
        private Tesseractexe.TesseractUsing m_tess = null;
        private EventHandler m_eventHandler = null;
        private int m_init_width;

        public Form1()
        {
            InitializeComponent();
            try
            {
                m_tess = new Tesseractexe.TesseractUsing();
                m_eventHandler = new EventHandler(this);
                ini();
            }
            catch (Exception e)
            {
                richTextBox1.Text = "\n\n" + e.Message;
                foreach (Control control in Controls)
                {
                    control.Enabled = false;
                }
            }

        }

        private void ini()
        {
            m_init_width = this.Width;
            m_openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a image file",
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.png; *.bmp)|*.jpg; *.jpeg; *.gif; *.png; *.bmp;",
                Title = "Open image file"
            };
            richTextBox1.KeyDown += richTextBox1_KeyDown;

            List<string> langs = m_tess.GetLangs();
            int index = 0;
            int selected_index = 0;
            foreach (string lang in langs)
            {
                if (lang.Equals(m_tess.Language, StringComparison.OrdinalIgnoreCase))
                {
                    selected_index = index;
                }
                cb_langs.Items.Insert(index++, lang);
            }
            cb_langs.SelectedIndex = selected_index;
            string val = (string)cb_langs.SelectedItem;
            val = val.ToLower();
            m_tess.Language = val + "+eng";
            pictureBox1.ImageLocation = m_tess.GetInputFile();
            toolTip1.SetToolTip(label1, "Img Preview.");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.RightToLeft == RightToLeft.No)
            {
                richTextBox1.RightToLeft = RightToLeft.Yes;
                button1.Text = "LTR";
                return;
            }
            else
            {
                richTextBox1.RightToLeft = RightToLeft.No;
                button1.Text = "RTL";
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                if (!m_tess.ImageFromClipboard())
                {
                    MessageBox.Show("Can't find an image in the clipboard.");
                }
                else
                {
                    ocr();
                }
            }
        }

        private void button_open_file_Click(object sender, EventArgs e)
        {
            var z = cb_langs.SelectedValue;

            if (m_openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = m_openFileDialog1.FileName;
                    if (File.Exists(filePath))
                    {
                        File.Copy(filePath, m_tess.GetInputFile(), true);
                        ocr();
                    }

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }

        }

        private void button_from_clipboard_Click(object sender, EventArgs e)
        {
            if (!m_tess.ImageFromClipboard())
            {
                MessageBox.Show("Can't find an image in the clipboard.");
            }
            else
            {
                ocr();
            }
        }
        private void button_go_Click(object sender, EventArgs e)
        {
            string val = (string)cb_langs.SelectedItem;
            val = val.ToLower();
            m_tess.Language = val + "+eng";
            Console.WriteLine("Lang:{0}", val);
            ocr();
        }

        private void ocr()
        {
            richTextBox1.Clear();
            richTextBox1.Text = "Wait...";
            pictureBox1.ImageLocation = m_tess.GetInputFile();
            string res = m_tess.go();
            if (m_tess.ErrorMessage != null)
            {
                MessageBox.Show(m_tess.ErrorMessage);
            }
            else
            {
                richTextBox1.Text = "\n" + res;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button_screenshot_Click(object sender, EventArgs e)
        {
            this.Hide();
            var bmp = WindowsFormsApp1.SnippingTool.Snip();
            if (bmp != null)
            {
                string file = m_tess.GetInputFile();
                // Do something with the bitmap
                bmp.Save(file);
            }
            this.Show();
            return;
        }

        class EventHandler : IEvent
        {
            private Form1 m_form1;

            public EventHandler(Form1 form1)
            {
                this.m_form1 = form1;
            }

            public void invoke(int arg)
            {
                m_form1.Show();
            }
        }//class EventHandler

        private void label1_Click(object sender, EventArgs e)
        {
            if (this.Width > m_init_width)
            {
                this.Width = m_init_width;
                label1.Text = "\u25B6"; // ">";
                return;
            }
            this.Width = m_init_width * 2;
            label1.Text = "\u25C0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }//
}
