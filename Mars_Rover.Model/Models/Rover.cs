using Mars_Rover.Model.Common;
using Mars_Rover.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Model
{
    public  class Rover
    {
        public Position Position;
        public Direction Direction;

        public Rover(int x, int y,Direction direction)
        {
            Position = new Position(x, y);
            Direction = direction;
        }
        public string Result => $"{this.Position.XAxis} {this.Position.YAxis} {this.Direction.ToString()}";

    }
}
