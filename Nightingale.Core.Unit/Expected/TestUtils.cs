using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nightingale.Core.CodeGenerators.Enums;

namespace Nightingale.Core.Unit.Expected
{
    /// <summary>
    /// A <see langword="class"/> providing helper methods to run tests
    /// </summary>
    internal static class TestUtils
    {
        /// <summary>
        /// Gets the expected codegen results for a specified operation.
        /// </summary>
        /// <param name="language">The target language to use to generate code.</param>
        /// <param name="category">The target category for the codegen request.</param>
        /// <param name="method">The name of the caller method.</param>
        /// <returns>A <see cref="string"/> representing the expected result for the current request.</returns>
        [Pure]
        public static string GetExpectedResult(CodegenLanguage language, CodegenCategory category, [CallerMemberName] string method = "")
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string id = $"{language}.{category}.{method}.txt";

            string filename = assembly.GetManifestResourceNames().First(name => name.EndsWith(id));

            using Stream stream = assembly.GetManifestResourceStream(filename);
            using StreamReader reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
    }
}
