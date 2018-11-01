using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace DurableTasks
{
    public static class GetWordCount
    {
        [FunctionName("GetWordCount")]
        public static async Task<int> Run(
            [ActivityTrigger()]
            char firstChar,
            TraceWriter log)
        {
            var repo = new InMemoryWordRepository();

            await Task.Delay(5000);
            var words = await repo.GetWordsByFirstLetter(firstChar);

            return words.Count();
        }
    }
}
