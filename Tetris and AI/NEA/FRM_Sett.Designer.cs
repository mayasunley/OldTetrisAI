namespace NEA
{
    partial class FRM_Sett
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
            this.CBX_Size = new System.Windows.Forms.ComboBox();
            this.CBX_Colour = new System.Windows.Forms.ComboBox();
            this.CBX_Lang = new System.Windows.Forms.ComboBox();
            this.LB_Lang = new System.Windows.Forms.Label();
            this.LB_Size = new System.Windows.Forms.Label();
            this.LB_Colour = new System.Windows.Forms.Label();
            this.BTN_Play = new System.Windows.Forms.Button();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.LB_Title = new System.Windows.Forms.Label();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBX_Size
            // 
            this.CBX_Size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_Size.FormattingEnabled = true;
            this.CBX_Size.Location = new System.Drawing.Point(267, 134);
            this.CBX_Size.Name = "CBX_Size";
            this.CBX_Size.Size = new System.Drawing.Size(249, 21);
            this.CBX_Size.TabIndex = 26;
            // 
            // CBX_Colour
            // 
            this.CBX_Colour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_Colour.FormattingEnabled = true;
            this.CBX_Colour.Location = new System.Drawing.Point(267, 189);
            this.CBX_Colour.Name = "CBX_Colour";
            this.CBX_Colour.Size = new System.Drawing.Size(249, 21);
            this.CBX_Colour.TabIndex = 25;
            // 
            // CBX_Lang
            // 
            this.CBX_Lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_Lang.FormattingEnabled = true;
            this.CBX_Lang.Location = new System.Drawing.Point(267, 82);
            this.CBX_Lang.Name = "CBX_Lang";
            this.CBX_Lang.Size = new System.Drawing.Size(249, 21);
            this.CBX_Lang.TabIndex = 24;
            // 
            // LB_Lang
            // 
            this.LB_Lang.Location = new System.Drawing.Point(12, 64);
            this.LB_Lang.Name = "LB_Lang";
            this.LB_Lang.Size = new System.Drawing.Size(249, 55);
            this.LB_Lang.TabIndex = 23;
            this.LB_Lang.Text = "text";
            this.LB_Lang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LB_Size
            // 
            this.LB_Size.Location = new System.Drawing.Point(12, 119);
            this.LB_Size.Name = "LB_Size";
            this.LB_Size.Size = new System.Drawing.Size(249, 55);
            this.LB_Size.TabIndex = 22;
            this.LB_Size.Text = "text";
            this.LB_Size.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LB_Colour
            // 
            this.LB_Colour.Location = new System.Drawing.Point(9, 174);
            this.LB_Colour.Name = "LB_Colour";
            this.LB_Colour.Size = new System.Drawing.Size(252, 55);
            this.LB_Colour.TabIndex = 21;
            this.LB_Colour.Text = "text";
            this.LB_Colour.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BTN_Play
            // 
            this.BTN_Play.Location = new System.Drawing.Point(267, 293);
            this.BTN_Play.Name = "BTN_Play";
            this.BTN_Play.Size = new System.Drawing.Size(249, 55);
            this.BTN_Play.TabIndex = 20;
            this.BTN_Play.Text = "text";
            this.BTN_Play.UseVisualStyleBackColor = true;
            this.BTN_Play.Click += new System.EventHandler(this.BTN_Play_Click);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(12, 232);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(504, 55);
            this.BTN_Save.TabIndex = 19;
            this.BTN_Save.Text = "text";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // LB_Title
            // 
            this.LB_Title.Location = new System.Drawing.Point(12, 9);
            this.LB_Title.Name = "LB_Title";
            this.LB_Title.Size = new System.Drawing.Size(504, 55);
            this.LB_Title.TabIndex = 18;
            this.LB_Title.Text = "text";
            this.LB_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_Back
            // 
            this.BTN_Back.Location = new System.Drawing.Point(12, 293);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.Size = new System.Drawing.Size(249, 55);
            this.BTN_Back.TabIndex = 17;
            this.BTN_Back.Text = "text";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // FRM_Sett
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 360);
            this.ControlBox = false;
            this.Controls.Add(this.CBX_Size);
            this.Controls.Add(this.CBX_Colour);
            this.Controls.Add(this.CBX_Lang);
            this.Controls.Add(this.LB_Lang);
            this.Controls.Add(this.LB_Size);
            this.Controls.Add(this.LB_Colour);
            this.Controls.Add(this.BTN_Play);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.LB_Title);
            this.Controls.Add(this.BTN_Back);
            this.Name = "FRM_Sett";
            this.Text = "FRM_Sett";
            this.Load += new System.EventHandler(this.FRM_Sett_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CBX_Size;
        private System.Windows.Forms.ComboBox CBX_Colour;
        private System.Windows.Forms.ComboBox CBX_Lang;
        private System.Windows.Forms.Label LB_Lang;
        private System.Windows.Forms.Label LB_Size;
        private System.Windows.Forms.Label LB_Colour;
        private System.Windows.Forms.Button BTN_Play;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Label LB_Title;
        private System.Windows.Forms.Button BTN_Back;
    }
}