namespace SalesOrderManagement.Api.Entities
{
    public class Glass
    {
        public int Id { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }

        public List<Glass> GetGlasses()
        {
            var glasses = new List<Glass>() { new Glass { Id = 1, Height = 2, Width = 2 }, new Glass { Id = 2, Height = 2, Width = 2 } };
            for (int i = 0; i < glasses.Count; i++)
            {
                for (int j = i + 1; j < glasses.Count; j++)
                {
                    if (glasses[j].Height > glasses[j].Height)
                    {
                        var temp = glasses[i];
                        glasses[i] = glasses[j];
                        glasses[j] = temp;
                    }
                }
            }

            return glasses;
        }
    }

}
