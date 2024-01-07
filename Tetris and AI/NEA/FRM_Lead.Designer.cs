namespace NEA
{
    partial class FRM_Lead
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BTN_Play = new System.Windows.Forms.Button();
            this.CBX_Show = new System.Windows.Forms.ComboBox();
            this.LB_Show = new System.Windows.Forms.Label();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.DGV_Lead = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Lead)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Play
            // 
            this.BTN_Play.Location = new System.Drawing.Point(191, 356);
            this.BTN_Play.Name = "BTN_Play";
            this.BTN_Play.Size = new System.Drawing.Size(169, 55);
            this.BTN_Play.TabIndex = 35;
            this.BTN_Play.Text = "text";
            this.BTN_Play.UseVisualStyleBackColor = true;
            this.BTN_Play.Click += new System.EventHandler(this.BTN_Play_Click);
            // 
            // CBX_Show
            // 
            this.CBX_Show.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_Show.FormattingEnabled = true;
            this.CBX_Show.Location = new System.Drawing.Point(153, 27);
            this.CBX_Show.Name = "CBX_Show";
            this.CBX_Show.Size = new System.Drawing.Size(207, 21);
            this.CBX_Show.TabIndex = 34;
            this.CBX_Show.SelectedIndexChanged += new System.EventHandler(this.CBX_Show_SelectedIndexChanged);
            // 
            // LB_Show
            // 
            this.LB_Show.Location = new System.Drawing.Point(12, 9);
            this.LB_Show.Name = "LB_Show";
            this.LB_Show.Size = new System.Drawing.Size(135, 55);
            this.LB_Show.TabIndex = 33;
            this.LB_Show.Text = "text";
            this.LB_Show.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BTN_Back
            // 
            this.BTN_Back.Location = new System.Drawing.Point(15, 356);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(169, 55);
            this.BTN_Back.TabIndex = 32;
            this.BTN_Back.Text = "text";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // DGV_Lead
            // 
            this.DGV_Lead.AllowUserToAddRows = false;
            this.DGV_Lead.AllowUserToDeleteRows = false;
            this.DGV_Lead.AllowUserToResizeColumns = false;
            this.DGV_Lead.AllowUserToResizeRows = false;
            this.DGV_Lead.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_Lead.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_Lead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Lead.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Lead.EnableHeadersVisualStyles = false;
            this.DGV_Lead.Location = new System.Drawing.Point(15, 72);
            this.DGV_Lead.MultiSelect = false;
            this.DGV_Lead.Name = "DGV_Lead";
            this.DGV_Lead.ReadOnly = true;
            this.DGV_Lead.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV_Lead.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Lead.Size = new System.Drawing.Size(345, 278);
            this.DGV_Lead.TabIndex = 31;
            // 
            // FRM_Lead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 421);
            this.ControlBox = false;
            this.Controls.Add(this.BTN_Play);
            this.Controls.Add(this.CBX_Show);
            this.Controls.Add(this.LB_Show);
            this.Controls.Add(this.BTN_Back);
            this.Controls.Add(this.DGV_Lead);
            this.Name = "FRM_Lead";
            this.Text = "FRM_Lead";
            this.Load += new System.EventHandler(this.FRM_Lead_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Lead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Play;
        private System.Windows.Forms.ComboBox CBX_Show;
        private System.Windows.Forms.Label LB_Show;
        private System.Windows.Forms.Button BTN_Back;
        private System.Windows.Forms.DataGridView DGV_Lead;
    }
}