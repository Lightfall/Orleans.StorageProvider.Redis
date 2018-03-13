﻿using Orleans.Providers;
using Orleans.StorageProviders.Redis.TestGrainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orleans.StorageProviders.Redis.TestGrains
{
    [StorageProvider(ProviderName = "REDIS-BINARY")]
    public class BinaryTestGrain2 : Grain<BinaryTestGrainState2>, IBinaryTestGrain2
    {
        public Task Set(string stringValue, int intValue, DateTime dateTimeValue, Guid guidValue, IBinaryTestGrain grainValue)
        {
            State.StringValue = stringValue;
            State.IntValue = intValue;
            State.DateTimeValue = dateTimeValue;
            State.GuidValue = guidValue;
            State.GrainValue = grainValue;
            return WriteStateAsync();
        }

        public async Task<Tuple<string, int, DateTime, Guid, IBinaryTestGrain>> Get()
        {
            await ReadStateAsync();
            return new Tuple<string, int, DateTime, Guid, IBinaryTestGrain>(
              State.StringValue,
              State.IntValue,
              State.DateTimeValue,
              State.GuidValue,
              State.GrainValue);
        }

        public Task Clear()
        {
            return ClearStateAsync();
        }
    }
}