using Mars_Rover.Model;
using Mars_Rover.Model.Common;
using Mars_Rover.Model.Enums;
using System;

namespace Mars_Rover.Interface
{
    public interface IDiscover
    {
        string ApplyCommands();
        void Initialize(Plateau plateau, Rover rover, string command);

    }
}
