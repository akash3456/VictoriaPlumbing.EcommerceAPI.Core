namespace VictoriaPlumbing.EcommerceAPI.Core
{
    public class ValidationResult
    {

        public bool Result { get; set; } = true;

        public List<string> Messages { get; set; } = new List<string>();

    }
}
