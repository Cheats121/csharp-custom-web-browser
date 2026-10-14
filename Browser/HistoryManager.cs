using System.Collections.Specialized;
using System.Windows.Forms;

namespace Browser
{
    public class HistoryManager
    {
        private TextBox searchBox;   // Reference to search bar
        private Form1 form;          // Reference to form.cs
        private ToolStripDropDownButton historyButton;       // Reference to history button
        private NavigationData navigationData;              // Reference to naviagtion data

        // Constructor to intialize historyManager with necessary components
        public HistoryManager(TextBox searchBox, Form1 form, ToolStripDropDownButton historyButton, NavigationData navigationData)
        {
            this.searchBox = searchBox;      // Assign search box
            this.form = form;               // Assign form
            this.historyButton = historyButton;  // Assign history button
            this.navigationData = navigationData;   // Assign navigation data
        }

        // Method to save browsing history to the settings
        public void SaveHistory()
        {
            Properties.Settings.Default.History = new StringCollection(); // Initialize history collection
            foreach (var url in navigationData.History)
            {
                Properties.Settings.Default.History.Add(url);  // Add URL to collection
            }
            Properties.Settings.Default.Save();    // Save the settings to get persistence
        }

        // Method to Load browsing history from settings
        public void LoadHistory()
        {
            var savedHistory = Properties.Settings.Default.History;  // Retrieve history from settings
            if (savedHistory == null) return;       // If no history is saved then get nothing

            foreach (var url in savedHistory)      
            {
                navigationData.History.Add(url);    // Add URL to history list

                var menuItem = new ToolStripMenuItem(url);   // Create menu item for each history URL
                menuItem.Click += (sender, e) => { searchBox.Text = url; form.LoadPage(url); };   // Load history page on click
                historyButton.DropDownItems.Insert(0, menuItem);     // Make sure latest history on top
            }
            navigationData.CurrentHistoryIndex = navigationData.History.Count - 1;    // Set history index to end
        }

        // Method to update browsing history to settings
        public void UpdateHistory(string url)
        {
            if (navigationData.CurrentHistoryIndex == -1 || navigationData.CurrentHistoryIndex == navigationData.History.Count - 1)
            {
                navigationData.History.Add(url);     // Add URL to history
                navigationData.CurrentHistoryIndex = navigationData.History.Count - 1; // Update history Index

                var menuItem = new ToolStripMenuItem(url);     // Create the menu item to put the history in
                menuItem.Click += (sender, e) => { searchBox.Text = url; form.LoadPage(url); };  // Load history page on click
                historyButton.DropDownItems.Insert(0, menuItem);  // Make sure latest history on top
            }
        }
    }
}
