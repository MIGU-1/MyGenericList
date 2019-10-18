using System;
using System.Collections;

namespace MyListEntitys
{
    internal class SortPersonPostCodeDescending : IComparer
    {
        public int Compare(object x, object y)
        {
            Person pers1 = x as Person;
            Person pers2 = y as Person;

            if (pers1 == null)
                throw new ArgumentNullException(nameof(pers1));
            if (pers2 == null)
                throw new ArgumentNullException(nameof(pers2));

            if (pers1.PostCode < pers2.PostCode)
            {
                return 1;
            }
            else if (pers1.PostCode > pers2.PostCode)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}