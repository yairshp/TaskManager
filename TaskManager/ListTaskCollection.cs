using System.Collections;

namespace TaskManager;

public class ListTaskCollection : ITaskCollection
{
    public int Count
    {
        get => _taskList.Count;
    }
    public bool IsReadOnly { get; }

    private List<Task> _taskList;

    public ListTaskCollection()
    {
        _taskList = new List<Task>();
        IsReadOnly = false;
    }

    public ListTaskCollection(List<Task> taskList)
    {
        _taskList = new List<Task>();
        foreach (Task task in taskList)
        {
            _taskList.Add(task);
        }
        IsReadOnly = false;
    }

    public IEnumerator<Task> GetEnumerator()
    {
        return this._taskList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(Task item)
    {
        this._taskList.Add(item);
    }

    public void Clear()
    {
        this._taskList.Clear();
    }

    public bool Contains(Task item)
    {
        return this._taskList.Contains(item);
    }

    public void CopyTo(Task[] array, int arrayIndex)
    {
        this._taskList.CopyTo(array, arrayIndex);
    }

    public bool Remove(Task item)
    {
        return this._taskList.Remove(item);
    }
    
    // public ITaskCollection Sort(IComparable property)
    // {
    //     throw new NotImplementedException();
    // }
}