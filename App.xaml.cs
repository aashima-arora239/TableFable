///////////////////////////////////////////////////////////////////////////////
//  App.xaml.cs :Startup file                                                // 
//  ver 1.0                                                                  //  
//  Language:    C#                                                          //
//  Application: Table Fable - Tables in mathematics made easy               //
//  Author:      Infinite Loop Apps - iMagic Ventures Company                //
//  (c)Copyright Infinite Loop Apps - iMagic Ventures Company                //
///////////////////////////////////////////////////////////////////////////////

using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Tables
{
    /// <summary>
    /// Startup Class for the Windows8 App.
    /// </summary>
    sealed partial class App : Application
    {
        #region Constructor

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        #endregion 

        #region Event Handlers

        #region OnLaunched

        /// <summary>
        /// Handler for OnLaunched Event
        /// </summary>
        /// <param name="args">Event Arguments</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                Window.Current.Activate();
                return;
            }

            // QQ: Why do we need this?
            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                return;
            }

            // Navigate to the start screen.
            var rootFrame = new Frame();
            if (!rootFrame.Navigate(typeof(StartScreen)))
            {
                throw new Exception("Failed to create initial page");
            }

            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

        #endregion 

        #region OnSuspending

        /// <summary>
        /// Handler for OnSuspending event
        /// </summary>
        /// <param name="sender">Event Generator</param>
        /// <param name="e">Event Arguments</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            SuspendingDeferral suspendingDeferral = e.SuspendingOperation.GetDeferral();
            suspendingDeferral.Complete();
        }

        #endregion 

        #endregion
    }
}
