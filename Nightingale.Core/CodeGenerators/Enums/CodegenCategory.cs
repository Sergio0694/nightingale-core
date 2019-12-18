namespace Nightingale.Core.CodeGenerators.Enums
{
    /// <summary>
    /// An <see langword="enum"/> that indicates the category of a codegen request to execute
    /// </summary>
    public enum CodegenCategory
    {
        /// <summary>
        /// A codegen request for a <see cref="Core.Models.WorkspaceRequest"/> instance
        /// </summary>
        Request,

        /// <summary>
        /// A codegen request for a <see cref="Core.Models.WorkspaceCollection"/> instance
        /// </summary>
        Collection
    }
}
