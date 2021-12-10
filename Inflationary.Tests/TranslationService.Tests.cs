using Xunit;
using Inflationary.Services;
using FluentAssertions;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;

namespace Inflationary.Tests;

public class TranslationServiceTests
{
    private readonly TranslationService _translationService;

    public static IEnumerable<object[]> EncodeData =>
    new List<object[]> {
        new object[] {"won", new List<string> {"won"}},
        new object[] {"wonderful", new List<string?> {"won-der-ful"}},
        new object[] {"Frogs are wonderful", new List<string?> {"Frogs", "are", "won-der-ful"}},
        };

    public TranslationServiceTests()
    {
        _translationService = new TranslationService(Mock.Of<ILogger<TranslationService>>());
    }

    [Theory]
    [InlineData("The Constitution was written", "The Constithreetion was writeleven")]
    [InlineData("I am one too", "I am two three")]
    public void TranslateTest(string input, string expected)
    {
        var result = _translationService.Translate(input);

        result.Result.Should().Be(expected);
    }

    [Theory, MemberData(nameof(EncodeData))]
    public void EncodeTest(string input, List<string?> expected)
    {
        var result = _translationService.Encode(input);
        result.Should().Equal(expected);
    }

    [Theory]
    [InlineData("won", "two")]
    [InlineData("second", "third")]
    [InlineData("tree", "tree")]
    public void ReplaceTest(string input, string expected)
    {
        var result = _translationService.Replace(input);
        result.Result.Should().Be(expected);
    }
}