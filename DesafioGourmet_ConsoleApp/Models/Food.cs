namespace DesafioGourmet_ConsoleApp.Models
{
    public class Food
    {
        public string Name { get; set; }
        public string Classification { get; set; }
        public bool InitialValues { get; set; }

        public Food(string name, string classification, bool initialValue = false)
        {
            Name = name;
            Classification = classification;
            InitialValues = initialValue;
        }
    }
}
