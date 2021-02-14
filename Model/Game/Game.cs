using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Model.Menu;

namespace Model.Game
{
    /// <summary>
    /// Базовая модель игры
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Скорость игры
        /// </summary>
        private const int GAME_SPEED = 50;

        /// <summary>
        /// Скорость движения
        /// </summary>
        private const int MOVE_SPEED = 30;

        /// <summary>
        /// Рандомайзер
        /// </summary>
        private Random _random = new Random();

        /// <summary>
        /// Игровая задача для выполения в отдельном потоке
        /// </summary>
        private Task _gameTask = null;

        /// <summary>
        /// Игровая задача движения для выполения в отдельном потоке
        /// </summary>
        private Task _movegameTask = null;

        /// <summary>
        /// Токен для завершения задачи _gameTask
        /// </summary>
        private CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        /// <summary>
        /// Токен для завершения задачи _movegameTask
        /// </summary>
        private CancellationTokenSource _mcancelTokenSource = new CancellationTokenSource();

        /// <summary>
        /// Человечек
        /// </summary>
        private Man _man;

        /// <summary>
        /// Препятствие
        /// </summary>
        private Obstacle _obstacle;

        /// <summary>
        /// Стены слева
        /// </summary>
        private Walls _leftwall;

        /// <summary>
        /// Стены справа
        /// </summary>
        private Walls _rightwall;

        /// <summary>
        /// Делегат, вызываемый при изменении данных и необходимости перерисовки
        /// </summary>
        public delegate void dNeedRedraw();

        /// <summary>
        /// Событие, возникающее при необходимости перерисовки
        /// </summary>
        public event dNeedRedraw NeedRedraw = null;

        /// <summary>
        /// Делегат, вызываемый при необходимости открытия меню
        /// </summary>
        public delegate void dShowMenu();

        /// <summary>
        /// Событие, возникающее при необходимости открытия меню
        /// </summary>
        public event dShowMenu ShowMenu = null;

        /// <summary>
        /// Игровая задача для выполения в отдельном потоке
        /// </summary>
        public Task GameTask { get => _gameTask; set => _gameTask = value; }

        /// <summary>
        /// Токен для завершения задачи _gameTask
        /// </summary>
        public CancellationTokenSource CancelTokenSource { get => _cancelTokenSource; set => _cancelTokenSource = value; }

        /// <summary>
        /// Состояние игры (true - игра окончена)
        /// </summary>
        public bool GameOver { get; private set; } = false;

        /// <summary>
        /// Состояние игры (true - если нужен выход из игры)
        /// </summary>
        public bool NeedExit { get; set; } = false;

        /// <summary>
        /// Счет игры
        /// </summary>
        public int Score { get; set; } = 0;

        /// <summary>
        /// Состояние игры, когда Man двигается влево
        /// </summary>
        private bool IsMovingLeft { get; set; } = false;

        /// <summary>
        /// Состояние игры, когда Man двигается вправо
        /// </summary>
        private bool IsMovingRight { get; set; } = false;

        /// <summary>
        /// Состояние игры, когда Man не может двигатсья влево
        /// </summary>
        private bool LeftUnavailable { get; set; } = false;

        /// <summary>
        /// Состояние игры, когда Man не может двигатсья вправо
        /// </summary>
        private bool RightUnavailable { get; set; } = false;

        /// <summary>
        /// Скорость движения человечка
        /// </summary>
        private int MovingSpeed { get; set; } = 10;

        /// <summary>
        /// Текущее отклонение от центра
        /// </summary>
        private int CenterDeviation { get; set; } = 0;

        /// <summary>
        /// Человечек
        /// </summary>
        public Man Man { get => _man; set => _man = value; }

        /// <summary>
        /// Препятствие
        /// </summary>
        public Obstacle Obstacle { get => _obstacle; set => _obstacle = value; }

        /// <summary>
        /// Стены слева
        /// </summary>
        public Walls LeftWalls { get => _leftwall; set => _leftwall = value; }

        /// <summary>
        /// Стены справа
        /// </summary>
        public Walls RightWalls { get => _rightwall; set => _rightwall = value; }

        /// <summary>
        /// Список игровых объектов
        /// </summary>
        public List<GameObject> GameObjects;

        /// <summary>
        /// Ширина игры
        /// </summary>
        public int Width { get; private set; } = 50;

        /// <summary>
        /// Высота игры
        /// </summary>
        public int Height { get; private set; } = 35;

        /// <summary>
        /// Коэффициент разрешения
        /// </summary>
        public int DrawCoefficient { get; private set; } = 10;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parGameObjects"></param>
        /// <param name="parDrawCoefficient"></param>
        public Game(List<GameObject> parGameObjects, int parDrawCoefficient)
        {
            GameObjects = parGameObjects;
            DrawCoefficient = parDrawCoefficient;
            SplitList();
            LeftWalls = new Walls(Man.X - 12 * DrawCoefficient, DrawCoefficient);
            RightWalls = new Walls(Man.X + 12 * DrawCoefficient, DrawCoefficient);
        }

        /// <summary>
        /// Инициализирует игровые задачи
        /// </summary>
        private void InitGame()
        {
            _gameTask = new Task(TickAction, _cancelTokenSource.Token);
            _movegameTask = new Task(MoveMan, _mcancelTokenSource.Token);
        }

