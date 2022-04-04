using AutoMapper;

namespace Allocator.API.Mapping;

public interface IMapWith<T>
{
    void Mapping(Profile profile);
}