using AutoMapper;

namespace CQRSExample.ProductApi.Business.Mapper
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new DomainToDtoProfile());
            });
        }
    }
}
