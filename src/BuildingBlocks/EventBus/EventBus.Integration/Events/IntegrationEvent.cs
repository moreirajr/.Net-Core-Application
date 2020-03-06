using Newtonsoft.Json;
using System;


namespace EventBus.Integration.Events
{
    public class IntegrationEvent
    {
        [JsonProperty]
        public Guid Id { get; private set; }

        [JsonProperty]
        public DateTime DataCriacao { get; private set; }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime createDate)
        {
            Id = id;
            DataCriacao = createDate;
        }
    }
}