Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms

Imports System.Drawing
Imports DevExpress.XtraPrinting
' ...

Namespace docPrintingSystemInsertPageBreak
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Start report generation.
			printingSystem1.Begin()

			' Obtain the Printing System's graphics.
			Dim gr As BrickGraphics = printingSystem1.Graph

			' Specify graphics settings.
			gr.Modifier = BrickModifier.Detail
			gr.BackColor = Color.FromArgb(26, 26, 154)
			gr.BorderColor = Color.FromArgb(254, 202, 2)

			' Insert a text brick.
			Dim s As String = "XtraPrinting Library"
			Dim textBrick As New TextBrick()
			textBrick = gr.DrawString(s, Color.FromArgb(67, 145, 252), New RectangleF(0, 0, 286, 80), BorderSide.All)
			textBrick.Font = New Font("Arial", 20, FontStyle.Bold Or FontStyle.Italic)
			Dim bsf As New BrickStringFormat(StringAlignment.Center, StringAlignment.Center)
			textBrick.StringFormat = bsf

			' Insert a page break.
			printingSystem1.InsertPageBreak(81)

			' Insert an image brick.
			Dim img As Image = Image.FromFile("..\..\logo.png")
			Dim imageBrick As New ImageBrick()
			imageBrick = gr.DrawImage(img, New RectangleF(0, 81, 286, 81))

			' Finish report generation.
			printingSystem1.End()

			' Display the Print Preview form.
			printingSystem1.PreviewFormEx.Show()
		End Sub
	End Class
End Namespace

