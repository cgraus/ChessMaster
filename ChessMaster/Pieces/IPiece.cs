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
    public interface IPiece
    {
        Image Image { get; set; }

        Piece.Pieces PieceType { get; set; }

        Point Position { get; set; }

        Point[] GetMoves(IPiece[] pieces);

        Colour Colour { get; set; }
    }
}
