using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using static ChessMaster.Pieces.BoardStyle;

namespace ChessMaster.Pieces
{
    public class Bishop : Piece, IPiece
    {
        public Bishop(Colour colour)
        {
            var img = new Image();
            img.Source = new BitmapImage(new Uri($"pack://application:,,/Resources/{BoardStyle.Board}/Bishop{colour}.png"));

            this.Image = img;

            this.Image.Tag = this;


            this.PieceType = Pieces.Bishop;
        }
    }
}
