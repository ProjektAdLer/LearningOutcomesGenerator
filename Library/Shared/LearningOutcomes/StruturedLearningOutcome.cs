using System.Globalization;
using System.Text;
using LearningOutcomesGenerator.Shared.LearningOutcomes;

namespace Library.Shared.LearningOutcomes;

public class StructuredLearningOutcome
{
    public StructuredLearningOutcome(TaxonomyLevel taxonomyLevel, string what, string whereby, string whatFor,
        string verbOfVisibility,
        CultureInfo language)
    {
        TaxonomyLevel = taxonomyLevel;
        What = what;
        Whereby = whereby;
        WhatFor = whatFor;
        VerbOfVisibility = verbOfVisibility;
        Language = language;
        Id = Guid.NewGuid();
    }

    public TaxonomyLevel TaxonomyLevel { get; set; }
    public string What { get; set; }
    public string Whereby { get; set; }
    public string WhatFor { get; set; }
    public string VerbOfVisibility { get; set; }
    public CultureInfo Language { get; set; }

    public Guid Id { get; set; }

    public string GetOutcome()
    {
        switch (Language)
        {
            case { Name: "de-DE" }:
                return GetOutcomeDe();
            case { Name: "en-DE" }:
                return GetOutcomeEn();
            default:
                throw new NotSupportedException("Language not supported");
        }
    }

    private string GetOutcomeEn()
    {
        var sb = new StringBuilder("You will be able to ");
        sb.Append(VerbOfVisibility).Append(" ").Append(What);

        if (!IsNullOrEmpty(Whereby))
        {
            sb.Append(" \n by ").Append(Whereby);
        }

        if (!IsNullOrEmpty(WhatFor))
        {
            sb.Append(" \n to ").Append(WhatFor);
        }

        sb.Append(".");

        return sb.ToString();
    }

    private string GetOutcomeDe()
    {
        var sb = new StringBuilder("Sie können ");
        sb.Append(What).Append(" ").Append(VerbOfVisibility);

        if (!IsNullOrEmpty(Whereby))
        {
            sb.Append(", \n indem Sie ").Append(Whereby);
        }

        if (!IsNullOrEmpty(WhatFor))
        {
            sb.Append(",\n um ").Append(WhatFor);
        }

        sb.Append(".");

        return sb.ToString();
    }

    private static bool IsNullOrEmpty(string value) =>
        string.IsNullOrWhiteSpace(value);
}