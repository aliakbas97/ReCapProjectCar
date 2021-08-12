using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {

        public static string CarAddedInvalid = " Wrong Car inforamtion ";
        public static string CarAdded = "  car added   ";
        internal static string CarDeleted = " car ,s deleted";
        internal static string CarGet = " car is listed at all ";
        internal static string CarUpdated = " car is updated ";
        internal static object CarGetAll = "  car is listed";
        internal static string CarGetDetail = "  car is listed with detail ";
        internal static string CarGetByBrandId = "   car is listed by brandId ";
        
        internal static string CarGetByColor = "   car is listed by ColorId ";
        internal static string CarGetByDailyPrice = "   car is listed by DailyPrice ";
        internal static string CustomerAdded;
        internal static string UserAdded;
        internal static string UserDeleted;
        internal static string CustomerDeleted;
        internal static string RentalDeleted;
        internal static string RentalCarListed;
        internal static string CustomerGet = " customer is listed";
        internal static string CustomerUpdated;
        internal static string UserUpdated;
        internal static string RentalCarUpdated;
        internal static string UserDetailsListed;
        internal static string RentalCarFail = " rentcar  is not added";
        internal static string RentalCarSuccess = "   rentcar is added ";
    }
}
