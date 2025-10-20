using System.Text.Json;
using src.Models;

namespace src.Services
{
    public class TaskService
    {
        private readonly string _tasksPath = "src/Data/tasks.json";

        private readonly List<TaskItem> _tasksCollection; // In-memory collection of all TaskItem objects.

        public TaskService()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_tasksPath)!);

            if (!File.Exists(_tasksPath) || new FileInfo(_tasksPath).Length == 0)
            {
                File.WriteAllText(_tasksPath, "[]");
            }

            var json = File.ReadAllText(_tasksPath);
            _tasksCollection = JsonSerializer.Deserialize<List<TaskItem>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
        }

        public List<TaskItem> GetAllTasks()
        {
            return _tasksCollection;
        }

        public TaskItem? GetTaskById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            return _tasksCollection.FirstOrDefault(t => t.Id == id);
        }

        public TaskItem CreateTask(string title)
        {
            // Validate & normalize inputs (business rules)
            var t = (title ?? string.Empty).Trim();
            if (t.Length == 0) throw new ArgumentException("Title empty");

            // Decide (apply domain rules; compute new state)
            var newTask = new TaskItem
            {
                Id = Guid.NewGuid().ToString()[..8],
                Title = t,
                IsCompleted = false
            };

            // Persist (save changes if any)
            _tasksCollection.Add(newTask);
            Save();

            // Return a domain result (entity/collection/boolean/Result)
            return newTask;
        }


        // ToggleComplete
        // TODO
        // Method that returns a TaskItem and accepts string id
        // (Method should toggle a TaskItem's completed status)
        // Validate: Find given task by ID / validate TaskItem exisits
        // Decide: Toggle TaskItems's completed status
        // Persist (save changes)
        // Return updated TaskItem

        // DeleteTaskById
        // TODO:
        // Build a method to delete one TaskItem
        // HINTS: 
        // Return a bool to validate TaskItem was deleted
        // Find and remove a TaskItem at it's index in _tasksCollection
        // Persist changes
        // Return if successful

        // Helper Method
        // This method helps simulate “saving to a database”
        private void Save()
        {
            File.WriteAllText(_tasksPath,
                JsonSerializer.Serialize(_tasksCollection,
                    new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}