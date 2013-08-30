using AutoMapper;
using MiniDropbox.Domain;
using MiniDropbox.Web.Models;

namespace MiniDropbox.Web.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<AccountInputModel, Account>();
        }
    }
}