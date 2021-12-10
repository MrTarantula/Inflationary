using Microsoft.PhoneticMatching.Matchers.FuzzyMatcher.Normalized;
using NHyphenator;
using NHyphenator.Loaders;

namespace Inflationary.Services;
public class TranslationService
{
    private readonly ILogger<TranslationService> _logger;

    private static List<string> numbers =
        new List<string>() {
                "zero",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine",
                "ten",
                "eleven",
                "twelve",
                "thirteen",
                "fourteen",
                "fifteen"
        };

    private static List<string> places =
        new List<string>() {
                "first",
                "second",
                "third",
                "fourth",
                "fifth",
                "sixth",
                "seventh",
                "eighth",
                "ninth",
                "tenth",
                "eleventh",
                "twelfth",
                "thirteenth",
                "fourteenth",
                "fifteenth"
        };

    public TranslationService(ILogger<TranslationService> logger)
    {
        _logger = logger;
    }

    public Translation Translate(string input)
    {
        var newSentence = new List<Translation>();

        //Split sentence into syllables
        var sentence = Encode(input);

        // Analyze and replace syllable if needed
        foreach (var word in sentence)
        {
            newSentence.Add(Replace(word));
        }

        return new Translation(
            string.Join(' ', newSentence.Select(w => w.Result)),
            newSentence.Sum(w => w.Count));
    }

    public List<string> Encode(string input)
    {
        var hyphenated = new List<string>();

        var hyphenator = new Hyphenator(new FilePatternsLoader("hyph-en-us.pat.txt", "hyph-en-us.hyp.txt"), "-");
        var words = input.Split(' ').ToList();

        foreach (var word in words)
        {
            hyphenated.Add(hyphenator.HyphenateText(word));
        }

        return hyphenated;
    }

    public Translation Replace(string word)
    {
        var numberMatcher = new EnPhoneticFuzzyMatcher<string>(numbers);
        var placeMatcher = new EnPhoneticFuzzyMatcher<string>(places);

        var newWord = new Translation();

        var syllables = word.Split('-');

        foreach (var syl in syllables)
        {
            var numberResult = numberMatcher.FindNearest(syl);
            var placeResult = placeMatcher.FindNearest(syl);

            try
            {
                if (numberResult.Distance <= 0.02)
                {
                    newWord += new Translation(numbers[numbers.IndexOf(numberResult.Element) + 1], 1);
                }
                else if (placeResult.Distance <= 0.02)
                {
                    newWord += new Translation(places[places.IndexOf(placeResult.Element) + 1], 1);
                }
                else
                {
                    newWord += new Translation(syl, 0);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                _logger.LogWarning($"Number not implemented. Keep it below 15. {e.Message}");
            }
        }

        return newWord;
    }
}

public class Translation
{
    public int Count { get; set; }
    public string Result { get; set; }

    public Translation() { }

    public Translation(string result, int count)
    {
        Result = result;
        Count = count;
    }

    public static Translation operator +(Translation a, Translation b) => new Translation($"{a.Result}{b.Result}", a.Count + b.Count);
}