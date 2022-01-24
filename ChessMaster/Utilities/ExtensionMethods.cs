using ChessMaster.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static ChessMaster.Pieces.BoardStyle;

namespace ChessMaster.Utilities
{
    // Extension methods add the method to a class.  The first variable in needs 'this' and the method then exists on that  class
    public static class ExtensionMethods
    {
        public static Colour PieceAtSquare(this IPiece[] pieces, Point square)
        {
            var piece = pieces.Where(p => p.Position == square).FirstOrDefault();

            if(piece != null)
            {
                return piece.Colour;
            }

            return Colour.None;
        }
    }
}
