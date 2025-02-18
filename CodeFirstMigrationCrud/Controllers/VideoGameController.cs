using CodeFirstMigrationCrud.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstMigrationCrud.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class VideoGameController(VideoGameDbContext context) : ControllerBase
   {
      private readonly VideoGameDbContext _context = context;
      // The old Way I liked it but if you want to Avoid IDE Message use primary constructor method
      // private readonly VideoGameDbContext _context;
      //public VideoGameController(VideoGameDbContext context)
      //{
      //   this._context = context;
      //}
      [HttpGet]
      public async Task<IActionResult> GetAllVideoGame()
      {
         var result = await _context.VideoGames.ToListAsync();
         return Ok(result);
      }
      [HttpGet]
      [Route("getGameById/{id}")]
      public async Task<IActionResult> GetVideoGameById(int id)
      {
         var videoGame = await _context.VideoGames.FindAsync(id);
         if (videoGame is null)
         {
            return NotFound();
         }
         return Ok(videoGame);
      }
      [HttpPost("PostNewGame")]
      public async Task<IActionResult> PostVideoGame(VideoGame videoGame)
      {
         if (videoGame is null)
         {
            return BadRequest();
         }
         _context.VideoGames.Add(videoGame);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(GetVideoGameById), new { id = videoGame.Id }, videoGame);
      }
      [HttpPut("updateExitingVideoGame/{id}")]
      public async Task<IActionResult> UpdateVideoGame(int id , VideoGame videoGame)
      {
         var game = await _context.VideoGames.FindAsync(id);
         if (game is null)
         {
            return BadRequest();
         }
         game.Title = videoGame.Title;
         game.Platform = videoGame.Platform;
         game.Publisher = videoGame.Publisher;
         game.Developer = videoGame.Developer;
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(GetVideoGameById), new {id = game.Id } , videoGame);
      }
      [HttpDelete("DeleteVideoGameByID/{id}")]
      public async Task<IActionResult> DeleteVideoGameByID(int id)
      {
         var game = await _context.VideoGames.FindAsync(id);
         if (game is null)
         {
            return BadRequest();
         }
         _context.VideoGames.Remove(game);
         await _context.SaveChangesAsync();
         return NoContent();
      }
   }
}
