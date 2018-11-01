using System.Collections.Generic;
using System.Threading.Tasks;

namespace DurableTasks
{
    public interface IWordRepository
    {
        Task<IEnumerable<string>> GetWordsByFirstLetter(char firstLetter);
    }
}