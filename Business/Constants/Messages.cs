using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string userWrongPassword = "wrong password";
        public static string CarAddedInvalid = " Wrong Car inforamtion ";
        public static string CarAdded = "  car added   ";
        public static string CarDeleted = " car ,s deleted";
        public static string CarGet = " car is listed at all ";
        public static string CarUpdated = " car is updated ";
        public static object CarGetAll = "  car is listed";
        public static string CarGetDetail = "  car is listed with detail ";
        public static string CarGetByBrandId = "   car is listed by brandId ";

        public static string CarGetByColor = "   car is listed by ColorId ";
        public static string CarGetByDailyPrice = "   car is listed by DailyPrice ";
        public static string CustomerAdded;
        public static string UserAdded;
        public static string UserDeleted;
        public static string CustomerDeleted;
        public static string RentalDeleted;
        public static string RentalCarListed;
        public static string CustomerGet = " customer is listed";
        public static string CustomerUpdated;
        public static string UserUpdated;
        public static string RentalCarUpdated;
        public static string UserDetailsListed;
        public static string RentalCarFail = " rentcar  is not added";
        public static string RentalCarSuccess = "   rentcar is added ";
        public static string CarImageNotFound;
        public static string CarImageUpdated;
        public static string CarImageNotUpdated;
        public static string CarImageOverLimit;
        public static string CarNotAdd;
        public static string CarImageAdded = "car image added";
        public static string CarImageNotAdd;
        public static string CarImageDeleted;
        public static string ImageLimitExceded;
        public static string CarImageLimitExceded;
        public static object UpdatedSuccess;
        public static string ItemsListed;
        public static string GetItem;
        public static string CarImageListed;
        public static string CarImageGot;
        public static string CarImagesGetByCar;
        public static string UserMailFound = " usermail not found";
       
       public static string userNotFound = "user not found";
        internal static string UserRegistered = "user registered";
        internal static string TokenCreated = "token created";
    }
}
