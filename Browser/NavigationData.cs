using System.Collections.Generic;

namespace Browser
{
    public class NavigationData
    {
        public List<string> History { get; set; } = new List<string>();  // Shared history list for syncronization across
        public int CurrentHistoryIndex { get; set; } = -1;               // Shared current history for syncronization of index
    }
}
