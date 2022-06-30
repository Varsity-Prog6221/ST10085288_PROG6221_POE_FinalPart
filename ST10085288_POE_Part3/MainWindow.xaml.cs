using System;
using System.Collections.Generic;
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
using System.Web;
using System.Text.RegularExpressions;

namespace ST10085288_POE_Part3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double monthlyIncome = 0;    
        public static double numMonths = 0;
        public static double monthlyRemainingMoney = 0;
        public static double totalexpenses = 0;
        public static string vehicleModel = "";
        public static string vehicleMake = "";            
        private static List<SortExpenses> sortExpenses = new List<SortExpenses>();    
        internal static List<SortExpenses> SortExpenses { get => sortExpenses; set => sortExpenses = value; }

        //delegate
        public delegate void ExceedMessageDelegate(string message);
        public MainWindow()
        {
            InitializeComponent();           
        }
        //methods below will check if their corrosponding chechboxes are checked and if they are it wil enable their corrosponding textboxes
        private void cbCommonExpenses_Click(object sender, RoutedEventArgs e)
        {
            if (cbCommonExpenses.IsChecked == true)
            {
                txtTax.IsEnabled = true;
                txtGroceries.IsEnabled = true;
                txtWaterLights.IsEnabled = true;
                txtTravelCosts.IsEnabled = true;
                txtCell_telephone.IsEnabled = true;
                txtOther.IsEnabled = true;
            }
            else
       if (cbCommonExpenses.IsChecked == false)
            {
                txtTax.IsEnabled = false;
                txtGroceries.IsEnabled = false;
                txtWaterLights.IsEnabled = false;
                txtTravelCosts.IsEnabled = false;
                txtCell_telephone.IsEnabled = false;
                txtOther.IsEnabled = false;
            }
        }

        private void cbVehicle_Click(object sender, RoutedEventArgs e)
        {
            if (cbVehicle.IsChecked == true)
            {
                txtModel.IsEnabled = true;
                txtMake.IsEnabled = true;
                txtVehiclePurchasePrice.IsEnabled = true;
                txtVehicleDeposit.IsEnabled = true;
                txtVehicleInterestRate.IsEnabled = true;
                txtInsurance.IsEnabled = true;
            }
            else
       if (cbVehicle.IsChecked == false)
            {
                txtModel.IsEnabled = false;
                txtMake.IsEnabled = false;
                txtVehiclePurchasePrice.IsEnabled = false;
                txtVehicleDeposit.IsEnabled = false;
                txtVehicleInterestRate.IsEnabled = false;
                txtInsurance.IsEnabled = false;
            }
        }
        
        private void cbSaving_Click(object sender, RoutedEventArgs e)
        {
            if (cbSaving.IsChecked == true)
            {
               txtAmount.IsEnabled = true;
               txtSavingMonths.IsEnabled = true;
               txtSavinginterestRate.IsEnabled = true;
            }
            else
       if (cbSaving.IsChecked == false)
            {
                txtAmount.IsEnabled = false;
                txtSavingMonths.IsEnabled = false;
                txtSavinginterestRate.IsEnabled = false;
            }
        }

        private void rdoRenting_Click(object sender, RoutedEventArgs e)
        {
            if (rdoRenting.IsChecked == true)
            {
                txtRenting.IsEnabled = true;
            
                txtHousePurchasePrice.IsEnabled = false;
                txtHouseDeposit.IsEnabled = false;
                txtHouseInterestRate.IsEnabled = false;
                txtHouseMonthsRepay.IsEnabled = false;
            }
        }

        private void rdoHomeLoan_Click(object sender, RoutedEventArgs e)
        {
            if (rdoHomeLoan.IsChecked == true)
            {
               txtHousePurchasePrice.IsEnabled = true;
               txtHouseDeposit.IsEnabled = true;
               txtHouseInterestRate.IsEnabled = true;
               txtHouseMonthsRepay.IsEnabled = true;
               txtRenting.IsEnabled = false;
            }
            
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)//button to calculate expenses
        {

            if (txtMonthlyIncome.Text == "")
            {
                MessageBox.Show("NOTE: PLEASE MAKE SURE INCOME TEXTBOX HAS AN ENTERED VALUE OR ELSE PROGRAM WILL NOT FUNCTION AS INTENDED");
                return;
            }
            else
            {
                monthlyIncome = double.Parse(txtMonthlyIncome.Text);
            }
            if (cbCommonExpenses.IsChecked == true)
            {
                if (txtTax.Text == "" || txtGroceries.Text == "" || txtWaterLights.Text == "" || txtTravelCosts.Text == "" || txtCell_telephone.Text == "" || txtOther.Text == "")
                {
                    MessageBox.Show("NOTE: PLEASE MAKE SURE ALL TEXTBOXES AT COMMON EXPENSES HAS ENTERED VALUES OR ELSE PROGRAM WILL NOT FUNCTION AS INTENDED");
                    return;
                }
                else
                {
                    CommonExpenses();
                }

                
            }
            
            if (rdoRenting.IsChecked == true)
            {
                if (txtRenting.Text == "")
                {
                    MessageBox.Show("NOTE: PLEASE MAKE SURE ALL TEXTBOXES AT RENTING EXPENSES HAS ENTERED VALUES OR ELSE PROGRAM WILL NOT FUNCTION AS INTENDED");
                    return;
                }
                else
                {
                    Renting();
                }
            }
            else if (rdoHomeLoan.IsChecked == true)
            {
                if (txtHousePurchasePrice.Text == "" || txtHouseDeposit.Text == "" || txtHouseInterestRate.Text == "" || txtHouseMonthsRepay.Text == "")
                {
                    MessageBox.Show("NOTE: PLEASE MAKE SURE ALL TEXTBOXES AT HOME LOAN EXPENSES HAS ENTERED VALUES OR ELSE PROGRAM WILL NOT FUNCTION AS INTENDED");
                    return;
                }
                else
                {
                    Buying();
                }

            }
            
            if (cbVehicle.IsChecked == true)
            {
                if (txtVehiclePurchasePrice.Text == "" || txtVehicleDeposit.Text == "" || txtVehicleInterestRate.Text == "" || txtInsurance.Text == "" )
                {
                    MessageBox.Show("NOTE: PLEASE MAKE SURE ALL TEXTBOXES AT VEHICLE EXPENSES HAS ENTERED VALUES OR ELSE PROGRAM WILL NOT FUNCTION AS INTENDED");
                    return;
                }
                else
                {
                    Vehicle();
                }
            }          

            CalculateMonthlyLivingExpenses();
            Display();

            sortExpenses.Clear();
        }
        public void  Renting()//gets the renting details from user
        {
            
            Renting rent = new Renting();
            rent.RentalAmount = double.Parse(txtRenting.Text);
            sortExpenses.Add(new SortExpenses() { CategoryName = "Renting", ExpenseAmount = rent.RentalAmount });

        }
        public  void Buying()//gets the home loan details from user
        {           
            HomeLoan loan = new HomeLoan();

            loan.PurchaseAmount = double.Parse(txtHousePurchasePrice.Text);
            loan.DepositAmount = double.Parse(txtHouseDeposit.Text);
            loan.InterestRate = double.Parse(txtHouseInterestRate.Text)/100;

            double  numMonths = double.Parse(txtHouseMonthsRepay.Text);

            if (numMonths >= 240 && numMonths <= 360)
            {
                loan.NumMonRepay = double.Parse(txtHouseMonthsRepay.Text);
            }
            else
            {
                MessageBox.Show("NOTE: Number of months must be between 240 and 360." +
                                "Home loan will not be calclated until number of months has been entered correctly");
                return;
            }

            sortExpenses.Add(new SortExpenses() { CategoryName = "Home Loan", ExpenseAmount = loan.CalculateRepayment() });

            if ((monthlyIncome / 3) < loan.CalculateRepayment())
            {
                lstExpenses.Items.Add("========================================" + 
                                      "\nNOTE:" +
                                      "\nHome loan is not approved due to insufficient monthly income. " +
                                      "\nMonthly home loan payment is more than a third of your monthly income" +
                                      "\n========================================");
            }
            else
            {
                lstExpenses.Items.Add("========================================" +
                                      "\nNOTE:" +
                                      "\nHome loan is approved" +
                                      "\n========================================");
            }
        }
        public  void Vehicle()//gets the cehicle details from user
        {
          Vehicle vehicle = new Vehicle();
          vehicleModel = txtModel.Text;
          vehicleMake = txtMake.Text;
          vehicle.PurchaseAmount = double.Parse(txtVehiclePurchasePrice.Text);
          vehicle.DepositAmount = double.Parse(txtVehicleDeposit.Text);
          vehicle.InterestRate = double.Parse(txtVehicleInterestRate.Text)/100;
          vehicle.InsuranceAmount = double.Parse(txtInsurance.Text);

          sortExpenses.Add(new SortExpenses() { CategoryName = "Vehicle: "+ vehicleMake + " " + vehicleModel, ExpenseAmount = vehicle.CalculateRepayment() });

        }

        public void CommonExpenses()//gets the common expenses details from user
        {
            sortExpenses.Add(new SortExpenses() { CategoryName = "Tax", ExpenseAmount = double.Parse(txtTax.Text) });
            sortExpenses.Add(new SortExpenses() { CategoryName = "Groceries", ExpenseAmount = double.Parse(txtGroceries.Text) });
            sortExpenses.Add(new SortExpenses() { CategoryName = "Water & lights", ExpenseAmount = double.Parse(txtWaterLights.Text) });
            sortExpenses.Add(new SortExpenses() { CategoryName = "Travel Costs(petrol included)", ExpenseAmount = double.Parse(txtTravelCosts.Text) });
            sortExpenses.Add(new SortExpenses() { CategoryName = "Cellphone/telephone", ExpenseAmount = double.Parse(txtCell_telephone.Text) });
            sortExpenses.Add(new SortExpenses() { CategoryName = "Other", ExpenseAmount = double.Parse(txtOther.Text) });
        }

        public static void CalculateMonthlyLivingExpenses()//calculates the available/remaining money per month and total expenses
        {

            ExceedMessageDelegate message = ExceedMessage;//(Troelsen and Japikse,2021: 451,452,453,454,455,456,457)
            totalexpenses = 0;
            totalexpenses += sortExpenses.Sum(x => x.ExpenseAmount);
            monthlyRemainingMoney = monthlyIncome - totalexpenses;

            if (totalexpenses > (monthlyIncome * 3 / 4))
            {
                message("\nNOTE: TOTAL MONTHLY EXPENSES EXCEED 75% OF YOUR TOTAL MONTHLY INCOME");
            }
        }

        public static void ExceedMessage(string message)//delegate to present the user with a message
        {
            //(Troelsen and Japikse,2021: 451,452,453,454,455,456,457)
            MessageBox.Show(message);
        }

        public  void Display()
        {


            Renting rent = new Renting();
            lstExpenses.Items.Add("TOTAL MONTHLY INCOME: R" + monthlyIncome);
            lstExpenses.Items.Add("TOTAL EXPENSES: R" + totalexpenses);
            lstExpenses.Items.Add("TOTAL REMAINING MONEY: R" + monthlyRemainingMoney);

            lstExpenses.Items.Add("========================================" +
                                "\nEXPENSES IN DESCENDING ORDER" +
                                "\n========================================");
            sortExpenses.Sort();
            sortExpenses.Reverse();           
            foreach (SortExpenses a in sortExpenses)
            {
                lstExpenses.Items.Add(a.CategoryName + ": R"+ a.ExpenseAmount);               
            }
            lstExpenses.Items.Add("========================================");
        }//displays all information in the listbox

        private void btnCalculateMonthlySaving_Click(object sender, RoutedEventArgs e)//calculates the monthly amount the user need to save to reach their goal
        {
            if (txtAmount.Text == "" || txtSavingMonths.Text == "" || txtSavinginterestRate.Text == "")
            {
                MessageBox.Show("NOTE: PLEASE MAKE SURE ALL TEXTBOXES AT SAVING DETAILS HAS ENTERED VALUES OR ELSE PROGRAM WILL NOT FUNCTION AS INTENDED");
                return;
            }
            else
            {
                Saving saving = new Saving();
                saving.SavingAmount = double.Parse(txtAmount.Text);
                saving.InterestRate = double.Parse(txtSavinginterestRate.Text) / 100;
                saving.NumMonRepay = double.Parse(txtSavingMonths.Text);

                lblMonthlySaving.Content = "You need to save R" + saving.CalculateRepayment() + " per month to reach your goal";
            }
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lstExpenses.Items.Clear();
        }//clears the list box

        //code attribution
        //this method was taken from Abundant Code
        //https://abundantcode.com/how-to-allow-only-numeric-input-in-a-textbox-in-wpf/
        //Abundant Code
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)//only allows numbers and the character "," to be entered in certain textboxes
        {
        Regex regex = new Regex("[^0-9,]+");
        e.Handled = regex.IsMatch(e.Text);
    }

        
    }
}
