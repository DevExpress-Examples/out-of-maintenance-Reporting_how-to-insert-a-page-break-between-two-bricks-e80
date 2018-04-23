using System;
using System.Windows.Forms;

using System.Drawing;
using DevExpress.XtraPrinting;
// ...

namespace docPrintingSystemInsertPageBreak {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Start report generation.
            printingSystem1.Begin();

            // Obtain the Printing System's graphics.
            BrickGraphics gr = printingSystem1.Graph;

            // Specify graphics settings.
            gr.Modifier = BrickModifier.Detail;
            gr.BackColor = Color.FromArgb(26, 26, 154);
            gr.BorderColor = Color.FromArgb(254, 202, 2);

            // Insert a text brick.
            string s = "XtraPrinting Library";
            TextBrick textBrick = new TextBrick();
            textBrick = gr.DrawString(s, Color.FromArgb(67, 145, 252),
                new RectangleF(0, 0, 286, 80), BorderSide.All);
            textBrick.Font = new Font("Arial", 20, FontStyle.Bold | FontStyle.Italic);
            BrickStringFormat bsf = new BrickStringFormat(StringAlignment.Center,
                StringAlignment.Center);
            textBrick.StringFormat = bsf;

            // Insert a page break.
            printingSystem1.InsertPageBreak(81);

            // Insert an image brick.
            Image img = Image.FromFile(@"..\..\logo.png");
            ImageBrick imageBrick = new ImageBrick();
            imageBrick = gr.DrawImage(img, new RectangleF(0, 81, 286, 81));

            // Finish report generation.
            printingSystem1.End();

            // Display the Print Preview form.
            printingSystem1.PreviewFormEx.Show();
        }
    }
}

