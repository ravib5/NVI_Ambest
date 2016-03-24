/* *******************************************************
 * Description : ShoppingCartPage.cs contains all the methods, objects related to ShoppingCartPage
 *               like verifying keep shopping functionality         
 *               
 * Date : 08-Feb-2016
 * 
 * *******************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;


namespace NationalVision.Automation.Pages
{

    public class ShoppingCartPage : CommonPage
    {

        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Your Shopping Cart";
        ///  <summary>
        /// AssertPageTitle method assert page title
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPageTitle(RemoteWebDriver driver, Iteration reporter)
        {
            AssertPageTitle(driver, reporter, pageTitle);
        }

        /// <summary>
        /// VerifyKeepShoppingButton method verify keep shopping button available in ShoppingCart Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyKeepShoppingButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Keep Shopping button presence in ShoppingCart Page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("keepshop_btn"));
        }

        /// <summary>
        /// VerifyStartCheckOutButton method verify start-check-out button available in ShoppingCart Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyStartCheckOutButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify start Checkout button presence in ShoppingCart Page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("startcheckout_btn"));
        }

        /// <summary>
        /// ClickKeepShopping method click on KeepShopping button on Shopping Cart page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickKeepShopping(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Keep Shopping button"));
            Selenide.Click(driver, Util.GetLocator("keepshop_btn"));
        }

        /// <summary>
        /// ClickStartCheckOut method click on start-checkout button
        /// This method will redirect the customer to BeginOrder Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickStartCheckOut(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Start CheckOut button"));
            Selenide.Click(driver, Util.GetLocator("startcheckout_btn"));

            // *** This method redirects to BegionOrder page. *** //
        }

        /// <summary>
        /// VerifyFeaturedProducts method is to verify if feature products displayed
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyFeaturedProducts(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify featured products availability"));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='product-list']/div[contains(.,'Featured Products')]/following-sibling::div/div[1]"));
        }

        /// <summary>
        /// ClickFeaturedProducts method is to click on the given index featured product
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="index">The index of the product on which click operation should be performed, Default:1 </param>
        public static string ClickFeaturedProducts(RemoteWebDriver driver, Iteration reporter,
            int index = 1)
        {
            string clickedProduct = null;
            int count = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='product-list']/div[contains(.,'Featured Products')]/following-sibling::div/div"));

            if (count != 0)
            {
                if (index <= count)
                {
                    clickedProduct = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                    string.Format(@"//div[@class='product-list']/div[contains(.,'Featured Products')]/following-sibling::div/div[{0}]/descendant::a[2]/span[1]", index)),
                    Selenide.ControlType.Label);
                    reporter.Add(new Act("Clicked on Product " + clickedProduct));

                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@class='product-list']/div[contains(.,'Featured Products')]/following-sibling::div/div[{0}]/descendant::a[2]", index)));

                }
                else
                {
                    clickedProduct = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        "//div[@class='product-list']/div[contains(.,'Featured Products')]/following-sibling::div/div[1]/descendant::a[2]"), Selenide.ControlType.Label);
                    reporter.Add(new Act("Clicked on first product in Featured Products"));
                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        "//div[@class='product-list']/div[contains(.,'Featured Products')]/following-sibling::div/div[1]/descendant::a[2]"));
                }
            }
            else
            {
                throw new Exception("Featured Products wizard not displaying");
            }
            Selenide.Wait(driver, 5, true);
            return clickedProduct;
        }

        #region PRODUCT EDIT; REMOVE BUTTONS (ASSERT AND CLICK) METHODS
        /// <summary>
        /// ClickRemoveProduct method click remove button assosiated with product
        /// If same product display twice, position will change
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="category">Category values: clubmebership, eyeglasses, contactlens</param>
        /// <param name="productName">Enter the product name wish to remove</param>
        /// <param name="position">Default=1; Position value changes same product display twice</param>
        public static void ClickRemoveProduct(RemoteWebDriver driver, Iteration reporter,
            string category,
            string productName,
            int position = 1)
        {
            switch (category.ToLower())
            {
                case "clubmebership":
                    reporter.Add(new Act("Verify selected product title/name in shopping cart"));
                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//span[contains(text(),""{0}"")]/parent::div[normalize-space(@class)=normalize-space('title')]/descendant::button[contains(.,'Remove')]", productName)));
                    break;

                case "eyeglasses":
                    reporter.Add(new Act("Verify selected Eye glasses product title/name in shopping cart"));
                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[text()='{0}'][{1}]/parent::div/parent::div[starts-with(@class,'title')]/descendant::button[contains(text(),'Remove')]",
                        productName, position)));
                    break;

                case "contactlens":
                    reporter.Add(new Act("Verify selected Contact lens product title/name in shopping cart"));
                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::a[text()='{0}'][{1}]/parent::span/parent::div[@class='title']/descendant::button[contains(text(),'Remove')]",
                        productName, position)));
                    break;

                default:
                    reporter.Add(new Act("Verify selected product title/name in shopping cart"));
                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[text()='{0}'][{1}]/parent::div/parent::div[starts-with(@class,'title')]/descendant::button[contains(text(),'Remove')]",
                        productName, position)));
                    break;
            }
        }

        /// <summary>
        /// AssertRemoveProduct method assert remove button assosiated with product
        /// If same product display twice, position will change
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="category">Category values: clubmebership, eyeglasses, contactlens</param>
        /// <param name="productName">Enter the product name wish to remove</param>
        /// <param name="position">Default=1; Position value changes same product display twice</param>
        public static void AssertRemoveProduct(RemoteWebDriver driver, Iteration reporter,
            string category,
            string productName,
            int position = 1)
        {
            reporter.Add(new Act("Verify remove button for a specific product"));

            switch (category.ToLower())
            {
                case "clubmebership":
                    reporter.Add(new Act("Verify selected product title/name in shopping cart"));
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//span[contains(text(),""{0}"")]/parent::div[normalize-space(@class)=normalize-space('title')]/descendant::button[contains(.,'Remove')]", productName)));
                    break;

                case "eyeglasses":
                    reporter.Add(new Act("Verify selected Eye glasses product title/name in shopping cart"));
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[text()='{0}'][{1}]/parent::div/parent::div[starts-with(@class,'title')]/descendant::button[contains(text(),'Remove')]",
                        productName, position)));
                    break;

                case "contactlens":
                    reporter.Add(new Act("Verify selected Contact lens product title/name in shopping cart"));
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::a[text()='{0}'][{1}]/parent::span/parent::div[@class='title']/descendant::button[contains(text(),'Remove')]",
                        productName, position)));
                    break;

                default:
                    reporter.Add(new Act("Verify selected product title/name in shopping cart"));
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[text()='{0}'][{1}]/parent::div/parent::div[starts-with(@class,'title')]/descendant::button[contains(text(),'Remove')]",
                        productName, position)));
                    break;
            }
        }

        /// <summary>
        /// ClickEditProduct method click Edit button of assosiated product
        /// If same product display twice, position will change
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="category">category values: eyeglasses, contactlens</param>
        /// <param name="productName">Edit Product name wish to edit</param>
        /// <param name="position">default=1; Position value changes if duplicate product display</param>
        public static void ClickEditProduct(RemoteWebDriver driver, Iteration reporter,
            string category,
            string productName,
            int position = 1)
        {
            reporter.Add(new Act("Click on Edit button assosiated with product"));
            switch (category.ToLower())
            {
                case "eyeglasses":
                    reporter.Add(new Act("Verify selected Eye glasses product title/name in shopping cart"));
                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[text()='{0}'][{1}]/parent::div/parent::div[starts-with(@class,'title')]/descendant::button[contains(text(),'Edit')]",
                        productName, position)));
                    break;

                case "contactlens":
                    reporter.Add(new Act("Verify selected Contact lens product title/name in shopping cart"));
                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::a[text()='{0}'][{1}]/parent::span/parent::div[@class='title']/descendant::button[contains(.,'Edit')]",
                        productName, position)));
                    break;

                default:
                    reporter.Add(new Act("Verify selected product title/name in shopping cart"));
                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[text()='{0}'][{1}]/parent::div/parent::div[starts-with(@class,'title')]/descendant::button[contains(text(),'Edit')]",
                        productName, position)));
                    break;
            }
        }

        /// <summary>
        /// AssertEditProduct assert Edit button assosiated to the product on shopping cart page
        /// If same product display in the shopping cart position value changes
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="category">category values: eyeglasses, contactlens</param>
        /// <param name="productName">Product name wish to assert</param>
        /// <param name="position">Default=1, if same product display twice postion value changes</param>
        public static void AssertEditProduct(RemoteWebDriver driver, Iteration reporter,
            string category,
            string productName,
            int position = 1)
        {
            reporter.Add(new Act("Assert edit button assosiated to product"));

            switch (category.ToLower())
            {
                case "eyeglasses":
                    reporter.Add(new Act("Verify selected Eye glasses product title/name in shopping cart"));
                    Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[text()='{0}'][{1}]/parent::div/parent::div[starts-with(@class,'title')]/descendant::button[contains(text(),'Edit')]",
                        productName, position)));
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[text()='{0}'][{1}]/parent::div/parent::div[starts-with(@class,'title')]/descendant::button[contains(text(),'Edit')]",
                        productName, position)));
                    break;

                case "contactlens":
                    reporter.Add(new Act("Verify selected Contact lens product title/name in shopping cart"));
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::a[text()='{0}'][{1}]/parent::span/parent::div[@class='title']/descendant::button[contains(.,'Edit')]",
                        productName, position)));
                    break;

                default:
                    reporter.Add(new Act("Verify selected product title/name in shopping cart"));
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[text()='{0}'][{1}]/parent::div/parent::div[starts-with(@class,'title')]/descendant::button[contains(text(),'Edit')]",
                        productName, position)));
                    break;
            }
        }
        #endregion


        /// <summary>
        /// VerifyClubMemberDetailsInShoppingCart method verify all the details of club membership Details
        /// Membership Name, Price and quantity.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="pName">Membership Details</param>
        /// <param name="qty">Quantity eg: 1,2,3 etc..</param>
        /// <param name="price">Membership Price eg: 120.00</param>
        /// <param name="position">Default : 1</param>
        public static void VerifyClubMemberDetailsInShoppingCart(RemoteWebDriver driver, Iteration reporter,
            string pName,
            String qty,
            string price,
            int position = 1)
        {
            VerifyProductTitle(driver, reporter, "clubmebership", pName, position);
            VerifyProductPriceValue(driver, reporter, "clubmebership", pName, price, position);
            VerifyProductQtyValues(driver, reporter, "clubmebership", pName, int.Parse(qty), position);
        }

        /// <summary>
        /// VerifyEyeGlassesDetailsInShoppingCart method assert all Eye Glasses details on Shipping Cart Page 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="pName">Product name wish to assert</param>
        /// <param name="category">Categories values:  eyeglasses, contactlens, membership,</param>
        /// <param name="qty">Quantity of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="position">position assert 2nd object with same name</param>
        public static void VerifyEyeGlassesDetailsInShoppingCart(RemoteWebDriver driver, Iteration reporter,
            string pName,
            string qty,
            string price,
            int position = 1)
        {
            WaitLoadingComplete(driver);
            VerifyProductTitle(driver, reporter, "eyeglasses", pName, position);
            VerifyProductPriceValue(driver, reporter, "eyeglasses", pName, price, position);
            VerifyProductQtyValues(driver, reporter, "eyeglasses", pName, int.Parse(qty), position);
        }

        /// <summary>
        /// VerifyContactDetailsInShoppingCart method assert all ContactLens details in Shopping cart page
        /// Product Name, qantity, and price of product
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="pName">Product name wish to assert</param>
        /// <param name="qty">expected qantity</param>
        /// <param name="price">expected price of product</param>
        /// <param name="position">default:1, postion value changes if same product added twice.</param>
        public static void VerifyContactDetailsInShoppingCart(RemoteWebDriver driver, Iteration reporter,
            string pName,
            string qty,
            string price,
            int position = 1)
        {
            WaitLoadingComplete(driver);
            VerifyProductTitle(driver, reporter, "contactlens", pName, position);
            VerifyProductPriceValue(driver, reporter, "contactlens", pName, price, position);
            VerifyProductQtyValues(driver, reporter, "contactlens", pName, int.Parse(qty), position);
        }

        #region VERIFY PRODUCT DETAILS LIKE  QTY, PRICE AND NAME
        /// <summary>
        /// VerifyProductTitle method verify the Product Name in shopping cart page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Product name wish to verify in shopping cart</param>
        /// <param name="categories">Categories values:  eyeglasses, contactlens, membership,  </param>
        /// <param name="position">Index of product if same product added twice, enter 2 to assert 2nd s</param>
        public static void VerifyProductTitle(RemoteWebDriver driver, Iteration reporter,
            string categories,
            string productName,
            int position = 1)
        {
            switch (categories.ToLower())
            {
                case "clubmebership":
                    reporter.Add(new Act("Verify selected product title/name in shopping cart"));
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[normalize-space(@class)=normalize-space('title')]/span[contains(text(),'{0}')]", productName)));
                    break;

                case "eyeglasses":
                    reporter.Add(new Act("Verify selected Eye glasses product title/name in shopping cart"));
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format("//div[@id='scDetails']/descendant::span[text()='{0}'][{1}]", productName, position)));
                    break;

                case "contactlens":
                    reporter.Add(new Act("Verify selected Contact lense product title/name in shopping cart"));
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format("//div[@id='scDetails']/descendant::a[text()='{0}'][{1}]", productName, position)));
                    break;

                default:
                    reporter.Add(new Act("Verify selected product title/name in shopping cart"));
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format("//div[@id='scDetails']/descendant::span[text()='{0}'][{1}]", productName, position)));
                    break;
            }
        }

        /// <summary>
        /// VerifyProductPrice method verify the Product Price on product details Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Product name wish to assert</param>
        /// <param name="categories">eg: eyeglasses, contactlens, clubmebership</param>
        /// <param name="position">Integer value assert 2nd object having same name</param>
        public static void VerifyProductPriceValue(RemoteWebDriver driver, Iteration reporter,
            string categories,
            string productName,
            string exptPrice,
            int position = 1)
        {
            string actualPrice = null;
            switch (categories.ToLower())
            {
                case "clubmebership":
                    reporter.Add(new Act("Verify selected product Price in shopping cart"));

                    if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//span[contains(text(),'{0}')]/parent::div/parent::div/descendant::span[text()='Price']/parent::div", productName))))
                    {
                        // *** Only if element exist it will verify the Price Compare
                        actualPrice = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//span[contains(text(),'{0}')]/parent::div/parent::div/descendant::span[text()='Price']/parent::div", productName)), Selenide.ControlType.Label);

                        string[] getPrice = actualPrice.Split('$');
                        if (actualPrice.Equals(exptPrice))
                        {
                            reporter.Add(new Act("Price not match"));
                            throw new Exception(string.Format("Actual Price: {0} <br> Expected Price: {1}", actualPrice, exptPrice));
                        }
                    }

                    break;

                case "eyeglasses":
                    reporter.Add(new Act("Verify selected Eye glasses product Price in shopping cart"));

                    if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[normalize-space()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Price']/parent::div",
                        productName, position))))
                    {
                        // *** Only if element exist it will verify the Price Compare
                        actualPrice = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[normalize-space()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Price']/parent::div",
                        productName, position)), Selenide.ControlType.Label);

                        string[] getPrice = actualPrice.Split('$');
                        if (!getPrice[1].Equals(exptPrice))
                        {
                            reporter.Add(new Act("Price not match"));
                            throw new Exception(string.Format("Actual Price: {0} <br> Expected Price: {1}", getPrice[1], exptPrice));
                        }
                    }
                    break;

                case "contactlens":
                    reporter.Add(new Act("Verify selected Contact lense product price in shopping cart"));

                    if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::a[text()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Price']/parent::div",
                        productName, position))))
                    {
                        // *** Only if element exist it will verify the Price Compare
                        actualPrice = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::a[text()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Price']/parent::div",
                        productName, position)), Selenide.ControlType.Label);

                        string[] getPrice = actualPrice.Split('$');
                        if (!getPrice[1].Equals(exptPrice))
                        {
                            reporter.Add(new Act("Price not match"));
                            throw new Exception(string.Format("Actual Price: {0} <br> Expected Price: {1}", getPrice[1], exptPrice));
                        }
                    }
                    break;

                default:
                    if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[normalize-space()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Price']/parent::div",
                        productName, position))))
                    {
                        // *** Only if element exist it will verify the Price Compare
                        actualPrice = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[normalize-space()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Price']/parent::div",
                        productName, position)), Selenide.ControlType.Label);

                        string[] getPrice = actualPrice.Split('$');
                        if (!getPrice[1].Equals(exptPrice))
                        {
                            reporter.Add(new Act("Price not match"));
                            throw new Exception(string.Format("Actual Price: {0} <br> Expected Price: {1}", getPrice[1], exptPrice));
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// VerifyProductQtyValues method verify quantity of specific product
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Product name wish to assert</param>
        /// <param name="categories">eg: eyeglasses, contactlens, clubmebership</param>
        /// <param name="qty">Quantity of product wish to assert</param>
        /// <param name="position">Integer value assert 2nd object having same name</param>
        public static void VerifyProductQtyValues(RemoteWebDriver driver, Iteration reporter,
            string categories,
            string productName,
            int qty = 1,
            int position = 1)
        {
            string actualqty = null;

            switch (categories.ToLower())
            {
                case "clubmebership":
                    reporter.Add(new Act("Verify selected membership Qty in shopping cart"));
                    if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//span[contains(text(),'{0}')]/parent::div/parent::div/descendant::span[text()='Qty']/parent::div", productName))))
                    {
                        // *** Quantity will match only if quantity displayed on Shipping Page
                        actualqty = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//span[contains(text(),'{0}')]/parent::div/parent::div/descendant::span[text()='Qty']/parent::div", productName)), Selenide.ControlType.Label);

                        string[] getQty = actualqty.Split('\n');
                        if (Int16.Parse(getQty[1]) != qty)
                        {
                            reporter.Add(new Act("Quantity not match"));
                            throw new Exception(string.Format("Actual Qty: {0} <br> Expected Qty: {1}", getQty[1], qty));
                        }
                    }
                    break;

                case "eyeglasses":
                    reporter.Add(new Act("Verify selected Eye glasses product Qty in shopping cart"));
                    if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[normalize-space()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Qty']/parent::div",
                        productName, position))))
                    {
                        // *** Quantity will match only if quantity displayed on Shipping Page
                        actualqty = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[normalize-space()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Qty']/parent::div",
                        productName, position)), Selenide.ControlType.Label);

                        string[] getQty = actualqty.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                        if (Int16.Parse(getQty[1]) != qty)
                        {
                            reporter.Add(new Act("Quantity not match"));
                            throw new Exception(string.Format("Actual Qty: {0} <br> Expected Qty: {1}", getQty[1], qty));
                        }
                    }
                    break;

                case "contactlens":
                    reporter.Add(new Act("Verify selected Contact lense product Qty in shopping cart"));
                    if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                         string.Format(@"//div[@id='scDetails']/descendant::a[text()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Qty']/parent::div",
                         productName, position))))
                    {
                        // *** Quantity will match only if quantity displayed on Shipping Page
                        actualqty = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::a[text()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Qty']/parent::div",
                        productName, position)), Selenide.ControlType.Label);

                        string[] getQty = actualqty.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                        if (Int16.Parse(getQty[1]) != qty)
                        {
                            reporter.Add(new Act("Quantity not match"));
                            throw new Exception(string.Format("Actual Qty: {0} <br> Expected Qty: {1}", getQty[1], qty));
                        }
                    }
                    break;

                default:
                    reporter.Add(new Act("Verify selected product Price in shopping cart"));
                    if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[normalize-space()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Qty']/parent::div",
                        productName, position))))
                    {
                        // *** Quantity will match only if quantity displayed on Shipping Page
                        actualqty = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@id='scDetails']/descendant::span[normalize-space()='{0}'][{1}]/ancestor::div[starts-with(@class,'item-info')]/descendant::span[text()='Qty']/parent::div",
                        productName, position)), Selenide.ControlType.Label);

                        string[] getQty = actualqty.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                        if (Int16.Parse(getQty[1]) != qty)
                        {
                            reporter.Add(new Act("Quantity not match"));
                            throw new Exception(string.Format("Actual Qty: {0} <br> Expected Qty: {1}", getQty[1], qty));
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// VerifySphereValues method is used to verify Sphere details for Contact Lenses products
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Name of the Product of which, the values should be asserted</param>
        /// <param name="exptSphere">Expected Power</param>
        /// <param name="eye">Eye, default values 'R','L'</param>
        /// <param name="position">Default:1, position value changes ifa smae product appears twice.</param>
        public static void VerifySphereValues(RemoteWebDriver driver, Iteration reporter,
            string productName,
            string exptSphere,
            string eye,
            int position = 1)

        {
            //@ TODO position variable need to write in write place. Need to fix this issue
            // For future purpose added position parameter
            // As of we will stick with single product in the shopping cart.
            reporter.Add(new Act("Verify contact lens Sphere in shopping cart"));
            if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//a[contains(text(),'{0}')]/ancestor::div[@class='title']/following-sibling::div/descendant::
                                div[@class='col-xs-1 col-eye'][contains(.,'{1}')]/following-sibling::div[@class='col-xs-2 col-sphere']", productName, eye))))
            {
                // *** Sphere will match only if Sphere displayed on ShoppingCart Page
                string actualSphere = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                    string.Format(@"//a[contains(text(),'{0}')]/ancestor::div[@class='title']/following-sibling::
                                    div/descendant::div[@class='col-xs-1 col-eye'][contains(.,'{1}')]/following-sibling::div[@class='col-xs-2 col-sphere']",
                                    productName, eye)), Selenide.ControlType.Label);

                if (!actualSphere.Contains(exptSphere))
                {
                    reporter.Add(new Act("Price not match"));
                    throw new Exception(string.Format("Actual Sphere: {0} <br> Expected Sphere: {1}", actualSphere, exptSphere));
                }
            }

        }

        /// <summary>
        /// VerifyBCValues method is used to verify the BC values for Contact Lenses products
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Name of the Product of which, the values should be asserted</param>
        /// <param name="exptBC">Expected BC</param>
        /// <param name="eye">Eye, default values 'R','L'</param>
        /// <param name="position">Default:1, if same prouct displays twice position value changes</param>
        public static void VerifyBCValues(RemoteWebDriver driver, Iteration reporter,
            string productName,
            string exptBC,
            string eye,
            int position = 1)

        {
            //@ TODO position variable need to write in write place. Need to fix this issue
            // For future purpose added position parameter
            // As of we will stick with single product in the shopping cart.
            reporter.Add(new Act("Verify Contact lens Base-Curve_value in shopping cart"));
            if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//[contains(text(),'{0}')]/ancestor::div[@class='title']/following-sibling::div/descendant::div[@class='col-xs-1 col-eye']
                [contains(.,'{1}')]/following-sibling::div[@class='col-xs-1 col-bc']", productName, eye))))
            {
                // *** BC will match only if it is displayed on ShoppingCart Page
                string actualBC = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                    string.Format(@"//a[contains(text(),'{0}')]/ancestor::div[@class='title']/following-sibling::div/descendant::div[@class='col-xs-1 col-eye']
                    [contains(.,'{1}')]/following-sibling::div[@class='col-xs-1 col-bc']", productName, eye)), Selenide.ControlType.Label);

                if (!actualBC.Contains(exptBC))
                {
                    reporter.Add(new Act("Price not match"));
                    throw new Exception(string.Format("Actual BC: {0} <br> Expected BC: {1}", actualBC, exptBC));
                }
            }

        }

        /// <summary>
        /// VerifyDIAValues method is used to verify the DIA values for Contact Lenses products
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Name of the Product of which, the values should be asserted</param>
        /// <param name="exptDIA">Expected DIA</param>
        /// <param name="eye">Eye, default values 'R','L'</param>
        /// <param name="position">Default:1, if same prouct displays twice postion value changes</param>
        public static void VerifyDIAValues(RemoteWebDriver driver, Iteration reporter,
            string productName,
            string exptDIA,
            string eye,
            int position = 1)

        {
            //@ TODO position variable need to write in write place. Need to fix this issue
            // For future purpose added position parameter
            // As of we will stick with single product in the shopping cart.
            reporter.Add(new Act("Verify Contact Lens DIA_value in shopping cart"));
            if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//a[contains(text(),'{0}')]/ancestor::div[@class='title']/following-sibling::
                                div/descendant::div[@class='col-xs-1 col-eye'][contains(.,'{1}')]/following-sibling::div[@class='col-xs-2 col-dia']",
                                productName, eye))))
            {
                // *** DIA will match only if it is displayed on ShoppingCart Page
                string actualDIA = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                    string.Format(@"//a[contains(text(),'{0}')]/ancestor::div[@class='title']/following-sibling::
                                    div/descendant::div[@class='col-xs-1 col-eye'][contains(.,'{1}')]/following-sibling::div[@class='col-xs-2 col-dia']",
                                        productName, eye)), Selenide.ControlType.Label);

                if (!actualDIA.Contains(exptDIA))
                {
                    reporter.Add(new Act("Price not match"));
                    throw new Exception(string.Format("Actual DIA: {0} <br> Expected DIA: {1}", actualDIA, exptDIA));
                }
            }

        }


        /// <summary>
        /// VerifyCYLValues method is used to verify the CYL values for Contact Lenses products
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Name of the Product of which, the values should be asserted</param>
        /// <param name="exptCYL">Expected CYL</param>
        /// <param name="eye">Eye, default values 'R','L'</param>
        /// <param name="position">Default:1, position value changes if same product appear twice in shooping cart</param>
        public static void VerifyCYLValues(RemoteWebDriver driver, Iteration reporter,
            string productName,
            string exptCYL,
            string eye,
            int position = 1)

        {
            //@ TODO position variable need to write in write place. Need to fix this issue
            // For future purpose added position parameter
            // As of we will stick with single product in the shopping cart.
            reporter.Add(new Act("Verify Contact Lens Cynlider_value in shopping cart"));
            if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//a[contains(text(),'{0}')]/ancestor::div[@class='title']/following-sibling::div/descendant::
                                div[@class='col-xs-1 col-eye'][contains(.,'{1}')]/following-sibling::div[@class='col-xs-2 col-cyl']", productName, eye))))
            {
                // *** CYL will match only if it is displayed on ShoppingCart Page
                string actualCYL = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                    string.Format(@"//a[contains(text(),'{0}')]/ancestor::div[@class='title']/following-sibling::div/descendant::
                                div[@class='col-xs-1 col-eye'][contains(.,'{1}')]/following-sibling::div[@class='col-xs-2 col-cyl']",
                                productName, eye)), Selenide.ControlType.Label);

                if (!actualCYL.Contains(exptCYL))
                {
                    reporter.Add(new Act("Contact Lens Cylinder_value not match"));
                    throw new Exception(string.Format("Actual CYL: {0} <br> Expected CYL: {1}", actualCYL, exptCYL));
                }
            }

        }

        /// <summary>
        /// VerifyAxisValues method is used to verify the DIA values for Contact Lenses products
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Name of the Product of which, the values should be asserted</param>
        /// <param name="exptAxis">Expected Axis</param>
        /// <param name="eye">Eye, default values 'R','L'</param>
        /// <param name="position">Default:1; if same prouct displays twice postion value changes</param>
        public static void VerifyAxisValues(RemoteWebDriver driver, Iteration reporter,
            string productName,
            string exptAxis,
            string eye,
            int position = 1)

        {
            //@ TODO position variable need to write in right place. Need to fix this issue
            // For future purpose added position parameter
            // As of we will stick with single product in the shopping cart.
            reporter.Add(new Act("Verify Contact lens Axis_value in shopping cart"));
            if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//a[contains(text(),'{0}')]/ancestor::div[@class='title']/following-sibling::
                                div/descendant::div[@class='col-xs-1 col-eye'][contains(.,'{1}')]/following-sibling::div[@class='col-xs-1 col-ax']", productName, eye))))
            {
                // *** Axis will match only if it is displayed on ShoppingCart Page
                string actualAxis = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                    string.Format(@"//a[contains(text(),'{0}')]/ancestor::div[@class='title']/following-sibling::
                                div/descendant::div[@class='col-xs-1 col-eye'][contains(.,'{1}')]/following-sibling::div[@class='col-xs-1 col-ax']", productName, eye)), Selenide.ControlType.Label);

                if (!actualAxis.Contains(exptAxis))
                {
                    reporter.Add(new Act("Contact lens Axis_value not match"));
                    throw new Exception(string.Format("Actual Axis: {0} <br> Expected Axis: {1}", actualAxis, exptAxis));
                }
            }

        }

        #endregion


        /// <summary>
        /// VerifyCartEmptyMsg method verify message no items in shopping cart.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="totalItems">number of items added to cart</param>
        public static void VerifyCartEmptyMsg(RemoteWebDriver driver, Iteration reporter,
            string totalItems)
        {
            reporter.Add(new Act("Verify message, when no items /empty cart"));
            if (int.Parse(totalItems) == 0)
            {
                string actMsg = Selenide.GetText(driver, Util.GetLocator("emptycart_lbl"), Selenide.ControlType.Label);
                if (!actMsg.Contains("There are no items in your cart"))
                    throw new Exception(string.Format("Message not displayed, Expected : There are no items in your cart <br> {0}", actMsg));
            }
        }

        /// <summary>
        /// VerifySubTotal method is used to verify SubTotal is avilable in ShoppingCart Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifySubTotal(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify SubTotal in ShoppingCart Page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("subtotal_lbl"));
        }

        /// <summary>
        /// VerifyFeaturedProd method verifies whether the product is addeed to the Cart Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="featuredProd">Featured Product Name</param>
        public static void VerifyFeaturedProd(RemoteWebDriver driver, Iteration reporter, string featuredProd)
        {
            string prodName = Selenide.GetText(driver, Util.GetLocator("featuredprod_lbl"), Selenide.ControlType.Label);
            if (!prodName.Equals(featuredProd))
                reporter.Add(new Act("Featured Product is not added to the Cart"));
            else
                reporter.Add(new Act("Featured Product is added to the Cart"));
        }

        /// <summary>
        /// VerifyAddLensesPopUp method is to verify the Add Lenses popup
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyAddLensesPopUp(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Add Lenses popup"));
            Selenide.VerifyVisible(driver, Util.GetLocator("lenses_popup"));
        }

        /// <summary>
        /// AddLensesInPopUp method is to click on the AddLenses link in the popup
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AddLensesInPopUp(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Add Lenses popup"));
            Selenide.Click(driver, Locator.Get(LocatorType.LinkText, "ADD LENSES"));
        }
    }
}
