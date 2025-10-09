namespace TollApp
{
    public class Car
    {
        private static Random rng = new Random();
        private static int counter = 0;
        private static object counter_lock = new();
        private const string letters =
            "АБВГДЕЖЗИКЛМНОПРСТУФХЦЧШЭЮЯ";
        public string LicenseNumber { get; set; }
        public int Id { get; set; }
        public Color Color { get; set; }
        public Car()
        {
            lock (counter_lock)
            {
                Id = ++counter;
            }
            Color = Color.FromArgb(
                rng.Next(256), rng.Next(256), rng.Next(256));
            int len = letters.Length;
            LicenseNumber =
                letters[rng.Next(len)].ToString()
                + letters[rng.Next(len)].ToString()
                + '-'
                + rng.Next(10).ToString()
                + rng.Next(10).ToString();
        }
        public override string ToString()
        {
            return LicenseNumber;
        }
    }
}
