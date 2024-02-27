using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceLibrary.ReplacementAlgorithmStrategy;
using ServiceLibrary;

namespace SequenceProcessing.Tests
{
    [TestFixture]
    public class ServiceLibraryTests
    {
        [Test]
        public void FizzBuzzReplacementTest()
        {
            List<int> input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            string expectedOutput = "1, 2, fizz, 4, buzz, fizz, 7, 8, fizz, buzz, 11, fizz, 13, 14, fizz-buzz";

            Service service 
                = new Service(
                    new UnambiguousReplacement(
                        new Dictionary<int, string>
                        {
                            {3, "fizz"},
                            {5, "buzz"},
                        }));

            string actualOutput = service.GetNewSequence(input);

            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void FizzBuzzMuzzGuzzReplacementTest()
        {
            List<int> input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
            string expectedOutput = "1, 2, fizz, muzz, buzz, fizz, guzz, muzz, fizz, buzz, 11, fizz-muzz, 13, guzz, fizz-buzz, fizz-buzz-muzz, fizz-buzz-guzz, fizz-buzz-muzz-guzz";

            Service service
                = new Service(
                    new UnambiguousReplacement(
                        new Dictionary<int, string>
                        {
                            {3, "fizz"},
                            {5, "buzz"},
                            {4, "muzz"},
                            {7, "guzz"},
                        }));

            string actualOutput = service.GetNewSequence(input);

            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void DogCatOrGoodBoyMuzzGuzzReplacementTest()
        {
            List<int> input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
            string expectedOutput = "1, 2, dog, muzz, cat, dog, guzz, muzz, dog, cat, 11, dog-muzz, 13, guzz, good-boy, good-boy-muzz, good-boy-guzz, good-boy-muzz-guzz";

            Service service
                = new Service(
                    new ReplacementWithCompositeDivider(
                        new Dictionary<int, string>
                        {
                            {3, "dog"},
                            {5, "cat"},
                            {15, "good-boy"},
                            {4, "muzz"},
                            {7, "guzz"},
                        }));

            string actualOutput = service.GetNewSequence(input);

            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void DogCatGoodBoyAntSpiderInsectReplacementTest()
        {
            List<int> input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 60, 84, 105, 140, 420 };
            string expectedOutput = "1, 2, dog, ant, cat, dog, spider, dog-cat-good-boy-ant, dog-ant-spider-insect, dog-cat-good-boy-spider, cat-ant-spider-insect, dog-cat-good-boy-ant-spider-insect";

            Service service
                = new Service(
                    new UnambiguousReplacement(
                        new Dictionary<int, string>
                        {
                            {3, "dog"},
                            {5, "cat"},
                            {15, "good-boy"},
                            {4, "ant"},
                            {7, "spider"},
                            {28, "insect"},
                        }));

            string actualOutput = service.GetNewSequence(input);

            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void DogCatOrGoodBoyAntSpiderOrInsectReplacementTest()
        {
            List<int> input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 60, 84, 105, 140, 420 };
            string expectedOutput = "1, 2, dog, ant, cat, dog, spider, good-boy-ant, insect-dog, good-boy-spider, insect-cat, good-boy-insect";

            Service service
                = new Service(
                    new ReplacementWithCompositeDivider(
                        new Dictionary<int, string>
                        {
                            {3, "dog"},
                            {5, "cat"},
                            {15, "good-boy"},
                            {4, "ant"},
                            {7, "spider"},
                            {28, "insect"},
                        }));

            string actualOutput = service.GetNewSequence(input);

            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }
    }
}
