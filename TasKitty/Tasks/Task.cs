using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Task
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

        public Task(string title, string desc, DateTime due)
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
        public Task(Task toCopy):this(toCopy.title, toCopy.desc, toCopy.due) { }

        //constructor for repetitive tasks
        public Task(Task original, TimeSpan addToOrgDeadline)
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

            Task other = (Task)obj;
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
            //TODO: figure out datetime representation 
            return this.title + ": " + this.desc + Environment.NewLine /*+ "Due at: " + this.due.ToString()*/;
        }

        public Task Copy(Task toCopy)
        {
            return new Task(toCopy);
        }
	
    }
}
