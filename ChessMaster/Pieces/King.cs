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
    public class King : Piece, IPiece
    {
        public King(Colour colour) : base(colour)
        {
            var img = new Image();
            img.Source = new BitmapImage(new Uri($"pack://application:,,/Resources/{BoardStyle.Board}/King{colour}.png"));

            this.Image = img;

            this.Image.Tag = this;

            this.PieceType = Pieces.King;
        }

        public override Point[] GetMoves(IPiece[] pieces)
        {
            var points = new List<Point>();

            
           var newPos = new Point(this.Position.X,this.Position.Y);
           

            int xx = -2;
            int yy = -1;

           for(int i = 0; i <= 8; i++)
            {
                if (xx >= 1 )
                {
                   yy ++;
                   xx = -1; 
                    
                }else xx ++;
             newPos = new Point(this.Position.X + xx,this.Position.Y + yy);
             var color = pieces.PieceAtSquare(newPos);
            if (color != this.Colour)
                {
                 points.Add(newPos);
                    if(color != Colour.None)
                    {
                        continue;
                    }
                }
                else
	            {
                    continue;
	            }
            }
            return points.ToArray();
        }
    }
}
