using AutoMapper;
using Gzt.Application.Interfaces;
using Gzt.Application.Services;
using Gzt.Domain.CommandHandlers;
using Gzt.Domain.Commands;
using Gzt.Domain.Core.Bus;
using Gzt.Domain.Core.Events;
using Gzt.Domain.Core.Notifications;
using Gzt.Domain.EventHandlers;
using Gzt.Domain.Events;
using Gzt.Domain.Interfaces;
using Gzt.Infra.CrossCutting.Bus;
using Gzt.Infra.CrossCutting.Identity.Authorization;
using Gzt.Infra.CrossCutting.Identity.Models;
using Gzt.Infra.CrossCutting.Identity.Services;
using Gzt.Infra.Data.Context;
using Gzt.Infra.Data.EventSourcing;
using Gzt.Infra.Data.Repository;
using Gzt.Infra.Data.Repository.EventSourcing;
using Gzt.Infra.Data.UoW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Gzt.Infra.CrossCutting.IoC
{
    public class SimpleInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<IHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<IHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<GztContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();
        }
    }
}