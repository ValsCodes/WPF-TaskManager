using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Service.TaskConflictValidators
{
    public interface ITaskConflictValidator
    {
        Task<Models.Task> GetConflictingTask(Models.Task task);
    }
}
