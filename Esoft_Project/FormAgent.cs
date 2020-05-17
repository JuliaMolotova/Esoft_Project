using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class FormAgent : Form
    {
        public FormAgent()
        {
            InitializeComponent();
            ShowAgent();
        }

        private void FormAgent_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //создаём новый экземпляр класса Риелтор
            AgentSet agentSet = new AgentSet();
            //делаем ссылку на объект, который хранится в textBox-ax
            agentSet.FirstName = textBoxFirstName.Text;
            agentSet.MiddleName = textBoxMiddleName.Text;
            agentSet.LastName = textBoxLastName.Text;
            agentSet.DealShare = Convert.ToInt32(textBoxDealShare.Text);
            //Добавляем в таблицу AgentsSet нового риелтора
            Program.агенство_Недвижимости.AgentSet.Add(agentSet);
            //Сохраняем изменения в модели  (экземпляр которой был создан ранее)
            Program.агенство_Недвижимости.SaveChanges();
            ShowAgent();
        }
        void ShowAgent()
        {
            //предварительно очищаем listView
            listViewAgent.Items.Clear();
            //проходимся по коллекции клиентов, которые находятся в базе с foreach
            foreach (AgentSet agentSet in Program.агенство_Недвижимости.AgentSet)
            {
                //создаем новый элемент в listView
                //для этого создаем новый массив строк
                ListViewItem item = new ListViewItem(new string[]
                    {
                //указываем необходимые поля
                agentSet.Id.ToString(), agentSet.FirstName, agentSet.MiddleName, agentSet.LastName, agentSet.DealShare.ToString()
                    });
                //указываем по какому тегу будем брать
                item.Tag = agentSet;
                //добавляем элементы в listView для отображения
                listViewAgent.Items.Add(item);
            }
                //выравниваем колонки в listView
                listViewAgent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //условие, если в listView выбран 1 элемент
            if (listViewAgent.SelectedItems.Count == 1)
            {
                //ищем элемент из таблицы по тегу
                AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                //указываем, что может быть изменено
                agentSet.FirstName = textBoxFirstName.Text;
                agentSet.MiddleName = textBoxMiddleName.Text;
                agentSet.LastName = textBoxLastName.Text;
                agentSet.DealShare = Convert.ToInt32(textBoxDealShare);
                //Сохраняем изменения в модели (экземпляр был создан ранее)
                Program.агенство_Недвижимости.SaveChanges();
                //отображение в listView
                ShowAgent();
            }
        }

        private void listViewAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //условие, если выбран 1
            if (listViewAgent.SelectedItems.Count == 1)
            {
                //ищем элемент из таблицы по тегу
                AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                //Указываем, что может быть изменено
                textBoxFirstName.Text = agentSet.FirstName;
                textBoxMiddleName.Text = agentSet.MiddleName;
                textBoxLastName.Text = agentSet.LastName;
                textBoxDealShare.Text = agentSet.DealShare.ToString();
            }
            else
            //условие, иначе, если не выбран ни один элемент, то задаем пустые поля
            textBoxFirstName.Text = "";
            textBoxMiddleName.Text = "";
            textBoxLastName.Text = "";
            textBoxDealShare.Text = "";
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //пробуем совершить действие
            try
            {
                //если выбран один элемент listView
                if (listViewAgent.SelectedItems.Count == 1)
                {
                    //ищем этот элемент, сверяем его
                    AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                    //удаляем из модели и базы данных
                    Program.агенство_Недвижимости.AgentSet.Remove(agentSet);
                    //сохраняем изменения
                    Program.агенство_Недвижимости.SaveChanges();
                    //отображаем обновлённый список
                    ShowAgent();
                }
                //очищаем TextBox-m
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";
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
