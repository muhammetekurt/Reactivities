using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController(AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        // var activities = await context.Activities.ToListAsync();
        // return Ok(activities);
        return await context.Activities.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(string id)
    {
        var activity = await context.Activities.FindAsync(id);

        if (activity == null)
        {
            return NotFound();
        }

        return activity;
    }
    [HttpGet("category/{category}")]
    public async Task<ActionResult<List<Activity>>> GetActivitiesByCategory(string category)
    {
        var activities = await context.Activities.Where(a => a.Category == category).ToListAsync();

        if (activities == null || activities.Count == 0)
        {
            return NotFound();
        }
        return activities;
    }
}
