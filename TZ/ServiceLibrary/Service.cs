using System;
using System.Collections.Generic;
using ServiceLibrary.ReplacementAlgorithmStrategy;

namespace ServiceLibrary;

public class Service
{
    public ISequenceHandlerStrategy Algorithm { get; private set; }

    public Service(ISequenceHandlerStrategy algorithm)
        => Algorithm = algorithm;

    private string ReplaceNumberToSequence(int number) => Algorithm.ReplacementAlgorithm(number);

    public string GetNewSequence(List<int> numbers)
        => string.Join(", ", numbers.Select(x => ReplaceNumberToSequence(x)));
}