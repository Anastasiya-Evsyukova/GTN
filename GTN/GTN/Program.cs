using GTNL.Interfaces;
using GTNL.Services;
using GTNL.Services.Difficulties;
using GTNL.Models;
using GTN.UserInterface;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace GTN
{
    class Program
    {
        static void Main(string[] args)
        {
            //composition Root
            var services = new ServiceCollection();

            //регистрация зависимостей
            services.AddTransient<IGameEngine, GameEngine>();   //для каждой игры новый движок
            services.AddSingleton<INumberGenerator, GTNL.Services.RandomNumberGenerator>(); //потокобезопасен, общий
            services.AddSingleton<IUserInterface, ConsoleUserInterface>();     //общий доступ к консоли

            var serviceProvider = services.BuildServiceProvider();

            RunGame(serviceProvider);
        }

        static void RunGame(IServiceProvider serviceProvider)
        {
            var ui = serviceProvider.GetRequiredService<IUserInterface>();
            ui.ShowMessage("Добро пожаловать в игру 'Угадай число'!");

            while (true)
            {
                ui.ShowMessage("\nВыберите уровень сложности:");
                ui.ShowMessage("1. Легкий (1-50, 10 попыток)");
                ui.ShowMessage("2. Средний (1-100, 7 попыток)");
                ui.ShowMessage("3. Сложный (1-200, 5 попыток)");
                ui.ShowMessage("0. Выход");

                var choice = ui.ReadInput();
                if (choice == "0")
                    break;

                IGameSettings? settings = choice switch
                {
                    "1" => new EasyGameSettings(),
                    "2" => new MediumGameSettings(),
                    "3" => new HardGameSettings(),
                    _ => null
                };

                if (settings == null)
                {
                    ui.ShowMessage("Неверный выбор. Попробуйте снова.");
                    continue;
                }

                //создаём новый движок для каждой игры
                var engine = serviceProvider.GetRequiredService<IGameEngine>();
                engine.StartNewGame(settings);

                ui.ShowMessage($"\nЗагадано число от {settings.MinValue} до {settings.MaxValue}. У вас {settings.MaxAttempts} попыток.");

                while (engine.State == GameState.InProgress)
                {
                    ui.ShowMessage($"Осталось попыток: ???"); //будет уточнено после хода
                    ui.ShowMessage("Введите ваше предположение:");
                    int guess = ui.ReadNumber();

                    var result = engine.Guess(guess);

                    switch (result.Outcome)
                    {
                        case GuessOutcome.Less:
                            ui.ShowMessage("Загаданное число больше.");
                            break;
                        case GuessOutcome.Greater:
                            ui.ShowMessage("Загаданное число меньше.");
                            break;
                        case GuessOutcome.Equal:
                            ui.ShowMessage($"Поздравляем! Вы угадали число {result.SecretNumber} за {settings.MaxAttempts - result.AttemptsLeft} попыток.");
                            break;
                        default:
                            ui.ShowMessage("Некорректный ввод или игра уже завершена.");
                            break;
                    }

                    //показываем оставшиеся попытки, если игра не завершена
                    if (!result.IsGameFinished)
                    {
                        ui.ShowMessage($"Осталось попыток: {result.AttemptsLeft}");
                    }
                    else if (engine.State == GameState.Lost)
                    {
                        ui.ShowMessage($"Вы проиграли. Загаданное число было {result.SecretNumber}.");
                    }
                }
            }

            ui.ShowMessage("Спасибо за игру!");
        }
    }
}