﻿using HttpClientExt.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientExt.Abstractions.Extensions
{
    public static class HttpClientQueryBuilderExtensions
    {
        public static IHttpClientQueryBuilder<TKClient> QueryFromArray<TKClient, TValue>(this IHttpClientQueryBuilder<TKClient> builder, string key, IEnumerable<TValue> value) where TKClient:HttpClient
        {
            foreach (TValue arrayValue in value)
            {
                if (arrayValue == null) continue;
                builder.Query(key, arrayValue);                
            }
            return builder;
        }

        public static async Task<T> AsJsonAsync<T>(this IHttpClientQueryBuilder builder, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage response = await builder.SendAsync(cancellationToken);
            return await response.Content.FromJsonAsync<T>(cancellationToken);
        }

        public static async Task<Stream> AsStreamAsync(this IHttpClientQueryBuilder builder, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage response = await builder.SendAsync(cancellationToken);
            return await response.Content.ReadAsStreamAsync();
        }
    }
}
