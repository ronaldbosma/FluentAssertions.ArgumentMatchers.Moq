using AutoMapper;

namespace Moq.ArgumentMatchers.FluentAssertions.Tests.TestTools
{
    public static class CopyHelper
    {
        private static readonly IMapper _mapper;

        static CopyHelper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
            });

            _mapper = configuration.CreateMapper();
        }

        public static ComplexType Copy(this ComplexType complexType)
        {
            return _mapper.Map<ComplexType>(complexType);
        }
    }
}
