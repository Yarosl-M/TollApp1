namespace TollApp
{
    public partial class Form1 : Form
    {
        public static readonly Random rng = new Random();
        private bool simulationRunning = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            foreach (NumericUpDown input in new[] {
                carArriveIntervalInput, toll1Interval,
                CarArrivalInterval, tollsInterval,
                highwayToll2Interval, toll1GateCount,
                toll2GateCount
            })
            {
                input.Value = 1;
            }
            pInput.Value = 25;
        }

        // запуск симуляции
        private void button1_Click(object sender, EventArgs e)
        {
            simulationRunning = true;
            tabControl1.SelectedIndex = 0;
            Task.Run(() => CarGenerator());
            Task.Run(() => CarGenerator2());
        }

        // создаёт машины для первого пункта
        private async Task CarGenerator()
        {
            double mean = (double)CarArrivalInterval.Value;
            while (simulationRunning)
            {
                double waitPeriod = NextExp(mean);

                var car = new Car();
                
                arrival1Queue.Invoke(() =>
                {
                    arrival1Queue.Items.Add(car);
                });
                await Task.Delay(TimeSpan.FromSeconds(waitPeriod));
            }
        }

        // создаёт машины для второго пункта (те, что подъезжают
        // с другого шоссе)
        private async Task CarGenerator2()
        {
            double mean = (double)highwayToll2Interval.Value;
            while (simulationRunning)
            {
                double waitPeriod = NextExp(mean);
                var car = new Car();
                arrival2Queue.Invoke(() =>
                {
                    arrival2Queue.Items.Add(car);
                });
                await Task.Delay(TimeSpan.FromSeconds(waitPeriod));
            }
        }


        // должно вернуть случайное число с экспоненциальным
        // распределением (также дополнительно ограничено сверху
        // и снизу)
        public static double NextExp(double meanSeconds)
        {
            Random rng = new Random();
            double u = rng.NextDouble();
            double lambda = 1.0 / meanSeconds;
            return Math.Clamp(-Math.Log(1.0 - u) / lambda,
                0.15, 5.0);
            
        }
    }
}
