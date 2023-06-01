namespace FirstMvc.Models
{
    public class Talaba
    {
        public int Id { get; set; }
        public string? Ismi { get; set; }
        public int Yoshi { get; set; }
        public string? Manzili { get; set; }
        public string ImageURL { get; set; }
        public Unversitet Unversitets { get; set; }
    }
}
