using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkSurvivalCalculator.Materials
{
    public class Wood
    {
        public Dictionary<string, int> Foundation = new Dictionary<string, int>();
        public Dictionary<string, int> Wall = new Dictionary<string, int>();
        public Dictionary<string, int> Ceiling = new Dictionary<string, int>();
        public Dictionary<string, int> Doorframe = new Dictionary<string, int>();
        public Dictionary<string, int> Door = new Dictionary<string, int>();
        public Dictionary<string, int> Windowframe = new Dictionary<string, int>();
        public Dictionary<string, int> Window = new Dictionary<string, int>();

        public Wood()
        {
            Foundation.Add("Thatch", 20);
            Foundation.Add("Fiber", 15);
            Foundation.Add("Wood", 80);

            Wall.Add("Thatch", 10);
            Wall.Add("Fiber", 7);
            Wall.Add("Wood", 40);

            Ceiling.Add("Thatch", 15);
            Ceiling.Add("Fiber", 10);
            Ceiling.Add("Wood", 60);

            Doorframe.Add("Thatch", 8);
            Doorframe.Add("Fiber", 6);
            Doorframe.Add("Wood", 30);

            Door.Add("Thatch", 7);
            Door.Add("Fiber", 4);
            Door.Add("Wood", 20);

            Windowframe.Add("Thatch", 9);
            Windowframe.Add("Fiber", 6);
            Windowframe.Add("Wood", 36);

            Window.Add("Thatch", 2);
            Window.Add("Fiber", 1);
            Window.Add("Wood", 8);
        }
    }
}
