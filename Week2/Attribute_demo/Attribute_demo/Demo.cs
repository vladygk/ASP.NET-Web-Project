using System.Runtime.CompilerServices;

namespace Attribute_demo
{
    internal class Demo
    {
        [NotABanana(ErrorMessage = "Error")]
        public  string Name { get; set; }
    }
}
