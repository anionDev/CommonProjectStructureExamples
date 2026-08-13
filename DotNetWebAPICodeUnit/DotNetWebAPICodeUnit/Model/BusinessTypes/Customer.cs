namespace DotNetWebAPICodeUnit.Core.Model.BusinessTypes
{
    /// <summary>Example-businesstype of this codeunit. A real product has one type per business-object here.</summary>
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmailAddress { get; set; }
    }
}
