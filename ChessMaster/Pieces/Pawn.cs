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

            var move = (this.Colour == Colour.Black) ? 1 : -1;

            var newPos = new Point(this.Position.X, this.Position.Y + move);

            if (pieces.PieceAtSquare(newPos) == Colour.None)
                points.Add(newPos);

            if ((this.Position.Y == 1 && this.Colour == Colour.Black) || (this.Position.Y == 6 && this.Colour == Colour.White))
            {
                newPos = new Point(this.Position.X, this.Position.Y + (move * 2));

                if (pieces.PieceAtSquare(newPos) == Colour.None)
                    points.Add(newPos);
            }

            newPos = new Point(this.Position.X - 1, this.Position.Y + move);

            if (pieces.PieceAtSquare(newPos) != Colour.None && pieces.PieceAtSquare(newPos) != this.Colour)
                points.Add(newPos);

            newPos = new Point(this.Position.X + 1, this.Position.Y + move);

            if (pieces.PieceAtSquare(newPos) != Colour.None && pieces.PieceAtSquare(newPos) != this.Colour)
                points.Add(newPos);

            return points.ToArray();
        }
    }
}
