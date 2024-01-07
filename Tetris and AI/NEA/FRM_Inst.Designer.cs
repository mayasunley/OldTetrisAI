namespace NEA
{
    partial class FRM_Inst
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
            this.BTN_Back = new System.Windows.Forms.Button();
            this.LB_Title = new System.Windows.Forms.Label();
            this.BTN_Play = new System.Windows.Forms.Button();
            this.TBX_Inst = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BTN_Back
            // 
            this.BTN_Back.Location = new System.Drawing.Point(12, 383);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(249, 55);
            this.BTN_Back.TabIndex = 14;
            this.BTN_Back.Text = "text";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // LB_Title
            // 
            this.LB_Title.Location = new System.Drawing.Point(15, 9);
            this.LB_Title.Name = "LB_Title";
            this.LB_Title.Size = new System.Drawing.Size(501, 55);
            this.LB_Title.TabIndex = 13;
            this.LB_Title.Text = "text";
            this.LB_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_Play
            // 
            this.BTN_Play.Location = new System.Drawing.Point(267, 383);
            this.BTN_Play.Name = "BTN_Play";
            this.BTN_Play.Size = new System.Drawing.Size(249, 55);
            this.BTN_Play.TabIndex = 11;
            this.BTN_Play.Text = "text";
            this.BTN_Play.UseVisualStyleBackColor = true;
            this.BTN_Play.Click += new System.EventHandler(this.BTN_Play_Click);
            // 
            // TBX_Inst
            // 
            this.TBX_Inst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBX_Inst.Location = new System.Drawing.Point(15, 67);
            this.TBX_Inst.Multiline = true;
            this.TBX_Inst.Name = "TBX_Inst";
            this.TBX_Inst.ReadOnly = true;
            this.TBX_Inst.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBX_Inst.Size = new System.Drawing.Size(502, 310);
            this.TBX_Inst.TabIndex = 15;
            this.TBX_Inst.Text = "text";
            this.TBX_Inst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FRM_Inst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 450);
            this.ControlBox = false;
            this.Controls.Add(this.TBX_Inst);
            this.Controls.Add(this.BTN_Back);
            this.Controls.Add(this.LB_Title);
            this.Controls.Add(this.BTN_Play);
            this.Name = "FRM_Inst";
            this.Text = "FRM_Inst";
            this.Load += new System.EventHandler(this.FRM_Inst_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Back;
        private System.Windows.Forms.Label LB_Title;
        private System.Windows.Forms.Button BTN_Play;
        private System.Windows.Forms.TextBox TBX_Inst;
    }
}