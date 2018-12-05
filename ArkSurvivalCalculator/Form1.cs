using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArkSurvivalCalculator.Materials;

namespace ArkSurvivalCalculator
{
    public partial class Form1 : Form
    {
        private static bool[,] Grid = new bool[10, 10];
        private static Color color = new Color();

        //storing our base requirements before and after accounting for floor count
        private static int foundation = 0;
        private static int roof = 0;
        private static int walls = 0;
        private static int doors = 0;
        private static int floors = 1;
        private static int height = 1;
        private static int windows = 0;

        private static string primaryMaterial = "Thatch";
        private static string secondaryMaterial = "Thatch";

        public Form1()
        {
            InitializeComponent();
            //defaulting array values to false
            Grid.Initialize();
            //collecting original button color
            color = Button00.BackColor;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            char[] name = b.Name.ToCharArray();
            //collecting array coordinates from button name.
            int cord1 = int.Parse(name[6].ToString());
            int cord2 = int.Parse(name[7].ToString());

            //swapping tile status
            Grid[cord1, cord2] = !(Grid[cord1, cord2]);

            //color swapping between selected vs non-selected tile
            if (Grid[cord1, cord2])
            {
                b.BackColor = Color.LightBlue;
            }
            else if (!Grid[cord1, cord2])
            {
                b.BackColor = color;
            }

            CalculateStructure(cord1, cord2);
            CalculateCost();

        }

        private void CalculateCost()
        {
            Dictionary<string, int> primary;
            Dictionary<string, int> secondary;

            primary = CalcPrimary();
            secondary = CalcSecondary();


            //ThatchAmount.Text = (primary["Thatch"]).ToString();
            //FiberAmount.Text = (primary["Fiber"]).ToString();
            //WoodAmount.Text = (primary["Wood"]).ToString();
            //StoneAmount.Text = (primary["Stone"]).ToString();
            //MetalAmount.Text = (primary["Metal"]).ToString();
            //PasteAmount.Text = (primary["Paste"]).ToString();
            //PolymerAmount.Text = (primary["Polymer"]).ToString();
            //CrystalAmount.Text = (primary["Crystal"]).ToString();
            //ElementAmount.Text = (primary["Element"]).ToString();


            ThatchAmount.Text = (primary["Thatch"] + secondary["Thatch"]).ToString();
            FiberAmount.Text = (primary["Fiber"] + secondary["Fiber"]).ToString();
            WoodAmount.Text = (primary["Wood"] + secondary["Wood"]).ToString();
            StoneAmount.Text = (primary["Stone"] + secondary["Stone"]).ToString();
            MetalAmount.Text = (primary["Metal"] + secondary["Metal"]).ToString();
            PasteAmount.Text = (primary["Paste"] + secondary["Paste"]).ToString();
            PolymerAmount.Text = (primary["Polymer"] + secondary["Polymer"]).ToString();
            CrystalAmount.Text = (primary["Crystal"] + secondary["Crystal"]).ToString();
            ElementAmount.Text = (primary["Element"] + secondary["Element"]).ToString();
        }

