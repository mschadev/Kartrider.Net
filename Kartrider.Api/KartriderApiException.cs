using System;
using System.Net;

namespace Kartrider.Api
{
    /// <summary>
    /// Kartrider.Api exception.
    /// </summary>
    public class KartriderApiException : Exception
    {
        /// <summary>HTTP error code returned by the Riot API, causing this exception.</summary>
        public readonly HttpStatusCode HttpStatusCode;

        /// <summary>
        ///     Initializes a new instance of the <see cref="KartriderApiException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        public KartriderApiException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}