namespace CodeFirstMigrationCrud
{
   public class VideoGame
   {
      public int Id { get; set; }
      public string? Title { get; set; }
      public string? Platform { get; set; }
      public string? Developer { get; set; }

      public string? Publisher { get; set; }
      public VideoGame() {
         Id = 0;
         Title = string.Empty;
         Platform = string.Empty;   
         Developer = string.Empty;
         Publisher = string.Empty;
      }

   }
}
