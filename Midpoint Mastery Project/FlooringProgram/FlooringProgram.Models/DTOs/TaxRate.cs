namespace FlooringProgram.Models.DTOs
{
    public class TaxRate
    {
        public string State { get; set; }
        public decimal TaxPercent { get; set; }

    }
}
//This is our "data transfer object" for TaxRate, this is an object that carries TaxRate data between processes