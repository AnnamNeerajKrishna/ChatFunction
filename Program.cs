using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client_Server_Communication
{
    public  class Program
    {
        // Server Object
        public static Server sc = new Server();

        // Checking Validity

       public static New_Client_Reg n1 = new New_Client_Reg();
        public string active_user;

        public static void Main(string[] args)
        {
           
           

            sc.Display_Data_Base();
            
          
           
            bool check=true;
            while (check)
            {
                Console.WriteLine("1 - Register_If_New_User");
                Console.WriteLine("2 - Login Details  ");
                Console.WriteLine("3 - To add Contact ");
                Console.WriteLine("4 - To Message");
                Console.WriteLine("5 - To Delete the Account");
                Console.WriteLine("6 - To Exit Without any Operation");

                Console.WriteLine("Enter your  choice:");
                string str1 = Console.ReadLine();

                switch (str1)
                {
                    case "1":
                        New_User();
                        break;
                    case "2":
                        VerificationToLogin();

                        break;
                  /*  case "3":
                        Console.WriteLine("Please Enter the Details:  ");
                        Console.Write("Name: ");
                        string ss = Console.ReadLine();
                        Console.Write("Phone Number :");
                        long ll = Convert.ToInt64(Console.ReadLine());

                        sc.AddContact(ss, ll);

                        break;-*/
                    case "4":

                        break;
                    case "5":

                        sc.DeleteClient();
                        Console.WriteLine("Thank You!! You have no longer access to the server");
                        break;

                    case "6":
                        check= false;
                        break;
                    default:
                        Console.WriteLine("Please Enter Valid Entry");
                        break;
                }
                Console.WriteLine("Press yes  to continue else no to End!");
                string  ch_k =Console.ReadLine();
                check = ch_k=="yes" ? true : false;

            }
            
          //  sc.Contact_Display();
            Console.ReadKey();


        }
        public static void VerificationToLogin()
        {
            #region Verification
            Program p11 =new Program();
            Console.WriteLine("Enter The User Name");
            string user =Console.ReadLine();
            p11.active_user = user;
            Console.WriteLine("Enter the Phone Number");
            long ph_number=Convert.ToInt64(Console.ReadLine()); 

            Client cls=new Client(user,ph_number);
            //Server Object

            if (sc.Check_Client(cls, sc.list))
            {
                Console.WriteLine("Checking..");
                Thread.Sleep(3000);
                Console.WriteLine("Welcome " + user);
            }
            else
            {
                Console.WriteLine("Invalid Entry");
            }
            #endregion
        }
        public static void New_User()
        {
            #region New_User
            Console.WriteLine("Enter the User_name");
            string user_name=Console.ReadLine();
            Console.WriteLine("Enter the Phone_number");
            long user_phone_number=Convert.ToInt64(Console.ReadLine());

            string user_phone = user_phone_number.ToString();
            Client c3 = new Client(user_name, user_phone_number);//creating a new Client

            if (sc.Check_Client(c3, sc.list))//Checks weather a user exictes or not 
            {
                // Console.WriteLine("asf");
                Console.WriteLine("User already Registered Please Login Throught your Details!!! ");

            }
            else
            {
                if (n1.Check_ph_no(user_phone))
                {
                    sc.list.Add(c3);
                }
                else
                {
                    Console.WriteLine("Please Enter The Valid Phone_Number");
                }
            }
            c3.Message=new List<Client> ();

            #endregion
            //Console.WriteLine(n1.Check_ph_no(user_phone) ? "Valid Phone Number" : "Invalid Please Check it");
        }







    }
}
