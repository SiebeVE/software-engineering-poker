namespace PokerProject
{
    partial class buttonsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.call_bttn = new System.Windows.Forms.Button();
      this.fold_bttn = new System.Windows.Forms.Button();
      this.raise_bttn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // call_bttn
      // 
      this.call_bttn.Location = new System.Drawing.Point(0, 0);
      this.call_bttn.Name = "call_bttn";
      this.call_bttn.Size = new System.Drawing.Size(58, 23);
      this.call_bttn.TabIndex = 0;
      this.call_bttn.Text = "Call\r\n";
      this.call_bttn.UseVisualStyleBackColor = true;
      this.call_bttn.Click += new System.EventHandler(this.call_bttn_Click);
      // 
      // fold_bttn
      // 
      this.fold_bttn.Location = new System.Drawing.Point(64, 0);
      this.fold_bttn.Name = "fold_bttn";
      this.fold_bttn.Size = new System.Drawing.Size(60, 23);
      this.fold_bttn.TabIndex = 1;
      this.fold_bttn.Text = "Fold";
      this.fold_bttn.UseVisualStyleBackColor = true;
      this.fold_bttn.Click += new System.EventHandler(this.fold_bttn_Click);
      // 
      // raise_bttn
      // 
      this.raise_bttn.Location = new System.Drawing.Point(130, 0);
      this.raise_bttn.Name = "raise_bttn";
      this.raise_bttn.Size = new System.Drawing.Size(59, 23);
      this.raise_bttn.TabIndex = 2;
      this.raise_bttn.Text = "Raise";
      this.raise_bttn.UseVisualStyleBackColor = true;
      this.raise_bttn.Click += new System.EventHandler(this.button3_Click);
      // 
      // buttonsView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.raise_bttn);
      this.Controls.Add(this.fold_bttn);
      this.Controls.Add(this.call_bttn);
      this.Name = "buttonsView";
      this.Size = new System.Drawing.Size(281, 23);
      this.Load += new System.EventHandler(this.buttonView_Load);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button call_bttn;
        private System.Windows.Forms.Button fold_bttn;
        private System.Windows.Forms.Button raise_bttn;
    }
}