        private Dictionary<string, int> CalcPrimary()
        {
            Dictionary<string, int> primary = new Dictionary<string, int>();
            primary.Add("Thatch", 0);
            primary.Add("Fiber", 0);
            primary.Add("Wood", 0);
            primary.Add("Stone", 0);
            primary.Add("Metal", 0);
            primary.Add("Paste", 0);
            primary.Add("Polymer", 0);
            primary.Add("Crystal", 0);
            primary.Add("Element", 0);

            Dictionary<string, int> Foundation = new Dictionary<string, int>();
            Dictionary<string, int> Walls = new Dictionary<string, int>();
            Dictionary<string, int> Ceiling = new Dictionary<string, int>();
            Dictionary<string, int> Doorframe = new Dictionary<string, int>();
            Dictionary<string, int> Door = new Dictionary<string, int>();
            Dictionary<string, int> Windowframe = new Dictionary<string, int>();
            Dictionary<string, int> Window = new Dictionary<string, int>();

            switch (primaryMaterial)
            {
                case "Thatch":
                    {
                        Thatch materialCost = new Thatch();
                        Foundation = materialCost.Foundation;
                        Walls = materialCost.Wall;
                        Ceiling = materialCost.Ceiling;
                        Doorframe = materialCost.Doorframe;
                        Door = materialCost.Door;
                        break;
                    }
                case "Wood":
                    {
                        Wood materialCost = new Wood();
                        Foundation = materialCost.Foundation;
                        Walls = materialCost.Wall;
                        Ceiling = materialCost.Ceiling;
                        Doorframe = materialCost.Doorframe;
                        Door = materialCost.Door;
                        Windowframe = materialCost.Windowframe;
                        Window = materialCost.Window;
                        break;
                    }
                case "Stone":
                    {
                        Stone materialCost = new Stone();
                        Foundation = materialCost.Foundation;
                        Walls = materialCost.Wall;
                        Ceiling = materialCost.Ceiling;
                        Doorframe = materialCost.Doorframe;
                        Door = materialCost.Door;
                        Windowframe = materialCost.Windowframe;
                        Window = materialCost.Window;
                        break;
                    }
                case "Metal":
                    {
                        Metal materialCost = new Metal();
                        Foundation = materialCost.Foundation;
                        Walls = materialCost.Wall;
                        Ceiling = materialCost.Ceiling;
                        Doorframe = materialCost.Doorframe;
                        Door = materialCost.Door;
                        Windowframe = materialCost.Windowframe;
                        Window = materialCost.Window;
                        break;
                    }
                case "Tek":
                    {
                        Tek materialCost = new Tek();
                        Foundation = materialCost.Foundation;
                        Walls = materialCost.Wall;
                        Ceiling = materialCost.Ceiling;
                        Doorframe = materialCost.Doorframe;
                        Door = materialCost.Door;
                        Windowframe = materialCost.Windowframe;
                        Window = materialCost.Window;
                        break;
                    }
            }

            foreach (KeyValuePair<string, int> kv in Foundation)
            {
                primary[kv.Key] += kv.Value * foundation;
            }

            foreach (KeyValuePair<string, int> kv in Walls)
            {
                primary[kv.Key] += kv.Value * walls;
            }

            foreach (KeyValuePair<string, int> kv in Ceiling)
            {
                primary[kv.Key] += kv.Value * roof;
            }

            foreach (KeyValuePair<string, int> kv in Doorframe)
            {
                primary[kv.Key] += kv.Value * doors;
            }

            foreach (KeyValuePair<string, int> kv in Door)
            {
                primary[kv.Key] += kv.Value * doors;
            }

            if (primaryMaterial != "Thatch")
            {
                foreach (KeyValuePair<string, int> kv in Windowframe)
                {
                    primary[kv.Key] += kv.Value * windows;
                }

                foreach (KeyValuePair<string, int> kv in Window)
                {
                    primary[kv.Key] += kv.Value * windows;
                }
            }

            return primary;
        }

        private Dictionary<string, int> CalcSecondary()
        {
            Dictionary<string, int> secondary = new Dictionary<string, int>();
            secondary.Add("Thatch", 0);
            secondary.Add("Fiber", 0);
            secondary.Add("Wood", 0);
            secondary.Add("Stone", 0);
            secondary.Add("Metal", 0);
            secondary.Add("Paste", 0);
            secondary.Add("Polymer", 0);
            secondary.Add("Crystal", 0);
            secondary.Add("Element", 0);

            Dictionary<string, int> Ceiling = new Dictionary<string, int>();
            switch (secondaryMaterial)
            {
                case "Thatch":
                    {
                        Thatch materialCost = new Thatch();
                        Ceiling = materialCost.Ceiling;
                        break;
                    }
                case "Wood":
                    {
                        Wood materialCost = new Wood();
                        Ceiling = materialCost.Ceiling;
                        break;
                    }
                case "Stone":
                    {
                        Stone materialCost = new Stone();
                        Ceiling = materialCost.Ceiling;
                        break;
                    }
                case "Metal":
                    {
                        Metal materialCost = new Metal();
                        Ceiling = materialCost.Ceiling;
                        break;
                    }
                case "Tek":
                    {
                        Tek materialCost = new Tek();
                        Ceiling = materialCost.Ceiling;
                        break;
                    }
            }

            foreach (KeyValuePair<string, int> kv in Ceiling)
            {
                secondary[kv.Key] += kv.Value*foundation*(floors-1);
            }

            return secondary;
        }

        //private Dictionary<string, int> PullMaterialCosts(Dictionary<string, int> from)
        //{
        //    Dictionary<string, int> to = new Dictionary<string, int>();

