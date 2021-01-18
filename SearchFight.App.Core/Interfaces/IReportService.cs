using SearchFight.App.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.App.Core.Interfaces
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
