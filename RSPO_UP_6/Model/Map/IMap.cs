using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_6.Model.Map
{
    public interface IMap
    {
        bool[,] Map { get; }
        int Size { get; }
    }
}
