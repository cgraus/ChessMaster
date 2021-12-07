using ChessMaster.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessMaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Piece> Pieces;

        public MainWindow()
        {
            InitializeComponent();
            CreatePieces();
            this.ContentRendered += this.Window_ContentRendered;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DrawGameArea();
        }

        private void CreatePieces()
        {
            this.Pieces = new List<Piece>();

            for(var n = 0; n<8; ++n)
            {
                Pieces.Add(new Pawn(BoardStyle.Colour.Black)
                {
                    Position = new Point(n, 1)
                });
            }

            Pieces.Add(new Rook(BoardStyle.Colour.Black)
            {
                Position = new Point(0, 0)
            });

            Pieces.Add(new Rook(BoardStyle.Colour.Black)
            {
                Position = new Point(7, 0)
            });

            Pieces.Add(new Knight(BoardStyle.Colour.Black)
            {
                Position = new Point(1, 0)
            });

            Pieces.Add(new Knight(BoardStyle.Colour.Black)
            {
                Position = new Point(6, 0)
            });

            Pieces.Add(new Bishop(BoardStyle.Colour.Black)
            {
                Position = new Point(2, 0)
            });

            Pieces.Add(new Bishop(BoardStyle.Colour.Black)
            {
                Position = new Point(5, 0)
            });

            Pieces.Add(new King(BoardStyle.Colour.Black)
            {
                Position = new Point(3, 0)
            });

            Pieces.Add(new Queen(BoardStyle.Colour.Black)
            {
                Position = new Point(4, 0)
            });

            for (var n = 0; n < 8; ++n)
            {
                Pieces.Add(new Pawn(BoardStyle.Colour.White)
                {
                    Position = new Point(n, 6)
                });
            }

            Pieces.Add(new Rook(BoardStyle.Colour.White)
            {
                Position = new Point(0, 7)
            });

            Pieces.Add(new Rook(BoardStyle.Colour.White)
            {
                Position = new Point(7, 7)
            });

            Pieces.Add(new Knight(BoardStyle.Colour.White)
            {
                Position = new Point(1, 7)
            });

            Pieces.Add(new Knight(BoardStyle.Colour.White)
            {
                Position = new Point(6, 7)
            });

            Pieces.Add(new Bishop(BoardStyle.Colour.White)
            {
                Position = new Point(2, 7)
            });

            Pieces.Add(new Bishop(BoardStyle.Colour.White)
            {
                Position = new Point(5, 7)
            });

            Pieces.Add(new King(BoardStyle.Colour.White)
            {
                Position = new Point(3, 7)
            });

            Pieces.Add(new Queen(BoardStyle.Colour.White)
            {
                Position = new Point(4, 7)
            });


            foreach(var piece in Pieces)
            {
                piece.Image.MouseDown += this.MouseDown;
            }
        }

        void MouseDown(object p, MouseButtonEventArgs ea)
        {
            var image = p as Image;

            var piece = image.Tag as Piece;

            MessageBox.Show(piece.PieceType.ToString());
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            DrawGameArea();
        }

   /*     private void AddPieces()
        {
            var width = Math.Floor(GameArea.ActualWidth / 8);
            var height = Math.Floor(GameArea.ActualHeight / 8);
            var size = (int)Math.Min(width, height);

            var xoffset = (int)(GameArea.ActualWidth - (size * 8)) / 2;
            var yoffset = (int)(GameArea.ActualHeight - (size * 8)) / 2;         
        }
   */
        private void DrawGameArea()
        {
            GameArea.Children.Clear();
            var width = Math.Floor(GameArea.ActualWidth / 8);
            var height = Math.Floor(GameArea.ActualHeight / 8);
            var size = (int) Math.Min(width,height);

            var xoffset = (int)(GameArea.ActualWidth - (size * 8)) / 2;
            var yoffset = (int)(GameArea.ActualHeight - (size * 8)) / 2;

            if ((Double.IsNaN(width) || Double.IsInfinity(width)))
                return;

            bool doneDrawingBackground = false;
            int nextX = xoffset, nextY = yoffset;
            int rowCounter = 0;
            bool nextIsOdd = false;

            int xRows = 0, yRows = 0;

            while (doneDrawingBackground == false)
            {
                Rectangle rect = new Rectangle
                {
                    Width = size,
                    Height = size,
                    Fill = nextIsOdd ? Brushes.White : Brushes.Black
                };
                GameArea.Children.Add(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);

                nextIsOdd = !nextIsOdd;
                nextX += size;
                ++xRows;
                if (xRows > 7 && yRows > 7)
                    break;

                if (nextX >= GameArea.ActualWidth || xRows > 7)
                {
                    xRows = 0;
                    ++yRows;
                    nextX = xoffset;
                    nextY += size;
                    rowCounter++;
                    nextIsOdd = (rowCounter % 2 != 0);
                }

                if (nextY >= GameArea.ActualHeight)
                    doneDrawingBackground = true;
            }

            foreach(var piece in Pieces)
            {
                var left = (piece.Position.X * size) + xoffset;
                var top = (piece.Position.Y * size) + yoffset;

                piece.Image.Width = size;
                piece.Image.Height = size;

                _ = GameArea.Children.Add(piece.Image);

                Canvas.SetTop(piece.Image, top);
                Canvas.SetLeft(piece.Image, left);
            }
        }
    }
}
