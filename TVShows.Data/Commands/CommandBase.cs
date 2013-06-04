using System;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Windows.Shared;

namespace TVShows.Data
{
    public class CommandBehaviorBase<TReturn, TEventArgs> : BuilderCommandBehaviorBase<MenuItem, TEventArgs, TReturn>
    { }

    public class CommandBase<TBehavior> : ControlCommandBase<TBehavior, MenuItem> where TBehavior : CommandBehaviorBase<MenuItem>, new()
    { }

    public class UserCommandBehaviour<TReturn> : CommandBehaviorBase<TReturn, RoutedEventArgs>
    {
        public UserCommandBehaviour(Func<object, RoutedEventArgs, TReturn> builder)
        {
            this.builder = builder;
            this.CommandCanExecuteCheckEnabled = true;
        }

        public UserCommandBehaviour()
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

    public class UserCommand<T, TBehavior> : CommandBase<TBehavior> where TBehavior : UserCommandBehaviour<T>, new()
    { }
}
