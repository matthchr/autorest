// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Generator.NodeJS
{
    using Azure;
    using Microsoft.Rest.Generator.ClientModel;
    using Microsoft.Rest.Generator.Utilities;
    using System.Collections.Generic;
    using System.Linq;   

    public class AzureParameterTemplateModel : ParameterTemplateModel
    {
        public AzureParameterTemplateModel(Parameter source) : base(source)
        {
        }

        public override string ParameterAccessor
        {
            get
            {
                if (string.IsNullOrEmpty(this.ParameterGroup))
                {
                    return base.ParameterAccessor;
                }
                else
                {
                    return AzureCodeGenerator.ParameterGroupName + CodeNamer.PascalCase(base.ParameterAccessor);
                }
            }
        }
    }
}