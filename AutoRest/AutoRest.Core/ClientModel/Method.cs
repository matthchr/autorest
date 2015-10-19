// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using Microsoft.Rest.Generator.Utilities;

namespace Microsoft.Rest.Generator.ClientModel
{
    /// <summary>
    /// Defines a method for the client model.
    /// </summary>
    public class Method : ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the Method class.
        /// </summary>
        public Method()
        {
            Extensions = new Dictionary<string, object>();
            Parameters = new List<Parameter>();
            RequestHeaders = new Dictionary<string, string>();
            Responses = new Dictionary<HttpStatusCode, IType>();
            ParameterExpansions = new Dictionary<string, Dictionary<Property, Parameter>>();
        }

        /// <summary>
        /// Gets or sets the method name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets the HTTP url.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings",
            Justification= "Url might be used as a template, thus making it invalid url in certain scenarios.")]
        public string Url { get; set; }

        /// <summary>
        /// Indicates whether the HTTP url is absolute.
        /// </summary>
        public bool IsAbsoluteUrl { get; set; }

        /// <summary>
        /// Gets or sets the HTTPMethod.
        /// </summary>
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// Gets or sets the method parameters.
        /// </summary>
        public List<Parameter> Parameters { get; private set; }

        /// <summary>
        /// Gets the list of Parameter Expansions
        /// </summary>
        public Dictionary<string, Dictionary<Property, Parameter>> ParameterExpansions { get; private set; }
        
        /// <summary>
        /// Gets the parameter groups.
        /// </summary>
        public IEnumerable<string> ParameterGroups
        {
            get
            {
                return this.ParameterExpansions.Keys;
            }
        }

        /// <summary>
        /// Gets or sets request headers.
        /// </summary>
        public Dictionary<string, string> RequestHeaders { get; private set; }

        /// <summary>
        /// Gets or sets the request format.
        /// </summary>
        public SerializationFormat RequestSerializationFormat { get; set; }

        /// <summary>
        /// Gets or sets the response format.
        /// </summary>
        public SerializationFormat ResponseSerializationFormat { get; set; }

        /// <summary>
        /// Gets or sets response bodies by HttpStatusCode.
        /// </summary>
        public Dictionary<HttpStatusCode, IType> Responses { get; private set; }

        /// <summary>
        /// Gets or sets the default response.
        /// </summary>
        public IType DefaultResponse { get; set; }

        /// <summary>
        /// Gets or sets the method return type.
        /// </summary>
        public IType ReturnType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets vendor extensions dictionary.
        /// </summary>
        public Dictionary<string, object> Extensions { get; private set; }

        /// <summary>
        /// Returns a string representation of the Method object.
        /// </summary>
        /// <returns>
        /// A string representation of the Method object.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} {1} ({2})", ReturnType, Name,
                string.Join(",", Parameters.Select(p => p.ToString())));
        }

        /// <summary>
        /// Performs a deep clone of a method.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Method newMethod = (Method)this.MemberwiseClone();
            newMethod.Extensions = new Dictionary<string, object>();
            newMethod.Parameters = new List<Parameter>();
            newMethod.RequestHeaders = new Dictionary<string, string>();
            newMethod.Responses = new Dictionary<HttpStatusCode, IType>();
            newMethod.ParameterExpansions = new Dictionary<string, Dictionary<Property, Parameter>>();
            this.Extensions.ForEach(e => newMethod.Extensions[e.Key] = e.Value);
            this.Parameters.ForEach(p => newMethod.Parameters.Add((Parameter)p.Clone()));
            this.ParameterExpansions.ForEach(p =>
                {
                    newMethod.ParameterExpansions.Add(p.Key, new Dictionary<Property, Parameter>());
                    p.Value.ForEach(inner => newMethod.ParameterExpansions[p.Key].Add(inner.Key, inner.Value));
                });
            this.RequestHeaders.ForEach(r => newMethod.RequestHeaders[r.Key] = r.Value);
            this.Responses.ForEach(r => newMethod.Responses[r.Key] = r.Value);
            return newMethod;
        }
        
        /// <summary>
        /// Adds a new grouped parameter.
        /// </summary>
        /// <param name="parameterGroupType">The composite type of the parameter group.</param>
        /// <param name="parameterGroupProperty">The property on the parameter group which represents the grouped parameter.</param>
        /// <param name="groupedParameter">The grouped parameter.</param>
        public void AddGroupedParameter(string parameterGroupType, Property parameterGroupProperty, Parameter groupedParameter)
        {
            if (!this.ParameterExpansions.ContainsKey(parameterGroupType))
            {
                this.ParameterExpansions.Add(parameterGroupType, new Dictionary<Property, Parameter>());
            }

            Dictionary<Property, Parameter> propertyToParameterMapping = this.ParameterExpansions[parameterGroupType];
            propertyToParameterMapping[parameterGroupProperty] = groupedParameter;
        }

        /// <summary>
        /// Retrives a dictionary of Property -> Parameter mappings.
        /// </summary>
        /// <param name="parameterGroupType">The type of the parameter group.</param>
        /// <returns>A dictionary of Property -> Parameter mappings.</returns>
        public IReadOnlyDictionary<Property, Parameter> GetGroupedParameters(string parameterGroupType)
        {
            return this.ParameterExpansions[parameterGroupType];
        }

        /// <summary>
        /// Updates a grouped parameter to have a new name.
        /// </summary>
        /// <param name="originalName">The original name of the grouped parameter.</param>
        /// <param name="newName">The new name of the grouped parameter.</param>
        public void UpdateGroupedParameterName(string originalName, string newName)
        {
            Dictionary<Property, Parameter> propertyToParameterMapping = this.ParameterExpansions[originalName];
            this.ParameterExpansions.Remove(originalName);
            this.ParameterExpansions.Add(newName, propertyToParameterMapping);
        }

    }
}
