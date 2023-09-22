﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
        int Commit();
    }
}
