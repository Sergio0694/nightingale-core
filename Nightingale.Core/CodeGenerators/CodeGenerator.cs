using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;
using Nightingale.Core.CodeGenerators.Enums;
using Nightingale.Core.Models;
using Stubble.Core;

namespace Nightingale.Core.CodeGenerators
{
    /// <summary>
    /// A <see langword="class"/> that provides an implementation of the <see cref="ICodeGenerator"/> service.
    /// </summary>
    public sealed class CodeGenerator : ICodeGenerator
    {
        /// <summary>
        /// The local cache of templates to use for codegen requests
        /// </summary>
        private readonly ConcurrentDictionary<string, string> RequestTemplates = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// Executes a codegen request with the specified parameters.
        /// </summary>
        /// <param name="data">The input data to use for the codegen request.</param>
        /// <param name="language">The target language to use to generate code.</param>
        /// <param name="category">The target category for the codegen request.</param>
        /// <returns>A <see cref="string"/> representing the codegen template to use.</returns>
        private string GenerateCode(object data, CodegenLanguage language, CodegenCategory category)
        {
            // Get the template to use
            string id = $"{category}.{category}.mustache";
            string template = RequestTemplates.GetOrAdd(id, key =>
            {
                Assembly assembly = Assembly.GetExecutingAssembly();

                string filename = assembly.GetManifestResourceNames().First(name => name.EndsWith(id));

                using (Stream stream = assembly.GetManifestResourceStream(filename))
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            });

            return StaticStubbleRenderer.Render(template, data);
        }

        /// <inheritdoc/>
        public string GenerateCode(WorkspaceRequest request, CodegenLanguage language)
        {
            return GenerateCode(request, language, CodegenCategory.Request);
        }

        /// <inheritdoc/>
        public string GenerateCode(WorkspaceCollection collection, CodegenLanguage language)
        {
            return GenerateCode(collection, language, CodegenCategory.Collection);
        }
    }
}
