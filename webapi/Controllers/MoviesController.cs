﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using webapi.DTOs;
using webapi.Models;
using webapi.Services.Movies;

namespace webapi.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesService _moviesService;

        public MoviesController(
            ILogger<MoviesController> logger,
            IMoviesService moviesService
            )
        {
            _logger = logger;
            _moviesService = moviesService;
        }

        [HttpGet(Name = "ListMovies")]
        [ProducesResponseType(typeof(IEnumerable<Movie>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Movie>>> List()
        {
            var result = await _moviesService.ListAsync();
            return Ok(result);
        }

        [HttpPost(Name = "CreateMovie")]
        public async Task<ActionResult> Create(Movie movie)
        {
            var result = await _moviesService.CreateAsync(movie);
            
            return result ? Ok() : BadRequest();
        }

        [HttpGet(Name = "MovieExists")]
        public async Task<ActionResult<bool>> Exists(string movie)
        {
            var result = await _moviesService.ExistsAsync(movie);

            return Ok(result);
        }

        [HttpPut(Name = "UpdateMovie")]
        public async Task<ActionResult> Update(Movie movie)
        {
            return await _moviesService.UpdateAsync(movie) ? Ok() : BadRequest();
        }

        [HttpDelete(Name = "DeleteMovie")]
        public async Task<ActionResult> Delete(int id)
        {
            return await _moviesService.DeleteAsync(id) ? Ok() : BadRequest();
        }

        [HttpGet(Name = "RatingCounts")]
        public async Task<IEnumerable<RatingCount>> RatingCounts()
        {
            return await _moviesService.ListRatingCountsAsync();
        }
    }
}
