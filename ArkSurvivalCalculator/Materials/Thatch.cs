using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkSurvivalCalculator.Materials
{
    public class Thatch
    {
        public Dictionary<string, int> Foundation = new Dictionary<string, int>();
        public Dictionary<string, int> Wall = new Dictionary<string, int>();
        public Dictionary<string, int> Ceiling = new Dictionary<string, int>();
        public Dictionary<string, int> Doorframe = new Dictionary<string, int>();
        public Dictionary<string, int> Door = new Dictionary<string, int>();

        public Thatch()
        {
            Foundation.Add("Thatch", 20);
            Foundation.Add("Fiber", 15);
            Foundation.Add("Wood", 6);

            Wall.Add("Thatch", 10);
            Wall.Add("Fiber", 7);
            Wall.Add("Wood", 2);

            Ceiling.Add("Thatch", 15);
            Ceiling.Add("Fiber", 10);
            Ceiling.Add("Wood", 4);

            Doorframe.Add("Thatch", 8);
            Doorframe.Add("Fiber", 6);
            Doorframe.Add("Wood", 6);

            Door.Add("Thatch", 7);
            Door.Add("Fiber", 4);
        }
    }
}
