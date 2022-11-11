using System.Windows;

namespace OCRApp4D
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button_open_file = new System.Windows.Forms.Button();
            this.button_from_clipboard = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cb_langs = new System.Windows.Forms.ComboBox();
            this.button_go = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_screenshot = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "RTL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_open_file
            // 
            this.button_open_file.Location = new System.Drawing.Point(14, 26);
            this.button_open_file.Name = "button_open_file";
            this.button_open_file.Size = new System.Drawing.Size(85, 30);
            this.button_open_file.TabIndex = 2;
            this.button_open_file.Text = "Open File";
            this.button_open_file.UseVisualStyleBackColor = true;
            this.button_open_file.Click += new System.EventHandler(this.button_open_file_Click);
            // 
            // button_from_clipboard
            // 
            this.button_from_clipboard.Location = new System.Drawing.Point(103, 26);
            this.button_from_clipboard.Name = "button_from_clipboard";
            this.button_from_clipboard.Size = new System.Drawing.Size(85, 30);
            this.button_from_clipboard.TabIndex = 3;
            this.button_from_clipboard.Text = "From Clipboard";
            this.button_from_clipboard.UseVisualStyleBackColor = true;
            this.button_from_clipboard.Click += new System.EventHandler(this.button_from_clipboard_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(14, 88);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(494, 326);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // cb_langs
            // 
            this.cb_langs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_langs.FormattingEnabled = true;
            this.cb_langs.Location = new System.Drawing.Point(379, 30);
            this.cb_langs.Name = "cb_langs";
            this.cb_langs.Size = new System.Drawing.Size(99, 23);
            this.cb_langs.TabIndex = 5;
            // 
            // button_go
            // 
            this.button_go.Location = new System.Drawing.Point(484, 27);
            this.button_go.Name = "button_go";
            this.button_go.Size = new System.Drawing.Size(29, 29);
            this.button_go.TabIndex = 6;
            this.button_go.Text = "Go";
            this.button_go.UseVisualStyleBackColor = true;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(553, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 326);
            this.panel1.TabIndex = 7;
            // 
            // button_screenshot
            // 
            this.button_screenshot.Location = new System.Drawing.Point(192, 26);
            this.button_screenshot.Name = "button_screenshot";
            this.button_screenshot.Size = new System.Drawing.Size(85, 30);
            this.button_screenshot.TabIndex = 8;
            this.button_screenshot.Text = "Screenshot";
            this.button_screenshot.UseVisualStyleBackColor = true;
            this.button_screenshot.Click += new System.EventHandler(this.button_screenshot_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(508, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "▶";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(494, 326);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipTitle = "Info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 432);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_screenshot);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.cb_langs);
            this.Controls.Add(this.button_from_clipboard);
            this.Controls.Add(this.button_open_file);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "OCR(4DC) Extract Text";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_open_file;
        private System.Windows.Forms.Button button_from_clipboard;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox cb_langs;
        private System.Windows.Forms.Button button_go;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_screenshot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}

