////////////////////////////////////////////////////////////////////////////////////////
//  StartScreen.xaml.cs : File defines the class representing the start screen where  //
//                        selection for features will be made product of two numbers. // 
//  ver 1.0                                                                           //  
//  Language:    C#                                                                   //
//  Application: Table Fable - Tables in mathematics made easy                        //
////////////////////////////////////////////////////////////////////////////////////////

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Tables
{

    #region Class StartScreen

    /// <summary>
    /// The first screen that shows up when the application is launched. This gives an option to go to "Table Fable" or "Test your skills"
    /// </summary>
    public sealed partial class StartScreen : Page
    {
        #region Constructors

        public StartScreen()
        {
            this.InitializeComponent();
        }

        #endregion 

        #region Event Handlers

        #region OnNavigatedTo

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        #endregion 

        #region onTableFableTapped

        /// <summary>
        /// Event handler for the tapped event when Table Fable is selected.
        /// </summary>
        /// <param name="sender">The object that generated the event.</param>
        /// <param name="e">TappedRouted EventArgs</param>
        private void onTableFableTapped(object sender, TappedRoutedEventArgs e)
        {
            // Navigate to table fable
            this.Frame.Navigate(typeof(TableFable));
        }

        #endregion 

        #region onTestYouSkillsTapped

        /// <summary>
        /// Event handler for the tapped event when "Test Your Skills" is selected.
        /// </summary>
        /// <param name="sender">The object that generated the event.</param>
        /// <param name="e">TappedRouted EventArgs</param>
        private void onTestYouSkillsTapped(object sender, TappedRoutedEventArgs e)
        {
            // Navigate to test your skills
            this.Frame.Navigate(typeof(TestYourSkillsLevelSelection));
        }

        #endregion 

        #endregion 
    }

    #endregion 

}
