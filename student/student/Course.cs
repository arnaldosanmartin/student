using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace student
{
    public class Course : INotifyPropertyChanged
    {
        private String name;
        private String id;

        public Course(String Name, String Id)
        {
            name = Name;
            id = Id;
        }

        public String Name
        {
            set
            {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
            get
            {
                return name;
            }
        }

        public String Id
        {
            set
            {
                if (id != value)
                {
                    id = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
                }
            }
            get
            {
                return id;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
