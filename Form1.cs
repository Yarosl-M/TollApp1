namespace TollApp
{
    public partial class Form1 : Form
    {
        public static readonly Random rng = new Random();
        // maybe we won't even need this?? idk
        private bool simulationRunning = false;
        private Semaphore tollSemaphore1;
        private Semaphore tollSemaphore2;

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
            tollSemaphore1 = new Semaphore(0, (int)toll1GateCount.Value);
            tollSemaphore2 = new Semaphore(0, (int)toll2GateCount.Value);
            Task.Run(() => CarGenerator(1));
            Task.Run(() => CarGenerator(2));
        }

        private async Task CarGenerator(int n)
        {
            double mean = n == 1 ? (double)CarArrivalInterval.Value
                : (double)highwayToll2Interval.Value;
            while (simulationRunning)
            {
                double waitPeriod = NextExp(mean);

                Car car = new Car();
                var addQueue = n == 1 ? arrival1Queue : arrival2Queue;
                var semaphore = n == 1 ? tollSemaphore1 : tollSemaphore2;
                //var tollTable = n == 1 ? toll1Table : toll2Table;
                var tollTable = n == 1 ? toll1List : toll2List;

                bool canEnterGate = false;
                if (semaphore != null)
                    // WaitOne() ждёт какое-то время и, если
                    // получает сигнал (в данном случае —
                    // освободился "шлагбаум"), возвращает true,
                    // возвращает false, если не дождался
                    // при времени ожидания = 0, как здесь, он
                    // просто смотрит, есть ли "свободное место"
                    // и сразу возвращает true/false
                    canEnterGate = semaphore.WaitOne(TimeSpan.Zero);
                if (canEnterGate) // в семафор, на шлагбаум
                {
                    tollTable.Invoke(() =>
                    {
                        tollTable.Items.Add(car);
                    });
                    ServiceCar(tollTable, semaphore, car);
                }
                else // в очередь, &*$%@# %@!$, в очередь!
                {
                    addQueue.Invoke(() =>
                    {
                        addQueue.Items.Add(car);
                    });
                }
                await Task.Delay(TimeSpan.FromSeconds(waitPeriod));
            }
        }

        private Car ServiceCar(ListBox tollList,
            Semaphore semaphore, Car car)
        {
            if (!tollList.Items.Contains(car)) return car;
            Task.Run(async () =>
            {
                double ServiceMeanTime = (double)tollsInterval.Value;
                // точно экспоненциальное?
                double serviceTime = NextExp(ServiceMeanTime);
                // ожидать какое-то время на шлагбауме (время обслуживания)
                await Task.Delay(TimeSpan.FromSeconds(serviceTime));
                // убрать машину из списка, соответствующего шлагбауму
                tollList.Invoke(() =>
                {
                    tollList.Items.Remove(car);
                });
                semaphore.Release();
                // далее, наверное, нужно что-то с ней делать, так?
                // ???
                return car;
            });
        }
        
        private void TryAdmitFromArrivalQueue(ListBox arrivalQueue,
            Semaphore semaphore, ListBox serviceList)
        {
            while (arrivalQueue.Items.Count > 0)
            {
                // проверяем, не занят ли семафор
                // (ожидание так же 0)
                if (!semaphore.WaitOne(0))
                {
                    // если занят (нет свободных шлагбаумов)
                    break;
                }
                // иначе (не занят, есть свободные шлагбаумы)
                Car next = arrivalQueue.Items[0] as Car;
                arrivalQueue.Items.Remove(next);
                serviceList.Invoke(() =>
                {
                    serviceList.Items.Add(next);
                });
                //ServiceCar(next);
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
                0.1, 7.5);
        }

        private void carTimer_Tick(object sender, EventArgs e)
        {
            if (simulationRunning) { }
        }
    }
}
