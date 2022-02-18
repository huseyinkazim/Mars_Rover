using Mars_Rover.Business;
using Mars_Rover.Interface;
using Mars_Rover.Model;
using Mars_Rover.Model.Enums;
using Mars_Rover.Model.Models.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp3
{
    internal class Program
    {
        private static IInputHandler sampleInputHandler;
        private static IDiscover discover;

        static void Main(string[] args)
        {

            //Type:1 parametre ile doldurulur
            var sampleInputHandler = new SampleInputHandler("5 5", new string[] { "1 2 N", "3 3 E" }, new string[] {  "LMLMLMLMM" , "MMRMMRMRRM"});
            Plateau plateau = sampleInputHandler.CreateMap();
            List<Rover> rovers = sampleInputHandler.CreateRovers();
            List<string> commands = sampleInputHandler.CreateCommands();
            var discover = new Discover(plateau, rovers, commands);

            var result = discover.ApplyCommands();

            //Type:2 default doldurulur
            sampleInputHandler = new SampleInputHandler();
            plateau = sampleInputHandler.CreateMap();
            rovers = sampleInputHandler.CreateRovers();
            commands = sampleInputHandler.CreateCommands();

            discover = new Discover(plateau, rovers, commands);

            Console.WriteLine(discover.ApplyCommands());


            Console.ReadLine();
        }
    }
}
