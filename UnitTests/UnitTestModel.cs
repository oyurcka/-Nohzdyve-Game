using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Game;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests
{
    /// <summary>
    /// Класс для тестирования модели игры
    /// </summary>
    [TestClass]
    public class UnitTestModel
    {
        /// <summary>
        /// Экземпляр игры
        /// </summary>
        private Game _modelGame;

        /// <summary>
        /// Инициализация перед каждым тестом
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            List<GameObject> GameObjects = new List<GameObject>() { new Man(10, 10, 2, 2), new Obstacle(25, 10, 1, 2) };
            _modelGame = new Game(GameObjects, 1);
        }

        /// <summary>
        /// Тест перемещения препятствия
        /// </summary>
        [TestMethod]
        public void TestMoveObstacle()
        {
            _modelGame.MoveObstacle();
            Assert.AreEqual(25, _modelGame.Obstacle.X);
        }

        /// <summary>
        /// Тест обработки действий
        /// </summary>
        [TestMethod]
        public void TestHandleAction()
        {
            _modelGame.HandleAction(GameAction.Escape);
            Assert.AreEqual(true, _modelGame.GameOver);
        }


        /// <summary>
        /// Тест создания игры
        /// </summary>
        [TestMethod]
        public void TestCreateGame()
        {
            _modelGame.CreateGame();
            Assert.AreEqual(TaskStatus.Created, _modelGame.GameTask.Status);
        }

        /// <summary>
        /// Тест начала игры
        /// </summary>
        [TestMethod]
        public void TestPlay()
        {
            _modelGame.CreateGame();
            _modelGame.Play();
            Assert.AreEqual(TaskStatus.WaitingToRun, _modelGame.GameTask.Status);
        }

        /// <summary>
        /// Тест остановки гры
        /// </summary>
        [TestMethod]
        public void TestStop()
        {
            _modelGame.CreateGame();
            _modelGame.Play();
            Assert.AreEqual(false, _modelGame.CancelTokenSource.IsCancellationRequested);
            _modelGame.Stop();
            Assert.AreEqual(true, _modelGame.CancelTokenSource.IsCancellationRequested);
        }

        /// <summary>
        /// Тест перемещения человечка
        /// </summary>
        [TestMethod]
        public void TestMoveMan()
        {
            _modelGame.MoveHorizontal(true, true);
            Assert.AreEqual(10, _modelGame.Man.Y);
        }

        /// <summary>
        /// Тест проверки врезался ли человечек в препятствие
        /// </summary>
        [TestMethod]
        public void TestCheckCrush()
        {
            _modelGame.Obstacle.X = 10;
            Assert.AreEqual(true, _modelGame.CheckCrush());
        }
    }
}
