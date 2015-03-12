using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarAndHorseStore.Core.System
{
    interface IStoreSystem
    {
        void StartSystem();
        void StopSystem();
        void DoAction();

    }
}
