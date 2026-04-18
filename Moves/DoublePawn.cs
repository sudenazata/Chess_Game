using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class DoublePawn : Move
    {
        public override MoveType Type => MoveType.DoublePawn;
        public override Position FromPos { get; }
        public override Position ToPos { get; }

        private readonly Position skippedPos;

        public DoublePawn(Position from, Position to)
        {
            FromPos = from;
            ToPos = to;
            skippedPos = new Position((from.Row + to.Row) / 2, from.Column);
        }

        public override bool Execute(Board board)
        {
            Piece piece = board[FromPos];

            // KORUMA: Eğer taş zaten yerinden kalkmışsa (null ise) çökmeyi engelle ve metodu durdur.
            

            Player player = piece.Color;
            board.SetPawnSkipPosition(player, skippedPos);
            new NormalMove(FromPos, ToPos).Execute(board);

            return true;
        }
    }
}