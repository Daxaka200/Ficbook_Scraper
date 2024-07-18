using System.Collections.Generic;

namespace Ficbook_Scraper
{
    public class Ficbook
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Fandom { get; set; }
        public List<string> Tags { get; set; }
        public string Description { get; set; }
        public List<Chapter> Chapters { get; set; }

        public Ficbook()
        {
            Tags = new List<string>();
            Chapters = new List<Chapter>();
        }
    }

    public class Chapter
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
