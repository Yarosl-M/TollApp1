namespace TollApp
{
    public partial class Form1 : Form
    {
        public static readonly Random rng = new Random();
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
            // переключение на вкладку с симуляцией
            tabControl1.SelectedIndex = 0;
            // для семафоров
            var gateCount1 = (int)toll1GateCount.Value;
            var gateCount2 = (int)toll2GateCount.Value;
            tollSemaphore1 = new Semaphore(gateCount1, gateCount1);
            tollSemaphore2 = new Semaphore(gateCount2, gateCount2);
            // в цикле создаёт машины для двух пропускных пунктов
            Task.Run(() => CarGenerator(1));
            Task.Run(() => CarGenerator(2));
        }


        /*
         * в CarGenerator(n):
         * в бесконечном цикле создаёт машину, затем проверяет, есть ли свободный
         * шлагбаум-баум-баум
         *      если есть, то он добавляет машину в шлагбаумный список
         *      (первый или второй)
         *      и "обслуживает её", т. е.запускает отдельный метод
         *      (который не Task, но он просто запускает Task,
         *      которая выполняется асинхронно)
         *      там он ждёт какое-то время (среднее время ожидания, не экспоненциальное
         *      распределение), после этого удаляет машину из очереди ожидания,
         *      открывает семафор обратно, и затем что-то делает:
         *      для первого пункта с вероятностью p машина просто убирается
         *      иначе — переходит в очередь/обслуживается во второй пункт
         *      для второго пункта — просто убирается
         *      нужно будет отдельно сделать, чтобы тот же код управлял
         *      помещением машины во вторую очередь
         *      !!! также: после того, как машина убрана из шлагбаума,
         *      нужно будет достать одну машину из очереди!
         *      это, видимо, и есть TryAdmitблаблабла()
         *      
         *      если нет свободного места, добавляет в список очереди
         *      дальше? не знаю что дальше, пока что с этой очередью вроде как ничего
         *      не происходит
         *  и после этого ждёт какое-то время (случайное на основе среднего времени
         *  появления новых машин) перед повторением итерации цикла (и добавлением
         *  новой машины)
         */

        // создаёт новые машины, отправляет их либо к первому,
        // либо ко второму пункту пропуска (определяется по номеру)
        private async Task CarGenerator(int n)
        {
            double mean = n == 1 ? (double)CarArrivalInterval.Value
                : (double)highwayToll2Interval.Value;
            while (simulationRunning)
            {
                // ожидание между двумя машинами согласно экспоненциальному распределению
                double waitPeriod = NextExp(mean);

                Car car = new Car();
                // очередь на n-ый пункт пропуска
                // (туда добавляются машины, если все шлагбаумы заняты)
                var addQueue = n == 1 ? arrival1Queue : arrival2Queue;
                var semaphore = n == 1 ? tollSemaphore1 : tollSemaphore2;
                // список, соответствующий n-ому шлагбауму
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

                    // NOTE (█████_███████ reference)!!!
                    // декремент счётчика семафора выполняется уже здесь
                    // автоматически, это не нужно делать потом (но нужно
                    // будет его обратно возвращать)
                    canEnterGate = semaphore.WaitOne(TimeSpan.Zero);
                if (canEnterGate) // в семафор, на шлагбаум
                {
                    // декремент счётчика семафора уже был выполнен при
                    // успешном выполнении WaitOne() (в данной ветви вернул true)
                    ServiceCar(n, car);
                }
                else // в очередь
                {
                    // в таблицу для очереди
                    addQueue.Invoke(() =>
                    {
                        addQueue.Items.Add(car);
                    });
                    // после этого на шлагбаум "заберётся" машина из этой очереди
                    // когда в ServiceCar() закончится обслуживание другой машины
                }
                // собственно тот период ожидания
                await Task.Delay(TimeSpan.FromSeconds(waitPeriod));
            }
        }

        // обслуживает машину на n-ном пропускном пункте,
        // затем делает что-то дальше, в зависимости от номера
        // пропускного пункта (для n = 1 либо убирает машину вообще,
        // либо перенаправляет её на 2 пункт)
        // помимо этого, также после того, как машина убрана со
        // шлагбаума, он берёт новую машину из своей очереди
        private void ServiceCar(int n, Car car)
        {
            var semaphore = n == 1 ? tollSemaphore1 : tollSemaphore2;
            // список: шлагбаум/пункт пропуска
            var tollList = n == 1 ? toll1List : toll2List;
            // список: очередь на шлагбаум
            var queueList = n == 1 ? arrival1Queue : arrival2Queue;

            // сначала добавить в сам "шлагбаумный" список
            tollList.Invoke(tollList.Items.Add, car);
            // с Invoke() вызывающая функция ожидает окончания выполнения,
            // с BeginInvoke() вызывающая функция не ожидает окончания выполнения
            // и продолжает выполнение (иногда это может быть полезно,
            // иногда нет... в любом случае здесь не такие долгие операции)

            // далее, выполняется Task.Run()
            // т. е. он просто запускает выполнение этого кода, и при этом
            // не блокирует вызывающий поток, т. е. просто запускает это отдельно
            // и продолжает выполнение после Task.Run() (т. е. фактически выходит
            // из метода)
            // это значит, что не будет и бесконечной рекурсии при повторном вызове
            // метода ServiceCar() прямо отсюда 
            // (ну в любом случае выполнение прекратится, когда закончатся машины в очереди)
            Task.Run(async () =>
            {
                double serviceMeanTime = (double)tollsInterval.Value;
                double serviceTime = NextExp(serviceMeanTime);
                // ожидание "обслуживания" машины
                await Task.Delay(TimeSpan.FromSeconds(serviceTime));
                // убрать машину из своего "шлагбаумного" списка
                tollList.Invoke(tollList.Items.Remove, car);
                // и открыть семафор обратно
                //semaphore.Release();
                // теперь если ещё что-то есть в очереди, забрать
                //Car? car_maybe = queueList.Invoke<Car?>(() =>
                //{
                //    if (queueList.Items.Count == 0) return null;
                //    var car = queueList.Items[0] as Car;
                //    queueList.Items.RemoveAt(0);
                //    return car;
                //});
                // теперь если ещё что-то есть в очереди, забрать
                if (queueList.Invoke<int>(() => queueList.Items.Count) != 0)
                {
                    Car carfromQ = queueList.Invoke<Car>(() =>
                    {
                        Car car1 = queueList.Items[0] as Car;
                        // и, конечно, также убрать из очереди
                        queueList.Items.Remove(car1);
                        // первый в очереди забрать
                        return car1;
                    });
                    // опять декремент счётчика семафора
                    // (фактически то же самое, что и в CarGenerator(),
                    // только без проверки, хорошо
                    //semaphore.WaitOne(TimeSpan.Zero);
                    ServiceCar(n, carfromQ);
                }
                // просто на всякий случай, семафор будет "закрыт" всё время
                // от "выхода" предыдущей машины до того, как опустеет очередь
                else semaphore.Release();
                // теперь, что происходит дальше с исходной машиной
                if (n == 1) // первый шлагбаум:
                { // либо съезжает с шоссе, либо на второй пункт
                    if (new Random().NextDouble() < ((double)(probInput.Value) / 100.0))
                    {
                        // "съезжает с шоссе" (т. е. ничего больше не делать)
                        return;
                    }
                    else // на второй пункт
                    {
                        // добавляется в другой список,
                        // где просто отображается, какие машины
                        // едут ко второму пункту
                        travel2List.Invoke(
                            travel2List.Items.Add, car);
                        double travelMean = (double)tollsInterval.Value;
                        double travelTime = NextExp(travelMean);
                        // собственно ожидание проезда до второго пункта
                        await Task.Delay(TimeSpan.FromSeconds(travelTime));
                        // после этого на второй шлагбаум либо в очередь
                        if (tollSemaphore2 != null)
                        {   // сразу на второй шлагбаум
                            if (tollSemaphore2.WaitOne(TimeSpan.Zero))
                            {
                                ServiceCar(2, car);
                            }
                        }
                        else // в очередь
                        {
                            arrival2Queue.Invoke(() =>
                            {
                                arrival2Queue.Items.Add(car);
                            });
                            // после этого ServiceCar(2) автоматически заберёт
                            // машину из очереди, когда освободится место
                        }
                    }
                }
                else if (n == 2) // второй шлагбаум
                {
                    // в принципе, более ничего не нужно делать?
                    // старая машина убрана, новая (если есть) добавлена,
                    // больше ничего не происходит
                }
            }); // конец Task
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
            //if (!toll1List.Items.Contains(car)) return;
            toll1List.Invoke(toll1List.Items.Add, car); // not as good as GDScript's Callable.bind() but will do
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
                // теперь нужнО ещё будет попробовать достать машину из очереди
#pragma warning disable CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до тех пор, пока вызов не будет завершен
                // если в очереди есть что-то
                // TODO:!!!!!
                // 1) заменить на arrivalNQueue
                // 2) также удалять из очереди
                // всё то же самое повторять со вторым методом
                if (toll1List.Invoke<bool>(() =>
                {
                    return toll1List.Items.Count != 0;
                }))
                {
                    // тогда нужно забрать это что-то из очереди
                    Car carFromQ = toll1List.Invoke<Car>(() =>
                    {
                        return toll1List.Items[toll1List.Items.Count - 1] as Car;
                    });
                    // и затем что-то с этим делать (добавить на шлагбаум)
                    ServiceCar1(carFromQ);
                }
                // и теперь продолжаем с предыдущей машиной
#pragma warning restore CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до тех пор, пока вызов не будет завершен
                // далее, наверное, нужно что-то с ней делать, так?
                // с вероятностью P съезжает с шоссе (ничего не нужно делать)
                if (new Random().NextDouble() < ((double)(probInput.Value) / 100.0))
                {
                    return;
                }
                // или едет дальше на второй пункт
                else
                {
                    travel2List.Invoke(travel2List.Items.Add, car);
                    double travelMean = (double)tollsInterval.Value;
                    double travelTime = NextExp(travelMean);
                    await Task.Delay(TimeSpan.FromSeconds(travelTime));
                    travel2List.Invoke(travel2List.Items.Remove, car);
                    bool canEnterToll2 = false;
                    if (tollSemaphore2 != null)
                    {
                        canEnterToll2 = tollSemaphore2.WaitOne(TimeSpan.Zero);
                    }
                    // на шлагбаум сразу
                    if (canEnterToll2)
                    {
                        ServiceCar2(car);
                    }
                    else
                    {
                        arrival2Queue.Invoke(arrival2Queue.Items.Add, car);
                    }
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
            //if (!toll2List.Items.Contains(car)) return;
            toll2List.Invoke(toll2List.Items.Add, car);
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
                // больше ничего не нужно? на самом деле
                // тоже нужно добавить машину из очереди (второй)
                if (toll2List.Invoke<bool>(() =>
                {
                    return toll2List.Items.Count != 0;
                })) // если есть машины во второй очереди
                {
                    Car carfromQ = toll2List.Invoke<Car>(() =>
                    {
                        return toll2List.Items[toll2List.Items.Count - 1] as Car;
                    });
                    ServiceCar2(carfromQ);
                }
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
    }
}
