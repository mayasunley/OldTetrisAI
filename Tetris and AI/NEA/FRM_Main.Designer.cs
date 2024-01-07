namespace NEA
{
    partial class FRM_Main
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
            this.LB_Title = new System.Windows.Forms.Label();
            this.BTN_Inst = new System.Windows.Forms.Button();
            this.BTN_AI = new System.Windows.Forms.Button();
            this.BTN_Lead = new System.Windows.Forms.Button();
            this.BTN_Sett = new System.Windows.Forms.Button();
            this.BTN_Game = new System.Windows.Forms.Button();
            this.BTN_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LB_Title
            // 
            this.LB_Title.Location = new System.Drawing.Point(12, 9);
            this.LB_Title.Name = "LB_Title";
            this.LB_Title.Size = new System.Drawing.Size(249, 55);
            this.LB_Title.TabIndex = 12;
            this.LB_Title.Text = "text";
            this.LB_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_Inst
            // 
            this.BTN_Inst.Location = new System.Drawing.Point(12, 128);
            this.BTN_Inst.Name = "BTN_Inst";
            this.BTN_Inst.Size = new System.Drawing.Size(249, 55);
            this.BTN_Inst.TabIndex = 11;
            this.BTN_Inst.Text = "text";
            this.BTN_Inst.UseVisualStyleBackColor = true;
            this.BTN_Inst.Click += new System.EventHandler(this.BTN_Inst_Click);
            // 
            // BTN_AI
            // 
            this.BTN_AI.Location = new System.Drawing.Point(12, 189);
            this.BTN_AI.Name = "BTN_AI";
            this.BTN_AI.Size = new System.Drawing.Size(249, 55);
            this.BTN_AI.TabIndex = 10;
            this.BTN_AI.Text = "text";
            this.BTN_AI.UseVisualStyleBackColor = true;
            this.BTN_AI.Click += new System.EventHandler(this.BTN_AI_Click);
            // 
            // BTN_Lead
            // 
            this.BTN_Lead.Location = new System.Drawing.Point(12, 250);
            this.BTN_Lead.Name = "BTN_Lead";
            this.BTN_Lead.Size = new System.Drawing.Size(249, 55);
            this.BTN_Lead.TabIndex = 9;
            this.BTN_Lead.Text = "text";
            this.BTN_Lead.UseVisualStyleBackColor = true;
            this.BTN_Lead.Click += new System.EventHandler(this.BTN_Lead_Click);
            // 
            // BTN_Sett
            // 
            this.BTN_Sett.Location = new System.Drawing.Point(12, 311);
            this.BTN_Sett.Name = "BTN_Sett";
            this.BTN_Sett.Size = new System.Drawing.Size(249, 55);
            this.BTN_Sett.TabIndex = 8;
            this.BTN_Sett.Text = "text";
            this.BTN_Sett.UseVisualStyleBackColor = true;
            this.BTN_Sett.Click += new System.EventHandler(this.BTN_Sett_Click);
            // 
            // BTN_Game
            // 
            this.BTN_Game.Location = new System.Drawing.Point(12, 67);
            this.BTN_Game.Name = "BTN_Game";
            this.BTN_Game.Size = new System.Drawing.Size(249, 55);
            this.BTN_Game.TabIndex = 7;
            this.BTN_Game.Text = "text";
            this.BTN_Game.UseVisualStyleBackColor = true;
            this.BTN_Game.Click += new System.EventHandler(this.BTN_Game_Click);
            // 
            // BTN_Close
            // 
            this.BTN_Close.Location = new System.Drawing.Point(12, 372);
            this.BTN_Close.Name = "BTN_Close";
            this.BTN_Close.Size = new System.Drawing.Size(249, 55);
            this.BTN_Close.TabIndex = 13;
            this.BTN_Close.Text = "text";
            this.BTN_Close.UseVisualStyleBackColor = true;
            this.BTN_Close.Click += new System.EventHandler(this.BTN_Close_Click);
            // 
            // FRM_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 435);
            this.ControlBox = false;
            this.Controls.Add(this.BTN_Close);
            this.Controls.Add(this.LB_Title);
            this.Controls.Add(this.BTN_Inst);
            this.Controls.Add(this.BTN_AI);
            this.Controls.Add(this.BTN_Lead);
            this.Controls.Add(this.BTN_Sett);
            this.Controls.Add(this.BTN_Game);
            this.Name = "FRM_Main";
            this.Text = "FRM_Main";
            this.Load += new System.EventHandler(this.FRM_Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LB_Title;
        private System.Windows.Forms.Button BTN_Inst;
        private System.Windows.Forms.Button BTN_AI;
        private System.Windows.Forms.Button BTN_Lead;
        private System.Windows.Forms.Button BTN_Sett;
        private System.Windows.Forms.Button BTN_Game;
        private System.Windows.Forms.Button BTN_Close;
    }
}