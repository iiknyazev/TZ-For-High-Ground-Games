using System;
using System.Collections.Generic;
namespace ServiceLibrary.ReplacementAlgorithmStrategy;

public class UnambiguousReplacement : ISequenceHandlerStrategy
{
    public Dictionary<int, string> SequenceForDivider { get; private set; }
    public UnambiguousReplacement(Dictionary<int, string> sequenceForDivider)
        => SequenceForDivider = sequenceForDivider;

    public string ReplacementAlgorithm(int number)   
    {
        string result = "";
        foreach (var div in SequenceForDivider.Keys)
        {
            result += Convert.ToInt32(number) % div == 0
                ? SequenceForDivider[div] + "-"
                : "";
        }
        result = result.Length > 0 && result[result.Length - 1] == '-'
            ? result.Substring(0, result.Length - 1)
            : number.ToString();
        return result;
    }
}
