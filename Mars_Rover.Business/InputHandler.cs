using Mars_Rover.Interface;
using Mars_Rover.Model;
using Mars_Rover.Model.Enums;
using Mars_Rover.Model.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Business
{
    public class SampleInputHandler : IInputHandler
    {

        public string PlateauLine { get; set; }
        public List<string> RoverLines { get; set; } = new List<string>();
        public List<string> CommandLines { get; set; } = new List<string>();

        public const char Move = 'M';
        public SampleInputHandler()
        {
            getInputs();
            controlRoverLineLength();
        }
        public SampleInputHandler(string plateauLine, string[] roverLines, string[] commandLines)
        {
            PlateauLine = plateauLine; ;
            RoverLines = roverLines.ToList();
            CommandLines = commandLines.ToList();

            controlRoverLineLength();
        }
    
        public Plateau CreateMap()
        {
            Tuple<int, int> tuple;
            tuple = controlPlateau();


            return new Plateau(tuple.Item1, tuple.Item2);
        }
        public List<Rover> CreateRovers()
        {
            List<Rover> rovers = new List<Rover>();

            foreach (var roverLine in RoverLines)
            {
                var tuple = controlCreateRover(roverLine);
                rovers.Add(new Rover(tuple.Item1, tuple.Item2, tuple.Item3));
            }
            return rovers;
        }

        public List<string> CreateCommands()
        {
            List<string> commands = new List<string>();
            foreach (var commandLine in CommandLines)
            {
                var command = controlCreateCommand(commandLine);
                commands.Add(command);
            }
            return commands;
        }


        private void getInputs()
        {
            PlateauLine = "5 5";
            RoverLines.Add("1 2 N");
            CommandLines.Add("LMLMLMLMM");
            RoverLines.Add("3 3 E");
            CommandLines.Add("MMRMMRMRRM");
        }
        private bool controlRoverLineLength() => RoverLines.Count == CommandLines.Count ? true : throw new Exception("Given inputs line count is not in correct format!");
        private Tuple<int, int> controlPlateau()
        {
            int x, y;

            var position = PlateauLine.Split(" ");

            if (position.Length != 2) throw new Exception($"Plateau input:{PlateauLine} is not in correct format!");
            if (!int.TryParse(position[0], out x)) throw new Exception($"Plateau first input:{position[0]} is not integer!");
            if (!int.TryParse(position[1], out y)) throw new Exception($"Plateau second input:{position[1]} is not integer!");
            return Tuple.Create(x, y);
        }
        private Tuple<int, int, Direction> controlCreateRover(string item)
        {
            int x, y;
            Direction direction;
            var values = item.Split(" ");
            if (values.Length != 3) throw new Exception($"Rover input:{item} is not in correct format!");
            if (!int.TryParse(values[0], out x)) throw new Exception($"Rover first input:{values[0]} is not integer!");
            if (!int.TryParse(values[1], out y)) throw new Exception($"Rover second input:{values[1]} is not integer!");
            if (!Enum.TryParse(values[2], out direction)) throw new Exception($"Rover direction input:{values[2]} is not in correct format!");

            return Tuple.Create(x, y, direction);
        }
        private string controlCreateCommand(string item)
        {
            Way way;
            var values = item.ToCharArray();
            for (int j = 0; j < values.Length; j++)
            {
                if (values[j] != CommonChracter.Move && !Enum.TryParse(values[j].ToString(), out way))
                    throw new Exception($"Rover command input character:{values[j]} is not in correct format!");
            }
            return item;
        }
    }
}
