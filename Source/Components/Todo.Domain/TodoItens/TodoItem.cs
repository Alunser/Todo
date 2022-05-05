using System;
using Todo.Domain.Core.Entities;

namespace Todo.Domain.TodoItens
{
    public class TodoItem : Entity
    {
        public TodoItem(string title, string user, DateTime date)
        {
            Title = title;
            Done = false;
            Date = date;
            User = user;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }

        public void MaskAsDone() 
        {
            Done = true;
        }

        public void MaskAsUndone()
        {
            Done = false;
        }

        public void UpdateTile(string title)
        {
            Title = title;
        }
    }
}