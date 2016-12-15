/////////////////////////////////////////////////////////////////////////////////////////////
//  TestYourSkillsLevelSelection.xaml.cs : File defines a class that corresponds to the    //
//  Level selection screen of "Test Your Skills" feature.                                  //
//  ver 1.0                                                                                //  
//  Language:    C#                                                                        //
//  Application: Table Fable - Tables in mathematics made easy                             //
//  Author:      Infinite Loop Apps - iMagic Ventures Company                              //
//  (c)Copyright Infinite Loop Apps - iMagic Ventures Company                              //
/////////////////////////////////////////////////////////////////////////////////////////////

using Windows.UI.Xaml.Controls;

namespace Tables
{
    #region Class TestYourSkillsLevelSelection

    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class TestYourSkillsLevelSelection : Tables.Common.LayoutAwarePage
    {
        #region Constructor

        public TestYourSkillsLevelSelection()
        {
            this.InitializeComponent();
            EasyButton.DataContext = Levels.Easy;
            MediumButton.DataContext = Levels.Medium;
            DifficultButton.DataContext = Levels.Difficult;
        }

        #endregion 

        #region EventHandlers

        #region onLevelClicked

        /// <summary>
        /// Handles Tapped event when a easy level is tapped on.
        /// </summary>
        /// <param name="sender">Button that was clicked</param>
        /// <param name="e">Event Arguments</param>
        private void onLevelClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string tag = button.Tag as string;
                if (string.IsNullOrEmpty(tag) == false)
                {
                    LevelWrapper levelWrapper = new LevelWrapper();
                    switch (tag.ToLower())
                    {
                        case "easy":
                            levelWrapper.LevelValue = Levels.Easy;
                            break;

                        case "medium":
                            levelWrapper.LevelValue = Levels.Medium;
                            break;

                        case "difficult":
                            levelWrapper.LevelValue = Levels.Difficult;
                            break;
                    }
                    this.Frame.Navigate(typeof(TestYourSkills), levelWrapper);
                }
            }
        }
        #endregion 

         #endregion
    }

    #endregion 
}
