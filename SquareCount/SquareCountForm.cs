using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SquareCount
{
    public partial class SquareCountForm : Form
    {
        string _image =
            "+---+---+---+---+\n" +
            "|   |   |   |   |\n" +
            "|   | +-+-+ |   |\n" +
            "|   | | | | |   |\n" +
            "+---+-+-+-+-+---+\n" +
            "|   | | | | |   |\n" +
            "|   | +-+-+ |   |\n" +
            "|   |   |   |   |\n" +
            "+---+---+---+---+\n" +
            "|   |   |   |   |\n" +
            "|   | +-+-+ |   |\n" +
            "|   | | | | |   |\n" +
            "+---+-+-+-+-+---+\n" +
            "|   | | | | |   |\n" +
            "|   | +-+-+ |   |\n" +
            "|   |   |   |   |\n" +
            "+---+---+---+---+\n";

        int _imageRows;
        int _imageCols;

        int _padding = 10;
        int UsableSize { get { return _pictureBox.Width - 2 * _padding; } }
        int MarkerWidth { get { return UsableSize / _imageCols; } }
        int MarkerHeight { get { return UsableSize / _imageRows; } }
        Point NorthOffset { get { return new Point(0, -MarkerHeight / 3); } }
        Point SouthOffset { get { return new Point(0, +MarkerHeight / 3); } }
        Point WestOffset { get { return new Point(-MarkerWidth / 3, 0); } }
        Point EastOffset { get { return new Point(+MarkerWidth / 3, 0); } }

        enum Marker { None=0, NS=1, EW=2, Cross=3 };

        Marker[,] _map;

        class Square
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Side { get; set; }

            public override string ToString()
            {
                return "( " + Row + ", " + Col + " ) x " + Side;
            }

            public void DrawSquare(Graphics graphics, Func<int,int,Point> map)
            {
                Pen hiliter = new Pen(Color.Yellow, 5);

                Point[] points = new Point[]
                {
                    map(Row, Col),
                    map(Row, Col + Side),
                    map(Row + Side, Col + Side),
                    map(Row + Side, Col),
                    map(Row, Col)
                };

                graphics.DrawLines(hiliter, points);
            }
        }

        List<Square> _squares = new List<Square>();

        void Initialize()
        {
            // count rows and cols
            _imageRows = _image.Where(c => c == '\n').Count();
            _imageCols = _image.IndexOf('\n');

            // convert to marker map
            _map = new Marker[_imageRows, _imageCols];
            int row=0, col=0;
            for (int i=0; i<_image.Length; ++i)
            {
                switch(_image[i])
                {
                    case '\n':
                        row++;
                        col = 0;
                        break;

                    case '-':
                        _map[row,col++] = Marker.EW;
                        break;

                    case '|':
                        _map[row,col++] = Marker.NS;
                        break;

                    case '+':
                        _map[row,col++] = Marker.Cross;
                        break;

                    default:
                        _map[row, col++] = Marker.None;
                        break;
                }
            }
        }

        /// <summary>
        /// Image has a south-path iff there's a "road" from beginning down to end.
        /// </summary>
        /// <param name="fromRow"></param>
        /// <param name="fromCol"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        bool HasSouthPath(int row, int col, int length)
        {
            for (int s = 0; s < length; ++s)
            {
                if (!_map[row + s, col].HasFlag(Marker.NS))
                {
                    return false;
                }
            }

            return true;
        }

        bool HasEastPath(int row, int col, int length)
        {
            for (int s = 0; s < length; ++s)
            {
                if (!_map[row, col + s].HasFlag(Marker.EW))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Image has a square at the given location if there is a cross at each corner and equal-length paths among adjacent corners
        /// </summary>
        /// <param name="row">row of upper-left corner</param>
        /// <param name="col">col of upper-left corner</param>
        /// <param name="side">path-length of side</param>
        /// <returns></returns>
        bool HasSquareAt(int row, int col, int side)
        {
            if (_map[row, col] != Marker.Cross) { return false; }
            if (_map[row, col + side] != Marker.Cross) { return false; }
            if (_map[row + side, col] != Marker.Cross) { return false; }
            if (_map[row + side, col + side] != Marker.Cross) { return false; }

            if (!HasSouthPath(row, col, side)) { return false; }
            if (!HasSouthPath(row, col + side, side)) { return false; }
            if (!HasEastPath(row, col, side)) { return false; }
            if (!HasEastPath(row + side, col, side)) { return false; }

            return true;
        }

        void CountSquares()
        {
            for (int row = 0; row < _imageRows; ++row)
            {
                for (int col = 0; col < _imageCols; ++col)
                {
                    for (int side = 1; row + side < _imageRows && col + side < _imageCols; ++side)
                    {
                        if (HasSquareAt(row, col, side))
                        {
                            _squares.Add(new Square() { Row = row, Col = col, Side = side });
                        }
                    }
                }
            }

            _squareCountLabel.Text = "/ " + _squares.Count;
            _selectedSquareTrackBar.Maximum = _squares.Count - 1;
        }

        public SquareCountForm()
        {
            InitializeComponent();
        }

        Point MapToPicture(int row, int col)
        {
            return new Point(
                _padding + MarkerWidth * col,
                _padding + MarkerHeight * row);
        }

        private void _pictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            Pen pen = new Pen(Color.Black);

            for (int row = 0; row < _imageRows; ++row)
            {
                for (int col = 0; col < _imageCols; ++col)
                {
                    Point p = MapToPicture(row, col), N = p, E = p, W = p, S = p;
                    N.Offset(NorthOffset);
                    E.Offset(EastOffset);
                    W.Offset(WestOffset);
                    S.Offset(SouthOffset);

                    if (_map[row, col].HasFlag(Marker.NS))
                    {
                        e.Graphics.DrawLine(pen, N, S);
                    }

                    if (_map[row, col].HasFlag(Marker.EW))
                    {
                        e.Graphics.DrawLine(pen, E, W);
                    }
                }
            }

            if (_selectedSquareTrackBar.Value >= 0 && _selectedSquareTrackBar.Value < _squares.Count)
            {
                _squares[_selectedSquareTrackBar.Value].DrawSquare(e.Graphics, MapToPicture);
            }
        }

        private void SquareCountForm_Load(object sender, EventArgs e)
        {
            Initialize();
            CountSquares();
        }

        private void _selectedSquareTrackBar_Scroll(object sender, EventArgs e)
        {
            _squareCountLabel.Text = _selectedSquareTrackBar.Value + 1 + " / " + _squares.Count;
            _pictureBox.Invalidate();
        }
    }
}