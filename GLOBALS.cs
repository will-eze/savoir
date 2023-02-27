using System.IO;
using System.Reflection.PortableExecutable;
using System.Data;

namespace Savoir
{
    public class GLOBALS
    {
        public static string[]? all_sets_info;
        public static string[]? sets_headers;
        public static string[]? sets_info;

        public static string[]? all_verbs_info;
        public static string[]? verbs_headers;
        public static string[]? verbs_info;

        public static List<string> TensesSelectedList = new List<string>();
        public static List<string> VerbsSelectedList = new List<string>();

        public static string selectedModuleName = string.Empty;
    }
}
