using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client_Server_Communication
{
    public class Client1
    {
        #region Client_creating
         public List<Client1> Contact_bookc1 = new List<Client1>();

        string client_name;
         long ph_no;
        //long adhar_number;
        public List<Client1> Message;

        public Client1(){
            client_name = Client_name;
            ph_no = Ph_no;
          //  adhar_number = Adhar_number;
            }
        public Client1(string a,long b)
        {
            Client_name = a;
            Ph_no = b;
           // Adhar_number = c;
        }
        public string Client_name
        {
            get { return client_name; }
            set { client_name = value; }
        }
        public long Ph_no
        {
            get { return ph_no; }
            set { ph_no = value; }
        }
        /*  public long Adhar_number
          {
              get { return adhar_number; }
              set { adhar_number = value; }
          }*/
        #endregion 
    }
    public class TO_Msg
    {
        //To send msgs;;;

        public static void TO_Send_Msg()
        {
            Server1 sc2=new Server1();
            Console.WriteLine("Please enter the User name that you want to add :");

            string ser_name = Console.ReadLine();
        }
    }
   
  /*  public class message
    {
        #region Message Class
       
        Server s11 = new Server();

        public  void Messaging()
        {
            Program ps = new Program();
            Console.WriteLine("Please enter the UserName of the person you want to send message");
            string name = Console.ReadLine();
            foreach (var x in s11.list)
            {
                if (x.Client_name == name)
                {
                    Console.WriteLine("Enter the message you want to send");
                    string msg = Console.ReadLine();
                    Message m = new Message(msg, ps.active_user, name);
                    

                }
                else
                {
                    Console.WriteLine("There is no user with the name you entered");
                }
            }
        }
        #endregion
    }*/

    public class New_Client_Reg
    {
        #region New_Client_reg_check
        public bool Check_ph_no(string n)
        {
           // Client_Server c1 = new Client_Server();
            var text = n;
            
            if (!Regex.Match(text, @"^[0-9]{10}$").Success)
            {
                //Console.WriteLine("Invalid phone number");
                return false;
               // Console.ReadLine();
            }
            else
            {
//                Console.WriteLine("Valid Phone number");
                return true;
               // Console.ReadKey();
            }
        }
        #endregion

    }

}
