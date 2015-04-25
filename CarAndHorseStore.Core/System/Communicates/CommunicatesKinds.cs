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
        ProductAddedToCart,
        ProductNotAddedError,
        ProductRemovedFromCart,
        ProductNotRemovedError,
        OrderIsInProgress,
        OrderCancelled, 
        LogoutFailed, 
        IncorrectParametersAmmount,
        CommandNotCooperate,
        LoggedAs,
        NotLogged,
        Thanks,
        LogoutAccepted,
        AlreadyLogged,
        IncorrectParameter,
        EmptyCart,
        IncorectKeyValue,
        InvalidHorseAttribute,
        InvalidCarAttribute,
        LoggedAsAdmin,       
        FoundCars,
        FoundHorses,
        InvalidAttribute,
        UserAlreadyExist,
        PasswordAreDifferent,
        NewUserCreated,
        ProductDeltedFromShop,
        UpdatedProductInfo,
        ProductAddedToShop,
        NewUserCreatedFail,
        ProductDeltedFromShopFail,
        UpdatedProductInfoFail,
        ProductAddedToShopFail,
        MusicComunikatesStop,
        Cleaned

    }
}
