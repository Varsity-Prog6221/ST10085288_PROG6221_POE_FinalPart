a) Personal budget planner can be used to plan your budget.
Users need to enter the values that the program asks for and will be presented with
output of the users monthly income, total expenses and the remaining money.
Other outputs, approval or non approval of a home loan, will also be presented at the 
appropriate time.

INSTRUCTIONS:
1: Enter monthly income(must be entered for the program to function correctly except for the saving details)
2: Check any checkbox to enter details
3: Enter all details for the checkboxes that has been checked or else program will give an error message
4: Make sure that all desired data is enterd before proceeding since an error message will appear if not
5: Click on calculate button to calculate the information
6: Click on clear button to clear the list
7: Check saving details chechbox to calculate how much you want to save to reach your goal
8: Enter all data that is being asked for or else an error message will appear
9: Click on the calculate monthly saving button to receive desired information

b)
I adding properties to each of the classes and adding the method  public abstract double Calculate(double income); 
the properties added are public double RentalAmount { get; set; } in the renting class, public double PurchaseAmount { get; set; },
public double InterestRate { get; set; },   public double DepositAmount { get; set; } ,public double NumMonRepay { get; set; } 
in the HomeLoan class, public double PurchaseAmount { get; set; }, public double InterestRate { get; set; }, public double DepositAmount { get; set; },  
public double InsuranceAmount { get; set; } in the Vehicle class and  public double SavingAmount { get; set; },  public double InterestRate { get; set; },
public double NumMonRepay { get; set; } in the Saving class. Properteis are used so that i dont have to make variables in the main class for them properties in the
classes which reduces code and the possibility that I might get confused with the amount of variables.
The method abstract double Calculate(double income); has been added to take the other method in the class and can be used to calculate the remaining income