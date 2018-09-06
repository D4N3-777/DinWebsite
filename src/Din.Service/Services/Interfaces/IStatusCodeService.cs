﻿using System.Threading.Tasks;
using Din.Service.DTO;

namespace Din.Service.Services.Interfaces
{
    public interface IStatusCodeService
    {
        /// <summary>
        /// Generates ViewModel corresponding to the status code.
        /// </summary>
        /// <param name="statusCode">Http status code.</param>
        /// <returns>ViewModel</returns>
        Task<StatusCodeDTO> GenerateDataToDisplayAsync(int statusCode);
    }
}
