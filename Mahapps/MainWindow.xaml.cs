using Mahapps.Models;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mahapps.Business_Logic;
using Mahapps.Data;

namespace Mahapps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public string RemainingBalance { get; set; }

        public ObservableCollection<Budget> budgets;

        private Budget selectedItem;

        private int budgetId;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            budgets = new ObservableCollection<Budget>(BudgetData.GetBudgets());

            BudgetListView.ItemsSource = budgets;


        }

        private void NewBudgetButton_Click(object sender, RoutedEventArgs e)
        {
            if (BudgetStackPanel.Visibility == Visibility.Collapsed)
            {
                BudgetStackPanel.Visibility = Visibility.Visible;
                AddButtonFontIcon.Glyph = "\uE738";
            }
            else
            {
                BudgetStackPanel.Visibility = Visibility.Collapsed;
                AddButtonFontIcon.Glyph = "\uE710";
            }
        }

        private void CreateBudgetButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = BudgetValidation.ValidateBudget(TotalBudgetTextBox.Text, StartDatePicker.SelectedDate, EndDatePicker.SelectedDate);

            if(errorMessage != "")
            {
                ShowError(errorMessage);
                return;
            }

            if(CreateBudgetButton.Content.ToString() == "Create Budget")
            {
                Budget budget = new Budget
                {
                    StartDate = (DateTime)StartDatePicker.SelectedDate,
                    EndDate = (DateTime)EndDatePicker.SelectedDate,
                    BudgetAmount = double.Parse(TotalBudgetTextBox.Text)
                };

                budgets.Add(budget);

                BudgetListView.ItemsSource = budgets;

                BudgetData.AddBudgetToDb(budget);

                ShowSuccess();

            }
            else
            {
                BudgetData.UpdateBudgetinDb(budgetId, (DateTime)StartDatePicker.SelectedDate, (DateTime)EndDatePicker.SelectedDate, TotalBudgetTextBox.Text);

                StartDatePicker.SelectedDate = null;
                EndDatePicker.SelectedDate = null;
                TotalBudgetTextBox.Text = null;

                BudgetStackPanel.Visibility = Visibility.Collapsed;
                CancelUpdateButton.Visibility = Visibility.Hidden;

                ShowSuccessUpdate();

            }


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlyout.IsOpen = true;
        }

        private void ShowError(string error)
        {
            UpdateFlyout.Background = Brushes.Red;

            FlyoutTextBlock.Text = error;

            UpdateFlyout.CloseButtonVisibility = Visibility.Hidden;

            UpdateFlyout.IsOpen = true;
        }

        private void ShowSuccess()
        {
            UpdateFlyout.Background = Brushes.Green;

            FlyoutTextBlock.Text = "Successfully Added Budget!";

            UpdateFlyout.CloseButtonVisibility = Visibility.Hidden;

            BudgetStackPanel.Visibility = Visibility.Collapsed;

            UpdateFlyout.IsOpen = true;
        }

        private void ShowSuccessUpdate()
        {
            UpdateFlyout.Background = Brushes.Green;

            FlyoutTextBlock.Text = "Successfully Updated Budget!";

            UpdateFlyout.CloseButtonVisibility = Visibility.Hidden;

            BudgetStackPanel.Visibility = Visibility.Collapsed;

            UpdateFlyout.IsOpen = true;
        }

        private void BudgetListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = (Budget)BudgetListView.SelectedItem;
           
            RemainingBalance = $"${selectedItem.BudgetAmount}";

            RemainingBudgetTextBlock.Text = RemainingBalance;

            AddExpenseButton.Visibility = Visibility.Visible;
        }

        private void EditBudgetButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            Budget budget = b.CommandParameter as Budget;

            StartDatePicker.SelectedDate = budget.StartDate;
            EndDatePicker.SelectedDate = budget.EndDate;
            TotalBudgetTextBox.Text = budget.BudgetAmount.ToString();

            BudgetStackPanel.Visibility = Visibility.Visible;
            CancelUpdateButton.Visibility = Visibility.Visible;

            CreateBudgetButton.Content = "Update Budget";

            budgetId = budget.Id;
        }

        private void CancelUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            StartDatePicker.SelectedDate = null;
            EndDatePicker.SelectedDate = null;
            TotalBudgetTextBox.Text = null;

            BudgetStackPanel.Visibility = Visibility.Collapsed;
            CancelUpdateButton.Visibility = Visibility.Hidden;
        }

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
