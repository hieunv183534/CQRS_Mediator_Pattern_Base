using AutoMapper;

namespace NOM.SMSGATEWAY.Domain._Base.Mappings
{
    public interface IMapFrom<T>
    {   
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
