using System.Windows.Forms;

namespace Browser
{
    public class FavouritesManager
    {
        private ToolStripDropDownButton bookmarkButton; // Reference to bookmarks
        private TextBox searchBox;  // Reference to search box
        private Form1 form;       // Reference to form

        // Constructor to intialize Favourites with necessary components
        public FavouritesManager(ToolStripDropDownButton bookmarkButton, TextBox searchBox, Form1 form)
        {
            this.bookmarkButton = bookmarkButton; // Assign bookmarks button
            this.searchBox = searchBox;    // Assign search box
            this.form = form;   // Assign form

            LoadFavourites();
        }

        // Methods to load favourites from settings
        private void LoadFavourites()
        {
            var favorites = Properties.Settings.Default.Favourites;  // Retrieve favourites name|URL
            if (favorites != null)
            {
                foreach (string favorite in favorites)
                {
                    var parts = favorite.Split('|');  // Split into name|URL
                    if (parts.Length == 2)
                    {
                        AddFavouriteToMenu(parts[0], parts[1]);  // Add to the favourites dropdown
                    }
                }
            }
        }


        // Method to add favourite to bookmarks menu and add sub options
        public void AddFavouriteToMenu(string name, string url)
        {
            var menuItem = new ToolStripMenuItem(name) { DropDown = new ContextMenuStrip() }; // Create another menu within the favourites menu
            menuItem.Click += (sender, e) => { searchBox.Text = url; form.LoadPage(url); }; // Load URL into search box and load the page

            menuItem.DropDown.Items.Add("Edit", null, (s, e) => EditFavourite(name, url, menuItem)); // Add edit button to menu and link to EditFavourite method
            menuItem.DropDown.Items.Add("Delete", null, (s, e) => DeleteFavourite(name, menuItem));  // Add delete button to menu and link to DeleteFavourite method

            bookmarkButton.DropDownItems.Add(menuItem); // Add the favourites pages to the bookmarks button
        }

        // Method to edit the favourites pages
        private void EditFavourite(string oldName, string oldUrl, ToolStripMenuItem menuItem)
        {
            string newName = PromptForFavouriteName();     // Prompt for new name
            string newUrl = PromptForFavouriteUrl(oldUrl);  // Prompt for new URL

            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newUrl)) // If URL or name is empty simply exit
                return;

            UpdateFavouriteInSettings(oldName, oldUrl, newName, newUrl);   // Update favourite settings with new name and URL
            menuItem.Text = newName; // Update the menu item with new name
            menuItem.Click += (sender, e) => { searchBox.Text = newUrl; form.LoadPage(newUrl); }; // Update the URL to new URL when clicked
        }


        // Method to delete the favourites pages
        private void DeleteFavourite(string name, ToolStripMenuItem menuItem)
        {
            RemoveFavouriteFromSettings(name);           // Remove name from menu
            bookmarkButton.DropDownItems.Remove(menuItem);  // Remove page from dropdown
        }

        // Method to update the favourite pages within settings
        private void UpdateFavouriteInSettings(string oldName, string oldUrl, string newName, string newUrl)
        {
            var favorites = Properties.Settings.Default.Favourites;  // Retrieve list of favourites pages from settings
            for (int i = 0; i < favorites.Count; i++)            // Iterate through pages to find old name and old URL
            {
                var parts = favorites[i].Split('|');             // Split into name|URL
                if (parts.Length == 2 && parts[0] == oldName && parts[1] == oldUrl)  // Check to see if favorites matches old name and URL
                {
                    favorites[i] = $"{newName}|{newUrl}";   // Updates the favourites entry with new name and URL
                    Properties.Settings.Default.Save();    // Save changes in the settings
                    break;   // Exit loop
                }
            }
        }


        // Method to remove favourite pages from settings
        private void RemoveFavouriteFromSettings(string name)
        {
            var favorites = Properties.Settings.Default.Favourites;   // Retrieve the list of favourite pages from settings
            for (int i = 0; i < favorites.Count; i++)   // Iterate through pages to find the match
            {
                var parts = favorites[i].Split('|');  // Split into name|URL
                if (parts.Length == 2 && parts[0] == name)   // Check to see if current matches from name
                {
                    favorites.RemoveAt(i);             // Remove the matching one
                    Properties.Settings.Default.Save();   //Save changes in settings
                    break;     // Exit loop
                }
            }
        }

        //Method to prompt user for a name for the favorite
        public string PromptForFavouriteName()
        {
            return Microsoft.VisualBasic.Interaction.InputBox("Enter a name for this favorite:", "Add/Edit Favorite", "Favorite Name");
        }

        // Method to Prompt user for a URL for the favorite
        public string PromptForFavouriteUrl(string defaultUrl)
        {
            return Microsoft.VisualBasic.Interaction.InputBox("Enter the URL for this favorite:", "Edit Favorite", defaultUrl);
        }
    }
}