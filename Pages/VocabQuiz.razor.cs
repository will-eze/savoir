using Microsoft.AspNetCore.Components;
using savoir.globals;

namespace savoir.Pages
{
    public class VocabQuizBase : ComponentBase
    {
        public string[] moduleInfo = File.ReadAllLines(GLOBALS.directory + $@"\csv_files\{GLOBALS.selectedModuleName.ToLower()}\{GLOBALS.selectedModuleName.ToLower()}Vocab.csv");

        public string[] vocabInfo = new string[2];

        public string userInput = string.Empty;
        public string wordShownToUser = string.Empty;

        public void RandomVocab()
        {
            Random random = new Random();

            vocabInfo = moduleInfo[random.Next(0, moduleInfo.Length)].Split(',');
            wordShownToUser = vocabInfo[0];
        }
    }
}
