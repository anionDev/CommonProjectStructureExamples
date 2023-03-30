using CommandLine;

namespace DotNetWebAPICodeUnit.Core
{
    public class CommandlineParameter
    {
        [Option(nameof(Domain), Required = true, HelpText = "TODO")]
        public string Domain { get; set; }
        [Option(nameof(TermsOfServiceURL), Required = true, HelpText = "TODO")]
        public string TermsOfServiceURL { get; set; }
        [Option(nameof(ContactURL), Required = true, HelpText = "TODO")]
        public string ContactURL { get; set; }
        [Option(nameof(LicenseURL), Required = true, HelpText = "TODO")]
        public string LicenseURL { get; set; }
    }
}
