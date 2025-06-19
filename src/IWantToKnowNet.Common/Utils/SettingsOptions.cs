using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantToKnowNet.Common.Utils
{
    public sealed class SettingsOptions
    {
        public const string ConfigurationSectionName = "ApplicationSettings";

        public required string FrontPublicApi { get; set; }
        public required string JWTValidAudience { get; set; }
        public required string JWTValidIssuer { get; set; }
        public required string JWTSecret { get; set; }
        public required int AmountStudentLevel_1 { get; set; }
        public required int AmountMentorLevel_1 { get; set; }

        [Required]
        public required string LocalConnectionString { get; set; }

        [Required]
        public required string AzureConnectionString { get; set; }

        [Required]
        public required string AWSConnectionString { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public required int QuantityCorrectAnswersOfQuestion { get; set; }

        [Required]
        [Range(0, 12, ErrorMessage = "Quantity hours for {0} must be between {1} and {2}.")]
        public required int ExpiresIn { get; set; }
        [Required]
        public required string FreeDays { get; set; }
        public string? SendGridKey { get; set; }

    }
}
