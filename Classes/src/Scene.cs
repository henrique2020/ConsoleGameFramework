namespace ConsoleGameFramework.src
{
    internal abstract class Scene
    {
        private World World;
        private int Top;

        public Scene()
        {
            World = new World(20, 80);
            World.Fill();

            Top = 1;
        }

        public void Add(string text)
        {
            Top += World.Draw(Top, 1, text);
        }

        public string RequestUserOption()
        {
            Console.WriteLine("Qual sua escolha?");
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