        //    foreach (KeyValuePair<string, int> kv in from)
        //    {
        //        to.Add(kv.Key, kv.Value);
        //    }

        //    return to;
        //}

        private void CalculateStructure(int cord1, int cord2)
        {
            walls = walls + doors + windows;
            walls = (walls / height) / floors;
            if (Grid[cord1, cord2])
            {

                foundation++;
                roof++;
                walls += 4;
                if (cord1 == 0 && cord2 == 0)
                {
                    if (Grid[0, 1])
                    {
                        walls--;
                    }

                    if (Grid[1, 0])
                    {
                        walls -= 2;
                    }
                }
                else if (cord1 == 9 && cord2 == 0)
                {
                    if (Grid[9, 1])
                    {
                        walls -= 2;
                    }

                    if (Grid[8, 0])
                    {
                        walls -= 2;
                    }
                }
                else if (cord1 == 0 && cord2 == 9)
                {
                    if (Grid[0, 8])
                    {
                        walls -= 2;
                    }

                    if (Grid[1, 9])
                    {
                        walls -= 2;
                    }
                }
                else if (cord1 == 9 && cord2 == 9)
                {
                    if (Grid[9, 8])
                    {
                        walls -= 2;
                    }

                    if (Grid[8, 9])
                    {
                        walls -= 2;
                    }
                }
                else if (cord1 == 0)
                {
                    if (Grid[cord1, cord2 + 1])
                    {
                        walls -= 2;
                    }

                    if (Grid[cord1 + 1, cord2])
                    {
                        walls -= 2;
                    }

                    if (Grid[cord1, cord2 - 1])
                    {
                        walls -= 2;
                    }
                }
                else if (cord1 == 9)
                {
                    if (Grid[cord1, cord2 + 1])
                    {
                        walls -= 2;
                    }

                    if (Grid[cord1, cord2 - 1])
                    {
                        walls -= 2;
                    }

                    if (Grid[cord1 - 1, cord2])
                    {
                        walls -= 2;
                    }
                }
                else if (cord2 == 0)
                {
                    if (Grid[cord1 + 1, cord2])
                    {
                        walls -= 2;
                    }

                    if (Grid[cord1 - 1, cord2])
                    {
                        walls -= 2;
                    }

                    if (Grid[cord1, cord2 + 1])
                    {
                        walls -= 2;
                    }
                }
                else if (cord2 == 9)
                {
                    if (Grid[cord1 + 1, cord2])
                    {
                        walls -= 2;
                    }

                    if (Grid[cord1 - 1, cord2])
                    {
                        walls -= 2;
                    }

                    if (Grid[cord1, cord2 - 1])
                    {
                        walls -= 2;
                    }
                }
                else
                {
                    if (Grid[cord1 + 1, cord2])
                    {
                        walls -= 2;
                    }
                    if (Grid[cord1 - 1, cord2])
                    {
                        walls -= 2;
                    }
                    if (Grid[cord1, cord2 + 1])
                    {
                        walls -= 2;
                    }
                    if (Grid[cord1, cord2 - 1])
                    {
                        walls -= 2;
                    }
                }
            }
            else
            {

                foundation--;
                roof--;
                walls -= 4;
                if (cord1 == 0 && cord2 == 0)
                {
                    if (Grid[0, 1])
                    {
                        walls += 2;
                    }

                    if (Grid[1, 0])
                    {
                        walls += 2;
                    }
                }
                else if (cord1 == 9 && cord2 == 0)
                {
                    if (Grid[9, 1])
                    {
                        walls += 2;
                    }

                    if (Grid[8, 0])
                    {
                        walls += 2;
                    }
                }
                else if (cord1 == 0 && cord2 == 9)
                {
                    if (Grid[0, 8])
                    {
                        walls += 2;
                    }

                    if (Grid[1, 9])
                    {
                        walls += 2;
                    }
                }
                else if (cord1 == 9 && cord2 == 9)
                {
                    if (Grid[9, 8])
                    {
                        walls += 2;
                    }

                    if (Grid[8, 9])
                    {
                        walls += 2;
                    }
                }
                else if (cord1 == 0)
                {
                    if (Grid[cord1, cord2 + 1])
                    {
                        walls += 2;
                    }

                    if (Grid[cord1 + 1, cord2])
                    {
                        walls += 2;
                    }

                    if (Grid[cord1, cord2 - 1])
                    {
                        walls += 2;
                    }
                }
                else if (cord1 == 9)
                {
                    if (Grid[cord1, cord2 + 1])
                    {
                        walls += 2;
                    }

                    if (Grid[cord1, cord2 - 1])
                    {
                        walls += 2;
                    }

                    if (Grid[cord1 - 1, cord2])
                    {
                        walls += 2;
                    }
                }
                else if (cord2 == 0)
                {
                    if (Grid[cord1 + 1, cord2])
                    {
                        walls += 2;
                    }

                    if (Grid[cord1 - 1, cord2])
                    {
                        walls += 2;
                    }

                    if (Grid[cord1, cord2 + 1])
                    {
                        walls += 2;
                    }
                }
                else if (cord2 == 9)
                {
                    if (Grid[cord1 + 1, cord2])
                    {
                        walls += 2;
                    }

                    if (Grid[cord1 - 1, cord2])
                    {
                        walls -= 2;
                    }

                    if (Grid[cord1, cord2 - 1])
                    {
                        walls += 2;
                    }
                }
                else
                {
                    if (Grid[cord1 + 1, cord2])
                    {
                        walls += 2;
                    }
                    if (Grid[cord1 - 1, cord2])
                    {
                        walls += 2;
                    }
                    if (Grid[cord1, cord2 + 1])
                    {
                        walls += 2;
                    }
                    if (Grid[cord1, cord2 - 1])
                    {
                        walls += 2;
                    }
                }
            }

            int.TryParse(floorCount.Text, out floors);
            walls = (walls * height) * floors;
            walls = walls - doors - windows;

            wallLabel.Text = walls.ToString();
            foundationLabel.Text = foundation.ToString();
            roofLabel.Text = roof.ToString();
        }

