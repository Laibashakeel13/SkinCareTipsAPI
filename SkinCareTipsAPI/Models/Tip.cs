namespace SkinCareTipsAPI.Models
{
    public class Tip
    {
        public int Id { get; set; }
        public string TipTitle { get; set; }      
        public string TipText { get; set; }   
        public string Description { get; set; }       
        public string ImageUrl { get; set; }      
        public string Source { get; set; }
        public string Category { get; set; }
    }
}
