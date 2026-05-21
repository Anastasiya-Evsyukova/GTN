using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTNL.Interfaces
{

    //абстракция взаимодействия с пользователем
    public interface IUserInterface
    {
        void ShowMessage(string message);
        string ReadInput(); //метод чтения строкового ввода от пользователя
        int ReadNumber(); //метод чтения целого числа (с повтором при ошибке)
    }
}
