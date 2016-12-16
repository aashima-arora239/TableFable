using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Tables
{
    public sealed partial class TYSLevelSelection : Tables.Common.LayoutAwarePage
    {


        #region Constructor

        public TYSLevelSelection()
        {
            this.InitializeComponent();
            EasyButton.DataContext = Level.Easy;
            MediumButton.DataContext = Level.Medium;
            DifficultButton.DataContext = Level.Difficult;

        } 

        #endregion

        #region EventHandler
        /// <summary>
        /// Handles Tapped event when a particular level is tapped on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        #endregion

        #region Methods

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }


        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
        
        #endregion

        private void onLevelClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Button source = sender as Button;
            if (source != null)
            {
                this.Frame.Navigate(typeof(TestYourSkills), source.Content.ToString());
            }

        }
    }
}
