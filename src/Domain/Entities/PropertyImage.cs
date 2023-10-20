namespace Domain.Entities
{
    public class PropertyImage
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public byte[] File { get; set; }
        public bool Enabled { get; set; }

        public Property Property { get; set; }
    }
}
