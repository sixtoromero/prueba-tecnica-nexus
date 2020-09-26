﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LaMC.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
