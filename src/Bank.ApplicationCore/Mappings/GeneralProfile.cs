using AutoMapper;
using Bank.ApplicationCore.DTOs.Account;
using Bank.ApplicationCore.DTOs.Client;
using Bank.ApplicationCore.DTOs.Movement;
using Bank.ApplicationCore.Entities;
using Store.ApplicationCore.DTOs;
using Store.ApplicationCore.Entities;

namespace Store.ApplicationCore.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateProductRequest, Product>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.Stock,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.CreatedAt,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.UpdatedAt,
                    opt => opt.Ignore()
                );
            CreateMap<CreateClientRequest, Client>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.Identification,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.Age,
                    opt => opt.Ignore()
                )
                 .ForMember(dest =>
                    dest.Genre,
                    opt => opt.Ignore()
                )
             .ForMember(dest =>
                    dest.Direction,
                    opt => opt.Ignore()
                )
              .ForMember(dest =>
                    dest.Phono,
                    opt => opt.Ignore()
                )
               .ForMember(dest =>
                    dest.ClientUser,
                    opt => opt.Ignore()
                )
               .ForMember(dest =>
                    dest.Password,
                    opt => opt.Ignore()
                )
               .ForMember(dest =>
                    dest.State,
                    opt => opt.Ignore()
                );
            CreateMap<CreateAccountRequest, Account>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.NumberAccount,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.TypeAccount,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.BalanceInitial,
                    opt => opt.Ignore()
                )
                 .ForMember(dest =>
                    dest.State,
                    opt => opt.Ignore()
                )
                  .ForMember(dest =>
                    dest.Client,
                    opt => opt.Ignore()
                );
            CreateMap<CreateMovementRequest, Movement>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.Balance,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.Date,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.TypeMovement,
                    opt => opt.Ignore()
                )
                 .ForMember(dest =>
                    dest.Value,
                    opt => opt.Ignore()
                )
                  .ForMember(dest =>
                    dest.Account,
                    opt => opt.Ignore()
                );

            

            CreateMap<Product, ProductResponse>();
            CreateMap<Product, SingleProductResponse>();
            CreateMap<Client, ClientResponse>();
            CreateMap<Client, SingleClientResponse>();
            CreateMap<Account, AccountResponse>();
            CreateMap<Account, SingleAccountResponse>();
            CreateMap<Movement, MovementResponse>();
            CreateMap<Movement, SingleMovementResponse>();
        }
    }
}