        /// <summary>
        /// Игровой период
        /// </summary>
        private void TickAction()
        {
            do
            {
                Thread.Sleep(GAME_SPEED);
                if (!GameOver)
                {
                    Action();
                    NeedRedraw?.Invoke();
                }
            } while (!_cancelTokenSource.Token.IsCancellationRequested);
        }

        /// <summary>
        /// Выполняет игровое действие
        /// </summary>
        private void Action()
        {
            if (Obstacle.Y < 0)
            {
                Obstacle.Y = _random.Next(30, 50) * DrawCoefficient;
                Obstacle.X = _random.Next(15, 30) * DrawCoefficient;
                Score++;
            }
            MoveObstacle();
        }

        /// <summary>
        /// Записывает в файл новый рекорд
        /// </summary>
        private void MakeRecord()
        {
            Thread thread = new Thread(new ThreadStart(() => ScoreRecorder.AddRecord(new Record(Score))));
            thread.Start();    
        }

        /// <summary>
        /// Запускает игровые задачи
        /// </summary>
        public void Play()
        {
            if (_gameTask.Status != TaskStatus.Running)
            {
                _gameTask.Start();
            }
            if (_movegameTask.Status != TaskStatus.Running)
            {
                _movegameTask.Start();
            }
        }

        /// <summary>
        /// Горизонтальное перемещение
        /// </summary>
        /// <param name="parMove"></param>
        /// <param name="parIsMovingLeft"></param>
        public void MoveHorizontal(bool parMove, bool parIsMovingLeft)
        {
            if (!GameOver)
            {
                if (parMove == true) {
                    if (parIsMovingLeft == true)
                    { Man.X -= DrawCoefficient; }
                    else
                    { Man.X += DrawCoefficient; }  
                }
            }
        }

        /// <summary>
        /// Перемещения препятствия
        /// </summary>
        public void MoveObstacle()
        {
            Obstacle.Y -= DrawCoefficient;
        }

        /// <summary>
        /// Обработать игровое действие
        /// </summary>
        /// <param name="parGameAction">Игровое действие</param>
        public void HandleAction(GameAction parGameAction)
        {
            switch (parGameAction)
            {
                case GameAction.Left:
                    if (!this.GameOver)
                    {
                        this.ChangeMoveState(true, false);
                    }
                    break;
                case GameAction.Right:
                    if (!this.GameOver)
                    {
                        this.ChangeMoveState(false, true);
                    }
                    break;
                case GameAction.Escape:
                    this.Stop();
                    NeedExit = true;
                    ShowMenu?.Invoke();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Останавливает игровую задачу
        /// </summary>
        public void Stop()
        {
            _cancelTokenSource.Cancel();
            _mcancelTokenSource.Cancel();
            GameOver = true;
            NeedRedraw?.Invoke();
            MakeRecord();
        }

        /// Проверка столкновения
        /// </summary>
        /// <returns></returns>
        public bool CheckCrush()
        {
            if (Man.Rect.IntersectsWith(Obstacle.Rect))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод движения человечка
        /// </summary>
        private void MoveMan()
        {
            do
            {
                Thread.Sleep(MOVE_SPEED);
                if (IsMovingLeft && !LeftUnavailable)
                {
                    MoveHorizontal(true, IsMovingLeft);
                    CenterDeviation++;
                    RightUnavailable = false;
                    if (CenterDeviation == MovingSpeed)
                    {
                        IsMovingLeft = false;
                        IsMovingRight = false;
                        LeftUnavailable = true;
                    }
                }
                else if (IsMovingRight && !RightUnavailable)
                {
                    MoveHorizontal(true, IsMovingLeft);
                    CenterDeviation--;
                    LeftUnavailable = false;
                    if (CenterDeviation == -1 * MovingSpeed + 1)
                    {
                        IsMovingRight = false;
                        IsMovingLeft = false;
                        RightUnavailable = true;
                    }
                }
                if (CenterDeviation == 0)
                {
                    MoveHorizontal(false, IsMovingLeft);
                    IsMovingRight = false;
                    IsMovingLeft = false;
                    LeftUnavailable = false;
                    RightUnavailable = false;
                }

                if (CheckCrush())
                {
                    Stop();
                }

                if (!GameOver)
                {
                    NeedRedraw?.Invoke();
                }

            } while (!_mcancelTokenSource.Token.IsCancellationRequested);
        }

        /// <summary>
        /// Изменение состояние движения 
        /// </summary>
        private void ChangeMoveState(bool parIsMovingLeft, bool parIsMovingRight)
        {
            if (parIsMovingLeft)
            {
                IsMovingLeft = true;
                IsMovingRight = false;
            }
            else if (parIsMovingRight)
            {
                IsMovingRight = true;
                IsMovingLeft = false;
            }
            else if (!IsMovingRight || !IsMovingLeft)
            {
                IsMovingRight = false;
                IsMovingLeft = false;
            }
        }

        /// <summary>
        /// Создание игры
        /// </summary>
        public void CreateGame()
        {
            InitGame();
        }

        /// <summary>
        /// Выделение из списка игровых объектов конкретных экземпляров
        /// </summary>
        private void SplitList()
        {
            foreach (GameObject elObj in this.GameObjects)
            {
                if (elObj is Man)
                {
                    Man = (Man)elObj;
                }
                else
                {
                    Obstacle = (Obstacle)elObj;
                }
            }
        }
    }
}
