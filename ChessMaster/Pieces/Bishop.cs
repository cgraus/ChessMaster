using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using static ChessMaster.Pieces.BoardStyle;
using System.Windows;

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

            var up = this.Position.Y-1;
            var left = this.Position.X +1;
            var down = this.Position.Y +1;
            var right = this.Position.X -1;

            // up left and right
            while(up >= 0 || left <= 7 || right >= 0 || down <= 7)

            {
                if(up >= 0 && right >=0)
                {
                    points.Add(new Point(right,up));
                }
                if(up >= 0 && left <=7)
                {
                    points.Add(new Point(left,up));
                }
                if(down <= 7 && right >= 0)
                {
                    points.Add(new Point(right,down));
                }
                if(down <= 7 && left <= 7)
                {
                    points.Add(new Point(left,down));
                }
                up --;
                left ++;
                right --;
                down ++;
            }

            return points.ToArray();
        }
    }
}
