// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Rest.Generator.ClientModel;
using Microsoft.Rest.Generator.Utilities;

namespace Microsoft.Rest.Generator.CSharp
{
    public class ParameterGroupTemplateModel
    {
        private readonly Parameter groupParameter;

        public ParameterGroupTemplateModel(ServiceClient serviceClient, Parameter groupParameter)
        {
            if (groupParameter == null)
            {
                throw new ArgumentNullException("groupParameter");
            }

            this.LoadFrom(serviceClient);
            this.groupParameter = groupParameter;
            
            CompositeType compositeType = this.groupParameter.Type as CompositeType;

            this.GroupedParameters = compositeType.Properties;
            this.Documentation = compositeType.Documentation;
        }

        public string ParameterGroupType 
        {
            get { return this.groupParameter.Type.Name; }
        }

        public string ConstructorParameters
        {
            get
            {
                List<string> declarations = new List<string>();
                foreach (var parameter in this.GroupedParameters.OrderBy(p => !p.IsRequired))
                {
                    string format = (parameter.IsRequired ? "{0} {1}" : "{0} {1} = default({0})");
                    declarations.Add(string.Format(CultureInfo.InvariantCulture,
                        format, parameter.Type, CodeNamer.CamelCase(parameter.Name)));
                }

                return string.Join(", ", declarations);
            }
        }

        public string Documentation { get; private set; }

        public IEnumerable<Property> GroupedParameters { get; private set; }

    }
}