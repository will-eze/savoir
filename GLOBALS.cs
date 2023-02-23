using System;


namespace savoir.globals
{
    public class GLOBALS
    {
        public static string directory = Directory.GetCurrentDirectory();

        public static string[] all_sets_info = File.ReadAllLines(directory + @"\csv_files\The Big 3\sets.csv");
        public static string[] sets_headers = all_sets_info[0].Split(',');
        public static string[] sets_info = all_sets_info[1..];

        public static string[] all_verbs_info = File.ReadAllLines(directory + @"\csv_files\The Big 3\small_conjugations.csv");
        public static string[] verbs_headers = all_verbs_info[0].Split(',');
        public static string[] verbs_info = all_verbs_info[1..];

        public static List<string> TensesSelectedList = new List<string>();
        public static List<string> VerbsSelectedList = new List<string>();

        public static string selectedModuleName = string.Empty;
    }
}
