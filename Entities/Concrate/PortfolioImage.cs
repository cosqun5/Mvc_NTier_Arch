namespace Entities.Concrate
{
	public class PortfolioImage
	{
		public int Id { get; set; }
		public string Path { get; set; }
		public bool IsActive { get; set; }
		public int PortfolioId { get; set; }
		public Portfolio Portfolio { get; set; }
	}
}
