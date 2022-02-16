using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client_Server_Communication
{
    public  class Program1
    {
        // Server Object
        public static Server1 sc = new Server1();


        public static file_data fd=new file_data();
        // Checking Validity
        public static Messaging m=new Messaging();
        public static New_Client_Reg n1 = new New_Client_Reg();
        public static string active_user;

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
                Console.WriteLine("5 - To ViewMessages");
                Console.WriteLine("6 - To Delete the Account");
                
                Console.WriteLine("7 - To Display the clients present in server");
                Console.WriteLine("8 - To Exit Without any Operation");

                Console.WriteLine("Enter your  choice:");
                string str1 = Console.ReadLine();

                switch (str1)
                {
                    case "1":
                        New_User();
                        //Thread t1 = new Thread(new ThreadStart (New_User));
                       // t1.Start();
                        break;
                    case "2":
                        //Thread t2 =new Thread(new ThreadStart(VerificationToLogin));
                        // t2.Start(); 
                        VerificationToLogin();
                        break;
                    case "3":
                        Console.WriteLine("Please Enter the Details:  ");
                        Console.Write("Name: ");
                        string ss = Console.ReadLine();
                        Console.Write("Phone Number :");
                        long ll = Convert.ToInt64(Console.ReadLine());

                        sc.AddContact(ss, ll);

                        break;
                    case "4":
                        Console.WriteLine("Please enter the name of the person to send the info");
                        string rec=Console.ReadLine();
                        Console.WriteLine("Enter the message");
                        string msg1=Console.ReadLine();
                        m.message(active_user, rec, msg1);
                        break;

                    case "5":
                       // Console.WriteLine("Message recived");
                        m.viewMessage();
                        break;
                    case "6":

                        //Thread t3 =new Thread(new ThreadStart(sc.DeleteClient));
                        sc.DeleteClient();
                        Console.WriteLine("Thank You!! You have no longer access to the server");
                        break;
                    case "7":
                        //Thread t4 = new Thread(new ThreadStart(Display_Clients));
                        Display_Clients();
                        break;

                    case "8":
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
            
            Console.WriteLine("Enter The User Name");
            string user =Console.ReadLine();
            active_user = user;
            Console.WriteLine("Enter the Phone Number");
            long ph_number=Convert.ToInt64(Console.ReadLine()); 

            Client1 cls=new Client1(user,ph_number);
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
            Client1 c3 = new Client1(user_name, user_phone_number);//creating a new Client

            if (sc.Check_Client(c3, sc.list))//Checks weather a user exictes or not 
            {
                // Console.WriteLine("asf");
                Console.WriteLine("User already Registered Please Login Throught your Details!!! ");

            }
            else
            {
                if (n1.Check_ph_no(user_phone))
                {
                    //sc.list.Add(c3);
                    string filename2 = $"E:\\{user_name}.txt";
                    string filemessage = $"E:\\{user_name}message.txt";
                    string str = "Welcome To Messages";
                    File.AppendAllText(filemessage, $"{str} \n");
                    File.AppendAllText(filename2, $"{user_name},{user_phone}");
                    File.AppendAllText(fd.filename1, $"{user_name},{user_phone}\n");


                    

                }
                else
                {
                    Console.WriteLine("Please Enter The Valid Phone_Number");
                }
            }
            c3.Message=new List<Client1> ();

            #endregion
            //Console.WriteLine(n1.Check_ph_no(user_phone) ? "Valid Phone Number" : "Invalid Please Check it");
        }
        public static void Display_Clients()
        {
            
            using (StreamReader sr = File.OpenText(fd.filename1))
            {
                string  s="";
                while( (s = sr.ReadLine() )!= null)
                {
                    
                }
            }
            
        }







    }
}
