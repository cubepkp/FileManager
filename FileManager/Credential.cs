using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace FileManager
{
    // klasa odpowiedzialna za dane serwera, z którym się łączymy
    public class Credential
    {
        // konstruktor klasy
        public Credential(string adress, string name, string password)
        {
            this.serverAdress = adress;
            this.userName = name;
            this.userPassword = password;
        }


        // adres serwera
        private string serverAdress;
        public string ServerAdress
        {
            get { return serverAdress; }
            set { serverAdress = value; }
        }
        // użytkownik serwera
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        // hasło serwera
        private string userPassword;
        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }
    }
}
