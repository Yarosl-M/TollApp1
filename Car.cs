namespace TollApp
{
    public class Car
    {
        private static Random rng = new Random();
        private static int counter = 0;
        private const string letters =
            "АБВГДЕЖЗИКЛМНОПРСТУФХЦЧШЭЮЯ";
        public string LicenseNumber { get; set; }
        public int Id { get; set; }
        public Color Color { get; set; }
        public Car()
        {
            Id = ++counter;
            Color = Color.FromArgb(
                rng.Next(256), rng.Next(256), rng.Next(256));
            int len = letters.Length;
            LicenseNumber =
                letters[rng.Next(len)].ToString()
                + letters[rng.Next(len)].ToString()
                + '-'
                + (char)rng.Next(10)
                + (char)rng.Next(10);
        }
        public override string ToString()
        {
            return LicenseNumber;
        }
    }
}
