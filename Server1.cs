using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Server_Communication
{
    public class Server1
    {
        public file_data fd1=new file_data();
        #region server
        public List<Client1> list = new List<Client1>();

       // Validity
        public  bool Check_Client(Client1 cc1, List<Client1> l1)
        {
            /*string s = "";
            using (StreamReader sr = File.OpenText(fd1.filename1))
            {
                
                while ((s = sr.ReadLine()) != null)
                {
                    s += s;
                }
            }*/
                
            //string[] authorsList = s.Split(',');
            //foreach (string author in authorsLis
            //t)
            using (StreamReader sr = File.OpenText(fd1.filename1))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string[] splitter = s.Split(',');
                        if (splitter[1] == cc1.Ph_no.ToString() || splitter[0] == cc1.Client_name)
                    {
                        return true;
                    }
                    Array.Clear(splitter, 0, splitter.Length);
                }
                return false;
            }

          /*  foreach (var x in l1)
            {
                if (x.Ph_no == cc1.Ph_no || x.Client_name == cc1.Client_name)
                {
                    return true;
                }

            }*/
            
        }
        // Adding contact to a client
        public void AddContact(string s1,long l1)
        {
            Client1 cs2 = new Client1();
            string s2 = l1.ToString();
            New_Client_Reg n1=new New_Client_Reg();
            
            if (n1.Check_ph_no(s2))
            {
                Client1 cs1 = new Client1(s1, l1);
                if(!Check_Client(cs1,cs2.Contact_bookc1))
                cs2.Contact_bookc1.Add(cs1);
                list.Add(cs2);

            }
            
        }
        

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
            Client1 cls1=new Client1(user_name,ph_num);
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

    public class file_data
    {
        public string filename1 = $"E:\\All_Data.txt";
    }
    public class Messaging
    {
        public void message(string sender,string reciver,string msg)
        {
            string path = $"E:\\{reciver}message.txt";
            if (File.Exists(path))
            {
                string rec_path = $"E:\\{reciver}message.txt";
                string sen_path = $"E:\\{sender}message.txt";
                string ms = $"{msg}\n";
                File.AppendAllText(rec_path, ms);
                File.AppendAllText(sen_path, ms);
            }
        }


        public void viewMessage()
        {
            string currt_user = $"E:\\{Program1.active_user}message.txt";
            using (StreamReader sr = File.OpenText(currt_user))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
