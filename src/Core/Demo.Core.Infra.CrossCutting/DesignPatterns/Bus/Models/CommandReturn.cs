namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models
{
    public class CommandReturn
    {
        public bool Success { get; set; }
        public bool Continue { get; set; }
    }
}
