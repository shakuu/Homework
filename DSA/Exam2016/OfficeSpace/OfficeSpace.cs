using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSpace
{
    public class OfficeSpace
    {
        public static void Main()
        {
            var tasksCount = int.Parse(Console.ReadLine());
            var inputTimes = Console.ReadLine().Split(' ');

            var completedTasks = new bool[tasksCount + 1];
            var tasksTimes = new int[tasksCount + 1];
            for (int i = 1; i < tasksCount + 1; i++)
            {
                tasksTimes[i] = int.Parse(inputTimes[i - 1]);
            }

            var tasksDependencies = new List<int>[tasksCount + 1];
            tasksDependencies[0] = new List<int>();
            for (int i = 1; i < tasksCount + 1; i++)
            {
                var dependencies = Console.ReadLine().Split(' ')
                    .Select(int.Parse)
                    .Where(x => x != 0)
                    .ToArray();

                tasksDependencies[i] = new List<int>();
                tasksDependencies[i].AddRange(dependencies);
            }

            var time = 0;
            while (true)
            {
                var tasksWithoutDependencies = OfficeSpace.FindTasksWithoutDependencies(tasksDependencies, completedTasks);
                if (tasksWithoutDependencies.Count == 0)
                {
                    break;
                }
                else
                {
                    var maxTime = 0;
                    foreach (var dependencyIndex in tasksWithoutDependencies)
                    {
                        completedTasks[dependencyIndex] = true;
                        var currentTime = tasksTimes[dependencyIndex];
                        if (maxTime < currentTime)
                        {
                            maxTime = currentTime;
                        }
                    }

                    time += maxTime;
                    OfficeSpace.RemoveDependencies(tasksDependencies, tasksWithoutDependencies);
                }
            }

            Console.WriteLine(time > 0 ? time : -1);
        }

        private static void RemoveDependencies(ICollection<int>[] dependencies, IEnumerable<int> dependenciesToRemove)
        {
            foreach (var item in dependencies)
            {
                foreach (var removeIndex in dependenciesToRemove)
                {
                    item.Remove(removeIndex);
                }
            }
        }

        private static ICollection<int> FindTasksWithoutDependencies(ICollection<int>[] dependencies, IList<bool> completed)
        {
            var tasksWithoutDependencies = new HashSet<int>();
            for (int i = 1; i < dependencies.Length; i++)
            {
                if (dependencies[i].Count == 0 && !completed[i])
                {
                    tasksWithoutDependencies.Add(i);
                }
            }

            return tasksWithoutDependencies;
        }
    }
}
