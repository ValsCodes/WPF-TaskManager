﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Service
{
    public interface ITaskCreator
    {
        Task CreateTask(Models.Task task);
    }
}
