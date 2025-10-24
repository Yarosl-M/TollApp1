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
            probInput.Value = 25;
        }

        // запуск симуляции
        private void button1_Click(object sender, EventArgs e)
        {
            simulationRunning = true;
            tabControl1.SelectedIndex = 0;
            var gateCount1 = (int)toll1GateCount.Value;
            var gateCount2 = (int)toll2GateCount.Value;
            tollSemaphore1 = new Semaphore(gateCount1, gateCount1);
            tollSemaphore2 = new Semaphore(gateCount2, gateCount2);
            Task.Run(() => CarGenerator(1));
            Task.Run(() => CarGenerator(2));
        }

        // создаёт новые машины, отправляет их либо к первому,
        // либо ко второму пункту пропуска (определяется по номеру)
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
                    if (n == 1)
                        ServiceCar1(car);
                    else if (n == 2)
                        ServiceCar2(car);
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

        // обслуживает машину на первом пропускном пункте
        // (когда она УЖЕ прошла очередь (если она была))
        // т. е. семафор уже тоже отсчитал
        // т. е. это добавление на один из "шлагбаумов"-"баумов"-"баумов"
        // затем: извлечение из первого пропускного пункта,
        // затем либо машина продолжает в очередь на второй пункт,
        // либо съезжает с шоссе
        private void ServiceCar1(Car car)
        {
            if (toll1List.Items.Contains(car)) return;
            Task.Run(async () =>
            {
                double ServiceMeanTime = (double)tollsInterval.Value;
                // точно экспоненциальное?
                //double serviceTime = NextExp(ServiceMeanTime);
                double serviceTime = (new Random())
                .NextDouble() * 5.0 + 0.1;
                // ожидать какое-то время на шлагбауме (время обслуживания)
                await Task.Delay(TimeSpan.FromSeconds(serviceTime));
                // убрать машину из списка, соответствующего шлагбауму
                toll1List.Invoke(() =>
                {
                    toll1List.Items.Remove(car);
                });
                tollSemaphore1.Release();
                // далее, наверное, нужно что-то с ней делать, так?
                // с вероятностью P съезжает с шоссе (ничего не нужно делать)
                if (new Random().NextDouble() < ((double)(probInput.Value) / 100.0))
                {
                    return;
                }
                // или едет дальше на второй пункт
                else
                {

                }
            });
        }

        // обслуживает машину на втором пропускном пункте
        // (так же, когда она уже прошла очередь и семафор уже
        // сработал
        // затем: машина только съезжает с шоссе
        // (т. е. просто удаляется)
        private void ServiceCar2(Car car)
        {
            if (toll2List.Items.Contains(car)) return;
            Task.Run(async () =>
            {
                // dt2 - среднее время обслуживания одинаково
                // для обоих пунктов
                double serviceMeanTime = (double)tollsInterval.Value;
                double serviceTime = new Random()
                .NextDouble() * 5.0 + 0.1;
                // ожидать какое-то время на шлагбауме
                await Task.Delay(TimeSpan.FromSeconds(serviceTime));
                toll2List.Invoke(() =>
                {
                    toll2List.Items.Remove(car);
                });
                tollSemaphore2.Release();
                // всё, конец
            });
        }

        // что это такое??????
        // serviceList - это шлагбаум???
        private void TryAdmitFromArrivalQueue(int n)
        {
            var arrivalQueue = n == 1 ? arrival1Queue : arrival2Queue;
            var semaphore = n == 1 ? tollSemaphore1 : tollSemaphore2;
            var serviceList = n == 1 ? toll1List : toll2List;
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
