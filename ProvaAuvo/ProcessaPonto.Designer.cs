namespace ProcessoRh
{
    partial class ProcessaPonto
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gerarJson = new System.Windows.Forms.Button();
            this.processarCsv = new System.Windows.Forms.Button();
            this.useSubFolders = new System.Windows.Forms.CheckBox();
            this.lerArquivos = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rota da pasta:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.gerarJson);
            this.panel1.Controls.Add(this.processarCsv);
            this.panel1.Controls.Add(this.useSubFolders);
            this.panel1.Controls.Add(this.lerArquivos);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBoxPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 413);
            this.panel1.TabIndex = 1;
            // 
            // gerarJson
            // 
            this.gerarJson.Enabled = false;
            this.gerarJson.Location = new System.Drawing.Point(862, 6);
            this.gerarJson.Name = "gerarJson";
            this.gerarJson.Size = new System.Drawing.Size(100, 28);
            this.gerarJson.TabIndex = 6;
            this.gerarJson.Text = "Gerar JSON";
            this.gerarJson.UseVisualStyleBackColor = true;
            // 
            // processarCsv
            // 
            this.processarCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.processarCsv.Enabled = false;
            this.processarCsv.Location = new System.Drawing.Point(743, 6);
            this.processarCsv.Name = "processarCsv";
            this.processarCsv.Size = new System.Drawing.Size(100, 28);
            this.processarCsv.TabIndex = 5;
            this.processarCsv.Text = "Processar CSV";
            this.processarCsv.UseVisualStyleBackColor = true;
            this.processarCsv.Click += new System.EventHandler(this.processarCsv_Click);
            // 
            // useSubFolders
            // 
            this.useSubFolders.AutoSize = true;
            this.useSubFolders.Location = new System.Drawing.Point(28, 43);
            this.useSubFolders.Name = "useSubFolders";
            this.useSubFolders.Size = new System.Drawing.Size(82, 17);
            this.useSubFolders.TabIndex = 1;
            this.useSubFolders.Text = "Sub Folders";
            this.useSubFolders.UseVisualStyleBackColor = true;
            this.useSubFolders.CheckedChanged += new System.EventHandler(this.useSubFolders_CheckedChanged);
            // 
            // lerArquivos
            // 
            this.lerArquivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lerArquivos.Location = new System.Drawing.Point(624, 6);
            this.lerArquivos.Name = "lerArquivos";
            this.lerArquivos.Size = new System.Drawing.Size(100, 28);
            this.lerArquivos.TabIndex = 0;
            this.lerArquivos.Text = "Ler Aqrquivos";
            this.lerArquivos.UseVisualStyleBackColor = true;
            this.lerArquivos.Click += new System.EventHandler(this.lerArquivos_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(28, 100);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(953, 293);
            this.textBox2.TabIndex = 4;
            this.textBox2.WordWrap = false;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPath.Location = new System.Drawing.Point(110, 11);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(500, 20);
            this.textBoxPath.TabIndex = 2;
            this.textBoxPath.Click += new System.EventHandler(this.textBoxPath_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1057, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "Estado do Processo";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar1.Step = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "Select_Folder";
            // 
            // ProcessaPonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "ProcessaPonto";
            this.Text = "Processo Ponto Mensal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button lerArquivos;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox useSubFolders;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button processarCsv;
        private System.Windows.Forms.Button gerarJson;
    }
}

