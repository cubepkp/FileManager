using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    // klasa pojedyńczego serwera FTP
    class ServerProperties
    {
        // obiekt przechowujący dane serwera wraz z autentykacją
        private Credential credential;
        public Credential Credential
        {
            get { return credential; }
            set { credential = value; }
        }

        // flaga połączenia
        private Boolean isConnected;
        public Boolean IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

        // katalog, w którym aktualnie jesteśmy
        public string currentSource;

        // metoda ustanawiająca połączenie
        public void setConnection(string adress, string name, string password)
        {
            credential = new Credential(adress, name, password);
            // ustawienie adresu serwera jako ściażka, w której się aktualnie znajdujemy
            currentSource = adress;
        }
    }
}
