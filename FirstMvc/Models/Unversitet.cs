namespace FirstMvc.Models
{
    public class Unversitet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Talaba> Talabas { get; set; }
        public string ImageURL { get; set; }
        public Unversitet()
        {
            Talabas = new List<Talaba>();
        }
    }
}
