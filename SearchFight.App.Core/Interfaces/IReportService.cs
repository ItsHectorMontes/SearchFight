﻿using SearchFight.Application.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFight.Application.Core.Interfaces
{
    /// <summary>
    /// Report Service Interface
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// To get search and obtain fight result.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<SearchReport> ExecuteSearchFightAsync(List<string> args);
    }
}
