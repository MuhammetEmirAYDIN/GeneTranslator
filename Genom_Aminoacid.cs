using System;
using System.Collections.Generic;
using System.Text;

class DNAtoProteinTranslator
{
   
    private static readonly Dictionary<string, string> CodonTable = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
       
        {"UUU", "Phe"}, {"UUC", "Phe"}, {"UUA", "Leu"}, {"UUG", "Leu"},
        {"CUU", "Leu"}, {"CUC", "Leu"}, {"CUA", "Leu"}, {"CUG", "Leu"},
        {"AUU", "Ile"}, {"AUC", "Ile"}, {"AUA", "Ile"}, {"AUG", "Met"}, 
        {"GUU", "Val"}, {"GUC", "Val"}, {"GUA", "Val"}, {"GUG", "Val"},

        {"UCU", "Ser"}, {"UCC", "Ser"}, {"UCA", "Ser"}, {"UCG", "Ser"},
        {"CCU", "Pro"}, {"CCC", "Pro"}, {"CCA", "Pro"}, {"CCG", "Pro"},
        {"ACU", "Thr"}, {"ACC", "Thr"}, {"ACA", "Thr"}, {"ACG", "Thr"},
        {"GCU", "Ala"}, {"GCC", "Ala"}, {"GCA", "Ala"}, {"GCG", "Ala"},

        {"UAU", "Tyr"}, {"UAC", "Tyr"}, {"UAA", "Stop"}, {"UAG", "Stop"}, 
        {"CAU", "His"}, {"CAC", "His"}, {"CAA", "Gln"}, {"CAG", "Gln"},
        {"AAU", "Asn"}, {"AAC", "Asn"}, {"AAA", "Lys"}, {"AAG", "Lys"},
        {"GAU", "Asp"}, {"GAC", "Asp"}, {"GAA", "Glu"}, {"GAG", "Glu"},

        {"UGU", "Cys"}, {"UGC", "Cys"}, {"UGA", "Stop"}, {"UGG", "Trp"},
        {"CGU", "Arg"}, {"CGC", "Arg"}, {"CGA", "Arg"}, {"CGG", "Arg"},
        {"AGU", "Ser"}, {"AGC", "Ser"}, {"AGA", "Arg"}, {"AGG", "Arg"},
        {"GGU", "Gly"}, {"GGC", "Gly"}, {"GGA", "Gly"}, {"GGG", "Gly"}
    };

    public static string Translate(string rawSequence)
    {
       
        int startIndex = rawSequence.IndexOf("AUG");
        if (startIndex == -1)
        {
            return "Error: Start codon (AUG / ATG) not found.";
        }

        List<string> aminoAcids = new List<string>();

        for (int i = startIndex; i <= rawSequence.Length - 3; i += 3)
        {
            string codon = rawSequence.Substring(i, 3);

            if (CodonTable.TryGetValue(codon, out string result))
            {
                if (result == "Stop")
                {
                    break;
                }
                aminoAcids.Add(result);
            }
            else
            {
                aminoAcids.Add("Unknown");
            }
        }

        return aminoAcids.Count > 0 ? string.Join("-", aminoAcids) : "No protein translated.";
    }

    static void Main()
    {
        string dnaSequence = "CGAUGGCCUUAGACAGCUGAACC"; 
        
        Console.WriteLine("Input Sequence: " + dnaSequence);
        Console.WriteLine("Translated Protein: " + Translate(dnaSequence));
    }
}
