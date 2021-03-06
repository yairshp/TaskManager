using System.Data;
using TaskManager.TaskCollections;

namespace TaskManager.Views;

public class ConsoleSearchView : SearchView
{
    private static readonly string PROMPT = "Please choose a property to search by:";
    public ConsoleSearchView(MainView mainView) : base(mainView)
    {
    }

    public override void Start()
    {
        SearchersList = TaskManagerController.Instance.GetSearchers();
        string[] options = CreateOptions();
        ConsoleMenu searchMenu = new ConsoleMenu(PROMPT, options);
        int selectedIndex = searchMenu.Run();
        ApplyAction(selectedIndex, options);
    }

    private void ApplyAction(int selectedIndex, string[] options)
    {
        if (selectedIndex == options.Length - 2)
        {
            Start();
        }
        else if (selectedIndex == options.Length - 1)
        {
            MainView.ShowTasksView();
        }
        else
        {
            Console.WriteLine("Please enter a to search by:");
            string param = Console.ReadLine() ?? throw new InvalidExpressionException("Invalid value!");
            ITaskCollection results = TaskManagerController.Instance.Search(SearchersList[selectedIndex], param);
            MainView.ShowSearchResultsView(results);
        }
    }

    private string[] CreateOptions()
    {
        string[] options = new string[SearchersList.Length + 2];
        int count = 0;
        for (; count < options.Length - 2; count++)
        {
            options[count] = SearchersList[count];
        }

        options[count++] = "";
        options[count] = "Back";
        return options;
    }
}