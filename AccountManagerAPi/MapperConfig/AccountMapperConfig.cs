using System;
using AccountManagerAPi.Dtos;
using Mapster;
using ApplicationLayer.Domain.Models;

namespace AccountManagerAPi.MapperConfig
{
    public class AccountMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Account, AccountResponse>()
                .Map(dest => dest.CurrentBalance, src => src.GetCurrentBalance())
                .Map(dest => dest.Status, src => src.Status);
        }

    }
}
