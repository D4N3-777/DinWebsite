﻿using System.Threading.Tasks;
using Din.Service.DTO;
using Din.Service.DTO.Content;
using TMDbLib.Objects.Search;

namespace Din.Service.Services.Interfaces
{
    public interface IMovieService
    {
        /// <summary>
        /// Search movies with a specific query.
        /// </summary>
        /// <param name="query">The movie title or a part of it.</param>
        /// <returns>ViewModel containing collections of existing movies and query results.</returns>
        Task<MovieDTO> SearchMovieAsync(string query);

        /// <summary>
        /// Adds movie to the system.
        /// </summary>
        /// <param name="movie">The movie object that needs to be added.</param>
        /// <param name="id">The account id of the current session.</param>
        /// <returns>The status result.</returns>
        Task<ResultDTO> AddMovieAsync(SearchMovie movie, int id);
    }
}