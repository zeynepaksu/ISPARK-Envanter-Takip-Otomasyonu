namespace EnvanterTakip
{
    partial class Form5
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.envanterTakipDataSet = new EnvanterTakip.EnvanterTakipDataSet();
            this.envanterTakipDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnanasayfa = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.envanterTakipDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.envanterTakipDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(76, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(710, 327);
            this.dataGridView1.TabIndex = 0;
            // 
            // envanterTakipDataSet
            // 
            this.envanterTakipDataSet.DataSetName = "EnvanterTakipDataSet";
            this.envanterTakipDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // envanterTakipDataSetBindingSource
            // 
            this.envanterTakipDataSetBindingSource.DataSource = this.envanterTakipDataSet;
            this.envanterTakipDataSetBindingSource.Position = 0;
            // 
            // btnanasayfa
            // 
            this.btnanasayfa.BackColor = System.Drawing.Color.Navy;
            this.btnanasayfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnanasayfa.ForeColor = System.Drawing.SystemColors.Control;
            this.btnanasayfa.Location = new System.Drawing.Point(47, 27);
            this.btnanasayfa.Name = "btnanasayfa";
            this.btnanasayfa.Size = new System.Drawing.Size(195, 43);
            this.btnanasayfa.TabIndex = 1;
            this.btnanasayfa.Text = "<-- Ana Sayfaya Dön";
            this.btnanasayfa.UseVisualStyleBackColor = false;
            this.btnanasayfa.Click += new System.EventHandler(this.btnanasayfa_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Navy;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSil.Location = new System.Drawing.Point(705, 443);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(104, 35);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Kaydı Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // txtAra
            // 
            this.txtAra.AutoSize = true;
            this.txtAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAra.Location = new System.Drawing.Point(491, 42);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(33, 18);
            this.txtAra.TabIndex = 3;
            this.txtAra.Text = "Ara";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(530, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Click += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(939, 546);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnanasayfa);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Takibi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.envanterTakipDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.envanterTakipDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource envanterTakipDataSetBindingSource;
        private EnvanterTakipDataSet envanterTakipDataSet;
        private System.Windows.Forms.Button btnanasayfa;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label txtAra;
        private System.Windows.Forms.TextBox textBox1;
    }
}