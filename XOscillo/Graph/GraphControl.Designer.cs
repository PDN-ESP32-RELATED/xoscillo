namespace XOscillo
{
	partial class GraphControl
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
         this.components = new System.ComponentModel.Container();
         this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
         this.timer = new System.Windows.Forms.Timer(this.components);
         this.SuspendLayout();
         // 
         // hScrollBar1
         // 
         this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.hScrollBar1.Location = new System.Drawing.Point(0, 151);
         this.hScrollBar1.Name = "hScrollBar1";
         this.hScrollBar1.Size = new System.Drawing.Size(195, 16);
         this.hScrollBar1.TabIndex = 0;
         this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
         // 
         // timer
         // 
         this.timer.Enabled = true;
         this.timer.Interval = 500;
         this.timer.Tick += new System.EventHandler(this.timer_Tick);
         // 
         // GraphControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.hScrollBar1);
         this.DoubleBuffered = true;
         this.Name = "GraphControl";
         this.Size = new System.Drawing.Size(195, 167);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControl1_Paint);
         this.Resize += new System.EventHandler(this.UserControl1_Resize);
         this.ResumeLayout(false);

		}

		#endregion

      private System.Windows.Forms.HScrollBar hScrollBar1;
      private System.Windows.Forms.Timer timer;

   }
}
