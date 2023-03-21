using Mongo.Context;
using Mongo.DatabaseHelper;
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
            service.AddSingleton<IUpdateDatabaseUseCase, UpdateDatabaseUseCase>();
            #endregion UseCases

            #region Adapters
            service.AddSingleton<ICardRepository, CardRepository>();
            service.AddSingleton<IChangeStreamMongo, ChangeStreamMongo>();
            service.AddSingleton<INotificationSender, NotificationSender>();
            service.AddSingleton<IDatabaseMigration, DatabaseMigration>();
            #endregion

            return service;
        }

        public static IServiceCollection RegisterMongoContext(this IServiceCollection service, string connectionString, string databaseName)
            => service.AddSingleton<IContext>(provider => new Context(connectionString, databaseName));
    }
}
