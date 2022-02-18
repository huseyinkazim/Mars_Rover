using Mars_Rover.Business;
using Mars_Rover.Model;
using Mars_Rover.Model.Enums;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mars_Rover.UnitTest
{
    public class Tests
    {
  

        [Fact]
        public void HappyPath()
        {
            var sampleInputHandler = new SampleInputHandler();//File için ayrý bussinies sýnýfý oluþturulabilir
            Plateau plateau = sampleInputHandler.CreateMap();
            List<Rover> rovers = sampleInputHandler.CreateRovers();
            List<string> commands = sampleInputHandler.CreateCommands();
            var discover = new Discover(plateau, rovers, commands);

            var result =  discover.ApplyCommands();
            string expect = "1 3 N\n5 1 E";
            Assert.Equal(expect, result);
        }

        [Theory]
        [InlineData(new object[] { "5 5" , new string[] { "1 2 N", "3 3 E" },new string[] {  "LMLMLMLMM", "MMRMMRMRRM" } , new string[] { "1 3 N", "5 1 E" } })]
        public void CorrectInputs(string plateauLine,string[] roverLines,string[] commandLines,string[] expectArr)
        {
            var sampleInputHandler = new SampleInputHandler(plateauLine,roverLines,commandLines);
            Plateau plateau = sampleInputHandler.CreateMap();
            List<Rover> rovers = sampleInputHandler.CreateRovers();
            List<string> commands = sampleInputHandler.CreateCommands();
            var discover = new Discover(plateau, rovers, commands);

            var result = discover.ApplyCommands();
            var expect = string.Join("\n", expectArr);// "1 3 N\n5 1 E";
            Assert.Equal(expect, result);
        }

        [Theory]
        [InlineData(new object[] { "3 5", new string[] { "1 2 N", "3 3 E" }, new string[] { "LMLMLMLMM", "MMRMMRMRRM" }, new string[] { "1 3 N", "5 1 E" } })]
        public void InCorrectInputs(string plateauLine, string[] roverLines, string[] commandLines, string[] expectArr)
        {
            var sampleInputHandler = new SampleInputHandler(plateauLine, roverLines, commandLines);
            Plateau plateau = sampleInputHandler.CreateMap();
            List<Rover> rovers = sampleInputHandler.CreateRovers();
            List<string> commands = sampleInputHandler.CreateCommands();
            var discover = new Discover(plateau, rovers, commands);

            var result = discover.ApplyCommands();
            var expect = string.Join("\n", expectArr);// "1 3 N\n5 1 E";
            Assert.Equal(expect, result);
        }

    }
}