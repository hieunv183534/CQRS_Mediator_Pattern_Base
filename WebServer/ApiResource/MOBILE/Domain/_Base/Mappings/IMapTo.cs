using AutoMapper;

namespace NOM.MOBILE.Domain._Base.Mappings
{
    public interface IMapTo<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
