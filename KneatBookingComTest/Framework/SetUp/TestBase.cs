using System;
namespace KneatBookingComTest.Framework.SetUp
{
    public static class TestBase
    {
        #region Base Url
        private static string UrlBookingCom = "https://www.booking.com/";
        public static string BaseUrl = UrlBookingCom;

        #endregion

        #region Browser
        public static string BaseBrowser = "Chrome";
        //public static string BaseBrowser = "Firefox";

        #endregion
    }
}
