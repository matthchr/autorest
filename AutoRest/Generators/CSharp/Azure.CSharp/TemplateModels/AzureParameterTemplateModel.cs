﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Globalization;
using Microsoft.Rest.Generator.ClientModel;
using Microsoft.Rest.Generator.Azure;

namespace Microsoft.Rest.Generator.CSharp.Azure
{
    public class AzureParameterTemplateModel : ParameterTemplateModel
    {
        public AzureParameterTemplateModel(Parameter source) : base(source)
        {
        }

        /// <summary>
        /// Gets declaration for the parameter.
        /// </summary>
        public override string DeclarationExpression
        {
            get
            {
                if (SerializedName.Equals("$filter", StringComparison.OrdinalIgnoreCase) &&
                    Location == ParameterLocation.Query &&
                    Type is CompositeType)
                {
                    return string.Format(CultureInfo.InvariantCulture, 
                        "Expression<Func<{0}, bool>>", Type.Name);
                }

                return base.DeclarationExpression;
            }
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
                    return CodeNamer.CamelCase(this.ParameterGroup) + CodeNamer.PascalCase(base.ParameterAccessor);
                }
            }
        }
    }
}