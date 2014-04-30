using ServiceStack.MovieRest.App_Start;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(SampleTradersAppHost), "Start")]
namespace ServiceStack.MovieRest.App_Start
{
    using Funq;
    using SampleTraders;
    using SampleTraders.Data;
    using SampleTraders.ServiceInterface;
    using ServiceStack.Common.Utils;
    using ServiceStack.OrmLite;
    using ServiceStack.ServiceInterface.Cors;
    using ServiceStack.Text;
    using ServiceStack.WebHost.Endpoints;
    using System.Configuration;

    public class SampleTradersAppHost
    : AppHostBase
    {
        /// <summary>
        /// Initializes a new instance of your ServiceStack application, with the specified name and assembly containing the services.
        /// </summary>
        public SampleTradersAppHost()
            : base("Sample Traders Products", typeof(ProductService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            JsConfig.DateHandler = JsonDateHandler.ISO8601;

            //Set JSON web services to return idiomatic JSON camelCase properties
            JsConfig.EmitCamelCaseNames = true;

            /*
            //Usar inyección de dependencias
            container.Register<IDbConnectionFactory>(
            c => new OrmLiteConnectionFactory("~/App_Data/db.sqlite".MapHostAbsolutePath(), SqliteOrmLiteDialectProvider.Instance));
            */
            container.Register<IMongoDBDatabaseFactory>(new MongoDatabaseFactory(ConfigurationManager.ConnectionStrings["main"].ConnectionString));
            container.RegisterAutoWiredAs<RepositoryProductMongo ,IRepositoryProduct>();
            container.RegisterAutoWiredAs<RepositoryVendorMongo, IRepositoryVendor>();

            /*
            // Reiniciar lista de películas
            using (var resetMovies = container.Resolve<ResetMoviesService>())
            {
                resetMovies.Any(null);
            }
            */

            Plugins.Add(new CorsFeature()); //Enable CORS

            SetConfig(new EndpointHostConfig
            {
                DebugMode = true //Show StackTraces for easier debugging (default auto inferred by Debug/Release builds)
            });
        }


        public static void Start()
        {
            new SampleTradersAppHost().Init();
        }
    }
}