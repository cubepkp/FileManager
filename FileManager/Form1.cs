using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace FileManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] drivers;
            drivers = Directory.GetLogicalDrives();
            foreach (string drive in drivers)
            {
                driversCB.Items.Add(drive);
            }
        }

        // zmienna serwisu
        FTP_Servicecs service = new FTP_Servicecs();

        // obiekt statyczny do wyświetlania popupu
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
          Form form = new Form();
          Label label = new Label();
          TextBox textBox = new TextBox();
          Button buttonOk = new Button();
          Button buttonCancel = new Button();

          form.Text = title;
          label.Text = promptText;
          textBox.Text = value;

          buttonOk.Text = "OK";
          buttonCancel.Text = "Cancel";
          buttonOk.DialogResult = DialogResult.OK;
          buttonCancel.DialogResult = DialogResult.Cancel;

          label.SetBounds(9, 20, 372, 13);
          textBox.SetBounds(12, 36, 372, 20);
          buttonOk.SetBounds(228, 72, 75, 23);
          buttonCancel.SetBounds(309, 72, 75, 23);

          label.AutoSize = true;
          textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
          buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
          buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

          form.ClientSize = new Size(396, 107);
          form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
          form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
          form.FormBorderStyle = FormBorderStyle.FixedDialog;
          form.StartPosition = FormStartPosition.CenterScreen;
          form.MinimizeBox = false;
          form.MaximizeBox = false;
          form.AcceptButton = buttonOk;
          form.CancelButton = buttonCancel;

          DialogResult dialogResult = form.ShowDialog();
          value = textBox.Text;
          return dialogResult;
        }

        // metoda sprawdzająca, czy katalog, w którym się znajdujemy jest katalogiem głównym.
        // w zależności od tego, czy tak, czy nie dodajemy lub nie "..." do listy elementów listy
        bool checkIfRoot(string serverAdress, TextBox source)
        {
            return source.Text.Equals(serverAdress);
        }

        // odświeżanie dostępności przycisków, a także czyszczenie okienka w przypadku rozłączenia
        // parametr określa, która storna okna (prawa/lewa) zmieniła swój stan
        private void refreshConnectionStatus(int wichButtonNr)
        {
            if (wichButtonNr == 1)
            {
                service.server1.IsConnected = !service.server1.IsConnected;
                userNameTB1.Enabled = !userNameTB1.Enabled;
                userPasswordTB1.Enabled = !userPasswordTB1.Enabled;
                serverAdressTB1.Enabled = !serverAdressTB1.Enabled;
                connectButton1.Enabled = !connectButton1.Enabled;
                disconnectButton1.Enabled = !disconnectButton1.Enabled;
                if (!service.server1.IsConnected)
                {
                    fileWindow1.Items.Clear();
                }
            }
            else if (wichButtonNr == 2)
            {
                service.server2.IsConnected = !service.server2.IsConnected;
                userNameTB2.Enabled = !userNameTB2.Enabled;
                userPasswordTB2.Enabled = !userPasswordTB2.Enabled;
                serverAdressTB2.Enabled = !serverAdressTB2.Enabled;
                connectButton2.Enabled = !connectButton2.Enabled;
                disconnectButton2.Enabled = !disconnectButton2.Enabled;
                if (!service.server2.IsConnected)
                {
                    fileWindow2.Items.Clear();
                }
            }
        }

        // odświeżenie katalogów i plików znajdujących się w bierzącej ścieżce
        private void refreshFolderWindow(ListBox windowFile,int nrOfServer, TextBox sourceTB)
        {
            windowFile.Items.Clear();
            // sprawdzenie, czy mamy doczynienia z serwerem, czy lokalnym dyskiem (wartość 0)
            if (nrOfServer == 0)
            {
                // sprawdzenie czy jesteśmy w katalogu głównym
                if (!driversCB.SelectedItem.ToString().Equals(sourceTB.Text))
                {
                    windowFile.Items.Add("...");
                }
                try
                {
                    List<string> elements = new List<string>();
                    string fileSize;
                    int nrOfTabs;
                    elements.AddRange(Directory.GetDirectories(sourceTB.Text));
                    elements.AddRange(Directory.GetFiles(sourceTB.Text));
                    for (int i = 0; i < elements.Count(); i++)
                    {
                        fileSize = "";
                        int pointer = elements[i].LastIndexOf("\\");
                        string newValue = elements[i].Substring(pointer + 1, elements[i].Length - pointer - 1);
                        // sprawdzenie, czy mamy doczynienia z plikiem
                        // jeśli tak, to mierzymy jego rozmiar i dodajemy
                        if (elements[i].Contains(".") && !elements[i].Equals(".") && !elements[i].Equals(".."))
                        {
                            // obliczenie ilości tabulacji potrzebnych, aby wyglądąło w miarę równo
                            nrOfTabs = 5 - ((newValue.Length + 1) - (newValue.Length + 1) % 10) / 10;
                            if ((newValue.Length + 1) % 10 == 0)
                            {
                                nrOfTabs++;
                            }
                            for (int p = 0; p < nrOfTabs; p++)
                            {
                                fileSize = fileSize + "\t";
                            }
                            fileSize = fileSize +service.GetLocalFileSize(elements[i]);
                        }
                        elements[i] = newValue + fileSize;
                    }
                    windowFile.Items.AddRange(elements.ToArray());
                }
                catch (IOException ) { };
            }
            // nie local, czyli server 
            else
            {
                // sprawdzenie, czy jesteśmy w katalogu głównym
                if (!checkIfRoot(service.getServerByNumber(nrOfServer).Credential.ServerAdress, sourceTB))
                {
                    windowFile.Items.Add("...");
                }
                try
                {
                    // medota GetFileList zwraca listę wszystkich elementów katalogu, w którym się znajdujemy
                    windowFile.Items.AddRange(service.GetFileList(nrOfServer));
                }
                catch (Exception) { };
            }

        }

        // -------------- Lewa strona,

        private void connectButton1_Click(object sender, EventArgs e)
        {
            // utworzenie nowego obiektu serverProperties oraz ustawienie w nim danych niezbędnych do połączenia z serwerem
            //takich jak nazwa użytkownika, adres serwera i hasło
            service.server1 = new ServerProperties();
            service.server1.setConnection(serverAdressTB1.Text, userNameTB1.Text, userPasswordTB1.Text);
            
            // uaktualnienie ścieżki, okna katalogu oraz odświeżenie statusu połączenia
            sourceTB1.Text = serverAdressTB1.Text;
            refreshFolderWindow(fileWindow1, 1, serverAdressTB1);
            refreshConnectionStatus(1);
        }

        private void fileWindow1_DoubleClick(object sender, EventArgs e)
        {
            // sprawdzenie, czy użytkownik nie kliknął na puste miejsce
            if (fileWindow1.SelectedItem != null)
            {
                // sprawdzenie, czy zaznaczony element nie zawiera kropkę, czyli czy nie jest plikiem
                if (!fileWindow1.SelectedItem.ToString().Contains("."))
                {
                    // jeśli nie, to przechodzę do zmiany folderu, w którym się znajduję
                    // 1 jako argument oznacza, że działamy na elementach po lewej stronie
                    service.changeFolder(fileWindow1.SelectedItem.ToString(), 1);
                    
                    // uaktualnienie wyświetlanej ścieżki, w której się aktualnie znajdujemy oraz odświeżenie okna
                    sourceTB1.Text = service.server1.currentSource;
                    refreshFolderWindow(fileWindow1,1, sourceTB1);
                }
                else if (fileWindow1.SelectedItem.ToString().Equals("..."))
                {
                    // jeśli kliknęliśmy na "...", to wywołujemy metodę pozwalającą iśc katalog wyżej oraz odświeżamy widok
                    service.goUp(1);
                    sourceTB1.Text = service.server1.currentSource;
                    refreshFolderWindow(fileWindow1, 1, sourceTB1);
                }
            }
        }

        private void disconnectButton1_Click(object sender, EventArgs e)
        {
            // rozłączenie z serwerem
            refreshConnectionStatus(1);
        }

        // metoda przycisku zapisującego ścieżkę do elementu kopiowanego
        private void copyButton1_Click(object sender, EventArgs e)
        {
            // sprawdzenie, czy cokolwiek jest zaznaczone
            if (fileWindow1.SelectedItem != null)
            {
                // sprawdzenie, czy element jest plikiem
                if (fileWindow1.SelectedItem.ToString().Contains(".") && !fileWindow1.SelectedItem.ToString().Contains("..."))
                {
                    // zapisanie ścieżki
                    string fileDirectory = sourceTB1.Text + "/" + service.cutTabs(fileWindow1.SelectedItem.ToString());
                    service.copySource = new MyDirectory(fileDirectory, false,1 );
                }
            }
        }

        // metoda przycisku kopiującego
        private void pasteButton1_Click(object sender, EventArgs e)
        {
            // sprawdzenie, czy jest zaznaczony jakiś element
            if (service.copySource != null)
            {
                // zapisanie ścieżki, na którą zapiszemy plik
                string fileDirectory = sourceTB1.Text;
                service.pasteDestination = new MyDirectory(fileDirectory, false,1);
                service.copyOperation();
                refreshFolderWindow(fileWindow1, 1, sourceTB1);
            }
        }
        //metoda przycisku usuwającego
        private void deleteButton1_Click(object sender, EventArgs e)
        {
            if (fileWindow1.SelectedItem != null)
            {
                service.DeleteFileOnServer(service.cutTabs(fileWindow1.SelectedItem.ToString()), 1);
                refreshFolderWindow(fileWindow1, 1, sourceTB1);
            }
        }
        //metoda przycisku zmieniającego nazwę
        private void renameButton1_Click(object sender, EventArgs e)
        {
            if (fileWindow1.SelectedItem != null)
            {
                string newName, oldName = service.cutTabs(fileWindow1.SelectedItem.ToString());
                newName = oldName;
                InputBox("Zmiana nazwy", "Podaj nową nazwę pliku wraz z rozszerzeniem", ref newName);
                service.RenameFileServer(oldName, newName, 1);
                refreshFolderWindow(fileWindow1, 1, sourceTB1);
            }
        }

        // ----------------------------Prawa strona

        // metoda opisana powyżej, ale dla lewej strony
        private void connectButton2_Click(object sender, EventArgs e)
        {
            service.server2 = new ServerProperties();
            service.server2.setConnection(serverAdressTB2.Text, userNameTB2.Text, userPasswordTB2.Text);
            sourceTB2.Text = serverAdressTB2.Text;
            refreshFolderWindow(fileWindow2, 2, sourceTB2);
            refreshConnectionStatus(2);
        }

        // metoda opisana powyżej, ale dla lewej strony
        private void disconnectButton2_Click(object sender, EventArgs e)
        {
            refreshConnectionStatus(2);
        }

        private void isServer_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = !groupBox3.Visible;
        }

        private void copyButton2_Click(object sender, EventArgs e)
        {
            // sprawdzenie, czy cokolwiek jest zaznaczone
            if (fileWindow2.SelectedItem != null)
            {
                // sprawdzenie, czy element jest plikiem
                if (fileWindow2.SelectedItem.ToString().Contains(".") && !fileWindow2.SelectedItem.ToString().Contains("..."))
                {
                    // zapisanie ścieżki
                    string separator;
                    // sprawdzamy, czy serwer, czy lokal, bo separatory są różne w obu przypadkach
                    if (groupBox3.Visible)
                    {
                        separator="\\";
                    }
                    else
                    {
                        separator="/";
                    }
                    string fileDirectory = sourceTB2.Text + separator + service.cutTabs(fileWindow2.SelectedItem.ToString());
                    // Jeśli groupBox3 jest widoczny, to oznacza, że mamy doczynienia z lokalną ściężką i tak ją zapisujemy 
                    service.copySource = new MyDirectory(fileDirectory, groupBox3.Visible, 2);
                }
            }
        }

        private void pasteButton2_Click(object sender, EventArgs e)
        {
            // sprawdzenie, czy jest zaznaczony jakiś element
            if (service.copySource != null)
            { // zapisanie ścieżki, na którą zapiszemy plik
                string fileDirectory = sourceTB2.Text;
                service.pasteDestination = new MyDirectory(fileDirectory, groupBox3.Visible, 2);
                service.copyOperation();
                refreshFolderWindow(fileWindow2, groupBox3.Visible ? 0 : 2, sourceTB2);
            }
        }

        private void driversCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sourceTB2.Text = driversCB.SelectedItem.ToString();
            refreshFolderWindow(fileWindow2, 0, sourceTB2);
        }

        private void fileWindow2_DoubleClick(object sender, EventArgs e)
        {
            if (fileWindow2.SelectedItem != null)
            {
                if (!fileWindow2.SelectedItem.ToString().Contains("."))
                {
                    // sprawdzamy dysk, czy lokal
                    if (groupBox3.Visible)
                    {
                        sourceTB2.Text += "\\" + fileWindow2.SelectedItem.ToString();
                        refreshFolderWindow(fileWindow2,0, sourceTB2);
                    }
                    // dwójka w wywołaniu powyżej mówi, że działamy na elementach ze strony prawej
                    else
                    {
                        service.changeFolder(fileWindow2.SelectedItem.ToString(), 2);
                        sourceTB2.Text = service.server2.currentSource;
                        refreshFolderWindow(fileWindow2,2, sourceTB2);
                    }
                }
                else if (fileWindow2.SelectedItem.ToString().Equals("..."))
                {
                    // sprawdzamy dysk, czy lokal
                    if (groupBox3.Visible)
                    {
                        sourceTB2.Text = Directory.GetParent(sourceTB2.Text).ToString();
                        refreshFolderWindow(fileWindow2, 0, sourceTB2);
                    }
                    // na serwerze
                    else
                    {
                        service.goUp(2);
                        sourceTB2.Text = service.server2.currentSource;
                        refreshFolderWindow(fileWindow2,2, sourceTB2);
                    }
                }
            }
        }

        private void deleteButton2_Click(object sender, EventArgs e)
        {
            if (fileWindow2.SelectedItem != null)
            {
                if (groupBox3.Visible)
                {
                    service.DeleteFileOnLocal(service.cutTabs(fileWindow2.SelectedItem.ToString()), sourceTB2.Text);
                    refreshFolderWindow(fileWindow2, 0, sourceTB2);
                }
                // na serwerze
                else
                {
                    service.DeleteFileOnServer(service.cutTabs(fileWindow2.SelectedItem.ToString()), 2);
                    refreshFolderWindow(fileWindow2, 2, sourceTB2);
                }
            }
            
        }

        private void renameButton2_Click(object sender, EventArgs e)
        {
            if (fileWindow2.SelectedItem != null)
            {
                string newName, oldName = service.cutTabs(fileWindow2.SelectedItem.ToString());
                newName = oldName;
                InputBox("Zmiana nazwy", "Podaj nową nazwę pliku wraz z rozszerzeniem", ref newName);
                if (groupBox3.Visible)
                {
                    service.RenameFileOnLocal(oldName, sourceTB2.Text, newName);
                    refreshFolderWindow(fileWindow2, 0, sourceTB2);
                }
                // na serwerze
                else
                {
                    service.RenameFileServer(oldName, newName, 2);
                    refreshFolderWindow(fileWindow2, 2, sourceTB2);
                }
            }
        }

        

    }
}
