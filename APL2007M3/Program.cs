namespace ReportGenerator
{
    class QuarterlyIncomeReport
    {
        static void Main(string[] args)
        {
            // create a new instance of the class
            QuarterlyIncomeReport report = new QuarterlyIncomeReport();

            // call the GenerateSalesData method
            List<SalesData> salesData = report.GenerateSalesData();

            // call the QuarterlySalesReport method
            report.QuarterlySalesReport(salesData.ToArray());
        }

        // public struct SalesData. Include the following fields: date sold, department name, product ID, quantity sold, unit price
        public struct SalesData
        {
            public string dateSold;
            public string departmentName;
            public string productID;
            public int quantitySold;
            public double unitPrice;
        }

        // the GenerateSalesData method returns 1000 SalesData records. It assigns random values to each field of the data structure
        public List<SalesData> GenerateSalesData()
        {
            List<SalesData> salesDataList = new List<SalesData>();
            Random random = new Random();
            string[] departments = { "Electronics", "Clothing", "Groceries", "Toys", "Furniture" };
            string[] productIDs = { "P001", "P002", "P003", "P004", "P005" };

            for (int i = 0; i < 1000; i++)
            {
                SalesData salesData = new SalesData
                {
                    dateSold = DateTime.Now.AddDays(-random.Next(0, 90)).ToString("yyyy-MM-dd"),
                    departmentName = departments[random.Next(departments.Length)],
                    productID = productIDs[random.Next(productIDs.Length)],
                    quantitySold = random.Next(1, 100),
                    unitPrice = Math.Round(random.NextDouble() * 100, 2)
                };
                salesDataList.Add(salesData);
            }

            return salesDataList;
        }

        public void QuarterlySalesReport(SalesData[] salesData)
        {
            // create a dictionary to store the quarterly sales data
            Dictionary<string, double> quarterlySales = new Dictionary<string, double>();

            // iterate through the sales data
            foreach (SalesData data in salesData)
            {
                // calculate the total sales for each quarter
                string quarter = GetQuarter(DateTime.Parse(data.dateSold).Month);
                double totalSales = data.quantitySold * data.unitPrice;

                if (quarterlySales.ContainsKey(quarter))
                {
                    quarterlySales[quarter] += totalSales;
                }
                else
                {
                    quarterlySales.Add(quarter, totalSales);
                }
            }

            // display the quarterly sales report
            Console.WriteLine("Quarterly Sales Report");
            Console.WriteLine("----------------------");
            foreach (KeyValuePair<string, double> quarter in quarterlySales)
            {
                Console.WriteLine("{0}: ${1}", quarter.Key, quarter.Value);
            }
        }

        private string GetQuarter(int month)
        {
            if (month >= 1 && month <= 3)
                return "Q1";
            else if (month >= 4 && month <= 6)
                return "Q2";
            else if (month >= 7 && month <= 9)
                return "Q3";
            else
                return "Q4";
        }
    }
}