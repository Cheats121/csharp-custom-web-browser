using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections.Specialized;



namespace Browser
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();  // Instance for handling HTTP requests
        private string currentUrl;  // Stores current URL for reloading
        private List<string> history = new List<string>();  // List to store browsing History
        private int currentHistoryIndex = -1;  // Tracks the current position in history for navigation
        private Dictionary<string, string> favorites = new Dictionary<string, string>();  // Dictionary to store favorites pages
        private string baseTitle = "";  // Base title without animation
        private FavouritesManager favoritesManager; // Instance for handling favorite pages
        private NavigationData navigationData; // Instance for syncronizing navigation data
        private HistoryManager historyManager; // Instance for handling history pages
        private BulkManager bulkManager;    // Instance for handling bulk downloads





        public Form1()
        {
            InitializeComponent();
            AdjustLoadingIndicatorPosition();  // Set initial position of loading animation

            // Initialize constructors with necessary references
            navigationData = new NavigationData();
            favoritesManager = new FavouritesManager(bookmarkButton, searchBox, this);
            historyManager = new HistoryManager(searchBox, this, historyButton, navigationData);
            bulkManager = new BulkManager(client, result => webBox.Text = result);
            

            // Event handlers for buttons and menu items
            favouritesButton.Click += new EventHandler(AddToFavorites_Click);
            goHomeToolStripMenuItem.Click += new EventHandler(GoHome_Click);
            setHomeToolStripMenuItem.Click += new EventHandler(SetHome_Click);
            backButton.Click += new EventHandler(BackButton_Click);
            forwardButton.Click += new EventHandler(ForwardButton_Click);

            historyManager.LoadHistory();
            LoadHomePage();  // Load home page on startup
        }



        /// <summary>
        /// Load Page Feature
        /// </summary>
        /// 

        // Method to load home page URL
        private async void LoadHomePage()
        {
            string homePage = Properties.Settings.Default.HomePageUrl;  // Get saved home page URL from settings
            searchBox.Text = homePage;  // Display the home page URL in the search box
            await LoadPage(homePage);  // Load the home page
        }

        // Method to send HTTP GET request to load web page, update title and code, add to history
        public async Task LoadPage(string url)
        {
            try
            {

                loadingIndicator.Visible = true;  // Loading animation set to true when page is laoding

                HttpResponseMessage response = await client.GetAsync(url);  // Send HTTP get request to retrieve web page
                currentUrl = url;  // store current URL for reloading purposes
               
                string responseBody = await response.Content.ReadAsStringAsync();  // Get the HTML page contents

                string title = ExtractTitle(responseBody); // Extract title from the html Content
              
                baseTitle = $" {title} - Status: {response.StatusCode} ({(int)response.StatusCode})"; // Set title and response code from HTML content
            
                webBox.Text = $"{responseBody}";  // Display content within the Web Box design

                
                this.Text = baseTitle;  // Update window title
                historyManager.UpdateHistory(url);     // Update history List with the url
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}");    // Error message if page not come
            }
            finally
            {
                loadingIndicator.Visible = false;  // loading animation set to false once page is loaded
            }

        }



        /// <summary>
        /// Title Extraction Feature
        /// </summary>
        /// 

        // Method to extract title from HTML code using regex
        private string ExtractTitle(string html)
        {
            var match = Regex.Match(html, @"<title>([^<]*)</title>"); // Using regex to filter to the title from the content
            return match.Success ? match.Groups[1].Value : "No Title";  // Return with title or nothing
        }



        /// <summary>
        /// Home Features
        /// </summary>
        /// 
        public async void GoHome_Click(object sender, EventArgs e)
        {
            string homePage = Properties.Settings.Default.HomePageUrl;  // Retrieve home page URL from settings
            searchBox.Text = homePage;  // Set URL from saved home in the search box
            await LoadPage(homePage);  // Load the home page
        }

        // Method to set the curent URL to home page
        public void SetHome_Click(object sender, EventArgs e)
        {
            string url = searchBox.Text;  // Get the current URL from search box
            if (!string.IsNullOrEmpty(url)) //
            {
                Properties.Settings.Default.HomePageUrl = url;  // Save the current URL as the home page
                Properties.Settings.Default.Save();  // Save the setting persistently
                MessageBox.Show($"Home page set to: {url}"); // Saved message
            }
            else
            {
                MessageBox.Show("Please enter a URL.");     // Enter URL for the homepage
            }
        }



        /// <summary>
        /// Reload Button
        /// </summary>
        /// 

        // Method to reload the current page via the URL in search box
        private async void ReloadButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentUrl))  // Check if URL is there on search box
            {
                await LoadPage(currentUrl);  // Reload page with current URL in box
            }
            else
            {
                MessageBox.Show("Error Loading Page");       // No URL in search box then error
            }
        }



        /// <summary>
        /// Search Button
        /// </summary>
        /// 

        // Method to searh the URL via a search button
        private async void SearchButton_Click(object sender, EventArgs e)
        {
            string url = searchBox.Text;  // Get URL from searchBox
            if (!string.IsNullOrEmpty(url))
            {
                await LoadPage(url);  // Load the page
            }
            else
            {
                MessageBox.Show("Please enter a URL.");  // Else enter URL in empty search box
            }
        }



        /// <summary>
        /// Forward and Back Buttons
        /// </summary>
        /// 

        // Back button functionality
        public void BackButton_Click(object sender, EventArgs e)
        {
            if (navigationData.CurrentHistoryIndex > 0) // Check if stack is empty or not
            {
                navigationData.CurrentHistoryIndex--;  // Move back one page
                string previousUrl = navigationData.History[navigationData.CurrentHistoryIndex]; // Retrieve the previous URL
                searchBox.Text = previousUrl;  // Place the URL back into search box
                LoadPage(previousUrl);  // Then load the URL to retrieve back the page
            }
        }

        // Forward button functionality
        public void ForwardButton_Click(object sender, EventArgs e)
        { 
            if (navigationData.CurrentHistoryIndex < navigationData.History.Count - 1) // Check if stack is full or not
            {
                navigationData.CurrentHistoryIndex++;   // Move front one page
                string nextUrl = navigationData.History[navigationData.CurrentHistoryIndex];  // Retrieve the next URL
                searchBox.Text = nextUrl;  // Place the URL back into search box
                LoadPage(nextUrl);   // Then load the URL to retrieve back the page
            }
        }



        /// <summary>
        /// Favourites Features
        /// </summary>
        ///

        // Method to add current web page to favourites settings via the favourites button
        public void AddToFavorites_Click(object sender, EventArgs e)
        {
            string url = searchBox.Text;   // Get URL from search box
            if (!string.IsNullOrEmpty(url))
            {
                string name = favoritesManager.PromptForFavouriteName();  // Prompt user to give a name for the favorite page
                if (!string.IsNullOrEmpty(name))
                {

                    if (Properties.Settings.Default.Favourites == null)  // Initialize favourites if null
                    {
                        Properties.Settings.Default.Favourites = new StringCollection();
                    }

                    Properties.Settings.Default.Favourites.Add($"{name}|{url}");  // Add favourites as name|URL
                    Properties.Settings.Default.Save();  // Save updated Favourites
                    favoritesManager.AddFavouriteToMenu(name, url);  // Add it to the favorites dropdown
                    MessageBox.Show($"Added to favorites: {name}");   // Save message
                }
            }
            else
            {
                MessageBox.Show("Please enter a URL.");  // Enter URL for favourites page
            }
        }



        /// <summary>
        /// Bulk Download Feature
        /// </summary>
        ///

        // Method to initiate bulk downloads via bulk download button
        private async void bulkDownloadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) // Open a dialog for the user to select the bulk download file in txt format
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt";  // Limit to text files only
                openFileDialog.Title = "Select Bulk Download File (Only text files)"; // prompt to tell user to select the file

                if (openFileDialog.ShowDialog() == DialogResult.OK)       // If user selects the file then
                {
                    string fileName = openFileDialog.FileName;  // Get the selected file's path
                    webBox.Clear();  // Clear previous content in webBox for fresh display
                    await bulkManager.BulkDownload(fileName);   // Call BulkDownload with the selected file
                }
            }
        }



        /// <summary>
        /// Form Customization and Saves
        /// </summary>
        /// 

        // Method to save browsing history when browser is closed
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            historyManager.SaveHistory();                    // Save History when browser is closed
            base.OnFormClosing(e);           // Complete the browser closing
        }

        // Method to adjust loading gif position
        private void Form1_Load(object sender, EventArgs e)
        {
            AdjustLoadingIndicatorPosition();             // Loading gif position adjusted
        }

        // Method to adjust loading gif position within search box
        private void AdjustLoadingIndicatorPosition()
        {
       
            this.loadingIndicator.Location = new System.Drawing.Point(this.searchBox.Width - 25, (this.panelSearchBar.Height - this.loadingIndicator.Height) / 2); // Position the loading indicator gif inside search box
        }

        // Method to make tool strip menu and loading gif dynamic to screen size changes
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.toolStrip1.Size = new System.Drawing.Size(this.Width, 36); // Dynamic width change of tool strip menu
            this.loadingIndicator.Location = new System.Drawing.Point(this.searchBox.Width - 25, (this.panelSearchBar.Height - this.loadingIndicator.Height) / 2);  // Dynamic position of loading gif within search box

        }

    }
}