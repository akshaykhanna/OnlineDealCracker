using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiDealCracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String dataCid = "3153700004";
        //band
        // String dataCid ="3153700004";
        //3160800001
        //3153700004
        //3162300004
        //3160700012

        String username = "user", pass = "pass";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IWebDriver driver = new FirefoxDriver();
                driver.Url = "http://www.mi.com/in/events/2ndanniversary/";
                List<IWebElement> list = driver.FindElements(By.LinkText("Please log in")).ToList<IWebElement>();
                String text = "";
                foreach (var l in list)
                {
                    // text+= l.GetAttribute("data-cid").ToString()+"\n";
                    if (l.GetAttribute("data-cid").ToString().Equals(dataCid))
                    {
                        l.Click();
                        loginMi(driver);
                        break;
                    }
                }
                textBox.Text = text;
            }
            catch (Exception ex)
            {

                textBox.Text =ex.ToString();
            }
        }

        private void loginMi(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.Id("username")).SendKeys(username);
                driver.FindElement(By.Id("pwd")).SendKeys(pass);
                driver.FindElement(By.Id("login-button")).Click();
            }
            catch (Exception ex) 
            {

                textBox.Text = ex.ToString();
            }
        }
    }
}
