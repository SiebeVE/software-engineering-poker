namespace PokerProject
{
  partial class cardView
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
      this.cardPicture = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.cardPicture)).BeginInit();
      this.SuspendLayout();
      // 
      // cardPicture
      // 
      this.cardPicture.Location = new System.Drawing.Point(0, 0);
      this.cardPicture.Name = "cardPicture";
      this.cardPicture.Size = new System.Drawing.Size(79, 123);
      this.cardPicture.TabIndex = 0;
      this.cardPicture.TabStop = false;
      // 
      // cardView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Desktop;
      this.Controls.Add(this.cardPicture);
      this.Name = "cardView";
      this.Size = new System.Drawing.Size(79, 123);
      ((System.ComponentModel.ISupportInitialize)(this.cardPicture)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox cardPicture;
  }
}
