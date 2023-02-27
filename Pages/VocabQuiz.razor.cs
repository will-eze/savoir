using Microsoft.AspNetCore.Components;

namespace Savoir.Pages
{
    public class VocabQuizBase : ComponentBase
    {
        public string[]? moduleInfo;

        public string[] vocabInfo = new string[2];

        public string userInput = string.Empty;
        public string wordShownToUser = string.Empty;

        public void RandomVocab()
        {
            Random random = new Random();

            vocabInfo = moduleInfo![random.Next(0, moduleInfo.Length)].Split(',');
            wordShownToUser = vocabInfo[0];
        }
    }
}
