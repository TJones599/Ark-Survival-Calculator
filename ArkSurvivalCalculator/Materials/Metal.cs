using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkSurvivalCalculator.Materials
{
    public class Metal
    {
        public Dictionary<string, int> Foundation = new Dictionary<string, int>();
        public Dictionary<string, int> Wall = new Dictionary<string, int>();
        public Dictionary<string, int> Ceiling = new Dictionary<string, int>();
        public Dictionary<string, int> Doorframe = new Dictionary<string, int>();
        public Dictionary<string, int> Door = new Dictionary<string, int>();
        public Dictionary<string, int> Windowframe = new Dictionary<string, int>();
        public Dictionary<string, int> Window = new Dictionary<string, int>();

        public Metal()
        {
            Foundation.Add("Metal", 50);
            Foundation.Add("Cementing Paste", 15);

            Wall.Add("Metal", 25);
            Wall.Add("Cementing Paste", 7);

            Ceiling.Add("Metal", 35);
            Ceiling.Add("Cementing Paste", 10);

            Doorframe.Add("Metal", 20);
            Doorframe.Add("Cementing Paste", 6);

            Door.Add("Metal", 10);
            Door.Add("Cementing Paste", 4);

            Windowframe.Add("Metal", 20);
            Windowframe.Add("Cementing Paste", 6);

            Window.Add("Metal", 7);
        }
    }
}
