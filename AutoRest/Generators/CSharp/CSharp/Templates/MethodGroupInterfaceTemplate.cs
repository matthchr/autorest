// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Generator.CSharp.Templates
{
    using System.Threading.Tasks;

    public class MethodGroupInterfaceTemplate : Microsoft.Rest.Generator.Template<Microsoft.Rest.Generator.CSharp.MethodGroupTemplateModel>
    {
        #line hidden
        public MethodGroupInterfaceTemplate()
        {
        }

        #pragma warning disable 1998
        public override async Task ExecuteAsync()
        {
#line 2 "MethodGroupInterfaceTemplate.cshtml"
Write(Header("/// "));

#line default
#line hidden
            WriteLiteral("\r\nnamespace ");
#line 3 "MethodGroupInterfaceTemplate.cshtml"
     Write(Settings.Namespace);

#line default
#line hidden
            WriteLiteral("\r\n{\r\n    using System;\r\n    using System.Collections.Generic;\r\n    using System.N" +
"et.Http;\r\n    using System.Threading;\r\n    using System.Threading.Tasks;\r\n    us" +
"ing Microsoft.Rest;\r\n");
#line 11 "MethodGroupInterfaceTemplate.cshtml"
 foreach (var usingString in Model.Usings) {

#line default
#line hidden

            WriteLiteral("    using ");
#line 12 "MethodGroupInterfaceTemplate.cshtml"
       Write(usingString);

#line default
#line hidden
            WriteLiteral(";\r\n");
#line 13 "MethodGroupInterfaceTemplate.cshtml"
}

#line default
#line hidden

#line 14 "MethodGroupInterfaceTemplate.cshtml"
Write(EmptyLine);

#line default
#line hidden
            WriteLiteral("\r\n    /// <summary>\r\n    ");
#line 16 "MethodGroupInterfaceTemplate.cshtml"
Write(WrapComment("/// ", Model.Documentation));

#line default
#line hidden
            WriteLiteral("\r\n    /// </summary>\r\n    public partial interface I");
#line 18 "MethodGroupInterfaceTemplate.cshtml"
                          Write(Model.MethodGroupType);

#line default
#line hidden
            WriteLiteral("\r\n    {\r\n");
#line 20 "MethodGroupInterfaceTemplate.cshtml"
    

#line default
#line hidden

#line 20 "MethodGroupInterfaceTemplate.cshtml"
     foreach(var method in Model.MethodTemplateModels)
    {

#line default
#line hidden

            WriteLiteral("        /// <summary>\r\n        ");
#line 23 "MethodGroupInterfaceTemplate.cshtml"
     Write(WrapComment("/// ", method.Documentation));

#line default
#line hidden
            WriteLiteral("\r\n        /// </summary>\r\n");
#line 25 "MethodGroupInterfaceTemplate.cshtml"
        foreach (var parameter in method.Parameters)
        {

#line default
#line hidden

            WriteLiteral("        /// <param name=\'");
#line 27 "MethodGroupInterfaceTemplate.cshtml"
                      Write(parameter.Name);

#line default
#line hidden
            WriteLiteral("\'>\r\n        ");
#line 28 "MethodGroupInterfaceTemplate.cshtml"
     Write(WrapComment("/// ", parameter.Documentation));

#line default
#line hidden
            WriteLiteral("\r\n        /// </param>\r\n");
#line 30 "MethodGroupInterfaceTemplate.cshtml"
        }

#line default
#line hidden

            WriteLiteral("        /// <param name=\'cancellationToken\'>\r\n        /// Cancellation token.\r\n  " +
"      /// </param>\r\n        Task<");
#line 34 "MethodGroupInterfaceTemplate.cshtml"
          Write(method.OperationResponseReturnTypeString);

#line default
#line hidden
            WriteLiteral("> ");
#line 34 "MethodGroupInterfaceTemplate.cshtml"
                                                      Write(method.Name);

#line default
#line hidden
            WriteLiteral("WithOperationResponseAsync(");
#line 34 "MethodGroupInterfaceTemplate.cshtml"
                                                                                              Write(method.AsyncMethodParameterDeclaration);

#line default
#line hidden
            WriteLiteral(");\r\n");
#line 35 "MethodGroupInterfaceTemplate.cshtml"
    }

#line default
#line hidden

            WriteLiteral("    }\r\n}\r\n");
        }
        #pragma warning restore 1998
    }
}