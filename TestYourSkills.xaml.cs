/////////////////////////////////////////////////////////////////////////////////////////////////////
//  TestYourSkills.xaml.cs : File defines a class that corresponds to "Test Your Skills" feature.  //
//  ver 1.0                                                                                        //  
//  Language:    C#                                                                                //
//  Application: Table Fable - Tables in mathematics made easy                                     //
//  Author:      Infinite Loop Apps - iMagic Ventures Company                                      //
//  (c)Copyright Infinite Loop Apps - iMagic Ventures Company                                      //
/////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Linq;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Tables
{
    #region Class TestYourSkills

    /// <summary>
    /// Class to perform tasks that will be done in TestYourSkills feature
    /// </summary>
    public sealed partial class TestYourSkills : Tables.Common.LayoutAwarePage
    {
        #region Private Members

        private List<TestCase> testCases = new List<TestCase>();
        List<Product> distinctQuestions = new List<Product>();
        private int numberOfQuestions = 30;
        private int lowerLimit = 1;
        private int upperLimit = 99;
        private int optionMax = 999;

        #endregion

        #region Constructor 

        public TestYourSkills()
        {
            this.InitializeComponent();

        } 
        #endregion

        #region EventHandlers

        #region CheckOnClick
        /// <summary>
        /// Click Handler for a radio Button. Concludes whether the option selected is the right answer or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckOnClick(object sender, RoutedEventArgs e)
        {
            
            RadioButton rb = sender as RadioButton;
            if ((rb != null) && rb.IsChecked == true)
            {
                int optionSelected = Convert.ToInt32(rb.Content);
                //Retrieve Current FlipView Selected Item.
                TestCase test = (TestCase)flipview.SelectedItem;
                
                //Construct Product Object from test elements.
                Product p = new Product(test.Question.Multiplier, test.Question.Multiplicand, optionSelected);

                //Check Answer using ValidateProduct Method.
                bool correct = Utils.ValidateProduct(p);
                
                if (correct)
                {
                    test.Remark = "Correct!";
                    test.Answer = optionSelected.ToString();

                }
                else
                {
                    test.Remark = "Incorrect!";
                }
            }

        }

        #endregion 

        #region OnNavigatedTo

        /// <summary>
        /// Invoked when a level is selected and generates appropriate questions.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LevelWrapper level = e.Parameter as LevelWrapper;

            if (level != null)
            {
                Levels levelValue = level.LevelValue;

                switch (levelValue)
                {
                    case Levels.Easy:
                        lowerLimit = 1;
                        upperLimit = 10;
                        optionMax = 100;
                        break;

                    case Levels.Medium:
                        lowerLimit = 11;
                        upperLimit = 30;
                        optionMax = 500;
                        break;

                    case Levels.Difficult:
                        lowerLimit = 31;
                        upperLimit = 60;
                        optionMax = 999;
                        break;

                    default:
                        lowerLimit = 1;
                        upperLimit = 99;
                        optionMax = 999;
                        break;
                }
            }

            // Generates Questions and Options in FlipView Items.
            this.GenerateTestCases(lowerLimit, upperLimit, optionMax, this.numberOfQuestions);

            //Set Data Context of FlipView.
            flipview.DataContext = testCases;

            base.OnNavigatedTo(e);
        }
        #endregion 

        #endregion

        #region Methods

        #region GenerateTestCases

        /// <summary>
        /// Generates Questions And Answers for Flipview.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="optionMax"></param>
        internal void GenerateTestCases(int min, int max, int optionMax, int numberOfTestsToGenerate)
        {
            // Get Random Object
            Random rand = GenerateRandom();

            Product question;
            List<Option> options;
            bool checkStatus = false;
            int answer, ansIndex;

            // Generate FlipView Items
            for (int i = 0; i < numberOfTestsToGenerate; i++)
            {
                question = this.GenerateQuestion(min, max, rand, distinctQuestions);
                answer = this.GenerateAnswer(rand, question, out ansIndex);
                options = this.GenerateOptions(optionMax, rand, checkStatus, answer, ansIndex);

                //Shuffle Options using OptionIndex as parameter
                options = options.OrderBy(a => a.OptionIndex).ToList();

                //Populates the collection with skills objects.
                this.testCases.Add(new TestCase(question, options));
            }
        }

        #endregion 

        #region GenerateOptions

        /// <summary>
        /// Generate Options for the current question.
        /// </summary>
        /// <param name="optionMax"></param>
        /// <param name="r"></param>
        /// <param name="options"></param>
        /// <param name="checkStatus"></param>
        /// <param name="answer"></param>
        /// <param name="ansIndex"></param>
        /// <returns></returns>
        private List<Option> GenerateOptions(int optionMax, Random r, bool checkStatus, int answer, int ansIndex)
        {
            List<Option> options = new List<Option>();
            Option value;
            int optionMin = 10;
            int randomValue;
            List<int> temp = new List<int>();
            temp.Add(answer);
            value = new Option(answer, ansIndex, checkStatus);
            options.Add(value);

            for (int index = 0; index <= 3; index++)
            { 
                // Generate Random Options for indices other than Answer Index.
                if (index != ansIndex)
                {
                    randomValue = r.Next(optionMin, optionMax);
                    while(temp.Contains(randomValue))
                    {
                        randomValue = r.Next(optionMin, optionMax);
                    }
                    temp.Add(randomValue);
                    value = new Option(randomValue, index, checkStatus);
                    options.Add(value);
                }
            }

            return options;
        }

        #endregion 

        #region GenerateAnswer

        /// <summary>
        /// Generate Answer from the Product Object.
        /// </summary>
        /// <param name="random"></param>
        /// <param name="question"></param>
        /// <param name="ansIndex"></param>
        private int GenerateAnswer(Random random, Product question, out int ansIndex)
        {
            ansIndex = random.Next(0, 3);
            return (question.Multiplier * question.Multiplicand);
        }
        #endregion 

        #region GenerateQuestion

        /// <summary>
        /// Generates Question for a flipview Item.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private Product GenerateQuestion(int min, int max, Random r , List<Product> distinctQuestions)
        {
            Product question;
            question = new Product(r.Next(1, 9), r.Next(min, max), 0);
            while (distinctQuestions.Contains(question))
            {
                question = new Product(r.Next(1, 9), r.Next(min, max), 0);
            }
            distinctQuestions.Add(question);
            return question;
        }

        #endregion 

        #region GenerateRandom

        /// <summary>
        /// Generates Random Number using a seed.
        /// </summary>
        /// <returns>A new instance of System.Random</returns>
        private Random GenerateRandom()
        {
            int seed = unchecked(DateTime.Now.Millisecond);
            Random rand = new Random(seed);
            return rand;
        }
        #endregion 

        #endregion
    }

    #endregion 
}
