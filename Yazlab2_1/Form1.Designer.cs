namespace Yazlab2_1
{
	partial class Form1
	{
		/// <summary>
		///Gerekli tasarımcı değişkeni.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///Kullanılan tüm kaynakları temizleyin.
		/// </summary>
		///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer üretilen kod

		/// <summary>
		/// Tasarımcı desteği için gerekli metot - bu metodun 
		///içeriğini kod düzenleyici ile değiştirmeyin.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.openFile = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.mix = new System.Windows.Forms.Button();
			this.label = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// openFile
			// 
			this.openFile.Image = ((System.Drawing.Image)(resources.GetObject("openFile.Image")));
			this.openFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.openFile.Location = new System.Drawing.Point(12, 9);
			this.openFile.Name = "openFile";
			this.openFile.Size = new System.Drawing.Size(100, 26);
			this.openFile.TabIndex = 0;
			this.openFile.Text = "Choose image";
			this.openFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.openFile.UseVisualStyleBackColor = true;
			this.openFile.Click += new System.EventHandler(this.openFile_Click);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(12, 41);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1218, 772);
			this.panel1.TabIndex = 1;
			// 
			// mix
			// 
			this.mix.Image = ((System.Drawing.Image)(resources.GetObject("mix.Image")));
			this.mix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mix.Location = new System.Drawing.Point(118, 9);
			this.mix.Name = "mix";
			this.mix.Size = new System.Drawing.Size(84, 26);
			this.mix.TabIndex = 2;
			this.mix.Text = "Mix Puzzle";
			this.mix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.mix.UseVisualStyleBackColor = true;
			this.mix.Click += new System.EventHandler(this.mix_Click);
			// 
			// label
			// 
			this.label.Location = new System.Drawing.Point(937, 9);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(268, 26);
			this.label.TabIndex = 3;
			this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.Location = new System.Drawing.Point(1211, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(18, 26);
			this.label1.TabIndex = 4;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1242, 821);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label);
			this.Controls.Add(this.mix);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.openFile);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Puzzle";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button openFile;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button mix;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Label label1;
	}
}

