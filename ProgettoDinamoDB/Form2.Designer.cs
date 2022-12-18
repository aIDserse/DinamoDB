
namespace ProgettoDinamoDB
{
    partial class Form2
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.buttonExportToCSV = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxGraphics = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonGenGraph = new System.Windows.Forms.Button();
            this.dateTimePickerGraphStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerGraphEnd = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxData.SuspendLayout();
            this.groupBoxGraphics.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(720, 465);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxData.Controls.Add(this.buttonExportToCSV);
            this.groupBoxData.Controls.Add(this.dataGridView1);
            this.groupBoxData.Location = new System.Drawing.Point(263, 12);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(732, 522);
            this.groupBoxData.TabIndex = 5;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Data";
            // 
            // buttonExportToCSV
            // 
            this.buttonExportToCSV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportToCSV.Location = new System.Drawing.Point(6, 492);
            this.buttonExportToCSV.Name = "buttonExportToCSV";
            this.buttonExportToCSV.Size = new System.Drawing.Size(720, 24);
            this.buttonExportToCSV.TabIndex = 1;
            this.buttonExportToCSV.Text = "Export to CSV";
            this.buttonExportToCSV.UseVisualStyleBackColor = true;
            this.buttonExportToCSV.Click += new System.EventHandler(this.buttonExportToSCV_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1194, 376);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBoxGraphics
            // 
            this.groupBoxGraphics.Controls.Add(this.label4);
            this.groupBoxGraphics.Controls.Add(this.label3);
            this.groupBoxGraphics.Controls.Add(this.buttonGenGraph);
            this.groupBoxGraphics.Controls.Add(this.dateTimePickerGraphStart);
            this.groupBoxGraphics.Controls.Add(this.dateTimePickerGraphEnd);
            this.groupBoxGraphics.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGraphics.Name = "groupBoxGraphics";
            this.groupBoxGraphics.Size = new System.Drawing.Size(245, 206);
            this.groupBoxGraphics.TabIndex = 9;
            this.groupBoxGraphics.TabStop = false;
            this.groupBoxGraphics.Text = "View Data Trend";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "To:";
            // 
            // buttonGenGraph
            // 
            this.buttonGenGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenGraph.Location = new System.Drawing.Point(6, 177);
            this.buttonGenGraph.Name = "buttonGenGraph";
            this.buttonGenGraph.Size = new System.Drawing.Size(231, 23);
            this.buttonGenGraph.TabIndex = 6;
            this.buttonGenGraph.Text = "Show data trend";
            this.buttonGenGraph.UseVisualStyleBackColor = true;
            this.buttonGenGraph.Click += new System.EventHandler(this.buttonGenGraph_Click);
            // 
            // dateTimePickerGraphStart
            // 
            this.dateTimePickerGraphStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerGraphStart.Location = new System.Drawing.Point(6, 41);
            this.dateTimePickerGraphStart.Name = "dateTimePickerGraphStart";
            this.dateTimePickerGraphStart.Size = new System.Drawing.Size(233, 22);
            this.dateTimePickerGraphStart.TabIndex = 5;
            // 
            // dateTimePickerGraphEnd
            // 
            this.dateTimePickerGraphEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerGraphEnd.Location = new System.Drawing.Point(6, 86);
            this.dateTimePickerGraphEnd.Name = "dateTimePickerGraphEnd";
            this.dateTimePickerGraphEnd.Size = new System.Drawing.Size(231, 22);
            this.dateTimePickerGraphEnd.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 546);
            this.Controls.Add(this.groupBoxGraphics);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBoxData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Dynamo Embedded Data DB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxGraphics.ResumeLayout(false);
            this.groupBoxGraphics.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBoxGraphics;
        private System.Windows.Forms.Button buttonGenGraph;
        private System.Windows.Forms.DateTimePicker dateTimePickerGraphStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerGraphEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonExportToCSV;
    }
}

