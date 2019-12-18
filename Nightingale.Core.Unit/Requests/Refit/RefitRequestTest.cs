using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nightingale.Core.CodeGenerators;
using Nightingale.Core.CodeGenerators.Enums;
using Nightingale.Core.Models;
using Nightingale.Core.Unit.Expected;

namespace Nightingale.Core.Unit.Requests.Refit
{
    /// <summary>
    /// A test <see langword="class"/> for codegen for individual refit requests
    /// </summary>
    [TestClass]
    public class RefitRequestTest
    {
        [TestMethod]
        public void SimpleRequest()
        {
            WorkspaceRequest request = new WorkspaceRequest
            {
                BaseUrl = "https://www.reddit.com/r/windows10/best.json",
                Name = "GetWindows10Trending"
            };
            request.Headers.Add(new Parameter(key: "User Agent", value: "NightingaleUWP"));
            request.Queries.Add(new Parameter(key: "limit", value: "50"));
            request.Queries.Add(new Parameter(key: "raw_json", value: "true"));

            ICodeGenerator generator = new CodeGenerator();
            string result = generator.GenerateCode(request, CodegenLanguage.Refit);
            string expected = TestUtils.GetExpectedResult(CodegenLanguage.Refit, CodegenCategory.Request);

            Assert.AreEqual(result, expected);
        }
    }
}
