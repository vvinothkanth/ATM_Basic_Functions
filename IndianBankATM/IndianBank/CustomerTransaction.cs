// ===============================
// Title of the Assesment : ATM Functionality
// Auther                 : Vinoth Kanth
// Starting Date          : 7/8/2018
//
// This class file is used to interact and read data from the user,
// it also used to transfer the data to ATM class and retrive the corresponding data 
//
// ================================

/// <summary>
/// The IndianBank NameSpace
/// </summary>
namespace IndianBank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The Customer Transaction class
    /// </summary>
    class CustomerTransaction
    {
        /// <summary>
        /// The User Choice enum 
        /// </summary>
        enum AtmMenu
        {
            Withdrawal = 1,
            MiniStatement,
            ChangePin,
            Deposit,
            CheckBalance
        };

        /// <summary>
        /// The Main Fuction
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            AutomatedTellerMachine atm = new AutomatedTellerMachine(  );

            // To set the customer details
            Console.WriteLine( "Enter your name" );
            string customerName = Convert.ToString( Console.ReadLine( ) );
            Console.WriteLine( "Enter your ATM-PIN number :<any four digit number>" );
            int setPinNumber = Convert.ToInt16( Console.ReadLine( ) );

            atm.IsAddCustomerDetail( customerName, setPinNumber );

            //Console.WriteLine("\n\n---------------------------------------------");
            //Console.WriteLine("Welcome");
            //Console.WriteLine("Your Account Name    : {0}", customerName);
            //Console.WriteLine("Your ATM Pin Number  :{0}", setPinNumber);
            //Console.WriteLine("Your Account Balance :{0}", 100000.00);
            //Console.WriteLine("---------------------------------------------\n\n");

            // To do atm functionality
            Console.WriteLine( "Hi {0}", customerName );
            Console.Write( "PLEASE ENTER YOUR 4 DIGIT PIN NUMBER : " );
            int atmPinNumber = Convert.ToInt16( Console.ReadLine() );

            bool isValidUser = atm.IsValidCustomer( customerName, atmPinNumber );

            if ( isValidUser )
            {
                bool isProcessContinue = true;
                while ( isProcessContinue )
                {
                    Console.WriteLine("1. Withdrawal");
                    Console.WriteLine("2. Mini statement");
                    Console.WriteLine("3. Change pin ");
                    Console.WriteLine("4. Deposit");
                    Console.WriteLine("5. Check balance. ");

                    int userChoice = Convert.ToInt16( Console.ReadLine( ) );

                    switch ( userChoice )
                    {
                        case (int)AtmMenu.Withdrawal:
                            Console.Write( "ENTER WITHDRAW AMOUNT Rs." );
                            double withdrawAmount = Convert.ToDouble( Console.ReadLine( ) );
                            Console.WriteLine( atm.GetWithdrawAmount( customerName, atmPinNumber, withdrawAmount ) );
                            break;

                        case (int)AtmMenu.MiniStatement:
                            Console.WriteLine( "Hi {0}", customerName );
                            Console.WriteLine( atm.GetMiniStatement( customerName, atmPinNumber ) );
                            Console.WriteLine( "YOUR ACCOUNT BALANCE {0}", atm.GetAccountBalance( customerName, atmPinNumber ) );
                            break;

                        case (int)AtmMenu.ChangePin:
                            Console.WriteLine( "ENTER OLD PIN NUMBER" );
                            int oldPin = Convert.ToInt16( Console.ReadLine( ) );
                            Console.WriteLine( "ENTER NEW PIN NUMBER" );
                            int newPin = Convert.ToInt16( Console.ReadLine( ) );
                            Console.WriteLine( atm.ResetPinNumber( customerName, oldPin, newPin ) );
                            atmPinNumber = newPin;
                            break;

                        case (int)AtmMenu.Deposit:
                            Console.Write( "ENTER DEPOSIT AMOUNT Rs." );
                            double depositAmount = Convert.ToDouble( Console.ReadLine( ) );
                            Console.WriteLine( atm.AddDepositAmount( customerName, atmPinNumber, depositAmount ) );
                            break;

                        case (int)AtmMenu.CheckBalance:
                            Console.WriteLine( "\n YOUR CURRENT BALANCE IS {0}", atm.GetAccountBalance( customerName, atmPinNumber ) );
                            break;

                        default:
                            Console.WriteLine( "Hi {0}", customerName );
                            Console.WriteLine( "ENTER VALID INPUT" );
                            break;
                    }

                    Console.WriteLine( "DO YOU WANT TO CONTINUE  : yes/no" );
                    string doAgain = Convert.ToString( Console.ReadLine( ) );
                    if ( doAgain.ToLower( ).Contains( "yes" ) )
                    {
                        isProcessContinue = true;
                    }
                    else
                    {
                        isProcessContinue = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("PLEASE CHECK PIN NUMBER");
                Console.ReadKey();
            }
        }
    }
}
