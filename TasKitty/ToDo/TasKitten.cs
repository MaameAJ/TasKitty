using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasKitten
{
   
    class TasKitten
    {
        #region class members
        private ToDoItem myTask;
        private TimeSpan repeatInterval;

        public String Title
        {
            get { return myTask.Title; }
            set { myTask.Title = value; }
        }

        public String Description
        {
            get { return myTask.Description; }
            set { myTask.Description = value; }
        }

        public DateTime Deadline
        {
            get { return myTask.Deadline; }
            set { myTask.Deadline = value; }
        }

        public RepetitionType Repeats { get; private set; }

        public bool Completed { get; set; }

        #endregion

        #region ctors
        public TasKitten(ToDoItem myTask)
        {
            this.myTask = myTask;
            this.Repeats = RepetitionType.None;
            this.repeatInterval = Repetition.EmptyInterval;
        }

        public TasKitten(ToDoItem myTask, RepetitionType repeats): this(myTask)
        {
            if(repeats == RepetitionType.Special)
            {
                throw new ArgumentException("Need to set RepeatInterval with Special Repetition Type.");
            }
            else
            {
                this.Repeats = repeats;
                this.repeatInterval = Repetition.GetTimeSpan(repeats);
            }
        }

        public TasKitten(ToDoItem myTask, TimeSpan repeatInterval): this(myTask)
        {
            this.Repeats = Repetition.GetRepetitionType(repeatInterval);
            this.repeatInterval = repeatInterval; 
        }
        #endregion

        #region methods

        public bool isPastDeadline()
        {
            return DateTime.Compare(myTask.Deadline, DateTime.Now) > 0;
        }

        public bool isOverdue()
        {
            return !Completed && isPastDeadline();
        }

        public void Repeat()
        {
            if(this.Repeats == RepetitionType.None)
            {
                throw new NotSupportedException("This is a one-time item.");
            }

            DateTime newDeadline;

            switch(this.Repeats)
            {
                case RepetitionType.Monthly:
                    newDeadline = myTask.Deadline.AddMonths(1);
                    break;
                case RepetitionType.Bimonthly:
                    newDeadline = myTask.Deadline.AddMonths(2);
                    break;
                case RepetitionType.Yearly:
                    newDeadline = myTask.Deadline.AddYears(1);
                    break;
                default:
                    newDeadline = myTask.Deadline.Add(this.repeatInterval);
                    break;
            }

            myTask.Deadline = newDeadline;
            Completed = false;
        }

        public void ChangeRepetition(TimeSpan repeatInterval)
        {
            this.Repeats = Repetition.GetRepetitionType(repeatInterval);
            this.repeatInterval = repeatInterval; 
        }

        public void ChangeRepetition(RepetitionType repeats)
        {
            if (repeats == RepetitionType.Special)
            {
                throw new ArgumentException("Need to set RepeatInterval with Special Repetition Type.");
            }
            else
            {
                this.Repeats = repeats;
                this.repeatInterval = Repetition.GetTimeSpan(repeats);
            }
        }

        #region overridden methods
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TasKitten other = (TasKitten)obj;

            return this.myTask.Equals(other.myTask) && this.repeatInterval.Equals(other.repeatInterval) && this.Repeats == other.Repeats && this.Completed == other.Completed;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }

        #endregion

        #endregion
    }
}
