namespace FlooringProgram.Models.DTOs
{
    public class Product
    {
        public string ProductType { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
    }
}
//This is our "data transfer object" for Product, this is an object that carries Product data between processes