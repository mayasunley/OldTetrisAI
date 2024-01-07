namespace NEA
{
    partial class FRM_AI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_AI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BTN_End = new System.Windows.Forms.Button();
            this.BTN_Start = new System.Windows.Forms.Button();
            this.DGV_Next = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LB_L = new System.Windows.Forms.Label();
            this.LB_R = new System.Windows.Forms.Label();
            this.LB_Level = new System.Windows.Forms.Label();
            this.LB_Score = new System.Windows.Forms.Label();
            this.LB_S = new System.Windows.Forms.Label();
            this.LB_Rows = new System.Windows.Forms.Label();
            this.LB_Next = new System.Windows.Forms.Label();
            this.DGV_Game = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMR_Time = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Game)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_End
            // 
            resources.ApplyResources(this.BTN_End, "BTN_End");
            this.BTN_End.Name = "BTN_End";
            this.BTN_End.UseVisualStyleBackColor = true;
            this.BTN_End.Click += new System.EventHandler(this.BTN_End_Click);
            // 
            // BTN_Start
            // 
            resources.ApplyResources(this.BTN_Start, "BTN_Start");
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.UseVisualStyleBackColor = true;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
            // 
            // DGV_Next
            // 
            this.DGV_Next.AllowUserToAddRows = false;
            this.DGV_Next.AllowUserToDeleteRows = false;
            this.DGV_Next.AllowUserToResizeColumns = false;
            this.DGV_Next.AllowUserToResizeRows = false;
            this.DGV_Next.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_Next.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGV_Next.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_Next.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Next.ColumnHeadersVisible = false;
            this.DGV_Next.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Wingdings", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Next.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Next.EnableHeadersVisualStyles = false;
            resources.ApplyResources(this.DGV_Next, "DGV_Next");
            this.DGV_Next.MultiSelect = false;
            this.DGV_Next.Name = "DGV_Next";
            this.DGV_Next.ReadOnly = true;
            this.DGV_Next.RowHeadersVisible = false;
            this.DGV_Next.ShowCellErrors = false;
            this.DGV_Next.ShowCellToolTips = false;
            this.DGV_Next.ShowEditingIcon = false;
            this.DGV_Next.ShowRowErrors = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // LB_L
            // 
            resources.ApplyResources(this.LB_L, "LB_L");
            this.LB_L.Name = "LB_L";
            // 
            // LB_R
            // 
            resources.ApplyResources(this.LB_R, "LB_R");
            this.LB_R.Name = "LB_R";
            // 
            // LB_Level
            // 
            resources.ApplyResources(this.LB_Level, "LB_Level");
            this.LB_Level.Name = "LB_Level";
            // 
            // LB_Score
            // 
            resources.ApplyResources(this.LB_Score, "LB_Score");
            this.LB_Score.Name = "LB_Score";
            // 
            // LB_S
            // 
            resources.ApplyResources(this.LB_S, "LB_S");
            this.LB_S.Name = "LB_S";
            // 
            // LB_Rows
            // 
            this.LB_Rows.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.LB_Rows, "LB_Rows");
            this.LB_Rows.Name = "LB_Rows";
            // 
            // LB_Next
            // 
            resources.ApplyResources(this.LB_Next, "LB_Next");
            this.LB_Next.Name = "LB_Next";
            // 
            // DGV_Game
            // 
            this.DGV_Game.AllowUserToAddRows = false;
            this.DGV_Game.AllowUserToDeleteRows = false;
            this.DGV_Game.AllowUserToResizeColumns = false;
            this.DGV_Game.AllowUserToResizeRows = false;
            this.DGV_Game.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_Game.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGV_Game.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_Game.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Game.ColumnHeadersVisible = false;
            this.DGV_Game.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Wingdings", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Game.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_Game.EnableHeadersVisualStyles = false;
            resources.ApplyResources(this.DGV_Game, "DGV_Game");
            this.DGV_Game.MultiSelect = false;
            this.DGV_Game.Name = "DGV_Game";
            this.DGV_Game.ReadOnly = true;
            this.DGV_Game.RowHeadersVisible = false;
            this.DGV_Game.ShowCellErrors = false;
            this.DGV_Game.ShowCellToolTips = false;
            this.DGV_Game.ShowEditingIcon = false;
            this.DGV_Game.ShowRowErrors = false;
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            resources.ApplyResources(this.Column5, "Column5");
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            resources.ApplyResources(this.Column6, "Column6");
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            resources.ApplyResources(this.Column7, "Column7");
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            resources.ApplyResources(this.Column8, "Column8");
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            resources.ApplyResources(this.Column9, "Column9");
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            resources.ApplyResources(this.Column10, "Column10");
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // TMR_Time
            // 
            this.TMR_Time.Interval = 50;
            this.TMR_Time.Tick += new System.EventHandler(this.TMR_Time_Tick_1);
            // 
            // FRM_AI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.DGV_Next);
            this.Controls.Add(this.LB_L);
            this.Controls.Add(this.LB_R);
            this.Controls.Add(this.LB_Level);
            this.Controls.Add(this.LB_Score);
            this.Controls.Add(this.LB_S);
            this.Controls.Add(this.LB_Rows);
            this.Controls.Add(this.LB_Next);
            this.Controls.Add(this.DGV_Game);
            this.Controls.Add(this.BTN_End);
            this.Controls.Add(this.BTN_Start);
            this.Name = "FRM_AI";
            this.Load += new System.EventHandler(this.FRM_AI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Game)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_End;
        private System.Windows.Forms.Button BTN_Start;
        private System.Windows.Forms.DataGridView DGV_Next;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label LB_L;
        private System.Windows.Forms.Label LB_R;
        private System.Windows.Forms.Label LB_Level;
        private System.Windows.Forms.Label LB_Score;
        private System.Windows.Forms.Label LB_S;
        private System.Windows.Forms.Label LB_Rows;
        private System.Windows.Forms.Label LB_Next;
        private System.Windows.Forms.DataGridView DGV_Game;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Timer TMR_Time;
    }
}