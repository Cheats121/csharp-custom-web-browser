
# C# Custom Web Browser

A lightweight Windows desktop application built with **C# and Windows Forms**, designed to retrieve web content, inspect HTML source code, manage browsing history and bookmarks, and perform bulk HTTP requests.

This project explores HTTP communication, asynchronous programming, GUI development, and local data persistence using the .NET Framework.

Unlike traditional browsers such as Chrome or Firefox, this application focuses on retrieving and displaying the **HTML source code** of webpages rather than rendering their visual appearance.

## Features

### HTTP Requests and HTML Source Viewing
- Retrieve webpages using HTTP GET requests.
- Display the HTML response in a dedicated text area.
- Extract webpage titles from HTML using regular expressions.
- Display HTTP response status codes.
- Handle network and HTTP request errors.
- Show a loading indicator while retrieving content.

### Navigation
- Navigate between previously visited URLs using Back and Forward buttons.
- Reload the current webpage.
- Access previously visited pages through the History menu.

### Homepage Management
- Set a custom homepage.
- Navigate to the saved homepage using the Home button.
- Automatically load the configured homepage when the application starts.
- Persist homepage preferences between sessions.

### Bookmarks and Favourites
- Save frequently visited webpages as favourites.
- Assign custom names to bookmarks.
- Edit existing bookmark names and URLs.
- Delete saved bookmarks.
- Access saved webpages through a dropdown menu.
- Preserve bookmarks between application sessions.

### Browsing History
- Track previously visited URLs.
- Access browsing history through a dropdown menu.
- Navigate directly to previously visited webpages.
- Save and restore history using application settings.

### Bulk URL Downloading
- Select a text file containing multiple URLs.
- Send HTTP GET requests to each URL.
- Display the HTTP status code for each request.
- Display the reported content length when available.
- Present results in a structured format.

Example input file:

```text
https://example.com
https://www.wikipedia.org
https://www.microsoft.com
```

Example output format:

```text
Status Code     Bytes       URL
OK              1256        https://example.com
OK              0           https://www.wikipedia.org
OK              15720       https://www.microsoft.com
```

*Note: The values above are illustrative. A byte count of 0 may indicate that the server did not provide a Content-Length header.*

## Technologies Used

| Technology | Purpose |
|------------|---------|
| C# | Application development |
| .NET Framework 4.7.2 | Application runtime |
| Windows Forms | Graphical user interface |
| HttpClient | HTTP communication |
| Async/Await | Asynchronous request handling |
| Regular Expressions | HTML title extraction |
| Application Settings | Persistent storage |
| Visual Studio | Development environment |

## Project Structure

```text
csharp-custom-web-browser/
├── Browser.sln
├── README.md
├── .gitignore
└── Browser/
    ├── Browser.csproj
    ├── App.config
    ├── packages.config
    ├── Program.cs
    ├── Form1.cs
    ├── Form1.Designer.cs
    ├── Form1.resx
    ├── HistoryManager.cs
    ├── FavouritesManager.cs
    ├── NavigationData.cs
    ├── BulkManager.cs
    ├── Properties/
    │   ├── AssemblyInfo.cs
    │   ├── Resources.resx
    │   ├── Resources.Designer.cs
    │   ├── Settings.settings
    │   └── Settings.Designer.cs
    └── Resources/
        └── Images and interface assets
```

### Main Components

**Form1.cs**

Contains the main application logic, including HTTP requests, navigation controls, homepage management, and user interface event handling.

**HistoryManager.cs**

Manages browsing history, including saving, loading, and updating previously visited URLs.

**FavouritesManager.cs**

Handles bookmark creation, editing, deletion, and persistent storage.

**NavigationData.cs**

Maintains shared navigation state and tracks the currently selected history entry.

**BulkManager.cs**

Processes text files containing URLs, performs asynchronous HTTP requests, and displays the resulting status codes and content lengths.

**Form1.Designer.cs**

