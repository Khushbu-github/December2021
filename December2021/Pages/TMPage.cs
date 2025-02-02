﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using December2021.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace December2021.Pages
{
    class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // Create time and material record

            // Click on create new button

            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            try
            {
                // Select typecode from Dropdown list

                IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
                typeCodeDropdown.Click();
                Thread.Sleep(2000);
                //Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TypeCode_listbox']/li[1]", 3);

                IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
                materialOption.Click();

                // Identify the code textbox and input a code

                IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
                codeTextbox.SendKeys("PDecember2012");

                // Identify the Discription and input a description 

                IWebElement discriptionTextbox = driver.FindElement(By.Id("Description"));
                discriptionTextbox.SendKeys("PDecember2012");

                // Identify the Price textbox and input a price
                IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
                priceTag.Click();

                IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
                priceTextbox.SendKeys("305");


                // Click on Save Button

                IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
                saveButton.Click();
                //Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 5);
                Thread.Sleep(3000);


                // go to last page button

                IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                lastPageButton.Click();
                Thread.Sleep(2000);
            }

            catch (Exception ex)
            {
                Assert.Fail("Material record did not created.", ex.Message);
            }
        }
        public string GetCode(IWebDriver driver)
        {
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return actualCode.Text;
        }
        public string GetTypeCode(IWebDriver driver)
        {
            IWebElement actualTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return actualTypeCode.Text;
        }

        public string GetActualDescription(IWebDriver driver)
        {
            IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return actualDescription.Text;
        }

        public string GetActualPrice(IWebDriver driver)
        {
            IWebElement actualPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return actualPrice.Text;
        }

        public void EditTM(IWebDriver driver, string description, string code)
        {
            Thread.Sleep(3000);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();
                
            // click on edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click(); 

            // Edit Current Code 
            IWebElement editCode = driver.FindElement(By.Id("Code"));
            editCode.Clear();
            editCode.SendKeys(code);

            // Edit Current Description
            IWebElement editDescription = driver.FindElement(By.Id("Description"));
            editDescription.Clear();
            editDescription.SendKeys(description);
            Thread.Sleep(3000);
            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 4);

            //Edit Current Price
            IWebElement editPriceTextBox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editPriceInput = driver.FindElement(By.Id("Price"));
            editPriceTextBox.Click();
            editPriceInput.Clear();
            editPriceTextBox.Click();
            editPriceInput.SendKeys("177");
                                            
            // Click on Save Button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Thread.Sleep(3000);
            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 3);

            // Go to last page button
            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton1.Click();
            Thread.Sleep(2000);

            // Check if edited record has edit the value
            IWebElement editedLastValue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
        }

        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement createdCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return createdCode.Text;
        }
        public string GetEditedTypeCode(IWebDriver driver)
        {
            IWebElement createdTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return createdTypeCode.Text;
        }
        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement createdDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return createdDescription.Text;
        }
        public string GetEditedPrice(IWebDriver driver)
        {
            IWebElement createdPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return createdPrice.Text;
        }

        public void DeleteTM(IWebDriver driver)
        {
            Thread.Sleep(3000);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            //if (findEditedRecord.Text == "TEditedDecember2012")
            //{
                // Click on the Delete Button
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(2000);

                // Click on Ok
                driver.SwitchTo().Alert().Accept();
            //}
            //else
            //{
            //    Assert.Fail("Record to be deleted hasn't been found. Record not deleted.");
            //}

            // Assert that Time record has been deleted.
            IWebElement goToLastPageBtn1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageBtn1.Click();
            Thread.Sleep(2000);        
        }
        public string GetDeletedCode(IWebDriver driver)
        {
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedCode.Text;
        }
        public string GetDeletedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;
        }
        public string GetDeletedPrice(IWebDriver driver)
        {
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return editedPrice.Text;
        }

    }
}
