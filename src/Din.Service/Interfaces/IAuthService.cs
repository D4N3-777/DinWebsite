﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Din.ExternalModels.Entities;

namespace Din.Service.Interfaces
{
    /// <summary>
    /// Authentication service for the corresponsing controller.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// User Login method, authenticates the supplied parameters.
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password in hash (BCrypt) format</param>
        /// <returns>The generated claims principle for authoraztion</returns>
        Task<ClaimsPrincipal> LoginAsync(string username, string password);

        /// <summary>
        /// Logging of the LoginAsync attempt
        /// </summary>
        /// <param name="username">Username supplied in the user input</param>
        /// <param name="userAgentString">user-agent string supplied by the browser</param>
        /// <param name="publicIp">Users puplic ip</param>
        /// <param name="status">Status returned by LoginAsync</param>
        /// <returns></returns>
        Task LogLoginAttempt(string username, string userAgentString, string publicIp, LoginStatus status);
    }
}
