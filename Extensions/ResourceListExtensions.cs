﻿using System.Collections.Generic;
using System.Linq;
using Orchard.UI.Resources;
using Piedone.Combinator.Models;

namespace Piedone.Combinator.Extensions
{
    public static class ResourceListExtensions
    {
        public static int GetResourceListHashCode<T>(this IEnumerable<T> resources) where T : ResourceRequiredContext
        {
            var key = string.Empty;

            resources.ToList().ForEach(resource => key += resource.Resource.GetFullPath() + "__");

            return key.GetHashCode();
        }

        public static IList<T> SetLocation<T>(this IList<T> resources, ResourceLocation location) where T : ResourceRequiredContext
        {
            resources.ToList().ForEach(resource => resource.Settings.Location = location);
            return resources;
        }

        public static int GetCombinatorResourceListHashCode<T>(this IEnumerable<T> resources) where T : CombinatorResource
        {
            return resources.Select(resource => resource.RequiredContext).GetResourceListHashCode();
        }
    }
}