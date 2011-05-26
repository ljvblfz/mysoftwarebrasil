using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dum_Mobile.Adapter;

namespace Dum_Mobile.Command
{
    public interface ICeCommand
    {
        IDbAdapter GetDbAdapter();
    }
}
