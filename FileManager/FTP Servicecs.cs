using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    // klasa serwisowa, odpowiedzialna za łączenie się z serwerem
    class FTP_Servicecs
    {
        // rozbite na dwa obiekty źródło kopiowania, a także miejsce gdzie mamy skopiować plik
        public MyDirectory copySource, pasteDestination;

        // rozbite na dwa obiekty źródło kopiowania, a także miejsce gdzie mamy skopiować plik
        public ServerProperties server1, server2;

        // metoda zwracająca jeden z serwerów w zależności od podanego parametru parametr 1
        // sprawi, że będziemy komunikowali się z serwerem po lewej stronie, a inny że z tym po prawej
        public ServerProperties getServerByNumber(int i)
        {
            return i == 1 ? server1 : server2; 
        }

        // metoda wejścia w katalog poniżej, dodajemy znak specjalny  separujący katalogi oraz nazwę folderu
        public void changeFolder(string folderName, int nrOfServer)
        {
            getServerByNumber(nrOfServer).currentSource += "/" + folderName;
        }

        // metoda do wyciągnięca nazwy pliku bez znaków tabulacji i rozmiaru
        public string cutTabs(string item)
        {
            string result = item;
            while (result.Contains("\t"))
            {
                //wycinanie z łańcucha ostatni znak tabulacji
                result = result.Substring(0, result.LastIndexOf("\t"));
            }
            return result;
        }

        // wejście w ściężkę wyżej. Wywoływane po naciśnięciu na "..."
        public void goUp(int nrOfServer)
        {
            // Sprawdzenie gdzie się znajduje ostatni znacznik separujący katalogi
            int lastSpecialChar = getServerByNumber(nrOfServer).currentSource.LastIndexOf("/");
            // obcinamy stringa do tamtego miejsca
            getServerByNumber(nrOfServer).currentSource = getServerByNumber(nrOfServer).currentSource.Substring(0, lastSpecialChar);
        }

        // Metoda wykonująca kopiowanie
        public void copyOperation()
        {
            // kopiowanie na linii lokal-serwer
            if (copySource.IsLocal && !pasteDestination.IsLocal)
            {
                Upload(copySource.FileDirectory, pasteDestination.NrOfServer);
            }
                // kopiowanie na linii serwer-lokal
                else if (!copySource.IsLocal && pasteDestination.IsLocal)
                {
                    Download(pasteDestination.FileDirectory + "\\" + getFileNameFromServerSource(copySource.FileDirectory), copySource.NrOfServer);
                }
                    // kopiowanie serwer-serwer
                    else if (!copySource.IsLocal && !pasteDestination.IsLocal)
                    {
                        CopyBetweenServers();
                    }
        }

        // wycięcie jednego znaku "/" z adresu lokalnego, pomocne do odpowiedzniego formatu adresu
        private string correctLocalSource(string source)
        {
            if (source[3].ToString().Equals("\\"))
                source = source.Substring(0, 3) + source.Substring(4, source.Length - 4);
            return source;
        }

        // metoda wyciągająca nazwę pliku z pełnego adresu lokalnego
        public string getFileNameFromLocalSource(string path)
        {
            int pointer = path.LastIndexOf("\\");
            string fileName = path.Substring(pointer + 1, path.Length - pointer - 1);
            return fileName;
        }

        // metoda wyciągająca nazwę pliku z pełnego adresu serwerowego
        public string getFileNameFromServerSource(string path)
        {
            int pointer = path.LastIndexOf("/");
            string fileName = path.Substring(pointer + 1, path.Length - pointer - 1);
            return fileName;
        }

        //metoda kopiująca plik z lokalnego źródła na serwer
        public void Upload(string fullSource, int nrOfServer)
        {
          FileInfo fileInf = new FileInfo(correctLocalSource(fullSource));
          string uri = "ftp://" + getServerByNumber(nrOfServer).Credential.ServerAdress + "/" + fileInf.Name;
          FtpWebRequest reqFTP;
          
    
          // Create FtpWebRequest object from the Uri provided
          reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(
                    "ftp://" + getServerByNumber(nrOfServer).currentSource+ "/" + fileInf.Name));
          reqFTP.UsePassive = true;
          // Provide the WebPermission Credintials
          reqFTP.Credentials = new NetworkCredential(getServerByNumber(nrOfServer).Credential.UserName,
                                                      getServerByNumber(nrOfServer).Credential.UserPassword);
    
          // By default KeepAlive is true, where the control connection is 
          // not closed after a command is executed.
          reqFTP.KeepAlive = false;

          // Specify the command to be executed.
          reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
    
          // Specify the data transfer type.
          reqFTP.UseBinary = true;

          // Notify the server about the size of the uploaded file
          reqFTP.ContentLength = fileInf.Length;

          // The buffer size is set to 2kb
          int buffLength = 2048;
          byte[] buff = new byte[buffLength];
          int contentLen;
    
          // Opens a file stream (System.IO.FileStream) to read 
          // the file to be uploaded
          FileStream fs = fileInf.OpenRead();
   
          try
          {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();
        
                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);
        
                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the 
                    // FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
        
                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
          }
          catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }

        // metoda kopiująca plik z serwera na serwer lokalny
        public void Download(string filePath, int nrOfServer)
        {
            FtpWebRequest reqFTP;
            try
            {
                //filePath = <<The full path where the 
                //file is to be created. the>>, 
                //fileName = <<Name of the file to be createdNeed not 
                //name on FTP server. name name()>>
                FileStream outputStream = new FileStream(filePath, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" +
                                         getServerByNumber(nrOfServer).Credential.ServerAdress + "/" + getFileNameFromLocalSource(filePath)));
                reqFTP.UsePassive = true;
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(getServerByNumber(nrOfServer).Credential.UserName,
                                                             getServerByNumber(nrOfServer).Credential.UserPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // kopiowanie plików między serwerami
        public void CopyBetweenServers()
        {

            //connect to the destination server
            ServerProperties pasteServer = getServerByNumber(pasteDestination.NrOfServer);
            ServerProperties copyServer = getServerByNumber(copySource.NrOfServer);
            string fileName = copySource.FileDirectory;

            int pointer = fileName.LastIndexOf("/");
            fileName = fileName.Substring(pointer + 1, fileName.Length - pointer - 1);

            FtpWebRequest requestDestination = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + pasteDestination.FileDirectory +"/"+fileName));
            requestDestination.Method = WebRequestMethods.Ftp.UploadFile;
            requestDestination.Credentials = new NetworkCredential(pasteServer.Credential.UserName, pasteServer.Credential.UserPassword);
            requestDestination.UsePassive = true;
            //retrieve the request stream

            Stream streamDestination = requestDestination.GetRequestStream();

            //connect to the source server

            FtpWebRequest fileRequest = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + copySource.FileDirectory));

            //set the protocol for the request

            fileRequest.Method = WebRequestMethods.Ftp.DownloadFile;

            //provide username and password (for anonymous FTP use the

            //username of Anonymous and password of your email address

            fileRequest.Credentials = new NetworkCredential(copyServer.Credential.UserName, copyServer.Credential.UserPassword);

            //get the servers response

            WebResponse response = fileRequest.GetResponse();

            //retrieve the response stream

            Stream stream = response.GetResponseStream();

            //create byte buffer

            byte[] buffer = new byte[1024];
            long size = 0;

            //determine how much has been read

            int totalRead = stream.Read(buffer, 0, buffer.Length);

            //loop through the total size of the file

            while (totalRead > 0)
            {
                size += totalRead;

                //write to the stream

                streamDestination.Write(buffer, 0, totalRead);

                //get remaining size

                totalRead = stream.Read(buffer, 0, 1024);
            }

            // Close the streams.

            streamDestination.Close();
            stream.Close();
          
        }

        // metoda usuwająca plik z serwera
        public void DeleteFileOnServer(string FileName ,int nrOfServer)
        {
            FtpWebRequest reqFTP = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" +
                          getServerByNumber(nrOfServer).currentSource + "/" + getFileNameFromLocalSource(FileName)));
            reqFTP.Credentials = new NetworkCredential(getServerByNumber(nrOfServer).Credential.UserName,
                                                             getServerByNumber(nrOfServer).Credential.UserPassword);
            reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
            reqFTP.UsePassive = true;
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            response.Close();
        }

        // metoda usuwająca plik lokalny
        public void DeleteFileOnLocal(string FileName, string Path)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(Path+"\\"+FileName);
            try
            {
                fi.Delete();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // metoda zmieniająca nazwę pliku lokalnego
        public void RenameFileOnLocal(string oldFileName, string Path, string newFileName)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(Path + "\\" + oldFileName);
            // Sprawdzenie gdzie się znajduje ostatni znacznik separujący katalogi
            try
            {
                fi.MoveTo(Path+"\\"+newFileName);
            }
            catch (System.IO.IOException e) {}
        }

        // metoda zmieniająca nazwę pliku z serwera
        public void RenameFileServer(string oldFileName,string newFileName, int nrOfServer)
        {
            FtpWebRequest reqFTP = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + 
                getServerByNumber(nrOfServer).currentSource + "/" + oldFileName));
            reqFTP.Credentials = new NetworkCredential(getServerByNumber(nrOfServer).Credential.UserName,
                                                             getServerByNumber(nrOfServer).Credential.UserPassword);
            reqFTP.Method = WebRequestMethods.Ftp.Rename;
            reqFTP.UseBinary = false;
            reqFTP.UsePassive = true;
            reqFTP.Proxy = null;
            reqFTP.RenameTo = newFileName;
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            Stream ftpStream = response.GetResponseStream();
            ftpStream.Close();
            response.Close();
        }

        // metoda odczytująca rozmiar pliku lokalnego
        public string GetLocalFileSize(string Path)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(Path);
            try
            {
                return fi.Length.ToString() + " B";
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // metoda odczytująca rozmiar pliku z serwera
        public string GetFileSize(int nrOfServer, string name)
        {
            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(
                           "ftp://" + getServerByNumber(nrOfServer).currentSource + "/" + name));
            reqFTP.UsePassive = true;
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(getServerByNumber(nrOfServer).Credential.UserName,
                                                        getServerByNumber(nrOfServer).Credential.UserPassword);
            reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;

            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            long size = response.ContentLength;
            response.Close();
            return size.ToString();
        }

        // odczytanie listy plikó z serwera
        public string[] GetFileList(int nrOfServer)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(
                          "ftp://" + getServerByNumber(nrOfServer).currentSource + "/"));
                reqFTP.UsePassive = true;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(getServerByNumber(nrOfServer).Credential.UserName,
                                                            getServerByNumber(nrOfServer).Credential.UserPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    //size = GetFileSize(nrOfServer, line);
                    int nrOfTabs;
                    result.Append(line);
                    if (line.Contains(".") && !line.Equals(".") && !line.Equals(".."))
                    {
                        nrOfTabs = 5 - ((line.Length+1) - (line.Length+1) % 10) / 10;
                        if ((line.Length+1) % 10 == 0)
                        {
                            nrOfTabs++;
                        }
                        for (int i = 0; i < nrOfTabs; i++)
                        {
                            result.Append("\t");
                        }
                        result.Append(GetFileSize(nrOfServer, line).ToString() + " B");
                    }
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();

                return result.ToString().Split('\n');
            }
            catch (IOException ex)
            {
                downloadFiles = null;
                return downloadFiles;
            }
        }

    }
}
