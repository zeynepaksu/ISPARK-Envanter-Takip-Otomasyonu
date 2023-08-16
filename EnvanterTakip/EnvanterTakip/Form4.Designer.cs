namespace EnvanterTakip
{
    partial class Form4
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
            this.txtAra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.anasyf2 = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
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
            this.dataGridView1.Location = new System.Drawing.Point(146, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(590, 336);
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
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(395, 39);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(332, 22);
            this.txtAra.TabIndex = 2;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(334, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ara";
            // 
            // anasyf2
            // 
            this.anasyf2.BackColor = System.Drawing.Color.Navy;
            this.anasyf2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.anasyf2.ForeColor = System.Drawing.SystemColors.Control;
            this.anasyf2.Location = new System.Drawing.Point(67, 24);
            this.anasyf2.Name = "anasyf2";
            this.anasyf2.Size = new System.Drawing.Size(194, 37);
            this.anasyf2.TabIndex = 4;
            this.anasyf2.Text = "<-- Ana Sayfaya Dön";
            this.anasyf2.UseVisualStyleBackColor = false;
            this.anasyf2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Navy;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSil.Location = new System.Drawing.Point(753, 390);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(118, 44);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "Ürünü Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(970, 534);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.anasyf2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Listesi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.envanterTakipDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.envanterTakipDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private EnvanterTakipDataSet envanterTakipDataSet;
        private System.Windows.Forms.BindingSource envanterTakipDataSetBindingSource;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button anasyf2;
        private System.Windows.Forms.Button btnSil;
    }
}