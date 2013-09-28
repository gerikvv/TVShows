using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using TVShows.Data;

namespace TVShows
{
    public class TVShowManipulatorViewModel : NotificationObject
    {
        #region Properties

        Class_tvshow tv = new Class_tvshow();

        public Class_tvshow TV
        {
            get { return tv; }
            set { tv = value; }
        }

        public int Id
        {
            get { return TV.Id; }
            set
            {
                TV.Id = value;
                RaisePropertyChanged("Id");
            }
        }
        
        public string Name
        {
            get { return TV.Name; }
            set
            {
                TV.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public int Year
        {
            get { return TV.Year; }
            set
            {
                TV.Year = value;
                RaisePropertyChanged("Year");
            }
        }

        public string Country
        {
            get { return TV.Country; }
            set
            {
                TV.Country = value;
                RaisePropertyChanged("Country");
            }
        }

        public string Slogan
        {
            get { return TV.Slogan; }
            set
            {
                TV.Slogan = value;
                RaisePropertyChanged("Slogan");
            }
        }

        public string Director
        {
            get { return TV.Director; }
            set
            {
                TV.Director = value;
                RaisePropertyChanged("Director");
            }
        }

        public string Script_writer
        {
            get { return TV.Script_writer; }
            set
            {
                TV.Script_writer = value;
                RaisePropertyChanged("Script_writer");
            }
        }

        public string Producer
        {
            get { return TV.Producer; }
            set
            {
                TV.Producer = value;
                RaisePropertyChanged("Producer");
            }
        }

        public int Budget
        {
            get { return TV.Budget; }
            set
            {
                TV.Budget = value;
                RaisePropertyChanged("Budget");
            }
        }

        public int Global_charges
        {
            get { return TV.Global_charges; }
            set
            {
                TV.Global_charges = value;
                RaisePropertyChanged("Global_charges");
            }
        }

        public TimeSpan Time
        {
            get { return new TimeSpan(TV.Time.Hour, TV.Time.Minute, 0); }
            set
            {
                TV.Time = new DateTime(1, 1, 1, value.Hours, value.Minutes, 0);
                RaisePropertyChanged("Time");
            }
        }

        public Double Overall_rating
        {
            get { return TV.Overall_rating; }
            set
            {
                TV.Overall_rating = value;
                RaisePropertyChanged("Overall_rating");
            }
        }

        public string Name_image
        {
            get { return TV.Name_image; }
            set
            {
                TV.Name_image = value;
                RaisePropertyChanged("Name_image");
                AddImageContent = value;
            }
        }

        public string SaveButtonContent
        {
            get;
            set;
        }

        private string addImageContent;
        public string AddImageContent
        {
            get { return addImageContent; }
            set
            {
                addImageContent = value;
                RaisePropertyChanged("AddImageContent");
            }
        }

        public string FileName { get; set; }

        #endregion

        #region Constructor & Methods

        public TVShowManipulatorViewModel(DataRowView employee)
        {
            CloneCustomers(employee);
        }

        public TVShowManipulatorViewModel(DataRowView employee, bool is_in_edit)
        {
            SaveCommand = new DelegateCommand<Class_tvshow>(Save);
            AddImageCommand = new DelegateCommand<Class_tvshow>(AddImage);
            SaveButtonContent = is_in_edit ? "Save" : "Add";
            if (is_in_edit)
                CloneCustomers(employee);
            AddImageContent = is_in_edit ? Name_image : "Выберите постер...";
        }

        private void CloneCustomers(DataRowView employee)
        {
            Id = Int32.Parse(employee["Id"].ToString());
            Name = employee["Name"].ToString();
            Year = Int32.Parse(employee["Year"].ToString());
            Country = employee["Country"].ToString();
            Slogan = employee["Slogan"].ToString();
            Director = employee["Director"].ToString();
            Script_writer = employee["Script_writer"].ToString();
            Producer = employee["Producer"].ToString();
            Budget = Int32.Parse(employee["Budget"].ToString());
            Global_charges = Int32.Parse(employee["Global_charges"].ToString());
            var time =  DateTime.Parse(employee["Time"].ToString());
            Time = new TimeSpan(time.Hour, time.Minute, 0);
            Overall_rating = Double.Parse(employee["Overall_rating"].ToString());
            Name_image = employee["Name_image"].ToString();
        }

        #endregion

        #region Save Command

        public DelegateCommand<Class_tvshow> SaveCommand
        {
            get;
            set;
        }

        private void Save(object obj)
        {
            if (FileName != null)
            {
                var bmp = new Bitmap(FileName);
                Image image = bmp;
                var size = new Size {Width = 120, Height = 160};

                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"..\Images\" + Name_image))
                    bmp.Save(AppDomain.CurrentDomain.BaseDirectory + @"..\Images\" + Name_image,
                             System.Drawing.Imaging.ImageFormat.Jpeg);

                bmp = new Bitmap(image, size);
                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"..\MiniImages\" + Name_image))
                    bmp.Save(AppDomain.CurrentDomain.BaseDirectory + @"..\MiniImages\" + Name_image,
                             System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public DelegateCommand<Class_tvshow> AddImageCommand
        {
            get; 
            set;
        }

        private void AddImage(object arg)
        {
            var openFile = new OpenFileDialog();
            openFile.Title = "Выберите постер фильма";
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.Multiselect = false;

            openFile.Filter = "Файлы изображений|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFile.FilterIndex = 0;

            if (openFile.ShowDialog() == true)
            {
                Name_image = openFile.SafeFileName;
                FileName = openFile.FileName;
            }
        }

        #endregion
    }
}
