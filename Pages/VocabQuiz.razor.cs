using Microsoft.AspNetCore.Components;
using System.Threading.Tasks.Sources;

namespace Savoir.Pages
{
    public class VocabQuizBase : ComponentBase
    {
        public string[] vocabInfo = new string[2] { string.Empty, string.Empty };

        public string userInput = string.Empty;
        public string wordShownToUser = string.Empty;

        public void RandomVocab()
        {
            Random rnd = new Random();

            string[] possibleVocab = Array.Empty<string>();

            foreach (string record in GLOBALS.sets_vocab_data!)
            {
                string[] temp = record.Split(',');

                if (temp[0].Replace('/', ',') == GLOBALS.selectedModuleName)
                {
                    possibleVocab = temp[1].Split('+');
                }
            }

            string vocabEnglish = possibleVocab[rnd.Next(0, possibleVocab.Length)];

            string vocabFrench = string.Empty;

            foreach (string record in GLOBALS.all_vocab_data!)
            {
                string[] temp = record.Split(',');

                if (temp[0] == vocabEnglish)
                {
                    vocabFrench = temp[1];
                }
            }

            vocabInfo = new string[]{ vocabEnglish, vocabFrench };
            wordShownToUser = vocabEnglish;
        }
    }
}
