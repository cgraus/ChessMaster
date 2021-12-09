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
    public class Pawn : Piece, IPiece
    {
        public Pawn(Colour colour) : base(colour)
        {
            var img = new Image();
            img.Source = new BitmapImage(new Uri($"pack://application:,,/Resources/{BoardStyle.Board}/Pawn{colour}.png"));

            this.Image = img;

            this.Image.Tag = this;

            this.PieceType = Pieces.Pawn;
        }

        public override Point[] GetMoves(IPiece[] pieces)
        {
            var points = new List<Point>();

            if (this.Colour == Colour.Black)
            {
                points.Add(new Point(this.Position.X, this.Position.Y + 1));

                if (this.Position.Y == 1)
                {
                    points.Add(new Point(this.Position.X, this.Position.Y + 2));
                }
            }
            else
            {
                points.Add(new Point(this.Position.X, this.Position.Y - 1));

                if (this.Position.Y == 6)
                {
                    points.Add(new Point(this.Position.X, this.Position.Y - 2));
                }
            }

            return points.ToArray();
        }
    }
}
