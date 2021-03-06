using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using static ChessMaster.Pieces.BoardStyle;
using System.Windows;
using ChessMaster.Utilities;

namespace ChessMaster.Pieces
{
    public class Rook : Piece, IPiece
    {
        public Rook(Colour colour) : base(colour)
        {
            var img = new Image();
            img.Source = new BitmapImage(new Uri($"pack://application:,,/Resources/{BoardStyle.Board}/Rook{colour}.png"));

            this.Image = img;

            this.Image.Tag = this;

            this.PieceType = Pieces.Rook;
        }

        public override Point[] GetMoves(IPiece[] pieces)
        {
            var points = new List<Point>();

            var up = this.Position.Y - 1;
            var down = this.Position.Y + 1;
            var right = this.Position.X + 1;
            var left = this.Position.X - 1;

            var newPos = new Point(this.Position.X, this.Position.Y);

           while (up >= 0)
           { 
             newPos = new Point(this.Position.X, up);
             var color = pieces.PieceAtSquare(newPos);
            if(color != this.Colour)
            {
                points.Add(newPos);

                if(color != Colour.None)
                {
                    break;
                }                                    
            }
            else
            {
                break;
            }

                up --;
           }

            while (down <= 7)
            {
                newPos = new Point(this.Position.X,down);
                var color = pieces.PieceAtSquare(newPos);
                if (color != this.Colour)
                {
                    points.Add(newPos);
                    if(color != Colour.None)
                    {
                        break;

                    }
                }
                else
                {
                    break;
                }

                down ++;
            }

            while(right <= 7)
            {
                newPos = new Point(right,this.Position.Y);
                var color = pieces.PieceAtSquare(newPos);
                if(color != this.Colour)
                {
                    points.Add(newPos);

                    if(color != Colour.None)
                    {
                        break;

                    }

                }
                else
                {
                    break;
                }


                right ++;
            }

            while(left >= 0)
            {
                newPos = new Point(left,this.Position.Y);
                var color = pieces.PieceAtSquare(newPos);
                if(color != this.Colour)
                {
                    points.Add(newPos);
                    if(color != Colour.None)
                    {
                     break;
                    }
                }
                else
                {
                    break;
                }
                left --;
            }

            return points.ToArray();
        }
    }
}
