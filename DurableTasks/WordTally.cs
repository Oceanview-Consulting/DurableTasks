using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace DurableTasks
{
    public static class WordTally
    {
        [FunctionName("WordTally")]
        public static async Task<int> Run(
            [OrchestrationTrigger] DurableOrchestrationContext context,
            TraceWriter log)
        {
            string input = context.GetInput<string>();
            IEnumerable<char> distinctChars = input.Distinct();

            IEnumerable<Task<int>> countTasks = distinctChars.Select(c => context.CallActivityAsync<int>("GetWordCount", c));

            int[] results = await Task.WhenAll(countTasks);

            return results.Sum();
        }
    }
}
