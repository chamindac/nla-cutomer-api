using System;
using System.Collections.Generic;
using NLA.CustomerAPI.Apis.Mapping.Interfaces;

namespace NLA.CustomerAPI.Apis.Mapping
{
    public class MapperConfigurationBuilder : IMapperConfigurationBuilder
    {
        public HashSet<Type> ProfileTypes { get; } = new HashSet<Type>();

        public IMapperConfigurationBuilder AddProfileTypes(HashSet<Type> profileTypes)
        {
            if (profileTypes == null)
            {
                return this;
            }

            foreach (Type profileType in profileTypes)
            {
                ProfileTypes.Add(profileType);
            }

            return this;
        }
    }
}