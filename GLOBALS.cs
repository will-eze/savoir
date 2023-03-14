using System.IO;
using System.Reflection.PortableExecutable;
using System.Data;

namespace Savoir
{
    public class GLOBALS
    {
        public static string[]? all_verb_data_french;
        public static string[]? sets_verb_data_french;
        public static string[]? all_vocab_data_french;
        public static string[]? sets_vocab_data_french;

        public static string[]? all_verb_data_spanish;
        public static string[]? sets_verb_data_spanish;
        public static string[]? all_vocab_data_spanish;
        public static string[]? sets_vocab_data_spanish;

        public static string[]? all_verb_data;
        public static string[]? sets_verb_data;
        public static string[]? all_vocab_data;
        public static string[]? sets_vocab_data;

        public static List<string> TensesSelectedList = new List<string>();
        public static List<string> VerbsSelectedList = new List<string>();
        public static List<string> PossibleVocabList = new List<string>();

        public static string selectedModuleName = string.Empty;
    }
}
