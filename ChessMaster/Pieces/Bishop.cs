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
    public class Bishop : Piece, IPiece
    {
        public Bishop(Colour colour) : base(colour)
        {
            var img = new Image();
            img.Source = new BitmapImage(new Uri($"pack://application:,,/Resources/{BoardStyle.Board}/Bishop{colour}.png"));

            this.Image = img;

            this.Image.Tag = this;

            this.PieceType = Pieces.Bishop;
        }

         public override Point[] GetMoves(IPiece[] pieces)
        {
            var points = new List<Point>();

            var up = this.Position.Y;
            var right = this.Position.X;
            var left = this.Position.X;
            var down = this.Position.Y;

            var newPos = new Point(this.Position.X, this.Position.Y);

            
                while(up >= 1 && right <=6)
                {   
                    up --;
                    right ++;
                    
                    newPos = new Point(right,up);
                    var color = pieces.PieceAtSquare(newPos);
                    if (color != this.Colour)
                    {
                        points.Add(newPos);
                        if (color != Colour.None)
                        {
                            break;
                        }
                    }
                    else
                    {
                             break;
                    }    
                    }
                up = this.Position.Y;

                while(up >=1 && left >=1)
                {
                     up --;
                     left --;
                    newPos = new Point(left,up);
                    var color = pieces.PieceAtSquare(newPos);
                    if (color != this.Colour)
                    {
                        points.Add(newPos);
                        if (color != Colour.None)
                        {
                            break;
                        }
                    }
                    else
                    {
                             break;
                    }
                }
                left = this.Position.X;

                up = this.Position.Y;
                right = this.Position.X;

                while(down <= 6 && right <= 6)
                {   
                    right ++;
                    down++;
                    newPos = new Point(right,down);
                    var color = pieces.PieceAtSquare(newPos);
                    if (color != this.Colour)
                    {
                        points.Add(newPos);
                        if (color != Colour.None)
                        {
                            break;
                        }
                    }
                    else
                    {
                             break;
                    }
                }
            
                down = this.Position.Y;

                while(down <= 6 && left >= 1)
                {
                    left --;
                    down ++;
                    newPos = new Point(left,down);
                    var color = pieces.PieceAtSquare(newPos);
                    if (color != this.Colour)
                    {
                        points.Add(newPos);
                        if (color != Colour.None)
                        {
                            break;
                        }
                    }
                    else
                    {
                             break;
                    }
                }


            return points.ToArray();
        }
    }
}
