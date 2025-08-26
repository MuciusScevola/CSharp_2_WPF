using System.Windows.Input;

namespace Theme09_Task01
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand ChangeColor = new RoutedUICommand(
            "Изменить цвет",
            "ChangeColor",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.C, ModifierKeys.Control)
            }
        );
    }
}