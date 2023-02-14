using Microsoft.AspNetCore.Components;
using savoir.Data;

namespace savoir.Pages
{
    public class VerbQuizBase : ComponentBase
    {

        // index 0 = french infinitive
        // index 1 = english translation
        // index 2 = tense
        public string[] verbinfo = new string[3];

        // list of correct conjugations for current verb
        public string[] conjugations = Array.Empty<string>();

        public string[] userVerbs = new string[6] {"", "", "", "", "", ""};

        public void RandomVerb()
        {
            Random random = new Random();

            // list of all possible verbs / tenses from the set and selected tenses
            string[] verbs = GLOBALS.VerbsSelectedList.ToArray();
            string[] tenses = GLOBALS.TensesSelectedList.ToArray();

            // generate a random verb and tense from the lists
            string verb = verbs[random.Next(0, verbs.Length)];
            string tense = tenses[random.Next(0, tenses.Length)];

            // stores the record for the randomly selected verb as an array
            string[] verb_info = new string[] { };

            foreach (string record in GLOBALS.verbs_info)
            {
                if (record.StartsWith(verb))
                {
                    verb_info = record.Split(",");
                }
            }

            string english_translation = verb_info[1];

            // locate the indexes of the randomly chosen tense's conjugations in 700_conjugations.csv

            List<int> tenses_indexesList = new List<int>();
            int i = 0;
            foreach (string temp in GLOBALS.verbs_headers)
            {
                if (temp.StartsWith(tense))
                {
                    tenses_indexesList.Add(i);
                }
                i++;
            }

            int[] tenses_indexes = tenses_indexesList.ToArray();

            // find the conjugations using the indexes found in tenses_indexes

            List<string> conjugationsList = new List<string>();
            List<string> verbinfoList = new List<string>();

            foreach (int j in tenses_indexes)
            {
                conjugationsList.Add(verb_info[j]);
            }

            verbinfoList.Add(verb);
            verbinfoList.Add(english_translation);
            verbinfoList.Add(tense);

            verbinfo = verbinfoList.ToArray();
            conjugations = conjugationsList.ToArray();
        }
    }
}
