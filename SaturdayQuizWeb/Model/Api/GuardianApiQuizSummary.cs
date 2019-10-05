using System;
using System.Diagnostics.CodeAnalysis;

namespace SaturdayQuizWeb.Model.Api
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class GuardianApiQuizSummary
    {
        public string Id { get; set; }
        public DateTime WebPublicationDate { get; set; }
        public string WebTitle { get; set; }
        public string WebUrl { get; set; }
    }
}
