﻿namespace CryptoCatalog.Behaviors
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public sealed class HandleClickBehavior
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command", typeof(ICommand), typeof(HandleClickBehavior), new PropertyMetadata(default(ICommand), OnComandChanged));

        public static void SetCommand(DependencyObject element, ICommand value)
        {
            element.SetValue(CommandProperty, value);
        }

        public static ICommand GetCommand(DependencyObject element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
            "CommandParameter", typeof(object), typeof(HandleClickBehavior), new PropertyMetadata(default(object)));

        public static void SetCommandParameter(DependencyObject element, object value)
        {
            element.SetValue(CommandParameterProperty, value);
        }

        public static object GetCommandParameter(DependencyObject element)
        {
            return (object)element.GetValue(CommandParameterProperty);
        }

        private static void OnComandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as Control;
            if (c == null)
                throw new InvalidOperationException($"can only be attached to {nameof(Control)}");
            c.PreviewMouseLeftButtonDown -= OnMouseLeftButtonDown;
            if (GetCommand(c) != null)
                c.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
        }

        private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var d = sender as DependencyObject;
            if (d == null)
                return;
            var command = GetCommand(d);
            if (command == null)
                return;
            var parameter = GetCommandParameter(d);
            if (!command.CanExecute(parameter))
                return;
            command.Execute(parameter);
        }
    }
}
