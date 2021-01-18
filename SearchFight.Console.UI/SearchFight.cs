using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchFight.App.Core.Interfaces;
using SearchFight.App.Core.Models;
using SearchFight.Console.UI.Helper;

namespace SearchFight.Console.UI
{
    /// <summary>
    /// Search fight process
    /// </summary>
    public class SearchFight
    {
        private readonly IReportService _reportService;
        public SearchFight(IReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Run search fight process
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            var args = Environment.CommandLine;
            args = args.Substring(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Length);
            string stringArgs;
            var listArgs = new List<string>();
            if (args.Length == 0)
            {
                System.Console.WriteLine("Enter values to search");
                stringArgs = System.Console.ReadLine();
                if (!string.IsNullOrEmpty(stringArgs))
                {
                   listArgs = ArgsHelper.ExtractArgs(stringArgs);
                }
            }
            else
            {
                stringArgs = string.Join(" ",args);
                listArgs = ArgsHelper.ExtractArgs(stringArgs);
            }

            try
            {
                var report = await _reportService.ExecuteSearchFightAsync(listArgs);
                PrintResult(report);
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            

        }

        /// <summary>
        /// Print serch fight results
        /// </summary>
        /// <param name="report"></param>
        private void PrintResult(SearchReport report)
        {
            PrintSearchResults(report.SearchResults);
            PrintWinnersBySearchengine(report.SearchWinners);
            PrintToltalWinner(report.SearchTotalWinner);
        }

        /// <summary>
        /// Print search results
        /// </summary>
        /// <param name="searchResults"></param>
        private void PrintSearchResults(List<Search> searchResults)
        {
            var resultString = searchResults.GroupBy(x => x.Term)
                .Select(y => $"{y.Key}: {string.Join(" ", y.Select(y => $"{y.SearchEngine}: {y.TotalResults}"))}");
            resultString.ToList().ForEach(x => System.Console.WriteLine(x));
        }
        /// <summary>
        /// Print winner by search engine
        /// </summary>
        /// <param name="winners"></param>
        private void PrintWinnersBySearchengine(List<Search> winners)
        {
            var resultString = winners.Select(x => $"{x.SearchEngine} winner: {x.Term}");
            resultString.ToList().ForEach(x => System.Console.WriteLine(x));
        }

        /// <summary>
        /// Print total winnner
        /// </summary>
        /// <param name="totalWinner"></param>
        private void PrintToltalWinner(string totalWinner)
        {
            System.Console.WriteLine($"Total winner: {totalWinner}");
        }
    }
}
