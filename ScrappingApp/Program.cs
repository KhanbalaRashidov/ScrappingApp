using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OfficeOpenXml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScrappingApp
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Dictionary<string, StoreData> storeInfos = new Dictionary<string, StoreData>();
            int totalPages = 9299;

            Uri baseAddress = new Uri("https://flutterwave.market/marketplace/getProducts");
            var storeUrl = "https://flutterwave.com/store/";


            
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
     JsonNumberHandling.WriteAsString
            };
            using (HttpClient client= new HttpClient()) 
            {
                client.BaseAddress= baseAddress;

                // Yeni bir Excel paketi oluştur
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage package = new ExcelPackage();

                // Yeni bir çalışma sayfası oluştur
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Başlıkları ve verileri yaz
                worksheet.Cells["A1"].Value = "StoreName";
                worksheet.Cells["B1"].Value = "Email";
                worksheet.Cells["C1"].Value = "PhoneNumber";
               

               

                for (int i = 1; i <totalPages; i++)
                {
                    var result = client.GetAsync($"?page={i}").Result.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Root>(result);
                    int rowIndex = 2;
                    foreach ( var product in data!.products)
                    {

                        var userName = product.store.slug;
                        var storeName= product.store.name;

                        var parserData = Parser($"{storeUrl}{userName}", storeName);

                        

                        if (!storeInfos.ContainsKey(userName))
                        {
                            storeInfos.Add(userName, parserData);
                            worksheet.Cells[rowIndex, 1].Value = parserData.StoreName;
                            worksheet.Cells[rowIndex, 2].Value = parserData.Email;
                            worksheet.Cells[rowIndex, 3].Value = parserData.PhoneNumber;
                            rowIndex++;
                        }
                        
                    }
                    Task.Delay(2000);
                    Console.WriteLine(i);
                }

                // Excel dosyasını kaydet
                string filePath = "C:\\example\\Aytac.xlsx";
                package.SaveAs(new FileInfo(filePath));

                Console.WriteLine();
            }
        }

        static StoreData Parser(string url,string storeName)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            Task.Delay(10000);

           
           
            string email = null;
            string phoneNumber = null;

            try
            {
                var emailElement = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/footer/div/div/div[2]/a[1]"));
                email = emailElement.Text;
            }
            catch (NoSuchElementException)
            {
                // Öğe bulunamadı, email değeri null olarak kalacak
            }

            try
            {
                var phoneNumberElement = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/footer/div/div/div[2]/a[2]"));

                phoneNumber = phoneNumberElement.Text;
            }
            catch (NoSuchElementException)
            {
                // Öğe bulunamadı, phoneNumber değeri null olarak kalacak
            }

            var data = new StoreData()
            {
                StoreName = storeName,
                Email = email,
                PhoneNumber = phoneNumber
            };


            driver.Quit();
            return data;

        }
    }
}