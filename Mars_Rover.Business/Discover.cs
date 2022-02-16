using Mars_Rover.Interface;
using Mars_Rover.Model;
using Mars_Rover.Model.Common;
using Mars_Rover.Model.Enums;
using Mars_Rover.Model.Models.Common;
using System;

namespace Mars_Rover.Business
{
    public class Discover : IDiscover
    {
        public Plateau plateau ;
        public Rover rover;
        public string command;

        public Discover(Plateau plateau, Rover rover, string command)
        {
            Initialize(plateau,rover,command);
        }

        public Discover()
        {
        }

        public void Initialize(Plateau plateau, Rover rover, string command)
        {
            this.plateau = plateau;
            this.rover = rover;
            this.command = command;
        }
        public string ApplyCommands()
        {
            foreach (var value in command)
            {
                Way way;
                if (CommonChracter.Move == value)
                    move();
                else if (Enum.TryParse(value.ToString(), out way))
                {
                    turn(way);
                }
            }
            return rover.Result;
        }

        private void turn(Way way)
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

        private void move()
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    if (rover.Position.YAxis + 1 > plateau.Position.YAxis)
                        throw new Exception($"Razor can not go out of plateau. Razor Y Axis position:{rover.Position.YAxis} Plateau Y Axis position:{plateau.Position.YAxis}");
                    else
                        rover.Position.YAxis++;
                    break;
                case Direction.S:
                    if (rover.Position.YAxis - 1 < 0)
                        throw new Exception($"Razor can not go out of plateau. Razor Y Axis position:{rover.Position.YAxis} Plateau Y Axis position:{plateau.Position.YAxis}");
                    else
                        rover.Position.YAxis--;
                    break;
                case Direction.E:
                    if (rover.Position.XAxis + 1 > plateau.Position.XAxis)
                        throw new Exception($"Razor can not go out of plateau. Razor X Axis position:{rover.Position.XAxis} Plateau X Axis position:{plateau.Position.XAxis}");
                    else
                        rover.Position.XAxis++;
                    break;
                case Direction.W:
                    if (rover.Position.XAxis - 1 < 0)
                        throw new Exception($"Razor can not go out of plateau. Razor X Axis position:{rover.Position.XAxis} Plateau X Axis position:{plateau.Position.XAxis}");
                    else
                        rover.Position.XAxis--;
                    break;
            }
        }

    }
}
