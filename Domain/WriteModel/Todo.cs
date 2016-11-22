using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WriteModel
{
    public enum TodoState
    {
        IN_PROGRESS,
        DONE
    }

    public class Todo : AgregateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public TodoState State { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Todo() { }

        public Todo(Guid id, string title="")
        {
            UUID = id;
            Title = title;
            State = TodoState.IN_PROGRESS;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 0;
        }

        internal void ChangeTitle(string title)
        {
            Title = title;
            UpdatedAt = DateTime.UtcNow;
            UpdateVersion();
        }

        public void ChangeDescription(string desctiption)
        {
            Description = desctiption;
            UpdatedAt = DateTime.UtcNow;
            UpdateVersion();
        }

        public void Close()
        {
            State = TodoState.DONE;
            UpdatedAt = DateTime.UtcNow;
            UpdateVersion();
        }
    }
}
