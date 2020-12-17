using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeLibrary
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public Badge() { }//nothing happens here
        public Badge(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
            
        }


    }
}
