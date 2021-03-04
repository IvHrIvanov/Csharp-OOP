using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface Birthdates : IIdentifiable
    {     
        string Name { get; }
        string Birthdates { get; }
    }
}
