using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Data_Filter.Class
{
    class CWebBrowser
    {
        public IWebDriver GoogleChrome()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("disable-infobars");               //disable test automation message
            option.AddArguments("--disable-notifications");        //disable notifications
            option.AddArguments("--disable-web-security");         //disable save password windows
            option.AddUserProfilePreference("credentials_enable_service", false);

            option.AddUserProfilePreference("browser.download.manager.showWhenStarting", false);
            option.AddUserProfilePreference("browser.helperApps.neverAsk.saveToDisk", "text/csv");
            option.AddUserProfilePreference("disable-popup-blocking", "true");
            option.AddUserProfilePreference("safebrowsing.enabled", true);
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            IWebDriver driver = new ChromeDriver(driverService, option);
            Thread.Sleep(1000);
            return driver;
        }

        public string[] FindEmailFromWebsite(IWebDriver driver, string url)
        {
            string[] result = new string[2];  
            try
            {
                if (!url.Contains("http"))
                {
                    url = "https://" + url;
                }

                driver.Navigate().GoToUrl(url);
                Thread.Sleep(5000);
                var str = driver.FindElement(By.XPath("//body")).Text;
                result[0] = SearchEmail(str);
                result[1] = SearchPhone(str);
            }
            catch (Exception)
            {
            }
            return result;
        }

        public bool CheckWebsite( string url)
        {
            try
            {
                if (!url.Contains("http"))
                {
                    url = "https://" + url;
                }

                try
                {
                    //Creating the HttpWebRequest
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    //Setting the Request method HEAD, you can also use GET too.
                    request.Method = "HEAD";
                    //Getting the Web Response.
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    //Returns TRUE if the Status code == 200
                    response.Close();
                    return (response.StatusCode == HttpStatusCode.OK);
                }
                catch
                {
                    //Any exception will returns false.
                    return false;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public string SearchEmail(string text)
        {
            List<string> list = new List<string>();
            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            MatchCollection emailMatches = emailRegex.Matches(text);
            foreach (Match emailMatch in emailMatches)
            {
                return emailMatch.Value;
            }
            return "";
        }

        public string SearchPhone(string text)
        {
            try
            {
                Regex rePhone = new Regex(@"\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d");
                MatchCollection phones = rePhone.Matches(text);
                foreach (Match p in phones)
                {
                    if (p.Value.ToString().Length >= 10)
                    {
                        return p.Value;
                    }
                }
            }
            catch (Exception)
            {
            }
            return "";
        }
    }
}
