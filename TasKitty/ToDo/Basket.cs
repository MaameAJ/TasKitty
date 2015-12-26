using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasKitten
{
    class TasKittenComparer : IComparer<TasKitten>
    {
        public override int Compare(TasKitten A, TasKitten B)
        {
            DateTime compareForA = (A.Reminders.Count > 0) ? A.Reminders.Min : A.Deadline;
            DateTime compareForB = (B.Reminders.Count > 0) ? B.Reminders.Min : B.Deadline;

            return DateTime.Compare(compareForA, compareForB);
        }
    }

    class Basket : SortedSet<TasKitten>
    {
        public Basket() : base(new TasKittenComparer()) { }


    }
}
