using TaskManagement.Domain.Core;
using TaskManagement.Domain.Validations;

namespace TaskManagement.Domain.Entities
{
    public class PersonalTask : EntityRoot
    {
        public PersonalTask(string title, string description, DateTime startDay, State state, DateTime? endDay = null)
        {
            Title = title;
            Description = description;
            StartDay = startDay;
            State = state;
            EndDay = endDay;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDay { get; private set; }
        public DateTime? EndDay { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public State State { get; private set; }

        public void SetTitle(string title) => this.Title = title;
        public void SetDescription(string description) => this.Description = description;
        public void SetStartDay(DateTime startDay) => this.StartDay = startDay;
        public void SetEndDay(DateTime? endDay) => this.EndDay = endDay;
        public void SetUpdateDate(DateTime? updateDate) => this.UpdateDate = updateDate;
        public void SetState(State state) => this.State = state;

        public override void Validate()
        {
            this.Title.NotNull("The field model is required.");
            this.Description.NotNull("The field Plate is required.");
            this.StartDay.NotNull("The field Plate is required.");
        }
    }
}

public enum State
{
    Todo = 1,
    InProgress = 2,
    Done = 3
}