Defines the Windows Forms interface, including buttons, text boxes, dropdown menus, and other visual components.

### Installation

**1. Clone the repository**

```bash
git clone https://github.com/YOUR_USERNAME/csharp-custom-web-browser.git
```

**2. Open the project**

Navigate to the downloaded folder and open:

```text
Browser.sln
```

in Visual Studio.

**3. Restore dependencies**

Restore any required NuGet packages using Visual Studio's NuGet Package Manager.

**4. Build the application**

Select:

```text
Build > Build Solution
```

or press:

```text
Ctrl + Shift + B
```

**5. Run the application**

Press `F5` in Visual Studio to launch the browser.

## How to Use

### Loading a Webpage

1. Launch the application.
2. Enter a valid URL into the address bar.
3. Click the Search button.
4. The application retrieves the webpage using an HTTP GET request.
5. The HTML source code appears in the main display area.
6. The window title displays the extracted page title and HTTP response status.

Example:

```text
https://example.com
```

### Navigating Between Pages

Use the navigation buttons to move between previously visited webpages.

- **Back:** Navigate to an earlier URL.
- **Forward:** Navigate to a later URL.
- **Reload:** Request the current webpage again.
- **Home:** Return to the configured homepage.

### Setting a Homepage

1. Enter the URL of the desired homepage.
2. Click the Home dropdown button.
3. Select **Set as Home**.
4. The homepage URL is saved in application settings.

The configured homepage will automatically load when the application starts.

### Adding Bookmarks

1. Navigate to a webpage.
2. Click the Favourites button.
3. Enter a name for the bookmark.
4. Confirm to save the webpage.

Saved bookmarks can be accessed through the Bookmarks dropdown menu.

Users can also edit or delete previously saved bookmarks.

### Viewing Browsing History

Click the History button to view previously visited webpages.

Select an entry from the dropdown menu to navigate to its URL.

Browsing history is stored locally and restored when the application restarts.

### Bulk Downloading

The bulk download functionality allows multiple URLs to be processed from a text file.

**Step 1:** Create a text file containing one URL per line.

Example:

```text
https://example.com
https://www.wikipedia.org
https://www.microsoft.com
```

**Step 2:** Click the Bulk Download button.

**Step 3:** Select the text file using the file selection dialog.

**Step 4:** The application sends HTTP GET requests to each URL.

**Step 5:** Results are displayed in the main application window, including the HTTP status code, reported content length, and URL.

## Implementation Details

### Asynchronous HTTP Communication

The application uses the `HttpClient` class to retrieve webpage content asynchronously.

```csharp
HttpResponseMessage response = await client.GetAsync(url);

string responseBody = await response.Content.ReadAsStringAsync();
```

Using asynchronous operations helps keep the Windows Forms interface responsive while requests are in progress.

### HTML Title Extraction

Webpage titles are extracted using a regular expression:

```csharp
var match = Regex.Match(html, @"<title>([^<]*)</title>");

return match.Success
    ? match.Groups[1].Value
    : "No Title";
```

This provides a lightweight way to identify webpage titles without implementing a full HTML parser.

### Persistent Storage

The application uses `Properties.Settings` to preserve user preferences and browsing information.

Persisted information includes:

- Homepage URL
- Saved bookmarks
- Browsing history

This allows users to retain their settings between application sessions without requiring an external database.

### Navigation Management

A shared navigation data class maintains an ordered list of previously visited URLs and an index representing the current navigation position.

This information is used to support Back and Forward navigation.

### Bulk Request Processing

The bulk request feature reads URLs from a text file and processes them using asynchronous HTTP requests.

For each URL, the application retrieves the HTTP response and reports its status code and content length where available.


## What This Project Demonstrates

This project demonstrates practical experience with:

- Object-oriented programming in C#
- Windows desktop application development
- HTTP request and response handling
- Asynchronous programming with async/await
- Event-driven GUI development
- Data structures and navigation state
- Persistent application settings
- Modular code organization
- Error handling and user interaction
