using Application.DTOs;
using AutoMapper;
using Infrastructure.Data;
using Domain.Entities;

namespace Application.Services;

public class ReviewService
{
    
    private readonly IMapper _mapper;
    private readonly HairTimeDbContext _dbContext;
    
    public ReviewService(IMapper mapper, HairTimeDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    
    public List<ReviewResponseDTO> GetReviews()
    {
        var reviews = _dbContext.Reviews.ToList();
        return _mapper.Map<List<ReviewResponseDTO>>(reviews);
    }
    
    public ReviewResponseDTO GetReviewById(int id)
    {
        var review = _dbContext.Reviews.FirstOrDefault(x => x.Id == id);
        
        return _mapper.Map<ReviewResponseDTO>(review);
    }
    
    public ReviewResponseDTO CreateReview(ReviewRequestDTO review)
    {
        
        var newReview = _mapper.Map<Review>(review);
        _dbContext.Reviews.Add(newReview);
        _dbContext.SaveChanges();

        return _mapper.Map<ReviewResponseDTO>(newReview);
    }
    
    public ReviewResponseDTO UpdateReview(ReviewRequestDTO review)
    {
        var updateReview = _mapper.Map<Review>(review);
        _dbContext.Reviews.Update(updateReview);
        _dbContext.SaveChanges();
        return _mapper.Map<ReviewResponseDTO>(updateReview);
    }
    
    public void DeleteReview(int id)
    {
        var review = _dbContext.Reviews.FirstOrDefault(x => x.Id == id);
        _dbContext.Reviews.Remove(review);
        _dbContext.SaveChanges();
    }
    
}