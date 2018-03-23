using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Skripts.Objects
{
   public interface IObject
    {
        void Use();

        string Speek();

        string Look();
    }
}
