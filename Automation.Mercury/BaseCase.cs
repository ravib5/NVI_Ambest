using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Management;
using System.Linq;


namespace Automation.Mercury
{
    /// <summary>
    /// Abstracts Common Test Case functionality. 
    /// Derived classes should implement specifics
    /// </summary>
    public abstract class BaseCase
    {
        /// <summary>
        /// Gets or Sets Driver
        /// </summary>
        public RemoteWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or Sets Reporter
        /// </summary>
        public Report.Iteration Reporter { get; set; }

        /// <summary>
        /// Gets or Sets Step
        /// </summary>
        protected string Step
        {
            get
            {
                //TODO: Get should go away
                return Reporter.Chapter.Step.Title;
            }
            set
            {
                Reporter.Add(new Report.Step(value));
            }
        }

        /// <summary>
        /// Gets or Sets Identity of Test Case
        /// </summary>
        public string TestCaseId { get; set; }

        /// <summary>
        /// Gets or Sets Identity of Test Data
        /// </summary>
        public string TestDataId { get; set; }

        /// <summary>
        /// Gets or Sets Test Data as Dictionary<string, string>
        /// </summary>
        public Dictionary<string, string> TestData { get; set; }

        /// <summary>
        /// Returns location where resutls stored.
        /// </summary>
        public string resultsPath = string.Empty;

        
        /// <summary>
        /// Executes Test Cases
        /// </summary>
        public void Execute(Dictionary<String, String> browserConfig,
            String testCaseId,
            String iterationId,
            Report.Iteration iteration,
            Dictionary<String, String> testData,
            Report.Engine reportEngine)
        {
            try
            {

                this.Driver = Util.GetDriver(browserConfig);
                this.Reporter = iteration;
                this.TestCaseId = testCaseId;
                this.TestDataId = iterationId;
                this.TestData = testData;
                this.resultsPath = reportEngine.ReportPath;


                if (browserConfig["target"] == "local")
                {
                    var wmi = new ManagementObjectSearcher("select * from Win32_OperatingSystem").Get().Cast<ManagementObject>().First();

                    this.Reporter.Browser.PlatformName = String.Format("{0} {1}", ((string)wmi["Caption"]).Trim(), (string)wmi["OSArchitecture"]);
                    this.Reporter.Browser.PlatformVersion = ((string)wmi["Version"]);
                    this.Reporter.Browser.BrowserName = Driver.Capabilities.BrowserName;
                    this.Reporter.Browser.BrowserVersion = Driver.Capabilities.Version;
                }
                else
                {
                    this.Reporter.Browser.PlatformName = browserConfig.ContainsKey("os") ? browserConfig["os"] : browserConfig["device"];
                    this.Reporter.Browser.PlatformVersion = browserConfig.ContainsKey("os_version") ? browserConfig["os_version"] : browserConfig.ContainsKey("realMobile") ? "Real" : "Emulator";
                    this.Reporter.Browser.BrowserName = browserConfig.ContainsKey("browser") ? browserConfig["browser"] : "Safari";
                    this.Reporter.Browser.BrowserVersion = browserConfig.ContainsKey("browser_version") ? browserConfig["browser_version"] : "";
                }

                // Does Seed having anything?
                if (this.Reporter.Chapter.Steps.Count == 0)
                    this.Reporter.Chapters.RemoveAt(0);

                ExecuteTestCase();
            }
            catch (System.IO.IOException sysex)
            {
                this.Reporter.Chapter.Step.Action.Extra = sysex.Message + "<br/>" + sysex.StackTrace;
                this.Reporter.Chapter.Step.Action.IsSuccess = false;
            }
            catch (SystemException sysex)
            {
                this.Reporter.Chapter.Step.Action.Extra = sysex.Message + "<br/>" + sysex.StackTrace;
                this.Reporter.Chapter.Step.Action.IsSuccess = false;
            }
            catch (Exception ex)
            {
                string currentUrl = Driver.Url;
                this.Reporter.Chapter.Step.Action.Extra = "<font color=blue>URL " + currentUrl + "</font><br/>" + "Exception Message : " + ex.Message + "<br/>" + ex.InnerException + ex.StackTrace;
                this.Reporter.Chapter.Step.Action.IsSuccess = false;
            }
            finally
            {
                this.Reporter.IsCompleted = true;

                // If current iteration is a failure, get screenshot
                if (!Reporter.IsSuccess)
                {
                    ITakesScreenshot iTakeScreenshot = Driver;
                    this.Reporter.Screenshot = iTakeScreenshot.GetScreenshot().AsBase64EncodedString;
                }
                this.Reporter.EndTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

                lock (reportEngine)
                {
                    reportEngine.PublishIteration(this.Reporter);
                    reportEngine.Summarize(false);
                }
                Driver.Quit();
            }
        }

        /// <summary>
        /// Executes Test Case, should be overriden by derived
        /// </summary>
        protected virtual void ExecuteTestCase()
        {
            Reporter.Add(new Report.Chapter("Execute Test Case"));
        }

        /// <summary>
        /// Gets or Sets Chapter
        /// </summary>
        protected string Chapter
        {
            get
            {
                //TODO: Get should go away
                return Reporter.Chapter.Title;
            }
            set
            {
                Reporter.Add(new Report.Chapter(value));
            }
        }

        #region NEW USER INFORMATION USE IN ALL TEST CASES
        // ** dynamicEmail variable generate the dynamic email address, dynamicEmail, standardPassword  to create new users
        protected string dynamicEmail = string.Format(@"QATestr{0}@aclenscorp.com", 
            System.DateTime.Now.ToString("yyyymmddhhMMssfff"));
        protected string standardPassword = "Welcome123";
        #endregion

        #region NEW USER DETAILS
        // ** Below veriables are used for to create new account
        protected string newUserFName = "STestFN";
        protected string newUserNName = "STestLN";
        protected string newUserAdd1 = "4265";
        protected string newUserAdd2 = "Diplomacy Dr";
        protected string newUserCity = "Columbus";
        protected string newUserState = "Ohio";
        protected string newUserZIP = "43228";
        protected string newUserCountry = "United States";
        protected string newUserPH = "555-666-1234";
        protected string newUserPHEtn = "4321";
        protected string patientmonth = "January";
        protected string patinetday = "1";
        protected string patinetyear = "1990";
        #endregion

        #region EXSTING ACCOUNT DETAILS
        protected string exsitingUserAccount = "QATestr20162718110256802@aclenscorp.com";
        protected string exsitingUserAccountPassword = "Welcome123";
        #endregion

        #region  STANDADRD PAYMENT DETAILS
        protected string CCName = "QATEST CARD";
        protected string CCNumber = "341134113411347";
        protected string CCExpMonth = "02 - Feb";
        protected string CCExpYear = "2020";
        protected string NewCCNumber = "6559906559906557";
        #endregion
    }
}
