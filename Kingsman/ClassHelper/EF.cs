using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingsman.ClassHelper
{
    internal class EF
    {
        public static DB.KingsmanEntities2 Context { get; } = new DB.KingsmanEntities2();
    }
}
