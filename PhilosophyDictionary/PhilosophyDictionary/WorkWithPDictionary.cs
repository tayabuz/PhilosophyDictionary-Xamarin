using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Philosophy
{
    public class WorkWithPDictionary
    {
        public readonly Dictionary<string, string> DictionaryPhilosophy = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private static WorkWithPDictionary instance = new WorkWithPDictionary();

        private WorkWithPDictionary()
        {
            ParseDictionaryContent();
        }
        public static WorkWithPDictionary getInstance()
        {
            if (instance == null)
                instance = new WorkWithPDictionary();
            return instance;
        }
        private string[] DictionaryContent()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(WorkWithPDictionary)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("Philosophy.DictionaryResourse.txt");
            List<string> list = new List<string>();
            using (var reader = new StreamReader (stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null) { list.Add(line); }
            }
            return list.ToArray();
        }

        private void ParseDictionaryContent()
        {
            string[] dictContent = DictionaryContent();
            string definition = "";
            string explanation = "";
            foreach (var newLine in dictContent)
            {
                if (newLine.Contains(" "))
                {
                    var firstWord = newLine.Substring(0, newLine.IndexOf(" "));
                    if (firstWord.All(char.IsUpper) && firstWord.Length > 1)
                    {
                        definition = newLine.Substring(0, newLine.IndexOf("—")).Trim();
                        explanation = newLine.Substring(newLine.IndexOf("—") + 2, newLine.Length - 1 - (newLine.IndexOf("—") + 2)).Trim();
                    }
                    else { explanation = explanation + newLine; }
                }
                else { explanation = explanation + newLine; }
                if (DictionaryPhilosophy.ContainsKey(definition)) { DictionaryPhilosophy[definition] = explanation; }
                else { DictionaryPhilosophy.Add(definition, explanation); }
            }
        }

        public IEnumerable<KeyValuePair<string, string>> FindTerm(string term)
        {
           var result = from x in DictionaryPhilosophy
                where x.Key.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0
                select x;
           return result;
        }
    }
}