        private void ResetGrid_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Grid[i, j] = false;
                }
            }

            mainThatch.Checked = true;
            floorThatch.Checked = true;


            ResetGridButtons();

            walls = 0;
            foundation = 0;
            roof = 0;

            wallLabel.Text = "0";
            foundationLabel.Text = "0";
            roofLabel.Text = "0";

            windowCount.Text = "0";
            doorCount.Text = "0";
            floorCount.Text = "1";
            floorHeight.Text = "1";
        }

        private void ResetGridButtons()
        {
            Button00.BackColor = color;
            Button01.BackColor = color;
            Button02.BackColor = color;
            Button03.BackColor = color;
            Button04.BackColor = color;
            Button05.BackColor = color;
            Button06.BackColor = color;
            Button07.BackColor = color;
            Button08.BackColor = color;
            Button09.BackColor = color;

            Button10.BackColor = color;
            Button11.BackColor = color;
            Button12.BackColor = color;
            Button13.BackColor = color;
            Button14.BackColor = color;
            Button15.BackColor = color;
            Button16.BackColor = color;
            Button17.BackColor = color;
            Button18.BackColor = color;
            Button19.BackColor = color;

            Button20.BackColor = color;
            Button21.BackColor = color;
            Button22.BackColor = color;
            Button23.BackColor = color;
            Button24.BackColor = color;
            Button25.BackColor = color;
            Button26.BackColor = color;
            Button27.BackColor = color;
            Button28.BackColor = color;
            Button29.BackColor = color;

            Button30.BackColor = color;
            Button31.BackColor = color;
            Button32.BackColor = color;
            Button33.BackColor = color;
            Button34.BackColor = color;
            Button35.BackColor = color;
            Button36.BackColor = color;
            Button37.BackColor = color;
            Button38.BackColor = color;
            Button39.BackColor = color;

            Button40.BackColor = color;
            Button41.BackColor = color;
            Button42.BackColor = color;
            Button43.BackColor = color;
            Button44.BackColor = color;
            Button45.BackColor = color;
            Button46.BackColor = color;
            Button47.BackColor = color;
            Button48.BackColor = color;
            Button49.BackColor = color;

            Button50.BackColor = color;
            Button51.BackColor = color;
            Button52.BackColor = color;
            Button53.BackColor = color;
            Button54.BackColor = color;
            Button55.BackColor = color;
            Button56.BackColor = color;
            Button57.BackColor = color;
            Button58.BackColor = color;
            Button59.BackColor = color;

            Button60.BackColor = color;
            Button61.BackColor = color;
            Button62.BackColor = color;
            Button63.BackColor = color;
            Button64.BackColor = color;
            Button65.BackColor = color;
            Button66.BackColor = color;
            Button67.BackColor = color;
            Button68.BackColor = color;
            Button69.BackColor = color;

            Button70.BackColor = color;
            Button71.BackColor = color;
            Button72.BackColor = color;
            Button73.BackColor = color;
            Button74.BackColor = color;
            Button75.BackColor = color;
            Button76.BackColor = color;
            Button77.BackColor = color;
            Button78.BackColor = color;
            Button79.BackColor = color;

            Button80.BackColor = color;
            Button81.BackColor = color;
            Button82.BackColor = color;
            Button83.BackColor = color;
            Button84.BackColor = color;
            Button85.BackColor = color;
            Button86.BackColor = color;
            Button87.BackColor = color;
            Button88.BackColor = color;
            Button89.BackColor = color;

            Button90.BackColor = color;
            Button91.BackColor = color;
            Button92.BackColor = color;
            Button93.BackColor = color;
            Button94.BackColor = color;
            Button95.BackColor = color;
            Button96.BackColor = color;
            Button97.BackColor = color;
            Button98.BackColor = color;
            Button99.BackColor = color;
        }

        private void floorHeight_TextChanged(object sender, EventArgs e)
        {
            int newHeight = 0;
            int.TryParse(floorHeight.Text, out newHeight);

            if (newHeight != 0)
            {
                walls = walls + doors + windows;
                walls = walls / height;
                walls = walls * newHeight;
                walls = walls - doors - windows;
                wallLabel.Text = walls.ToString();
                height = newHeight;

                CalculateCost();
            }
        }

        private void floorCount_TextChanged(object sender, EventArgs e)
        {
            int newFloorCount = 0;
            int.TryParse(floorCount.Text, out newFloorCount);

            if (newFloorCount != 0)
            {
                walls = walls + doors + windows;
                walls = walls / floors;
                walls = walls * newFloorCount;
                walls = walls - doors - windows;
                wallLabel.Text = walls.ToString();
                floors = newFloorCount;

                CalculateCost();
            }
        }

        private void doorCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int newDoors = 0;
                int.TryParse(doorCount.Text, out newDoors);
                if (newDoors >= 0)
                {
                    walls += doors;
                    doors = newDoors;
                    walls -= doors;
                    wallLabel.Text = walls.ToString();

                    doorframeLabel.Text = doors.ToString();
                    doorLabel.Text = doors.ToString();
                    CalculateCost();
                }
            }
            catch
            {

            }
        }

        private void windowCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int newWindows = 0;
                int.TryParse(windowCount.Text, out newWindows);

                if (newWindows >= 0)
                {
                    walls += windows;
                    windows = newWindows;
                    walls -= windows;
                    wallLabel.Text = walls.ToString();
                    windowframeLabel.Text = windows.ToString();
                    windowLabel.Text = windows.ToString();

                    CalculateCost();
                }
            }
            catch
            {

            }
        }

        private void mainMaterialSwitched(object sender, EventArgs e)
        {
            RadioButton b = (RadioButton)sender;
            primaryMaterial = b.Text;
            if (primaryMaterial == "Thatch")
            {
                windowCount.Visible = false;
                windowCount.Text = "0";
                windows = 0;
            }
            else
            {
                windowCount.Visible = true;
            }

            CalculateCost();
        }

        private void floorMaterialSwitched(object sender, EventArgs e)
        {
            RadioButton b = (RadioButton)sender;
            secondaryMaterial = b.Text;

            CalculateCost();
        }
    }
}

//for(int i = 0; i < 10; i ++)
//{
//    for (int j = 0; j < 10; i ++)
//    {
//        if(i==0)
//        {
//            if(j==0)
//            {

//            }
//            else if (j==9)
//            {

//            }
//            else
//            {

//            }
//        }
//        else if (i ==9)
//        {

//            if (j == 0)
//            {

//            }
//            else if (j == 9)
//            {

//            }
//            else
//            {

//            }
//        }
//        else
//        {

//            if (j == 0)
//            {

//            }
//            else if (j == 9)
//            {

//            }
//            else
//            {

//            }
//        }
//    }
//}
