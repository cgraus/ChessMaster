﻿using System;
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
            return null;
        }
    }
}
