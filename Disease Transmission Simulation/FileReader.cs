using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Disease_Transmission_Simulation
{
    public class FileReader
    {
        private string[] textInput;

        public FileReader()
        {
            textInput = File.ReadAllLines("D:\\run.txt");
        }

        public void printAllLines()
        {
            foreach(string s in this.textInput)
            {
                Console.WriteLine(s);
            }
        }
    }
}
