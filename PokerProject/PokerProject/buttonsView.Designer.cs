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
      this.showCards = new System.Windows.Forms.Button();
      this.currentPlayer = new System.Windows.Forms.Label();
      this.inzet = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.inzet)).BeginInit();
      this.SuspendLayout();
      // 
      // call_bttn
      // 
      this.call_bttn.Location = new System.Drawing.Point(98, 0);
      this.call_bttn.Name = "call_bttn";
      this.call_bttn.Size = new System.Drawing.Size(58, 23);
      this.call_bttn.TabIndex = 0;
      this.call_bttn.Text = "Call\r\n";
      this.call_bttn.UseVisualStyleBackColor = true;
      this.call_bttn.Click += new System.EventHandler(this.call_bttn_Click);
      // 
      // fold_bttn
      // 
      this.fold_bttn.Location = new System.Drawing.Point(162, 0);
      this.fold_bttn.Name = "fold_bttn";
      this.fold_bttn.Size = new System.Drawing.Size(60, 23);
      this.fold_bttn.TabIndex = 1;
      this.fold_bttn.Text = "Fold";
      this.fold_bttn.UseVisualStyleBackColor = true;
      this.fold_bttn.Click += new System.EventHandler(this.fold_bttn_Click);
      // 
      // raise_bttn
      // 
      this.raise_bttn.Location = new System.Drawing.Point(228, 0);
      this.raise_bttn.Name = "raise_bttn";
      this.raise_bttn.Size = new System.Drawing.Size(59, 23);
      this.raise_bttn.TabIndex = 2;
      this.raise_bttn.Text = "Raise";
      this.raise_bttn.UseVisualStyleBackColor = true;
      this.raise_bttn.Click += new System.EventHandler(this.raise_Click);
      // 
      // showCards
      // 
      this.showCards.Enabled = false;
      this.showCards.Location = new System.Drawing.Point(3, 0);
      this.showCards.Name = "showCards";
      this.showCards.Size = new System.Drawing.Size(89, 23);
      this.showCards.TabIndex = 6;
      this.showCards.Text = "Toon kaarten";
      this.showCards.UseVisualStyleBackColor = true;
      this.showCards.Click += new System.EventHandler(this.showCards_Click);
      // 
      // currentPlayer
      // 
      this.currentPlayer.AutoSize = true;
      this.currentPlayer.Location = new System.Drawing.Point(3, 26);
      this.currentPlayer.Name = "currentPlayer";
      this.currentPlayer.Size = new System.Drawing.Size(35, 13);
      this.currentPlayer.TabIndex = 4;
      this.currentPlayer.Text = "label1";
      // 
      // inzet
      // 
      this.inzet.Location = new System.Drawing.Point(294, 4);
      this.inzet.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
      this.inzet.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.inzet.Name = "inzet";
      this.inzet.Size = new System.Drawing.Size(68, 20);
      this.inzet.TabIndex = 7;
      this.inzet.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.inzet.ValueChanged += new System.EventHandler(this.inzet_ValueChanged);
      // 
      // buttonsView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.Controls.Add(this.inzet);
      this.Controls.Add(this.showCards);
      this.Controls.Add(this.currentPlayer);
      this.Controls.Add(this.raise_bttn);
      this.Controls.Add(this.fold_bttn);
      this.Controls.Add(this.call_bttn);
      this.Name = "buttonsView";
      this.Size = new System.Drawing.Size(465, 43);
      this.Load += new System.EventHandler(this.buttonView_Load);
      ((System.ComponentModel.ISupportInitialize)(this.inzet)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button call_bttn;
        private System.Windows.Forms.Button fold_bttn;
        private System.Windows.Forms.Button raise_bttn;
    private System.Windows.Forms.Button showCards;
    private System.Windows.Forms.Label currentPlayer;
    private System.Windows.Forms.NumericUpDown inzet;
  }
}
