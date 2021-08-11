using System;
using System.Collections.Generic;

namespace NLA.CustomerAPI.Apis.Mapping.Interfaces
{
    public interface IMapperConfigurationBuilder
    {
        HashSet<Type> ProfileTypes { get; }

        IMapperConfigurationBuilder AddProfileTypes(HashSet<Type> profileTypes);
    }
}