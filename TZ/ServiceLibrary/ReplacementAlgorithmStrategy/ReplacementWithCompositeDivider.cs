using System;
using System.Collections.Generic;
namespace ServiceLibrary.ReplacementAlgorithmStrategy;

public class ReplacementWithCompositeDivider : ISequenceHandlerStrategy
{
    public Dictionary<int, string> SequenceForDivider { get; private set; }
    public ReplacementWithCompositeDivider(Dictionary<int, string> sequenceForDivider)
        => SequenceForDivider = sequenceForDivider;

    private bool IsCompositeDivider(int divider)
    {
        int tmp = divider;
        foreach (var div in SequenceForDivider.Keys)
        {
            tmp = tmp % div == 0 && div != divider 
                ? tmp / div 
                : tmp;
        }
        return tmp == 1;
    }

    public string ReplacementAlgorithm(int number)
    {
        Dictionary<int, string> SequenceForCompositeDivider 
            = SequenceForDivider
                .Where(x => IsCompositeDivider(x.Key))
                .ToDictionary();

        Dictionary<int, string> SequenceForNonCompositeDivider
            = SequenceForDivider
                .Where(x => !(SequenceForCompositeDivider.ContainsKey(x.Key)))
                // Можно было по предикату фильтровать вместо проверки на наличие ключа, но так дольше
                // потому, что ContainsKey работает за O(1), а IsCompositeDivider за O(n)
                //.Where(x => !IsCompositeDivider(x.Key))
                .ToDictionary();

        string result = "";
        foreach (var div in SequenceForCompositeDivider.Keys)
        {
            if (Convert.ToInt32(number) % div == 0)
            {
                SequenceForNonCompositeDivider
                    = SequenceForNonCompositeDivider
                        .Where(x => div % x.Key != 0)
                        .ToDictionary();
                result += SequenceForCompositeDivider[div] + "-";
            }
        }

        foreach (var div in SequenceForNonCompositeDivider.Keys)
        {
            result += Convert.ToInt32(number) % div == 0
                ? SequenceForNonCompositeDivider[div] + "-"
                : "";
        }

        result = result.Length > 0 && result[result.Length - 1] == '-'
            ? result.Substring(0, result.Length - 1)
            : number.ToString();

        return result;
    }
}
