using AutoMapper;

namespace NOM.RIFDGATEWAY.Domain._Base.Mappings
{
    public interface IMapTo<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
