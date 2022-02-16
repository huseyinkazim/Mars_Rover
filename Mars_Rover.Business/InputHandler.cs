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
        public List<string> RoverLine { get; set; } = new List<string>();

        public const char Move = 'M';
        public SampleInputHandler()
        {
            getInputs();
            controlRoverLineLength();
        }
        private void getInputs()//Interface e bağlanack
        {
            PlateauLine = "5 5";
            RoverLine.Add("1 2 N");
            RoverLine.Add("LMLMLMLMM");
            RoverLine.Add("3 3 E");
            RoverLine.Add("MMRMMRMRRM");
        }
        private bool controlRoverLineLength() => RoverLine.Count % 2 == 0 ? true : throw new Exception("Given inputs line count is not in correct format!");

        public Plateau CreateMap()
        {
            int x, y;
            var position = PlateauLine.Split(" ");

            if (position.Length != 2) throw new Exception($"Plateau input:{PlateauLine} is not in correct format!");
            if (!int.TryParse(position[0], out x)) throw new Exception($"Plateau first input:{position[0]} is not integer!");
            if (!int.TryParse(position[1], out y)) throw new Exception($"Plateau second input:{position[1]} is not integer!");

            return new Plateau(x, y);
        }
        public List<Rover> CreateRovers()
        {
            List<Rover> rovers = new List<Rover>();
            int x, y;
            Direction direction;
            for (int i = 0; i < RoverLine.Count; i = i + 2)
            {
                var item = RoverLine[i];
                var values = item.Split(" ");
                if (values.Length != 3) throw new Exception($"Rover input:{item} is not in correct format!");
                if (!int.TryParse(values[0], out x)) throw new Exception($"Rover first input:{values[0]} is not integer!");
                if (!int.TryParse(values[1], out y)) throw new Exception($"Rover second input:{values[1]} is not integer!");
                if (!Enum.TryParse(values[2], out direction)) throw new Exception($"Rover direction input:{values[2]} is not in correct format!");
                rovers.Add(new Rover(x, y, direction));
            }
            return rovers;
        }
        public List<string> CreateCommands()
        {
            List<string> commands = new List<string>();
            Way way;
            for (int i = 1; i < RoverLine.Count; i = i + 2)
            {
                var values = RoverLine[i].ToCharArray();
                for (int j = 0; j < values.Length; j++)
                {
                    if (values[j] != CommonChracter.Move && !Enum.TryParse(values[j].ToString(), out way))
                        throw new Exception($"Rover command input character:{values[j]} is not in correct format!");
                }
                commands.Add(RoverLine[i]);
            }
            return commands;
        }
    }
}
