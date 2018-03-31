using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP202Project
{
    class Entry
    {
        private string name;
        private string source;
        private Uri image;
        private string description;
        private string[] keywords;
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
        public string[] Keywords
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

        public Entry(string Name, string Source, string Description)
        {
            this.Name = Name;
            this.Source = Source;
            this.Description = Description;
            //this.Keywords = keywords;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        static public string GetImageDirectory()
        {
            string imageDirectory = "";
            string currentDir = Directory.GetCurrentDirectory();
            DirectoryInfo parent = Directory.GetParent(currentDir);
            DirectoryInfo grandParent = Directory.GetParent(parent.FullName);



            imageDirectory = grandParent + "\\Images\\";



            return imageDirectory;
        }
    }

    #region Category Constructors
    class Networking : Entry
    {
        public Networking(string Name, string Source, string Description) : base(Name, Source, Description)
        {
           ImageType  = "Networking.png";
           Image = new Uri(GetImageDirectory() + ImageType, UriKind.Absolute);
        }
    }

    class Database : Entry
    {
        public Database(string Name, string Source, string Description, string[] Keywords) : base(Name, Source, Description)
        {
            ImageType = "Database.png";
            Image = new Uri(GetImageDirectory() + ImageType, UriKind.Absolute);
        }
    }
    class Internet : Entry
    {
        public Internet(string Name, string Source, string Description, string[] Keywords) : base(Name, Source, Description)
        {
            ImageType = "Internet.png";
            Image = new Uri(GetImageDirectory() + ImageType, UriKind.Absolute);
        }
    }
    class Scams : Entry
    {
        public Scams(string Name, string Source, string Description, string[] Keywords) : base(Name, Source, Description)
        {
            ImageType = "Scams.png";
            Image = new Uri(GetImageDirectory() + ImageType, UriKind.Absolute);
        }
    }
    #endregion
    
}
