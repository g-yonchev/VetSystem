namespace VetSystem.Web.Areas.ClinicOwner.ViewModels
{
    using System;

    using Kendo.Mvc.UI;

    using VetSystem.Data.Models;

    public class TaskViewModel : ISchedulerEvent
    {
        private DateTime start;
        private DateTime end;

        public TaskViewModel()
        {
        }

        public TaskViewModel(Task task)
        {
                this.Id = task.Id;
                this.Title = task.Title;
                this.Start = DateTime.SpecifyKind(task.Start, DateTimeKind.Utc);
                this.End = DateTime.SpecifyKind(task.End, DateTimeKind.Utc);
                this.StartTimezone = task.StartTimezone;
                this.EndTimezone = task.EndTimezone;
                this.Description = task.Description;
                this.IsAllDay = task.IsAllDay;
                this.RecurrenceRule = task.Recurrence2;
                this.RecurrenceException = task.RecurrenceException;
                this.RecurrenceID = task.Recurrence1;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Start
        {
            get
            {
                return this.start;
            }

            set
            {
                this.start = value.ToUniversalTime();
            }
        }

        public DateTime End
        {
            get
            {
                return this.end;
            }

            set
            {
                this.end = value.ToUniversalTime();
            }
        }

        public string StartTimezone { get; set; }

        public string EndTimezone { get; set; }

        public string RecurrenceRule { get; set; }

        public string RecurrenceID { get; set; }

        public string RecurrenceException { get; set; }

        public bool IsAllDay { get; set; }

        public Task ToEntity()
        {
            return new Task
            {
                Id = this.Id,
                Title = this.Title,
                Start = this.Start,
                End = this.End,
                StartTimezone = this.StartTimezone,
                EndTimezone = this.EndTimezone,
                Description = this.Description,
                IsAllDay = this.IsAllDay,
                Recurrence2 = this.RecurrenceRule,
                RecurrenceException = this.RecurrenceException,
                Recurrence1 = this.RecurrenceID
            };
        }
    }
}
