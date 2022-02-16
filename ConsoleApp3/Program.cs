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
            sampleInputHandler = new SampleInputHandler();//File için ayrı bussinies sınıfı oluşturulabilir
            discover = new Discover();
            Plateau plateau = sampleInputHandler.CreateMap();
            List<Rover> rovers = sampleInputHandler.CreateRovers();
            List<string> commands = sampleInputHandler.CreateCommands();
            int i = 0;
            foreach (Rover rover in rovers)
            {
                discover.Initialize(plateau, rover, commands[i]);
                Console.WriteLine(discover.ApplyCommands());
                i++;
            }

            Console.ReadLine();
        }
    }
}
