﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TEKUP_Trainning
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
