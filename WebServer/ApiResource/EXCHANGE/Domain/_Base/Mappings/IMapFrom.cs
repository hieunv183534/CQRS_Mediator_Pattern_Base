using AutoMapper;

namespace NOM.EXCHANGE.Domain._Base.Mappings
{
    public interface IMapFrom<T>
    {   
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
