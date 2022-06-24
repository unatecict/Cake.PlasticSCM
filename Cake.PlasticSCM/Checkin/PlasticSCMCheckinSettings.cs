using System.Collections.Generic;

namespace Cake.PlasticSCM.Checkin
{   
    public class PlasticSCMCheckinSettings : PlasticSCMSettings
    {   
        public IList<string> Paths { get; private set; } = new List<string>();
        public string Comment { get; set; }   
        public bool NoCheck { get; set; }
        public bool All { get; set; } = true;
        public bool Dependencies { get; set; }
        public bool Symlink { get; set; }
        public bool Private { get; set; }
    }
}   
