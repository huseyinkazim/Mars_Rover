using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Model.Common
{
    public class Position
    {
        private int _xAxis;
        private int _yAxis;

        public int XAxis { get { return _xAxis; } set { if (_xAxis != value) _xAxis = value; } }
        public int YAxis { get { return _yAxis; } set { if (_yAxis != value) _yAxis = value; } }


        public Position(int x, int y)
        {
            this._xAxis = x;
            this._yAxis = y;
        }
    }
}
