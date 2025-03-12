namespace WebApplication1.Entities
{
    public class TrainingSession
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Trainer { get; set; }
        public string Location { get; set; }
    }
}
