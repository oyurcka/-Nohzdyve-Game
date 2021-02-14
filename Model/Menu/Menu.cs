using System.Collections.Generic;

namespace Model.Menu
{
    /// <summary>
    /// Класс, описывающий меню
    /// </summary>
    public class Menu : SubMenuItem
    {
        /// <summary>
        /// Делегат, вызываемый при необходимости отрисовки
        /// </summary>
        public delegate void dNeedRedraw();

        /// <summary>
        /// Событие, возникающее при еобходимости отрисовки
        /// </summary>
        public event dNeedRedraw NeedRedraw = null;

        /// <summary>
        /// Индекс текущего выделенного элемента
        /// </summary>
        public int FocusedItemIndex { get; protected set; } = -1;

        /// <summary>
        /// Конструктор меню
        /// </summary>
        /// <param name="parName">Имя меню</param>
        public Menu(string parName) : base(0, parName)
        {
        }

        /// <summary>
        /// Выделить следующий элемент меню
        /// </summary>
        public void FocusNext()
        {
            int prevFocusedIndex = FocusedItemIndex;

            if (FocusedItemIndex == Items.Length - 1)
            {
                FocusedItemIndex = 0;
            }
            else
            {
                FocusedItemIndex++;
            }

            Items[FocusedItemIndex].State = States.Focused;
            Items[prevFocusedIndex].State = States.Normal;

            NeedRedraw?.Invoke();
        }

        /// <summary>
        /// Выделить предыдущий элемент меню
        /// </summary>
        public void FocusPrevious()
        {
            int prevFocusedIndex = FocusedItemIndex;

            if (FocusedItemIndex == 0)
            {
                FocusedItemIndex = Items.Length - 1;
            }
            else
            {
                FocusedItemIndex--;
            }

            Items[FocusedItemIndex].State = States.Focused;
            Items[prevFocusedIndex].State = States.Normal;

            NeedRedraw?.Invoke();
        }

        /// <summary>
        /// Выделить элемент с заданным индексом
        /// </summary>
        /// <param name="parId">Индекс элемента</param>
        public void FocusItemById(int parId)
        {
            int prevFocusedIndex = FocusedItemIndex;
            MenuItem menuItem = this[parId];
            FocusedItemIndex = new List<MenuItem>(Items).IndexOf(menuItem);

            if (prevFocusedIndex != -1)
            {
                Items[prevFocusedIndex].State = States.Normal;
            }
            Items[FocusedItemIndex].State = States.Focused;
        }

        /// <summary>
        /// Выбрать выделенный элемент
        /// </summary>
        public void SelectFocusedItem()
        {
            Items[FocusedItemIndex].State = States.Selected;
            NeedRedraw?.Invoke();
        }
    }
}