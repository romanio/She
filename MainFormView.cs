using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using She.ECLStructure;

namespace She
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };

    public class VisualFilter
    {
        public Pair<bool, int> ICfrom = new Pair<bool, int>();
        public Pair<bool, int> ICto = new Pair<bool, int>();
        public Pair<bool, int> JCfrom = new Pair<bool, int>();
        public Pair<bool, int> JCto = new Pair<bool, int>();
        public Pair<bool, int> KCfrom = new Pair<bool, int>();
        public Pair<bool, int> KCto = new Pair<bool, int>();
        public Pair<bool, float> min = new Pair<bool, float>();
        public Pair<bool, float> max = new Pair<bool, float>();
    }


    public class MainFormView
    {
        public ECL ecl = null;
        public Engine3D engine = new Engine3D();
        public Grid3D grid = new Grid3D();

        public List<string> Wellnames { get; set; }
        public List<string> RestartDates { get; set; }
        public List<WELLDATA> WellRestart { get; set; }
        public List<string> StaticProperties { get; set; }
        public List<string> DynamicProperties { get; set; }

        void GetStaticProperties()
        {
            StaticProperties = new List<string>();

            for (int iw = 0; iw < ecl.INIT.NAME.Count; ++iw)
                for (int it = 0; it < ecl.INIT.NAME[iw].Length; ++it)
                    if (ecl.INIT.NUMBER[iw][it] == ecl.INIT.NACTIV)
                        StaticProperties.Add(ecl.INIT.NAME[iw][it]);
        }

        void GetDinamicProperties(int istep)
        {
            DynamicProperties = new List<string>();

                for (int it = 0; it < ecl.RESTART.NAME[istep].Length; ++it)
                    if (ecl.RESTART.NUMBER[istep][it] == ecl.INIT.NACTIV)
                        DynamicProperties.Add(ecl.RESTART.NAME[istep][it]);
        }

        public void SetDynamicProperty(string name)
        {
            ecl.RESTART.ReadGrid(name);
            grid.GenerateGraphics(ecl, ecl.RESTART.GetValue, null);
            engine.SetGridModel(grid);
        }

        public void SetVisualFilter(VisualFilter filter)
        {

        }

        public void SetStaticProperty(string name)
        {
            ecl.INIT.ReadGrid(name);
            grid.GenerateGraphics(ecl, ecl.INIT.GetValue, null);
            engine.SetGridModel(grid);
        }

        public void ReadRestartFile(int istep)
        {
            ecl.ReadRestart(istep);
            GetDinamicProperties(istep);
        }

        public void OpenNewModel(string filename)
        {
            ecl = new ECL();

            ecl.OpenData(filename);
            ecl.ReadVectors();
            ecl.ReadRestartList();
            
            Wellnames =
                (from item in ecl.VECTORS
                 where item.Type == NameOptions.Well
                 select item.Name).ToList();

            RestartDates =
                (from item in ecl.RESTART.DATE
                 select item.ToShortDateString()).ToList();

            GetStaticProperties();
        }
    }
}
