using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTNL.Interfaces;

namespace GTN.UserInterface
{
    public class ConsoleUserInterface : IUserInterface
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }

        public int ReadNumber()
        {
            while (true)
            {
                var input = ReadInput();
                if (int.TryParse(input, out int number))
                    return number;

                ShowMessage("Пожалуйста, введите целое число.");
            }
        }
    }
}