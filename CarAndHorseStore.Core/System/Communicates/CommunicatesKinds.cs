using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndHorseStore.Core.CommandParser.Communicates
{
    enum CommunicatesKinds
    {
        LoginAccepted,
        LoginFailed,
        LoginNotFound,
        IncorrectPassword,
        ProductNotFound,
        ProductOutOfStock,
        ProductAddedToList,
        ProductNotAddedError,
        ProductRemovedFromList,
        ProductNotRemovedError,
        OrderIsInProgress,
        OrderCancelled, // potrzebne?
        LogoutFailed //fantazja,co?
    }
}
