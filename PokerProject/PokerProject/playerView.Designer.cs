namespace PokerProject
{
  partial class playerView
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
      this.kapitaal = new System.Windows.Forms.Label();
      this.naam = new System.Windows.Forms.Label();
      this.curInzet = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // kapitaal
      // 
      this.kapitaal.AutoSize = true;
      this.kapitaal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.kapitaal.Location = new System.Drawing.Point(8, 114);
      this.kapitaal.Name = "kapitaal";
      this.kapitaal.Size = new System.Drawing.Size(13, 13);
      this.kapitaal.TabIndex = 0;
      this.kapitaal.Text = "0";
      this.kapitaal.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // naam
      // 
      this.naam.AutoSize = true;
      this.naam.Location = new System.Drawing.Point(3, 101);
      this.naam.Name = "naam";
      this.naam.Size = new System.Drawing.Size(32, 13);
      this.naam.TabIndex = 1;
      this.naam.Text = "Rudy";
      // 
      // curInzet
      // 
      this.curInzet.AutoSize = true;
      this.curInzet.Location = new System.Drawing.Point(6, 134);
      this.curInzet.Name = "curInzet";
      this.curInzet.Size = new System.Drawing.Size(35, 13);
      this.curInzet.TabIndex = 2;
      this.curInzet.Text = "label1";
      // 
      // playerView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.BackColor = System.Drawing.SystemColors.GrayText;
      this.Controls.Add(this.curInzet);
      this.Controls.Add(this.naam);
      this.Controls.Add(this.kapitaal);
      this.Name = "playerView";
      this.Load += new System.EventHandler(this.playerView_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label kapitaal;
    private System.Windows.Forms.Label naam;
    private System.Windows.Forms.Label curInzet;
  }
}
