using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.SearchTable
{
    public class Hashing<Key>
    {
        public int Hash(Key key, int M)
        {
            return ((key.GetHashCode() & 0x7fffffff) % M);
        }
    }
}
