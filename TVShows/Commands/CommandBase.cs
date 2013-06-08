using System;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Windows.Shared;

namespace TVShows
{
    public class CommandBehaviorBase<TReturn, TEventArgs> : BuilderCommandBehaviorBase<MenuItem, TEventArgs, TReturn>
    { }

    public class CommandBase<TBehavior> : ControlCommandBase<TBehavior, MenuItem> where TBehavior : CommandBehaviorBase<MenuItem>, new()
    { }

    public class CommandBehaviour<TReturn> : CommandBehaviorBase<TReturn, RoutedEventArgs>
    {
        public CommandBehaviour(Func<object, RoutedEventArgs, TReturn> builder)
        {
            this.builder = builder;
            this.CommandCanExecuteCheckEnabled = true;
        }

        public CommandBehaviour()
            : this(null)
        { }

        /// <summary>
        /// Called when [target attached].
        /// </summary>
        protected override void OnTargetAttached()
        {
            (TargetObject as MenuItem).Click += new RoutedEventHandler(OnEventRaised);
        }
    }

    public class Command<T, TBehavior> : CommandBase<TBehavior> where TBehavior : CommandBehaviour<T>, new()
    { }
}
