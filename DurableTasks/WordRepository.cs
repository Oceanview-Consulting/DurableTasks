using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurableTasks
{
    public class InMemoryWordRepository : IWordRepository
    {
        private List<string> _words = new List<string>();

        public InMemoryWordRepository()
        {
            CreateWords();
        }

        public Task<IEnumerable<string>> GetWordsByFirstLetter(char firstLetter)
        {
            var s = new string(firstLetter, 1);
            var result = _words.Where(word => word.StartsWith(s, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(result);
        }

        private void CreateWords()
        {
            // T: Four Words
            _words.Add("Test");
            _words.Add("Telephone");
            _words.Add("Telegram");
            _words.Add("Teacher");

            // R: Three Words
            _words.Add("radio");
            _words.Add("right");
            _words.Add("rain");

            // A: One Word
            _words.Add("Alphabet");

            // V: Two Words
            _words.Add("very");
            _words.Add("victory");

            // I: One Word
            _words.Add("instinct");

            // S: Two words
            _words.Add("suede");
            _words.Add("soup");
        }
    }
}
