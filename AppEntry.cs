using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP202Project
{
    public class AppEntry
    {
        private string name;
        private string source;
        private Uri image;
        private string description;
        private List<string> keywords;
        public string[] keywordsArray;
        protected string ImageType;

        #region Assigning Values
        public string Name { get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }
        public Uri Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public List<string> Keywords
        {
            get
            {
                return keywords;
            }
            set
            {
                
                keywords = value;
            }
        }
        #endregion 

        public AppEntry(string Name, string Source, string Description, string Keywords)
        {
            this.Name = Name;
            this.Source = Source;
            this.Description = Description;
            this.Keywords = new List<string>();
            keywordsArray = Keywords.Split(',');
            for (int i = 0; i < keywordsArray.Length; i++)
            {
                this.Keywords.Add(keywordsArray[i].ToLower());
            }

        }

        public override string ToString()
        {
            return $"{Name}";
        }

        

    }

    #region Category Constructors
    class Networking : AppEntry
    {
        public Networking(string Name, string Source, string Description, string Keywords) : base(Name, Source, Description, Keywords)
        {
           ImageType  = "Networking.png";
           Image = new Uri("\\images\\" + ImageType, UriKind.Relative);
            this.Keywords.Add("networking");
        }
    }

    class Database : AppEntry
    {
        public Database(string Name, string Source, string Description, string Keywords) : base(Name, Source, Description, Keywords)
        {
            ImageType = "Database.png";
            Image = new Uri("\\images\\" + ImageType, UriKind.Relative);
            this.Keywords.Add("database");
        }
    }
    class Internet : AppEntry
    {
        public Internet(string Name, string Source, string Description, string Keywords) : base(Name, Source, Description, Keywords)
        {
            ImageType = "Internet.png";
            Image = new Uri("\\images\\" + ImageType, UriKind.Relative);
            this.Keywords.Add("internet");

        }
    }
    class Scams : AppEntry
    {
        public Scams(string Name, string Source, string Description, string Keywords) : base(Name, Source, Description, Keywords)
        {
            ImageType = "Scams.png";
            Image = new Uri("\\images\\" + ImageType, UriKind.Relative);
            this.Keywords.Add("scams");
        }
    }
    #endregion
    
    
}
