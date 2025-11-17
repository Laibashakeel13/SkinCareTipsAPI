using Microsoft.AspNetCore.Mvc;
using SkinCareTipsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SkinCareTipsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipsController(AppDbContext context)
        {
            _context = context;
        }

        // GET all herbal remedies
        [HttpGet]
        public async Task<IActionResult> GetAllTips()
        {
            var tips = await _context.Tips.ToListAsync();
            return Ok(tips);
        }

        // GET remedies by category
        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetTipsByCategory(string category)
        {
            var tips = await _context.Tips
                .Where(t => t.Category.ToLower() == category.ToLower())
                .ToListAsync();

            if (!tips.Any())
                return NotFound($"No remedies found in {category} category.");

            return Ok(tips);
        }

        // GET random remedy
        [HttpGet("random")]
        public async Task<IActionResult> GetRandomTip()
        {
            var tips = await _context.Tips.ToListAsync();
            if (!tips.Any()) return NotFound("No remedies available.");

            var random = new Random();
            var tip = tips[random.Next(tips.Count)];
            return Ok(tip);
        }

        // POST new herbal remedy
        [HttpPost]
        public async Task<IActionResult> AddTip([FromBody] Tip newTip)
        {
            _context.Tips.Add(newTip);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllTips), new { id = newTip.Id }, newTip);
        }

        // PUT update remedy
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTip(int id, [FromBody] Tip updatedTip)
        {
            var tip = await _context.Tips.FindAsync(id);
            if (tip == null) return NotFound("Remedy not found");

            tip.TipTitle = updatedTip.TipTitle;
            tip.TipText = updatedTip.TipText;
            tip.Description = updatedTip.Description;
            tip.ImageUrl = updatedTip.ImageUrl;
            tip.Source = updatedTip.Source;
            tip.Category = updatedTip.Category;
            await _context.SaveChangesAsync();
            return Ok(tip);
        }

        // DELETE remedy
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTip(int id)
        {
            var tip = await _context.Tips.FindAsync(id);
            if (tip == null) return NotFound("Remedy not found");

            _context.Tips.Remove(tip);
            await _context.SaveChangesAsync();
            return Ok($"Remedy with ID {id} deleted successfully.");
        }
    }
}
