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

            ecl.ReadRestartList();

            RestartDates =
                (from item in ecl.RESTART.DATE
                 select item.ToShortDateString()).ToList();
        }
    }
}
