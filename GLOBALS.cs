﻿using System.IO;
using System.Reflection.PortableExecutable;
using System.Data;

namespace Savoir
{
    public class GLOBALS
    {
        public static string[] allLanguages = new string[2] { "fr", "sp" };
        public static Dictionary<string, string[][]> languageData = new Dictionary<string, string[][]>();
        public static Dictionary<string, string> languageHeaders = new Dictionary<string, string>();

        public static Dictionary<string, string[]> languageDefaultTenses = new Dictionary<string, string[]>
        {
            { "fr", new[] { "present", "past perfect", "imperfect", "simple future", "conditional" } },
            { "sp", new[] { "present", "future", "imperfect", "preterite", "conditional", } }
        };

        public static string[]? all_verb_data;
        public static string[]? sets_verb_data;
        public static string[]? all_vocab_data;
        public static string[]? sets_vocab_data;

        public static string[]? setNames = Array.Empty<string>();
        public static Dictionary<string, List<string>>? setNamesDict = new Dictionary<string, List<string>>();

        public static List<string> setNamesVerb = new List<string>();
        public static List<string> setNamesVocab = new List<string>();

        public static int numberOfSets;

        public static Dictionary<string, int> allTensesIndices = new Dictionary<string, int>();

        public static List<string> TensesSelectedList = new List<string>();
        public static List<string> VerbsSelectedList = new List<string>();
        public static List<string> PossibleVocabList = new List<string>();

        public static bool[]? TensesChecked;

        public static string selectedModuleName = string.Empty;
            
        private static string _activeLanguage = string.Empty;
        public static string ActiveLanguage
        {
            get { return _activeLanguage; }
            set
            {
                if (value.ToLower() == "fr" || value.ToLower() == "sp")
                {
                    _activeLanguage = value;
                    UpdateData();
                    UpdateSetsData();
                    UpdateTenses();
                }
            }
        }

        private static void UpdateData()
        {
            all_verb_data = languageData[_activeLanguage][0];
            all_vocab_data = languageData[_activeLanguage][1];
            sets_verb_data = languageData[_activeLanguage][2];
            sets_vocab_data = languageData[_activeLanguage][3];
        }

        private static void UpdateSetsData()
        {
            setNamesDict!.Clear();
            setNamesVerb.Clear();
            setNamesVocab.Clear();
            setNames = Array.Empty<string>();
            numberOfSets = -1;

            string[] allSetsData = sets_verb_data!.Concat(sets_vocab_data!).ToArray();

            for (int i = 0; i < allSetsData.Length; i++)
            {
                string[] record = allSetsData[i].Split(',');

                string recordSetName = record[0].Replace("/", ",");
                string recordHeader = record[1];

                // if the setNamesDict already contains the header, then just add the set name to the right list
                if (setNamesDict!.ContainsKey(recordHeader)) 
                {
                    if (!setNamesDict.Values.Any(arr => arr.Any(setName => setName == recordSetName)))
                    {
                        setNamesDict[recordHeader].Add(recordSetName);
                    }
                    
                }
                // else if the header isnt yet a part of setNamesDict, then make a new entry for it
                else { setNamesDict.Add(recordHeader, new List<string> { recordSetName }); }

                // if the current record is a member of sets_verb_data :
                if (i < sets_verb_data!.Length) { setNamesVerb.Add(recordSetName); }
                // else if the current record is a member of sets_vocab_data :
                else { setNamesVocab.Add(recordSetName); }
            }

            // update the number of sets by looking at how many distinct sets there are
            setNames = setNamesVerb.Concat(setNamesVocab).Distinct().ToArray();
            numberOfSets = setNames.Length;
        }

        private static void UpdateTenses()
        {
            allTensesIndices.Clear();

            string[] headers = languageHeaders[ActiveLanguage].Split(',');

            for (int i = 0; i < headers.Length; i++)
            {
                string element = headers[i];

                // only the actual tense headers contain a dash, english and infinitive do not. so this if statement only runs if the element is a tense
                if (element.Contains("-"))
                {
                    string tense = element.Remove(element.Length - 5);
                    if (!allTensesIndices.ContainsKey(tense))
                    {
                        allTensesIndices[tense] = i;
                    }
                }
            }

            TensesChecked = Enumerable.Repeat(false, allTensesIndices.Keys.Count).ToArray();
            for (int i = 0; i < allTensesIndices.Keys.Count; i++)
            {
                if (languageDefaultTenses[ActiveLanguage].Contains(allTensesIndices.Keys.ToArray()[i])) 
                {
                    TensesChecked[i] = true;
                }
            }
        }
    }
}
