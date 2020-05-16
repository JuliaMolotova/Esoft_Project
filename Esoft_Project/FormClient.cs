using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
            ShowСlient();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //создаём новый экземпляр класса Клиент
            ClientsSet clientSet = new ClientsSet();
            //делаем ссылку на объект, который хранится в textBox-ax
            clientSet.FirstName = textBoxFirstName.Text;
            clientSet.MiddleName = textBoxMiddleName.Text;
            clientSet.LastName = textBoxLastName.Text;
            clientSet.Phone = textBoxPhone.Text;
            clientSet.E_mail = textBoxEmail.Text;
            //Добавляем в таблицу ClientsSet нового клиента c
            Program.агенство_Недвижимости.ClientsSet.Add(clientSet);
            //Сохраняем изменения в модели wft0b (экземпляр которой был создан ранее)
            Program.агенство_Недвижимости.SaveChanges();
            ShowСlient();
        }
        void ShowСlient()
        {
            //предварительно очищаем listView
            listViewClient.Items.Clear();
            //проходимся по коллекции клиентов, которые находятся в базе с foreach
            foreach (ClientsSet clientsSet in Program.агенство_Недвижимости.ClientsSet)
            {
                //создаем новый элемент в listView
                //для этого создаем новый массив строк
                ListViewItem item = new ListViewItem(new string[]
                    {
                //указываем необходимые поля
                clientsSet.Id.ToString(), clientsSet.FirstName, clientsSet.MiddleName, clientsSet.LastName, clientsSet.Phone, clientsSet.E_mail
                    });
                //указываем по какому тегу будем брать
                item.Tag = clientsSet;
                //добавляем элементы в listView для отображения
                listViewClient.Items.Add(item);
                //выравниваем колонки в listView
                listViewClient.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //условие, если в listView выбран 1 элемент
            if (listViewClient.SelectedItems.Count == 1)
            {
                //ищем элемент из таблицы по тегу
                ClientsSet clientSet = listViewClient.SelectedItems[0].Tag as ClientsSet;
                //указываем, что может быть изменено
                clientSet.FirstName = textBoxFirstName.Text;
                clientSet.MiddleName = textBoxMiddleName.Text;
                clientSet.LastName = textBoxLastName.Text;
                clientSet.Phone = textBoxPhone.Text;
                clientSet.E_mail = textBoxEmail.Text;
                //Сохраняем изменения в модели (экземпляр был создан ранее)
                Program.агенство_Недвижимости.SaveChanges();
                //отображение в listView
                ShowСlient();
            }

        }

        private void listViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            //условие, если выбран 1
            if (listViewClient.SelectedItems.Count == 1)
            {
                //ищем элемент из таблицы по тегу
                ClientsSet clientSet = listViewClient.SelectedItems[0].Tag as ClientsSet;
                //Указываем, что может быть изменено
                textBoxFirstName.Text = clientSet.FirstName;
                textBoxMiddleName.Text = clientSet.MiddleName;
                textBoxLastName.Text = clientSet.LastName;
                textBoxPhone.Text = clientSet.Phone;
                textBoxEmail.Text = clientSet.E_mail;
            }
            else
                //условие, иначе, если не выбран ни один элемент, то задаем пустые поля
                textBoxFirstName.Text = "";
            textBoxMiddleName.Text = "";
            textBoxLastName.Text = "";
            textBoxPhone.Text = "";
            textBoxEmail.Text = "";
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //пробуем совершить действие
            try
            {
                //если выбран один элемент listView
                if (listViewClient.SelectedItems.Count == 1)
                {
                    //ищем этот элемент, сверяем его
                    ClientsSet clientsSet = listViewClient.SelectedItems[0].Tag as ClientsSet;
                    //удаляем из модели и базы данных
                    Program.агенство_Недвижимости.ClientsSet.Remove(clientsSet);
                    //сохраняем изменения
                    Program.агенство_Недвижимости.SaveChanges();
                    //отображаем обновлённый список
                    ShowСlient();
                }
                //очищаем TextBox-m
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
            }
            //если возникает какая-то ошибка, к примеру, запись исп, выводим всплывающее сообщение
            catch
            {
                //вызываем метод всплывающего окна, в котором указываем текст, заголовок, кнопку и иконку
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
