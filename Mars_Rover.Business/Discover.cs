using Mars_Rover.Interface;
using Mars_Rover.Model;
using Mars_Rover.Model.Common;
using Mars_Rover.Model.Enums;
using Mars_Rover.Model.Models.Common;
using System;
using System.Collections.Generic;

namespace Mars_Rover.Business
{
    public class Discover : IDiscover
    {
        public Plateau Plateau;
        public List<Rover> Rovers;
        public List<string> Commands;

        public Discover(Plateau plateau, List<Rover> rovers, List<string> commands)
        {
            this.Plateau = plateau;
            this.Rovers = rovers;
            this.Commands = commands;
        }

        public string ApplyCommands()
        {
            int i = 0;
            Way way;
            string result = String.Empty;

            foreach (var rover in Rovers)
            {
                var command = Commands[i++];

                foreach (var value in command)
                {
                    if (CommonChracter.Move == value)
                        move(rover);
                    else if (Enum.TryParse(value.ToString(), out way))
                    {
                        turn(rover, way);
                    }
                }
                result = result+ rover.Result +"\n";

            }
            return result.Substring(0,result.Length-1);
        }

        private void turn(Rover rover, Way way)
        {
            switch (way)
            {
                case Way.L:
                    switch (rover.Direction)
                    {
                        case Direction.N:
                            rover.Direction = Direction.W;
                            break;
                        case Direction.S:
                            rover.Direction = Direction.E;
                            break;
                        case Direction.E:
                            rover.Direction = Direction.N;
                            break;
                        case Direction.W:
                            rover.Direction = Direction.S;
                            break;
                    }
                    break;
                case Way.R:
                    switch (rover.Direction)
                    {
                        case Direction.N:
                            rover.Direction = Direction.E;
                            break;
                        case Direction.S:
                            rover.Direction = Direction.W;
                            break;
                        case Direction.E:
                            rover.Direction = Direction.S;
                            break;
                        case Direction.W:
                            rover.Direction = Direction.N;
                            break;
                    }
                    break;
            }
        }

        private void move(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    if (rover.Position.YAxis + 1 > Plateau.Position.YAxis)
                        throw new Exception($"Razor can not go out of plateau. Razor Y Axis position:{rover.Position.YAxis} Plateau Y Axis position:{Plateau.Position.YAxis}");
                    else
                        rover.Position.YAxis++;
                    break;
                case Direction.S:
                    if (rover.Position.YAxis - 1 < 0)
                        throw new Exception($"Razor can not go out of plateau. Razor Y Axis position:{rover.Position.YAxis} Plateau Y Axis position:{Plateau.Position.YAxis}");
                    else
                        rover.Position.YAxis--;
                    break;
                case Direction.E:
                    if (rover.Position.XAxis + 1 > Plateau.Position.XAxis)
                        throw new Exception($"Razor can not go out of plateau. Razor X Axis position:{rover.Position.XAxis} Plateau X Axis position:{Plateau.Position.XAxis}");
                    else
                        rover.Position.XAxis++;
                    break;
                case Direction.W:
                    if (rover.Position.XAxis - 1 < 0)
                        throw new Exception($"Razor can not go out of plateau. Razor X Axis position:{rover.Position.XAxis} Plateau X Axis position:{Plateau.Position.XAxis}");
                    else
                        rover.Position.XAxis--;
                    break;
            }
        }

    }
}
