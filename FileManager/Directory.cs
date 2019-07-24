using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    // klasa, która przechowuje dane źródła z którego lub do do którego ma zostać wykonane kopiowanie
    class MyDirectory
    {
        // konstruktor
        public MyDirectory(string directory, bool isItLocal, int serverNr)
        {
            fileDirectory = directory;
            isLocal = isItLocal;
            nrOfServer = serverNr;
        }

        // Miejsce z którego lub do którego ma być kopiowany plik
        private string fileDirectory;
        public string FileDirectory
        {
            get { return fileDirectory; }
            set { fileDirectory = value; }
        }

        // informacja, czy źródło znajduje się na dysku lokalnym, czy na serwerze ftp
        private bool isLocal;
        public bool IsLocal
        {
            get { return isLocal; }
            set { isLocal = value; }
        }

        private int nrOfServer;
        public int NrOfServer
        {
            get { return nrOfServer; }
            set { nrOfServer = value; }
        }

        // zmiana źródła
        public void changeDirectory(string value)
        {
            fileDirectory = value;
        }
    }
}
