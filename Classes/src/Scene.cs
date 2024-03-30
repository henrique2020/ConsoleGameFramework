using static System.Net.Mime.MediaTypeNames;

namespace ConsoleGameFramework.src
{
    internal abstract class Scene
    {
        private World World;
        private int Top;
        public string UserOptionMessage;

        public Scene()
        {
            World = new World(25, 80);
            World.Fill();

            Top = 1;
            if (!string.IsNullOrWhiteSpace(Player.Instance.Name))
            {
                Add($"{Player.Instance.Name} ({Player.Instance.Life}♥) - ${Player.Instance.Money}");
            }

            UserOptionMessage = "Qual a sua escolha?";
        }

        public void Add(string text)
        {
            Top += World.Draw(Top, 1, text);
        }

        public string RequestUserOption()
        {
            Console.WriteLine(UserOptionMessage);
            string option = Console.ReadLine();

            return option;
        }

        public void Show()
        {
            World.Print();
            string palyerOptinon = RequestUserOption();
            ProcessOption(palyerOptinon);
        }

        public abstract void ProcessOption(string playerOption);

        public static void Move(Scene scene)
        {
            Console.Clear();
            scene.Show();
        }
    }
}
