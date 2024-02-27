using System;
using System.Collections.Generic;
namespace ServiceLibrary.ReplacementAlgorithmStrategy;

public interface ISequenceHandlerStrategy
{
    public Dictionary<int, string> SequenceForDivider { get; }
    public string ReplacementAlgorithm(int number);
}