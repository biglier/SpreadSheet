namespace SpreadSheet
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
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonEquals = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.AllowUserToAddRows = false;
            this.dataGridViewTable.AllowUserToDeleteRows = false;
            this.dataGridViewTable.AllowUserToOrderColumns = true;
            this.dataGridViewTable.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewTable.Location = new System.Drawing.Point(1, 52);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewTable.Size = new System.Drawing.Size(849, 647);
            this.dataGridViewTable.TabIndex = 0;
            this.dataGridViewTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTable_CellClick);
            this.dataGridViewTable.SelectionChanged += new System.EventHandler(this.dataGridViewTable_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(803, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(63, 26);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(764, 20);
            this.textBox.TabIndex = 2;
            // 
            // buttonEquals
            // 
            this.buttonEquals.Location = new System.Drawing.Point(826, 25);
            this.buttonEquals.Name = "buttonEquals";
            this.buttonEquals.Size = new System.Drawing.Size(24, 21);
            this.buttonEquals.TabIndex = 3;
            this.buttonEquals.Text = "=";
            this.buttonEquals.UseVisualStyleBackColor = true;
            this.buttonEquals.Click += new System.EventHandler(this.buttonEquals_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 711);
            this.Controls.Add(this.buttonEquals);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewTable);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonEquals;
    }
}

