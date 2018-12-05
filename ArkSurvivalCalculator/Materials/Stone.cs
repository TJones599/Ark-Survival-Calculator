using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkSurvivalCalculator.Materials
{
    public class Stone
    {
        public Dictionary<string, int> Foundation = new Dictionary<string, int>();
        public Dictionary<string, int> Wall = new Dictionary<string, int>();
        public Dictionary<string, int> Ceiling = new Dictionary<string, int>();
        public Dictionary<string, int> Doorframe = new Dictionary<string, int>();
        public Dictionary<string, int> Door = new Dictionary<string, int>();
        public Dictionary<string, int> Windowframe = new Dictionary<string, int>();
        public Dictionary<string, int> Window = new Dictionary<string, int>();

        public Stone()
        {
            Foundation.Add("Stone", 80);
            Foundation.Add("Wood", 40);
            Foundation.Add("Thatch", 30);

            Wall.Add("Stone", 40);
            Wall.Add("Wood", 20);
            Wall.Add("Thatch", 15);

            Ceiling.Add("Stone", 60);
            Ceiling.Add("Wood", 30);
            Ceiling.Add("Thatch", 20);

            Doorframe.Add("Stone", 30);
            Doorframe.Add("Wood", 16);
            Doorframe.Add("Thatch", 12);

            Door.Add("Stone", 20);
            Door.Add("Wood", 14);
            Door.Add("Thatch", 8);

            Windowframe.Add("Stone", 36);
            Windowframe.Add("Wood", 18);
            Windowframe.Add("Thatch", 12);

            Window.Add("Stone", 8);
            Window.Add("Wood", 4);
            Window.Add("Thatch", 3);
        }
    }
}
