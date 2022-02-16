using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Server_Communication
{
    public class Server
    {
        #region server
        public List<Client> list = new List<Client>();
       // Validity
        public  bool Check_Client(Client cc1, List<Client> l1)
        {
            foreach (var x in l1)
            {
                if (x.Ph_no == cc1.Ph_no ||  x.Client_name==cc1.Client_name)
                {
                    return true;
                }

            }
            return false;
        }
        // Adding contact to a client
       /* public void AddContact(string s1,long l1)
        {
            Client_Server cs2 = new Client_Server();
            string s2 = l1.ToString();
            New_Client_Reg n1=new New_Client_Reg();
            
            if (n1.Check_ph_no(s2))
            {
                Client_Server cs1 = new Client_Server(s1, l1);
                if(!Check_Client(cs1,cs2.Contact_bookc1))
                cs2.Contact_bookc1.Add(cs1);
                list.Add(cs2);

            }
            
        }
        */
        public void Display_Data_Base()
        {
            foreach (var x in list)
            {
                Console.WriteLine(x.Client_name + " " + x.Ph_no);
            }

        }
        
        //TO Delete From Server
        public  void DeleteClient()
        {
            Console.WriteLine("Enter the User_name");
            string user_name=Console.ReadLine();
            Console.WriteLine("Enter the Phone Number");
            long ph_num=Convert.ToInt64(Console.ReadLine());
            Client cls1=new Client(user_name,ph_num);
            foreach(var x in list.ToArray())
            {
                if(x.Ph_no==cls1.Ph_no && x.Client_name == cls1.Client_name)
                {
                    list.Remove(x);
                }
            }
        }
        // Contact Details
        /* public void Contact_Display()
         {
             Client_Server cs3 = new Client_Server();
             foreach (var y in cs3.Contact_bookc1)
             {
                 Console.WriteLine(y.Client_name + " " + y.Ph_no);
             }
         }
        */


        #endregion
    }
    public class Message
    {
        #region message

        public String msg { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }

        public DateTime dt { get; set; }
        public Message(String m, string s, string r)
        {
            msg = m;
            sender = s;
            receiver = r;
            dt = DateTime.Now;
        }

    }
    #endregion
}
