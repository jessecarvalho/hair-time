using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers;

[ApiController]
public class ReviewController : ControllerBase
{
    
    public readonly ReviewService ReviewService;
    
    public ReviewController(ReviewService reviewService)
    {
        ReviewService = reviewService;
    }
    
    [Authorize]
    [HttpGet("api/review")]
    public ActionResult<ReviewController> Get()
    {
        var reviews = ReviewService.GetReviews();
        return Ok(reviews);
    }
    
    [Authorize]
    [HttpGet("api/review/{id}")]
    public ActionResult<ReviewController> GetById(int id)
    {
        var review = ReviewService.GetReviewById(id);
        if (review == null)
        {
            return NotFound();
        }
        return Ok(review);
    }
    
    [Authorize]
    [HttpPost("api/review")]
    public ActionResult<ReviewController> Create(ReviewRequestDTO review)
    {
        var createdReview = ReviewService.CreateReview(review);
        return CreatedAtAction(nameof(GetById), new { id = createdReview.Id }, createdReview);
    }
    
    [Authorize]
    [HttpPut("api/review/{id}")]
    public ActionResult<ReviewController> Update(int id, ReviewRequestDTO review)
    {
        var updatedReview = ReviewService.UpdateReview(review);
        return Ok(updatedReview);
    }
    
    [Authorize]
    [HttpDelete("api/review/{id}")]
    public ActionResult Delete(int id)
    {
        ReviewService.DeleteReview(id);
        return NoContent();
    }
    
}