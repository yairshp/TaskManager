namespace TaskManager.Views;

public interface ITaskView : IView
{
    public void SetSelectedTask(Task task);
}