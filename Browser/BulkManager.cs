using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public class BulkManager
    {
        private readonly HttpClient client; // Reference to client
        private readonly Action<string> displayResults; // To display the result in the browser

        // Constructor to intialize BulkManager with necessary components
        public BulkManager(HttpClient client, Action<string> displayResults)
        {
            this.client = client;  // Assign client
            this.displayResults = displayResults;    // Assign display result

        }

        // Method to to read URLS from file and initiate bulk download
        public async Task BulkDownload(string fileName)
        {
            try
            {
                // Read URLs from the specified file
                var urls = System.IO.File.ReadAllLines(fileName);  // To read the URLS from the file
                var results = new List<string> ();  // List to store results


                results.Add($"{"Status Code",-15} {"Bytes",-10} {"URL"}");  // Headings added with space

                foreach (var url in urls)
                {
                    if (!string.IsNullOrWhiteSpace(url))
                    {

                        var response = await client.GetAsync(url.Trim()); // Retrieve each page async
                        var byteCount = response.Content.Headers.ContentLength ?? 0; // Get the bytes for each URL

                        // Format the result
                        string resultLine = $"{response.StatusCode,-15} {byteCount,-10} {url.Trim()}";  // Aligning the results
                        results.Add(resultLine); // Add the results to the line
                    }
                }
                displayResults(string.Join(Environment.NewLine + Environment.NewLine, results));  // Display results



            }
            catch (Exception ex)
            {
                MessageBox.Show($"error while downloading:{ex.Message}"); // Error message if bulk download doesnt work
            }
        }
    }
}
