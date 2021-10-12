using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters
{
    public interface IGenerate
    {
        Type GeneratedType { get; }
        object GetValue();
    }
}
