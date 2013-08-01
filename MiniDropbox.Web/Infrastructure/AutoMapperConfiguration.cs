using System.Collections.Generic;
using AutoMapper;
using MiniDropbox.Domain;
using MiniDropbox.Web.Models;
using Ninject.Modules;

namespace MiniDropbox.Web.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<AccountInputModel, Account>();
            Mapper.CreateMap<Account, AccountInputModel>();
        }
    }
}