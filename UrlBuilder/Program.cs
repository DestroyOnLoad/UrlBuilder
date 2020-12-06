using System;
using System.IO;
using System.Collections.Generic;

namespace UrlBuilder
{
    class Program
    {
        /// <summary>
        /// General example of preparing url paths by inserting id's from a CSV file and then
        /// saving the url paths to a CSV file so it can be copied to the Octoparse url list.
        /// </summary>

        static List<string> prodIdList = new List<string>();
        static List<string> urlList = new List<string>();

        static void Main(string[] args)
        {
            ExtractProductIds();
            BuildUrlList();
            WriteUrlListToFile();
            Console.WriteLine("complete");
            
        }

        private static void BuildUrlList()
        {
            for (int i = 0; i < prodIdList.Count; i++)
            {
                AddUrlToList(prodIdList[i]);
            }
        }

        static void ExtractProductIds()
        {
            string path = @"C:\Users\PCMiner1\Desktop\Dietary Supplements\All Products\prod_id.csv";
            if (!File.Exists(path))
            {
                Console.WriteLine("File path is not correct or file does not exist");
            }

            // Open the file to read from.
            using (StreamReader sr = new StreamReader(path))
            {
                string prod_id;
                while ((prod_id = sr.ReadLine()) != null)
                {
                    prodIdList.Add(prod_id);
                }
            }
        }

        static void AddUrlToList(string prod_id)
        {
            string url = $"https://dsld.od.nih.gov/dsld/prdLabel.jsp?id={prod_id}#prdContact";

            urlList.Add(url);
        }

        static void WriteUrlListToFile()
        {
            string path = @"C:\Users\PCMiner1\Desktop\Dietary Supplements\All Products\url_list.csv";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (var item in urlList)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
        }
    }
}
