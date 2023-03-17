using Mongo.Context;
using Mongo.Repositories;
using Mongo.Streams;
using SignalRHub.Sender;
using UseCases.Gateways;
using UseCases.Stream;
using UseCases.UseCases;

namespace Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service)
        {
            #region UseCases 
            service.AddScoped<IGetAllCardsUseCase, GetAllCardsUseCase>();
            service.AddScoped<IUpdateDatabaseUseCase, UpdateDatabaseUseCase>();
            #endregion UseCases

            #region Adapters
            service.AddScoped<INotificationSender, NotificationSender>();
            service.AddScoped<ICardRepository, CardRepository>();
            service.AddScoped<IChangeStreamMongo, ChangeStreamMongo>();
            #endregion

            return service;
        }

        public static IServiceCollection RegisterMongoContext(this IServiceCollection service, string connectionString, string databaseName)
            => service.AddSingleton<IContext>(provider => new Context(connectionString, databaseName));
    }
}
