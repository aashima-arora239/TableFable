////////////////////////////////////////////////////////////////////////////////////////
//  TableFable.xaml.cs : File defines the class representing the UI for table fable   //
//  ver 1.0                                                                           //  
//  Language:    C#                                                                   //
//  Application: Table Fable - Tables in mathematics made easy                        //
//  Author:      Infinite Loop Apps - iMagic Ventures Company                         //
//  (c)Copyright Infinite Loop Apps - iMagic Ventures Company                         //
////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace Tables
{
    /// <summary>
    /// Class represrnting table fable feature of the application.
    /// </summary>
    public sealed partial class TableFable : Tables.Common.LayoutAwarePage
    {
        #region Private Members

        private int tableLimit = 1000;
        private int tableDisplayLimit = 10;
            
        #endregion

        #region Properties

        public ObservableCollection<Product> TableOfDigit 
        { 
            get; 
            set; 
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Generates object of class TableFable
        /// </summary>
        public TableFable()
        {
            this.InitializeComponent();
            TableOfDigit = new ObservableCollection<Product>();
            TableModel View = new TableModel(tableLimit);
            this.DataContext = View;
            Window.Current.SizeChanged += OnSizeChanged; 

        } 

        #endregion

        #region EventHandler

        /// <summary>
        /// Event Handler for handling the Click event for a Button display a table Digit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClick(object sender, RoutedEventArgs e)
        {
            TableOfDigit.Clear();
            int productValue = 0, multiplier = 0;
            Button b = sender as Button;
            if (b != null)
            {
                multiplier = Convert.ToInt32(b.Content);

                //Loops till limit generating Product objects dynamically.
                for (int i = 1; i <= tableDisplayLimit; i++)
                {
                    productValue = i * multiplier;
                    Product obj = new Product(multiplier, i, productValue);
                    //Added to TableList 
                    TableOfDigit.Add(obj);

                }
                //Set data context
                tableBox.DataContext = TableOfDigit;
                tableID.Text = "Table of " + multiplier.ToString();
            }
        }

        private void OnSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs args)
        {
            switch (Windows.UI.ViewManagement.ApplicationView.Value)
            {
                case Windows.UI.ViewManagement.ApplicationViewState.Filled:
                    VisualStateManager.GoToState(this, "Fill", false);
                    break; 
                case Windows.UI.ViewManagement.ApplicationViewState.Snapped:
                    VisualStateManager.GoToState(this, "Snapped", false); 
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region Methods

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        protected override void SaveState(Dictionary<String, Object> pageState)
        {

        } 

        #endregion

        
    }
}
           
