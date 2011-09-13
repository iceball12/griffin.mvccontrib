﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web.Mvc;

namespace Griffin.MvcContrib.Localization
{
    /// <summary>
    /// Used to return strings from one or more StringTables.
    /// </summary>
    /// <example>
    /// <code>
    /// var provider = new ResourceStringProvider(MyLocalizedStrings.ResourceProvider);
    /// </code>
    /// </example>
    /// <remarks>
    /// <para>Model translations should have the following format: "ClassName_PropertyName", for example: "User_FirstName". All
    /// extra metadata should have the following format: "ClassName_PropertyName_MetadataName".</para>
    /// <para>
    /// Validation error messages should just be named as the attributes, but without the "Attribute" suffix. Example: "Required".
    /// </para>
    /// </remarks>
    public class ResourceStringProvider : ILocalizedStringProvider
    {
        private readonly List<ResourceManager> _resourceManagers = new List<ResourceManager>();


        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceStringProvider"/> class.
        /// </summary>
        /// <param name="resourceManager">The resource manager.</param>
        /// <example>
        /// </example>
        public ResourceStringProvider(params ResourceManager[] resourceManager)
        {
            _resourceManagers.AddRange(resourceManager);
        }

        #region ILocalizedStringProvider Members

        /// <summary>
        /// Get a localized string for a model property
        /// </summary>
        /// <param name="model">Model being localized</param>
        /// <param name="propertyName">Property to get string for</param>
        /// <returns>Translated string</returns>
        public string GetModelString(Type model, string propertyName)
        {
            return GetString(Format(model, propertyName));
        }

        /// <summary>
        /// Get a localized metadata for a model property
        /// </summary>
        /// <param name="model">Model being localized</param>
        /// <param name="propertyName">Property to get string for</param>
        /// <param name="metadataName">Valid names are: Watermark, Description, NullDisplayText, ShortDisplayText.</param>
        /// <returns>Translated string</returns>
        /// <remarks>
        /// Look at <see cref="ModelMetadata"/> to know more about the meta data
        /// </remarks>
        public string GetModelString(Type model, string propertyName, string metadataName)
        {
            return GetString(Format(model, propertyName, metadataName));
        }

        /// <summary>
        /// Get a translated string for a validation attribute
        /// </summary>
        /// <param name="attributeType">Type of attribute</param>
        /// <returns>Localized validation message</returns>
        /// <remarks>
        /// Used to get localized error messages for the DataAnnotation attributes. The returned string 
        /// should have the same format as the built in messages, such as "{0} is required.".
        /// </remarks>
        public string GetValidationString(Type attributeType)
        {
            var name = attributeType.Name.Replace("Attribute", "");
            return GetString(name);
        }

        #endregion

        protected virtual string Format(Type type, string propertyName, params string[] extras)
        {
            string baseStr = string.Format("{0}_{1}", type.Name, propertyName);
            return extras.Aggregate(baseStr, (current, extra) => current + ("_" + extra));
        }

        private string GetString(string name)
        {
            return _resourceManagers.Select(resourceManager => resourceManager.GetString(name))
                .Where(value => value != null)
                .FirstOrDefault();
        }
    }
}