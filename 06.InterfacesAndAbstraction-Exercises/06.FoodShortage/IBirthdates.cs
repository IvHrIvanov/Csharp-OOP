using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IBirthdates : IIdentifiable
    {     
        string Name { get; }
        string Birthdates { get; }
    }
}
