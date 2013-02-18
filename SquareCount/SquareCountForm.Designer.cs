namespace SquareCount
{
    partial class SquareCountForm
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
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._squareCountLabel = new System.Windows.Forms.Label();
            this._selectedSquareTrackBar = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._selectedSquareTrackBar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pictureBox
            // 
            this._pictureBox.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this._pictureBox, 2);
            this._pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pictureBox.Location = new System.Drawing.Point(3, 3);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(284, 263);
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            this._pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this._pictureBox_Paint);
            // 
            // _squareCountLabel
            // 
            this._squareCountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._squareCountLabel.AutoSize = true;
            this._squareCountLabel.Location = new System.Drawing.Point(188, 288);
            this._squareCountLabel.Name = "_squareCountLabel";
            this._squareCountLabel.Size = new System.Drawing.Size(99, 13);
            this._squareCountLabel.TabIndex = 2;
            this._squareCountLabel.Text = "_squareCountLabel";
            // 
            // _selectedSquareTrackBar
            // 
            this._selectedSquareTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this._selectedSquareTrackBar.Location = new System.Drawing.Point(3, 272);
            this._selectedSquareTrackBar.Name = "_selectedSquareTrackBar";
            this._selectedSquareTrackBar.Size = new System.Drawing.Size(179, 45);
            this._selectedSquareTrackBar.TabIndex = 3;
            this._selectedSquareTrackBar.Scroll += new System.EventHandler(this._selectedSquareTrackBar_Scroll);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this._pictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._selectedSquareTrackBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._squareCountLabel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 320);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // SquareCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 320);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SquareCountForm";
            this.Text = "Square count";
            this.Load += new System.EventHandler(this.SquareCountForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._selectedSquareTrackBar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.Label _squareCountLabel;
        private System.Windows.Forms.TrackBar _selectedSquareTrackBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

