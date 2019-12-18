using Nightingale.Core.Models;
using Nightingale.Core.CodeGenerators.Enums;

namespace Nightingale.Core.CodeGenerators
{
    /// <summary>
    /// An <see langword="interface"/> for generating code from workspace items.
    /// </summary>
    public interface ICodeGenerator
    {
        /// <summary>
        /// Generates code based on a <see cref="WorkspaceRequest"/>.
        /// </summary>
        /// <param name="request">The <see cref="WorkspaceRequest"/> to use.</param>
        /// <param name="language">The target language to use to generate code.</param>
        /// <returns>A <see cref="string"/> representing generated code.</returns>
        string GenerateCode(WorkspaceRequest request, CodegenLanguage language);

        /// <summary>
        /// Generates code based on a <see cref="WorkspaceCollection"/>.
        /// </summary>
        /// <param name="collection">The <see cref="WorkspaceCollection"/> to use.</param>
        /// <param name="language">The target language to use to generate code.</param>
        /// <returns>A <see cref="string"/> representing generated code.</returns>
        string GenerateCode(WorkspaceCollection collection, CodegenLanguage language);

        /// <summary>
        /// Generates code based on a <see cref="WorkspaceRequest"/> and a specified template.
        /// </summary>
        /// <param name="request">The <see cref="WorkspaceRequest"/> to use.</param>
        /// <param name="template">The input template to use, following the mustache specs (see <see href="https://mustache.github.io/mustache.5.html"/>).</param>
        /// <returns>A <see cref="string"/> representing generated code.</returns>
        string GenerateCode(WorkspaceRequest request, string template);

        /// <summary>
        /// Generates code based on a <see cref="WorkspaceCollection"/> and a specified template.
        /// </summary>
        /// <param name="collection">The <see cref="WorkspaceCollection"/> to use.</param>
        /// <param name="template">The input template to use, following the mustache specs (see <see href="https://mustache.github.io/mustache.5.html"/>).</param>
        /// <returns>A <see cref="string"/> representing generated code.</returns>
        string GenerateCode(WorkspaceCollection collection, string template);
    }
}
