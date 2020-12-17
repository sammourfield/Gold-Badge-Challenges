using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeLibrary
{
    public class BadgeRepo
    {
        public readonly Dictionary<int, List<string>> _badgesDictionary = new Dictionary<int, List<string>>();

        public void CreateNewBadge(Badge item)
        {
            _badgesDictionary.Add(item.BadgeID, item.DoorNames);
        }

        public void EditExistingBadge(Badge item)
        {

        }

        public Array GetBadgeList()
        {
            return _badgesDictionary.Keys.ToArray();
        }

        public List<string> GetDoorsForID(int id)
        {
            List<string> doors = _badgesDictionary[id];
            return doors;
        }
    }
}
