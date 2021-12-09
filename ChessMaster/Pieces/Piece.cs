using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static ChessMaster.Pieces.BoardStyle;

namespace ChessMaster.Pieces
{
    public abstract class Piece : IPiece
    {
        public Piece(Colour colour)
        {
            Colour = colour;
        }

        public Image Image { get; set; }

        public enum Pieces { Rook, Knight, Bishop, King, Queen, Pawn };

        public Pieces PieceType { get; set; }

        public Point Position { get; set; }

        public Colour Colour { get; set; }

        public abstract Point[] GetMoves(IPiece[] pieces);
    }
}
