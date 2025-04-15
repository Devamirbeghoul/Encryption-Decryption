namespace Encryption___Decryption
{
    partial class fmMain
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
            this.cbMethods = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbBasicKey = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnStart = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // cbMethods
            // 
            this.cbMethods.BackColor = System.Drawing.Color.Transparent;
            this.cbMethods.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.cbMethods.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbMethods.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethods.FocusedColor = System.Drawing.Color.Empty;
            this.cbMethods.FocusedState.Parent = this.cbMethods;
            this.cbMethods.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMethods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.cbMethods.FormattingEnabled = true;
            this.cbMethods.HoverState.Parent = this.cbMethods;
            this.cbMethods.ItemHeight = 30;
            this.cbMethods.Items.AddRange(new object[] {
            "Basic",
            "Symmetric"});
            this.cbMethods.ItemsAppearance.Parent = this.cbMethods;
            this.cbMethods.Location = new System.Drawing.Point(27, 50);
            this.cbMethods.Name = "cbMethods";
            this.cbMethods.ShadowDecoration.Parent = this.cbMethods;
            this.cbMethods.Size = new System.Drawing.Size(250, 36);
            this.cbMethods.TabIndex = 12;
            this.cbMethods.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cbMethods.SelectedIndexChanged += new System.EventHandler(this.cbMethods_SelectedIndexChanged);
            // 
            // tbBasicKey
            // 
            this.tbBasicKey.Animated = true;
            this.tbBasicKey.BackColor = System.Drawing.Color.Transparent;
            this.tbBasicKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.tbBasicKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbBasicKey.DefaultText = "";
            this.tbBasicKey.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbBasicKey.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbBasicKey.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbBasicKey.DisabledState.Parent = this.tbBasicKey;
            this.tbBasicKey.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbBasicKey.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbBasicKey.FocusedState.Parent = this.tbBasicKey;
            this.tbBasicKey.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBasicKey.ForeColor = System.Drawing.Color.Black;
            this.tbBasicKey.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbBasicKey.HoverState.Parent = this.tbBasicKey;
            this.tbBasicKey.Location = new System.Drawing.Point(27, 168);
            this.tbBasicKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBasicKey.Name = "tbBasicKey";
            this.tbBasicKey.PasswordChar = '\0';
            this.tbBasicKey.PlaceholderText = "";
            this.tbBasicKey.SelectedText = "";
            this.tbBasicKey.ShadowDecoration.Parent = this.tbBasicKey;
            this.tbBasicKey.Size = new System.Drawing.Size(250, 36);
            this.tbBasicKey.TabIndex = 13;
            this.tbBasicKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbBasicKey.Visible = false;
            this.tbBasicKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBasicKey_KeyPress);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BorderRadius = 24;
            this.btnStart.CheckedState.Parent = this.btnStart;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.CustomImages.Parent = this.btnStart;
            this.btnStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.btnStart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.HoverState.Parent = this.btnStart;
            this.btnStart.Location = new System.Drawing.Point(27, 286);
            this.btnStart.Name = "btnStart";
            this.btnStart.ShadowDecoration.Parent = this.btnStart;
            this.btnStart.Size = new System.Drawing.Size(250, 46);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // fmMain
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(311, 345);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbBasicKey);
            this.Controls.Add(this.cbMethods);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fmMain";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbMethods;
        private Guna.UI2.WinForms.Guna2TextBox tbBasicKey;
        private Guna.UI2.WinForms.Guna2Button btnStart;
    }
}