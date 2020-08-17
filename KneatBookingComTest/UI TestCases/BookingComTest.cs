using System;
using KneatBookingComTest.Framework.Common;
using KneatBookingComTest.Framework.POM;
using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;

namespace KneatBookingComTest.UITestCases
{
    public class BookingComTest : IDisposable
    {
        private readonly ITestOutputHelper output;

        public string Element { get; private set; }
        public IWebDriver Driver { get; }

        public BookingComTest(ITestOutputHelper output)
        {
            this.output = output;
            Driver = BrowserType.Initialize();

        }
        [Fact]
        public void TC_OpenUrl()
        {
            Utilities.OpenUrl(Driver);
            output.WriteLine($"Booking website opened successfully and Title name is: {Driver.Title}");

        }

        [Fact]
        public void TC_SearchLocation()
        {
            Utilities.OpenUrl(Driver);
            HomePage.SelectLocationFromList(Driver);
            output.WriteLine($"Location entered successfully");
            HomePage.SelectDateFromPopUpView(Driver);
            output.WriteLine($"Date selected successfully");
            HomePage.CheckAdultAndRoomCounts(Driver);
            output.WriteLine($"Adult and Room counts are checked successfully");
        }

        [Fact]
        public void TC_SelectSpaAndWellnessCenterFilter()
        {
            Utilities.OpenUrl(Driver);
            HomePage.SelectLocationFromList(Driver);
            output.WriteLine($"Location entered successfully");
            HomePage.SelectDateFromPopUpView(Driver);
            output.WriteLine($"Date selected successfully");
            HomePage.CheckAdultAndRoomCounts(Driver);
            output.WriteLine($"Adult and Room counts are checked successfully");
            HomePage.SelectSpaandWellnessFilters(Driver);
            output.WriteLine($"Spa and Wellness center filter is selected successfully");
           
        }

        [Fact]
        public void TC_CheckSavoyHotelNameWith5StarRatingFilter()
        {
            TC_SelectSpaAndWellnessCenterFilter();
            HomePage.SelectFiveStarRating(Driver);
            output.WriteLine($"Five star filter is selected successfully");
            HomePage.CheckSavoyHotelName(Driver);
            output.WriteLine($"Savoy Hotel text is found successfully");
        }

        [Fact]
        public void TC_CheckLimerickStrandHotelNameWithSaunaFilter()
        {
            Utilities.OpenUrl(Driver);
            HomePage.SelectLocationFromList(Driver);
            output.WriteLine($"Location entered successfully");
            HomePage.SelectDateFromPopUpView(Driver);
            output.WriteLine($"Date selected successfully");
            HomePage.CheckAdultAndRoomCounts(Driver);
            output.WriteLine($"Adult and Room counts are checked successfully");
            HomePage.SelectSaunaFilter(Driver);
            output.WriteLine($"Sauna filter is selected successfully");
            HomePage.CheckLimerickStrandHotelName(Driver);
            output.WriteLine($"Limerick Strand Hotel text is found successfully");

        }
        public void Dispose()
        {
            Driver.Quit();
        }

    }
}
