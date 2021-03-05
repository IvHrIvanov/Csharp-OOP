using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
        void AddPriver(IPrivate @private);
    }
}
