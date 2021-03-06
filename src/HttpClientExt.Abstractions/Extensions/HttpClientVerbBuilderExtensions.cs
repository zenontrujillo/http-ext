﻿using System.Net.Http;
using HttpClientExt.Interfaces;
using HttpClientExt.Common;

namespace HttpClientExt.Abstractions.Extensions
{
    public static class HttpClientVerbBuilderExtensions
    {
        public static IHttpClientVerbBuilder<T> Request<T>(this T httpClient) where T : HttpClient
        {
            return new HttpClientVerbBuilder<T>(httpClient);
        }

        public static IHttpClientQueryBuilder<T> PostAsJson<T, TContent>(this IHttpClientVerbBuilder<T> builder, string requestUri, TContent content) where T : HttpClient
        {
            return builder.Post(requestUri, new JsonContent(content));
        }

        public static IHttpClientQueryBuilder<T> PutAsJson<T, TContent>(this IHttpClientVerbBuilder<T> builder, string requestUri, TContent content) where T : HttpClient
        {
            return builder.Put(requestUri, new JsonContent(content));
        }

    }
}
