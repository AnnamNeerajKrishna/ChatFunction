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
        public bool Check_Client(Client cc1, List<Client> l1)
        {
            foreach (var x in l1)
            {
                if (x.Ph_no == cc1.Ph_no || x.Client_name == cc1.Client_name)
                {
                    return true;
                }

            }
            return false;
        }

        public void Display_Data_Base()
        {
            foreach (var x in list)
            {
                Console.WriteLine(x.Client_name + " " + x.Ph_no);
            }

        }

        //TO Delete From Server
        public void DeleteClient()
        {
            Console.WriteLine("Enter the User_name");
            string user_name = Console.ReadLine();
            Console.WriteLine("Enter the Phone Number");
            long ph_num = Convert.ToInt64(Console.ReadLine());
            Client cls1 = new Client(user_name, ph_num);
            foreach (var x in list.ToArray())
            {
                if (x.Ph_no == cls1.Ph_no && x.Client_name == cls1.Client_name)
                {
                    list.Remove(x);
                }
            }
        }



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
