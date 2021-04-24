using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestProject.Model
{
    public class ItemModel
    {
        public ItemModel()
        {
            
        }

        private string name;

        private List<string> listOfTargets = new List<string>();

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public List<string> ListOfTargets
        {
            get { return listOfTargets; }
            set
            {
                value = listOfTargets;
            }
        }

    }
}
