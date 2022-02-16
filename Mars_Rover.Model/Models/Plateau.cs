using Mars_Rover.Model.Common;
using System;

namespace Mars_Rover.Model
{
    public class Plateau
    {
        public Position Position;

        public Plateau(int x,int y)
        {
            Position = new Position(x,y);
        }
    }
}
