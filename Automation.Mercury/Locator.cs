﻿using OpenQA.Selenium;
using System;

namespace Automation.Mercury
{
    public enum LocatorType
    {
        XPath,
        LinkText,
        ID,
        ClassName,
        Name,
        CSS
    }

    public class Locator
    {
        public Locator(LocatorType locatorType, String location)
        {
            this.Location = location;
            this.LocatorType = locatorType;
        }

        public static Locator Get(LocatorType locatorType, String location)
        {
            return new Locator(locatorType, location);
        }

        internal By GetBy()
        {
            By by = null;
            switch (this.LocatorType)
            {
                case LocatorType.XPath:
                    by = By.XPath(this.Location);
                    break;

                case LocatorType.LinkText:
                    by = By.LinkText(this.Location);
                    break;

                case LocatorType.ID:
                    by = By.Id(this.Location);
                    break;

                case Mercury.LocatorType.ClassName:
                    by = By.ClassName(this.Location);
                    break;

                case LocatorType.Name:
                    by = By.Name(this.Location);
                    break;

                case LocatorType.CSS:
                    by = By.Name(this.Location);
                    break;
            }

            return by;
        }

        public String Location { get; set; }
        public LocatorType LocatorType { get; set; }
    }
}
