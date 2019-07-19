using static Suckless.Asserts.Assertions;

namespace Aveneo.SearchEngine.Domain.Statistics
{
    internal class HttpHeader
    {
        public HttpHeader(string name, string value)
        {
            Assert(name).NotEmpty();
            Assert(value).NotEmpty();

            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }
    }
}
