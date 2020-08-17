using System;
using System.Threading;
using KneatBookingComTest.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KneatBookingComTest.Framework.POM
{
    public static class HomePage
    {
        #region Search section
        public static string EnterLocationID = "ss";
        public static string AcceptXpath = "//*[@id='cookie_warning']/div/div/div[2]/button";
        public static string LocationListFromDropDownXpath = "//*[@id='frm']/div[1]/div[1]/div[1]/div[1]/ul[1]/li[1]";
        public static string CheckInDateXpath = "//*[@id='frm']/div[1]/div[2]/div[1]/div[2]/div/div/div/div/span";
        public static string NextMonthButtonJS = "#frm > div.xp__fieldset.accommodation > div.xp__dates.xp__group > div.xp-calendar > div > div > div.bui-calendar__control.bui-calendar__control--next";
        public static string CheckInCurrentDateXpath = "//*[@id='frm']/div[1]/div[2]/div[2]/div/div/div[3]/div[2]/table/tbody/tr[2]/td[7]";
        public static string CheckOutXpath= "//*[@id='frm']/div[1]/div[2]/div[1]/div[3]/div/div/div/div/div[1]";
        public static string CheckOutDateXpath = "/html/body/div[5]/div/div/div[2]/form/div[1]/div[2]/div[2]/div/div/div[3]/div[2]/table/tbody/tr[3]/td[1]";
        public static string SearchButtonXpath = "//*[@id='frm']/div[1]/div[4]/div[2]/button";
        public static string AdultButtonXpath = "//*[@id='xp__guests__toggle']";
        public static string AdultCountsTextXpath = "//*[@id='xp__guests__inputs-container']/div/div/div[1]/div"; //Adults 2
        public static string Adult2TextXpath = "//*[@id='xp__guests__inputs-container']/div/div/div[1]/div/div[2]/span[1]"; //2
        public static string RoomCountsTextXpath = "//*[@id='xp__guests__inputs-container']/div/div/div[3]/div"; //Room 1
        public static string AdultCountPlusButtonXpath = "//*[@id='xp__guests__inputs-container']/div/div/div[1]/div/div[2]/button[2]";
        public static string RoomCountPlusButtonXpath = "//*[@id='xp__guests__inputs-container']/div/div/div[3]/div/div[2]/button[2]";
        #endregion


        #region Filter for Spa and Fitness Center
        public static string FilterCenterLocatorID= "filter_facilities";
        public static string ShowAllXpath = "//*[@id='filter_facilities']/div[2]/button[1]";
        public static string ShowAllFilterXpath = "//*[@id='filter_facilities']/div[2]/button";
        public static string ShowAllFilterEnterInputXpath = "//*[@id='sr-facility-search-modal']/div/div/div/div[1]/div/div/input";
        public static string SpaAndWellnessCenterXpath = "//*[@id='sr-facility-search-modal']/div/div/div/div[2]/div/label/div";
        public static string ApplyFilterXpath = "//*[@id='sr-facility-search-modal']/div/div/div/button";
        public static string SpaFilterXpath = "//*[@id='filter_facilities']/div[2]/a[7]/label/div/span";
        public static string FilterCenterXpath = "//*[@id='filter_facilities']/div[2]/a[6]/label/div/span";
        public static string SpaAndWellnessXpath = "//*[@id='filter_facilities']/div[2]/a[10]/label/div/span[1]";
        public static string StarRatingID = "filter_class_tracking";
        public static string FiveStarXpath = "//*[@id='filter_class']/div[2]/a[3]/label/div/span[1]";
        public static string SavoyHotelTextXpath = "//*[@id='hotellist_inner']/div[1]/div[2]/div[1]/div[1]/div[1]/h3/a/span[1]";
        public static string FunThingsToDoFilterID = "filter_popular_activities";
        public static string SaunaXpath = "//*[@id='filter_popular_activities']/div[2]/a[5]/label/div/span[1]";
        public static string LimerickStrandHotelTextXpath = "/html/body/div[6]/div/div[3]/div[1]/div[1]/div[6]/div[3]/div[1]/div/div[1]/div[2]/div[1]/div[1]/div[1]/h3/a/span[1]";
        #endregion


        public static void SelectLocationFromList(IWebDriver Driver)
        {
            Utilities.WaitandClickXpath(Driver,AcceptXpath);
            Utilities.WaitandSendInputID(Driver, EnterLocationID, "Lime");
            Utilities.WaitandClickXpath(Driver, LocationListFromDropDownXpath);

        }
        public static void SelectDateFromPopUpView(IWebDriver Driver)
        {
            Utilities.WaitandClickCSSSelector(Driver, NextMonthButtonJS);
            Utilities.WaitandClickXpath(Driver, CheckInCurrentDateXpath);
            Utilities.WaitandClickXpath(Driver, CheckOutDateXpath);
            //Utilities.WaitandClickXpath(Driver, SearchButtonXpath);

        }
        public static void CheckAdultAndRoomCounts(IWebDriver Driver)
        {
            Utilities.WaitandClickXpath(Driver, AdultButtonXpath);
            Utilities.CheckAndClickXpath(Driver, Adult2TextXpath, RoomCountsTextXpath);
        }
        public static void SelectSpaandWellnessFilters(IWebDriver Driver)
        {
            
            Utilities.MoveToElement(Driver, FilterCenterLocatorID);
            Utilities.WaitAndClickEitherXpath(Driver, ShowAllXpath, ShowAllFilterXpath);
        }
        public static void SelectFiveStarRating(IWebDriver Driver)
        {
            Utilities.MoveToElement(Driver, StarRatingID);
            Thread.Sleep(2000);
            Utilities.WaitandClickXpath(Driver, FiveStarXpath);
        }
        public static void CheckSavoyHotelName(IWebDriver Driver)
        {
            Thread.Sleep(2000);
            Utilities.VerifyTextXpath(Driver, SavoyHotelTextXpath, "The Savoy Hotel", "George Limerick Hotel");

        }
        public static void SelectSaunaFilter(IWebDriver Driver)
        {
            Utilities.MoveToElement(Driver, FunThingsToDoFilterID);
            Thread.Sleep(3000);
            Utilities.WaitandClickXpath(Driver, SaunaXpath);
        }
        public static void CheckLimerickStrandHotelName(IWebDriver Driver)
        {
            Thread.Sleep(2000);
            Utilities.VerifyTextXpath(Driver, LimerickStrandHotelTextXpath, "Limerick Strand Hotel", "George Limerick Hotel");
        }
    }
}
