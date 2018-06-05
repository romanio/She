using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using She.ECLStructure;

namespace She
{
    public class MainFormView
    {
        public ECL ecl = null;

        public List<string> Wellnames { get; set; }
        public List<string> RestartDates { get; set; }
        public List<WELLDATA> WellRestart { get; set; }
        public List<string> StaticProperties { get; set; }
        public List<string> DynamicProperties { get; set; }


        public void SetStaticProperty(string name)
        {

        }

        public void ReadRestartFile(int istep)
        {
            ecl.ReadRestart(istep);

            //

            DynamicProperties = new List<string>();

            for (int iw = 0; iw < ecl.RESTART.NAME.Count; ++iw)
            {
                for (int it = 0; it < ecl.RESTART.NAME[iw].Length; ++it)
                {
                    if (ecl.RESTART.NUMBER[iw][it] == ecl.INIT.NACTIV)
                    {
                        DynamicProperties.Add(ecl.RESTART.NAME[iw][it]);
                    }
                }
            }
        }

        public void OpenNewModel(string filename)
        {
            ecl = new ECL();

            ecl.OpenData(filename);
            ecl.ReadVectors();
            ecl.ReadRestartList();
            
            // Update wellnames

            Wellnames =
                (from item in ecl.VECTORS
                 where item.Type == NameOptions.Well
                 select item.Name).ToList();

            Wellnames.Sort();

            RestartDates =
                (from item in ecl.RESTART.DATE
                 select item.ToShortDateString()).ToList();

            //

            StaticProperties = new List<string>();

            for (int iw = 0; iw < ecl.INIT.NAME.Count; ++iw)
                for (int it = 0; it < ecl.INIT.NAME[iw].Length; ++it)
                    if (ecl.INIT.NUMBER[iw][it] == ecl.INIT.NACTIV)
                    {
                        StaticProperties.Add(ecl.INIT.NAME[iw][it]);
                    }
        }
    }
}
