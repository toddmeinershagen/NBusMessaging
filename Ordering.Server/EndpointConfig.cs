
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using NServiceBus.Features;

namespace Ordering.Server
{
    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
	public class EndpointConfig : 
        IConfigureThisEndpoint, 
        //AsA_Server, 
        AsA_Publisher,
        UsingTransport<RabbitMQ>,
        IWantCustomInitialization
	{
	    public void Init()
	    {
	        Configure.With()
	            .DefaultBuilder();

	        Configure.Serialization.Json();
	        Configure.With()
                .RijndaelEncryptionService()
                .DefiningEncryptedPropertiesAs(x => x.Name.StartsWith("Encrypted"));
	        
            Configure.Features.Disable<Sagas>();
	    }
	}

    public class ConfigOverride : IProvideConfiguration<RijndaelEncryptionServiceConfig>
    {
        public RijndaelEncryptionServiceConfig GetConfiguration()
        {
            return new RijndaelEncryptionServiceConfig
            {
                Key = "gdDbqRpqdRbTs3mhdZh9qCaDaxJXl+e7"
            };
        }
    }
}
