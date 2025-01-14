// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Net.Http.Headers;

namespace Microsoft.AspNetCore.HttpLogging
{
    /// <summary>
    /// Options for the <see cref="HttpLoggingMiddleware"/>.
    /// </summary>
    public sealed class HttpLoggingOptions
    {
        /// <summary>
        /// Fields to log for the Request and Response. Defaults to logging request and response properties and headers.
        /// </summary>
        public HttpLoggingFields LoggingFields { get; set; } = HttpLoggingFields.RequestPropertiesAndHeaders | HttpLoggingFields.ResponsePropertiesAndHeaders;

        /// <summary>
        /// Request header values that are allowed to be logged.
        /// <p>
        /// If a request header is not present in the <see cref="RequestHeaders"/>,
        /// the header name will be logged with a redacted value.
        /// </p>
        /// </summary>
        public ISet<string> RequestHeaders => _internalRequestHeaders;

        internal HashSet<string> _internalRequestHeaders = new HashSet<string>(26, StringComparer.OrdinalIgnoreCase)
        {
            HeaderNames.Accept,
            HeaderNames.AcceptCharset,
            HeaderNames.AcceptEncoding,
            HeaderNames.AcceptLanguage,
            HeaderNames.Allow,
            HeaderNames.CacheControl,
            HeaderNames.Connection,
            HeaderNames.ContentEncoding,
            HeaderNames.ContentLength,
            HeaderNames.ContentType,
            HeaderNames.Date,
            HeaderNames.DNT,
            HeaderNames.Expect,
            HeaderNames.Host,
            HeaderNames.MaxForwards,
            HeaderNames.Range,
            HeaderNames.SecWebSocketExtensions,
            HeaderNames.SecWebSocketVersion,
            HeaderNames.TE,
            HeaderNames.Trailer,
            HeaderNames.TransferEncoding,
            HeaderNames.Upgrade,
            HeaderNames.UserAgent,
            HeaderNames.Warning,
            HeaderNames.XRequestedWith,
            HeaderNames.XUACompatible
        };

        /// <summary>
        /// Response header values that are allowed to be logged.
        /// <p>
        /// If a response header is not present in the <see cref="ResponseHeaders"/>,
        /// the header name will be logged with a redacted value.
        /// </p>
        /// </summary>
        public ISet<string> ResponseHeaders => _internalResponseHeaders;

        internal HashSet<string> _internalResponseHeaders = new HashSet<string>(20, StringComparer.OrdinalIgnoreCase)
        {
            HeaderNames.AcceptRanges,
            HeaderNames.Age,
            HeaderNames.Allow,
            HeaderNames.AltSvc,
            HeaderNames.Connection,
            HeaderNames.ContentDisposition,
            HeaderNames.ContentLanguage,
            HeaderNames.ContentLength,
            HeaderNames.ContentLocation,
            HeaderNames.ContentRange,
            HeaderNames.ContentType,
            HeaderNames.Date,
            HeaderNames.Expires,
            HeaderNames.LastModified,
            HeaderNames.Location,
            HeaderNames.Server,
            HeaderNames.Status,
            HeaderNames.TransferEncoding,
            HeaderNames.Upgrade,
            HeaderNames.XPoweredBy
        };

        /// <summary>
        /// Options for configuring encodings for a specific media type.
        /// <p>
        /// If the request or response do not match the supported media type,
        /// the response body will not be logged.
        /// </p>
        /// </summary>
        public MediaTypeOptions MediaTypeOptions { get; } = MediaTypeOptions.BuildDefaultMediaTypeOptions();

        /// <summary>
        /// Maximum request body size to log (in bytes). Defaults to 32 KB.
        /// </summary>
        public int RequestBodyLogLimit { get; set; } = 32 * 1024;

        /// <summary>
        /// Maximum response body size to log (in bytes). Defaults to 32 KB.
        /// </summary>
        public int ResponseBodyLogLimit { get; set; } = 32 * 1024;
    }
}
