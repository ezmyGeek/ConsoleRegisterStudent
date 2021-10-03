using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRegisterStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).run();
        }


        void run()
        {
            int choice;
            int firstChoice = 0, secondChoice = 0, thirdChoice = 0;
            int totalCredit = 0;
            string yesOrNo = "";

            System.Console.WriteLine("Teacher's Copy");

            do
            {
                WritePrompt();
                choice = Convert.ToInt32(Console.ReadLine());

                switch (ValidateChoice(choice, firstChoice, secondChoice, thirdChoice, totalCredit))
                {
                    case -1:
                        Console.WriteLine("Your entered selection {0} is not a recognized course.", choice);
                        break;
                    case -2:
                        Console.WriteLine("You have already registerd for this {0} course.", ChoiceToCourse(choice));
                        break;
                    case -3:
                        Console.WriteLine("You can not register for more than 9 credit hours.");
                        break;
                    case 0:
                        Console.WriteLine("Registration Confirmed for course {0}.", ChoiceToCourse(choice));
                        if (firstChoice == 0)
                            firstChoice = choice;
                        else if (secondChoice == 0)
                            secondChoice = choice;
                        else
                            thirdChoice = choice;
                        totalCredit += 3;// add total credit after course registry not before

                        break;
                }

                

                WriteCurrentRegistration(firstChoice, secondChoice, thirdChoice);
                Console.Write("\nDo you want to try again? (Y|N)? : ");
                yesOrNo = (Console.ReadLine()).ToUpper();
            } while (yesOrNo == "Y");

            Console.WriteLine("Thank you for registering with us");
        }

        void WritePrompt()
        {
            Console.WriteLine("Please select a course for which you want to register by typing the number inside []");
            Console.WriteLine("[1]IT 145\n[2]IT 200\n[3]IT 201\n[4]IT 270\n[5]IT 315\n[6]IT 328\n[7]IT 330");
            Console.Write("Enter your choice : ");
        }

        int ValidateChoice(int myChoice, int myFChoice, int mySChoice, int myTChoice, int myTCredit)// changes parameters names to avoid confusion because the same variables are used in the main method run.
        {
            if (myChoice < 1 || myChoice > 7)// choice is between 1 to 70 included so 7 not 70.
                return -1;
            else if ((myChoice == myFChoice) || (myChoice == mySChoice))// myFChoice is stored in th program, then after entering myChoice for the second time before the system stores it it will compare it to myFChoice if not the same it will be stores as myFChoice, the same process will happen with mySChoise.
                return -2;
            else if (myTCredit >= 9)// the total credit is >=9 not >9 this will avoid an extra iteration to 12 and once credits reach 9 the condition will execute.
                return -3;
            else
            return 0;// return 0 not -4
        }


        void WriteCurrentRegistration(int num1, int num2, int num3)// all parameters names were changed from firstChoice, secondChoice, thirdChoice, to avoid confusion in the program each method uses different variables then the main run method.
        {
            if (num2 == 0)
                Console.WriteLine("You are currently registered for {0}", ChoiceToCourse(num1));
            else if (num3 == 0)
                Console.WriteLine("You are currently registered for {0}, {1}", ChoiceToCourse(num1), ChoiceToCourse(num2));
            else
                Console.WriteLine("You are currently registered for {0}, {1}, {2}", ChoiceToCourse(num1), ChoiceToCourse(num2), ChoiceToCourse(num3));
        }

        string ChoiceToCourse(int myChoiceHere)// changed again variable from choice to make sure no duplicate variables used in different methods
        {
            string course = "";
            switch (myChoiceHere)
            {
                case 1:
                    course = "IT 145";
                    break;
                case 2:
                    course = "IT 200";
                    break;
                case 3:
                    course = "IT 201";
                    break;
                case 4:
                    course = "IT 270";
                    break;
                case 5:
                    course = "IT 315";
                    break;
                case 6:
                    course = "IT 328";
                    break;
                case 7:
                    course = "IT 330";
                    break;
                default:
                    break;
            }
            return course;
        }
    }
}
