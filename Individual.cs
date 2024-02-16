namespace EpidemiologyKDR
{
    // Individual.cs
    public class Individual
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Symptoms { get; set; }
        public bool Diagnosed { get; set; }
        public DateTime Date_Diagnosed { get; set; }
    }

}
