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
    public class Knight : Piece, IPiece
    {
        public Knight(Colour colour) : base(colour)
        {
            var img = new Image();
            img.Source = new BitmapImage(new Uri($"pack://application:,,/Resources/{BoardStyle.Board}/Knight{colour}.png"));

            this.Image = img;

            this.Image.Tag = this;

            this.PieceType = Pieces.Knight;
        }

        public override Point[] GetMoves(IPiece[] pieces)
        {
            var points = new List<Point>();

            var moves = new List<Point>();

            moves.Add(new Point(this.Position.X + 2, this.Position.Y + 1));
            moves.Add(new Point(this.Position.X + 2, this.Position.Y - 1));
            moves.Add(new Point(this.Position.X + 1, this.Position.Y - 2));
            moves.Add(new Point(this.Position.X + 1, this.Position.Y + 2));
            moves.Add(new Point(this.Position.X - 2, this.Position.Y + 1));
            moves.Add(new Point(this.Position.X - 2, this.Position.Y - 1));
            moves.Add(new Point(this.Position.X - 1, this.Position.Y - 2));
            moves.Add(new Point(this.Position.X - 1, this.Position.Y + 2));

            foreach(var move in moves)
            {
                if(move.X > -1 && move.X < 8 && move.Y > -1 && move.Y < 8)
                {
                    points.Add(move);
                }
            }

            return points.ToArray();
        }
    }
}
