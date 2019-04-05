//160202009 MERT HÜSEYİN UZAN
//160202063 SERKAN YAVAŞ
//YAZLAB 2 - 1.PROJE PUZZLE

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Yazlab2_1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		OpenFileDialog file = new OpenFileDialog();
		Bitmap bmp;
		Bitmap tmp;
		Button[,] pictures =new Button[4,4];
		Button[,] real = new Button[4, 4];
		int score = 100;
		Boolean scoreflag = false;
		int isClicked = 0;
		Button previous;
		int correct = 0;
		int highscore=0;
		String highscoreDate;

		private void Form1_Load(object sender, EventArgs e)
		{
			panel1.Visible = false;
			String txt = "enyuksekskor.txt";
			var lines = File.ReadLines(txt);
			foreach (var line in lines)
			{
				String s = line.Substring(17);
				String d = line.Substring(0, 16);
				int n = int.Parse(s);
				if (n > highscore)
				{
					highscoreDate = d;
					highscore = n;
				}
			}
			label.Text = "Best Score: "+highscore+" Date: "+highscoreDate;
		}

		private void openFile_Click(object sender, EventArgs e)
		{
			file.Filter = " PNG |*.png| BMP |*.bmp| JPEG |*.jpeg| JPG |*.jpg";
			file.FilterIndex = 4;
			file.RestoreDirectory = true;
			file.CheckFileExists = false;
			file.Title = "Select picture";
			file.ShowDialog();
			images();

		}

		private void images()
		{
			panel1.AutoScroll = true;
			Image image = Image.FromFile(file.FileName);
			tmp = (Bitmap)image;

			int h = image.Size.Height;
			int y = (this.ClientSize.Height / 2) - ((2 * h / 4) + 3);
			int w = image.Size.Width;
			int x= (this.ClientSize.Width / 2) - ((2 * w/4) + 3);
			int imageHeight = image.Size.Height / 4;
			int imageWidth = image.Size.Width / 4;

			for (int i = 0; i < 4; i++)
			{
				for(int j = 0; j < 4; j++)
				{
					real[i, j] = new Button();
					real[i, j].Size = new Size(w / 4, h / 4);
					String name = "real";
					name = name + i + "" + j;
					real[i, j].Name = name;
					bmp = tmp.Clone(new System.Drawing.Rectangle(j * imageWidth, i * imageHeight, imageWidth, imageHeight), tmp.PixelFormat);
					real[i, j].Image = bmp;


					pictures[i, j] = new Button();
					pictures[i, j].Size= new Size(w / 4, h / 4);
					pictures[i, j].Location=new Point(j * (w/4) + x, i * (h/4) + y);
					String name2 = "picture";
					name2 = name2 + i+""+j;
					pictures[i, j].Name = name2;
					pictures[i, j].Click += pictureClick;
					panel1.Controls.Add(pictures[i, j]);
					bmp = tmp.Clone(new System.Drawing.Rectangle(j * imageWidth, i * imageHeight, imageWidth, imageHeight), tmp.PixelFormat);
					pictures[i, j].Image = bmp;
					
				}
			}
		}
	
		private void control(Button button)
		{ 
			int x= int.Parse(""+ button.Name.Substring(7,1));
			int y= int.Parse(""+ button.Name.Substring(8));
			int w = real[x, y].Width;
			int h = real[x, y].Height;
			Bitmap real_ = (Bitmap)real[x, y].Image;
			Bitmap clicked = (Bitmap)button.Image;
			int counter=0;
			for(int i = 0; i < w; i++)
			{
				for(int j = 0; j < h; j++)
				{
					Color pixelreal = real_.GetPixel(i, j);
					Color pixelclicked = clicked.GetPixel(i, j);
					if (pixelreal.Equals(pixelclicked))
					{
						counter++;
					}
				}
			}
			if (counter == w * h)
			{
				button.Click -= pictureClick;
				correct++;
				scoreflag = true;
				Console.WriteLine("Correct puzzle piece:" + correct);
				if (correct >= 16)
				{
					finish();
				}
			}
			else
			{
				if (!scoreflag)
				{
					score -= 5;
				}
			}
			Console.WriteLine(score);
		}

		private void pictureClick(object sender, EventArgs e)
		{
			mix.Visible = false; // After click any puzzle piece mix&file button gets locked
			openFile.Visible = false;
			Button pic = (Button)sender;

			if (isClicked==1)
			{
				isClicked = 0;
				Image tmp = previous.Image;
				previous.Image = pic.Image;
				pic.Image = tmp;
				control(pic);
				control(previous);
				scoreflag = false;
			}
			else
			{
				previous = pic;
				isClicked=1;
			}
		}

		private void finish()
		{
			TextWriter textWriter = new StreamWriter("enyuksekskor.txt", true);
			DateTime dt = DateTime.Now;
			textWriter.WriteLine(dt.ToString("MM/dd/yyyy HH:mm") + ";" + score);
			textWriter.Close();
			Console.WriteLine("Puzzle has done. Score: "+score);
			DialogResult result = MessageBox.Show("Puzzle has done. Score:" + score, "Congratulations!");
			if (result == DialogResult.OK)
			{
				Environment.Exit(1);
			}
		}

		private void mix_Click(object sender, EventArgs e)
		{
			panel1.Visible = true;
			Random r = new Random();
			
			for (int i = 0; i < 8; i++)
			{
				int random = r.Next(0, 4);
				int random2 = r.Next(0, 4);
				int random3 = r.Next(0, 4);
				int random4 = r.Next(0, 4);
				Image tmp = pictures[random, random2].Image;
				pictures[random, random2].Image = pictures[random3, random4].Image;
				pictures[random3, random4].Image = tmp;
			}
			int counter2 = 0;
			correct = 0;

			//Getting number of correct pictures after the mixing process
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					Bitmap pic_=(Bitmap)pictures[i, j].Image;
					Bitmap real_= (Bitmap)real[i, j].Image;
					int w = real_.Width;
					int h = real_.Height;

					for (int x = 0; x < w; x++)
					{
						for (int y = 0; y < h; y++)
						{
							if (real_.GetPixel(x, y).Equals(pic_.GetPixel(x, y))) // Comparing pixels
							{
								counter2++;
							}

						}
					}
					if (counter2 == w * h)
					{
						correct++;
						pictures[i, j].Click -= pictureClick;
					}
					counter2 = 0;
				}
			}
			Console.WriteLine(correct);
			if (correct >= 16)
			{
				finish();
			}
		}

		
	}
}

