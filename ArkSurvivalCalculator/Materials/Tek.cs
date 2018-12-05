using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkSurvivalCalculator.Materials
{
    public class Tek
    {
        public Dictionary<string, int> Foundation = new Dictionary<string, int>();
        public Dictionary<string, int> Wall = new Dictionary<string, int>();
        public Dictionary<string, int> Ceiling = new Dictionary<string, int>();
        public Dictionary<string, int> Doorframe = new Dictionary<string, int>();
        public Dictionary<string, int> Door = new Dictionary<string, int>();
        public Dictionary<string, int> Windowframe = new Dictionary<string, int>();
        public Dictionary<string, int> Window = new Dictionary<string, int>();

        public Tek()
        {
            Foundation.Add("Metal", 100);
            Foundation.Add("Polymer", 45);
            Foundation.Add("Crystal", 20);
            Foundation.Add("Element", 1);

            Wall.Add("Metal", 35);
            Wall.Add("Polymer", 20);
            Wall.Add("Crystal", 15);
            Wall.Add("Element", 1);

            Ceiling.Add("Metal", 50);
            Ceiling.Add("Polymer", 25);
            Ceiling.Add("Crystal", 20);
            Ceiling.Add("Element", 1);

            Doorframe.Add("Metal", 30);
            Doorframe.Add("Polymer", 15);
            Doorframe.Add("Crystal", 5);
            Doorframe.Add("Element", 1);

            Door.Add("Polymer", 40);
            Door.Add("Crystal", 60);
            Door.Add("Element", 1);

            Windowframe.Add("Metal", 30);
            Windowframe.Add("Polymer", 15);
            Windowframe.Add("Crystal", 5);
            Windowframe.Add("Element", 1);

            Window.Add("Polymer", 16);
            Window.Add("Crystal", 40);
            Window.Add("Element", 1);

        }
    }
}
