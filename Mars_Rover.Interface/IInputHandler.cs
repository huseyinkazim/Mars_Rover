using Mars_Rover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Interface
{
    public interface IInputHandler
    {
        string PlateauLine { get; set; }
        List<string> RoverLines { get; set; }
        List<string> CommandLines { get; set; }
        Plateau CreateMap();
        List<Rover> CreateRovers();
        List<string> CreateCommands();

    }
}
