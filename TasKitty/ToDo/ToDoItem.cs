using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TasKitten
{
    public class ToDoItem
    {
        private string title;
        private string desc;
        private DateTime due;

	    public String Title
	    {
		    get { return title;}
		    set { title = value;}
	    }

        public String Description
        {
            get { return desc; }
            set { desc = value; }
        }

        public DateTime Deadline
        {
            get { return due; }
            set { due = value; }
        }

        public ToDoItem(string title, string desc, DateTime due)
        {
            if(title == String.Empty && desc == String.Empty)
            {
                throw new ArgumentException("Either title or desc must be provided.");
            }
            else if(due == null)
            {
                throw new ArgumentNullException("due cannot be null");
            }
            else
            {
                this.title = title;
                this.desc = desc;
                this.due = due;
            }
        }

        //copy constructor
        public ToDoItem(ToDoItem toCopy):this(toCopy.title, toCopy.desc, toCopy.due) { }

        //constructor for repetitive tasks
        public ToDoItem(ToDoItem original, TimeSpan addToOrgDeadline)
            : this(original)
        {
            this.due.Add(addToOrgDeadline);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ToDoItem other = (ToDoItem)obj;
            return (String.Equals(this.title, other.title) && String.Equals(this.desc, other.desc) && DateTime.Equals(this.due, other.due));
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }

        public override string ToString()
        {
            // TODO: figure out datetime representation 
            return this.title + ": " + this.desc + Environment.NewLine /*+ "Due at: " + this.due.ToString()*/;
        }

        public ToDoItem Copy(ToDoItem toCopy)
        {
            return new ToDoItem(toCopy);
        }
	
    }
}
