﻿using Orleans;
using Orleans.Concurrency;
using Piraeus.Core.Messaging;
using Piraeus.Core.Metadata;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Piraeus.GrainInterfaces
{
    public interface IPiSystem : IGrainWithStringKey
    {
        [AlwaysInterleave]

        Task UpsertMetadataAsync(EventMetadata metadata);

        [AlwaysInterleave]

        Task<CommunicationMetrics> GetMetricsAsync();
        [AlwaysInterleave]

        Task<EventMetadata> GetMetadataAsync();

        [AlwaysInterleave]

        Task SubscribeAsync(ISubscription subscription);

        [AlwaysInterleave]

        Task UnsubscribeAsync(string subscriptionUriString);

        [AlwaysInterleave]

        Task UnsubscribeAsync(string subscriptionUriString, string identity);

        Task<IEnumerable<string>> GetSubscriptionListAsync();

        [AlwaysInterleave]

        Task PublishAsync(EventMessage message);

        [AlwaysInterleave]

        Task PublishAsync(EventMessage message, List<KeyValuePair<string, string>> indexes);

        Task ClearAsync();

        [AlwaysInterleave]

        Task<string> AddObserverAsync(TimeSpan lifetime, IMetricObserver observer);

        [AlwaysInterleave]

        Task<string> AddObserverAsync(TimeSpan lifetime, IErrorObserver observer);

        [AlwaysInterleave]

        Task RemoveObserverAsync(string leaseKey);

        [AlwaysInterleave]

        Task<bool> RenewObserverLeaseAsync(string leaseKey, TimeSpan lifetime);

    }
}
