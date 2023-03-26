using Microsoft.AspNetCore.Components;
using Savoir;

namespace Savoir.Pages
{
    public class VerbQuizBase : ComponentBase
    {
        // {french_infinitive, english_translation, tense}
        public string[] verbinfo = new string[3];

        // list of correct conjugations for currently selected verb
        public string[] conjugations = new string[6] { "", "", "", "", "", "" };

        // list of user conjugations for currently selected verb
        public string[] userVerbs = new string[6] { "", "", "", "", "", "" };

        public void RandomVerb()
        {
            Random rnd = new Random();

            // 1 -- GENERATE RANDOM VERB
            string verb = GLOBALS.VerbsSelectedList[rnd.Next(GLOBALS.VerbsSelectedList.Count)];

            // 2 -- FIND VERB INDEX in small_conjugations.csv
            string[] verbRecord = GLOBALS.all_verb_data![GLOBALS.allUnfilteredVerbs.FindIndex(x => x == verb)].Split(',');

            // 3 -- FIND ALL CONJUGATIONS FOR THE VERB IN THE SELECTED / POSSIBLE TENSES

            Dictionary<string, string[]> allConjugations = new Dictionary<string, string[]>();

            foreach (string _tense in GLOBALS.TensesSelectedList)
            {
                string[] tenseConjugations = new string[6] { "", "", "", "", "", "" };

                for (int i = 0; i <= 5; i++)
                {
                    tenseConjugations[i] = verbRecord[GLOBALS.allTensesIndices[_tense] + i];
                }

                // only add a tense if it has atleast 1 subject's conjugation available
                if (conjugations.All(x => x != "N/A"))
                {
                    allConjugations.Add(_tense, tenseConjugations);
                }

            }

            // 4 -- GENERATE RANDOM TENSE AND FIND ITS' CONJUGATIONS 

            string tense = allConjugations.ElementAt(rnd.Next(0, allConjugations.Count)).Key;
            string[] _conjugations = allConjugations[tense];

            // 5 -- UPDATE FIELDS "verbinfo" AND "conjugations"

            verbinfo = new string[3] { verbRecord[0], verbRecord[1], tense };
            conjugations = _conjugations;
        }
    }
}
