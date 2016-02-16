﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using VetSystem.Data.Models;

namespace VetSystem.Web.Areas.ClinicOwner.Controllers
{
    public class TaskViewModel: ISchedulerEvent
    {
        public TaskViewModel()
        {
        }

        public TaskViewModel(Task task)
        {
                Id = task.Id;
                Title = task.Title;
                Start = DateTime.SpecifyKind(task.Start, DateTimeKind.Utc);
                End = DateTime.SpecifyKind(task.End, DateTimeKind.Utc);
                StartTimezone = task.StartTimezone;
                EndTimezone = task.EndTimezone;
                Description = task.Description;
                IsAllDay = task.IsAllDay;
                RecurrenceRule = task.Recurrence2;
                RecurrenceException = task.RecurrenceException;
                RecurrenceID = task.Recurrence1;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        private DateTime start;
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value.ToUniversalTime();
            }
        }

        private DateTime end;
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value.ToUniversalTime();
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
                Id = Id,
                Title = Title,
                Start = Start,
                End = End,
                StartTimezone = StartTimezone,
                EndTimezone = EndTimezone,
                Description = Description,
                IsAllDay = IsAllDay,
                Recurrence2 = RecurrenceRule,
                RecurrenceException = RecurrenceException,
                Recurrence1 = RecurrenceID
            };
        }
    }
}
