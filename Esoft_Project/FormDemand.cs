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
    public partial class FormDemand : Form
    {
        public FormDemand()
        {
            InitializeComponent();
            comboBoxType.SelectedIndex = 0;
            ShowAgents();
            ShowClients();
            ShowDemandSet();
        }

        private void listViewRealEstateSet_Land_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormDemand_Load(object sender, EventArgs e)
        {

        }

        private void listViewDEmandSet_Apartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemandSet_Apartment.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemandSet_Apartment.SelectedItems[0].Tag as DemandSet;
                comboBoxAgent.SelectedItem = comboBoxAgent.FindString(demand.IdAgent.ToString());
                comboBoxClient.SelectedItem = comboBoxAgent.FindString(demand.IdClient.ToString());
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                textBoxMinArea.Text = demand.MinArea.ToString();
                textBoxMaxArea.Text = demand.MaxArea.ToString();
                textBoxMinRooms.Text = demand.MinRooms.ToString();
                textBoxMaxRooms.Text = demand.MaxRooms.ToString();
                textBoxMinFloor.Text = demand.MinFloor.ToString();
                textBoxMaxFloor.Text = demand.MaxFloor.ToString();
            }
            else
            {
                comboBoxAgent.SelectedItem = null;
                comboBoxClient.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMaxRooms.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxFloor.Text = "";
            }
        }

        private void comboBoxRealEstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                listViewDemandSet_Apartment.Visible = true;
                labelAgent.Visible = true;
                comboBoxAgent.Visible = true;
                labelClient.Visible = true;
                comboBoxClient.Visible = true;
                labelMinPrice.Visible = true;
                textBoxMinPrice.Visible = true;
                labelMaxPrice.Visible = true;
                textBoxMaxPrice.Visible = true;
                labelMinArea.Visible = true;
                textBoxMinArea.Visible = true;
                labelMaxArea.Visible = true;
                textBoxMaxArea.Visible = true;
                labelMinRooms.Visible = true;
                textBoxMinRooms.Visible = true;
                labelMaxRooms.Visible = true;
                textBoxMaxRooms.Visible = true;
                labelMinFloor.Visible = true;
                textBoxMinFloor.Visible = true;
                labelMaxFloor.Visible = true;
                textBoxMaxFloor.Visible = true;

                listViewDemandSet_House.Visible = false;
                listViewDemandSet_Land.Visible = false;
                labelMinFloors.Visible = false;
                textBoxMinFloors.Visible = false;
                labelMaxFloors.Visible = false;
                textBoxMaxFloors.Visible = false;

                comboBoxAgent.Text = "";
                comboBoxClient.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMaxRooms.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxFloor.Text = "";
            }

            else if (comboBoxType.SelectedIndex == 1)
            {
                listViewDemandSet_House.Visible = true;
                labelMinFloors.Visible = true;
                textBoxMinFloors.Visible = true;
                labelMaxFloors.Visible = true;
                textBoxMaxFloors.Visible = true;

                listViewDemandSet_Land.Visible = false;
                listViewDemandSet_Apartment.Visible = false;
                labelMinRooms.Visible = false;
                textBoxMinRooms.Visible = false;
                labelMaxRooms.Visible = false;
                textBoxMaxRooms.Visible = false;
                labelMinFloor.Visible = false;
                textBoxMinFloor.Visible = false;
                labelMaxFloor.Visible = false;
                textBoxMaxFloor.Visible = false;

                comboBoxAgent.Text = "";
                comboBoxClient.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinFloors.Text = "";
                textBoxMaxFloors.Text = "";
            }

            else if (comboBoxType.SelectedIndex == 2)
            {
                listViewDemandSet_Land.Visible = true;

                listViewDemandSet_House.Visible = false;
                listViewDemandSet_Apartment.Visible = false;
                labelMinRooms.Visible = false;
                textBoxMinRooms.Visible = false;
                labelMaxRooms.Visible = false;
                textBoxMaxRooms.Visible = false;
                labelMinFloor.Visible = false;
                textBoxMinFloor.Visible = false;
                labelMaxFloor.Visible = false;
                textBoxMaxFloor.Visible = false;
                labelMinFloors.Visible = false;
                textBoxMinFloors.Visible = false;
                labelMaxFloors.Visible = false;
                textBoxMaxFloors.Visible = false;

                comboBoxAgent.Text = "";
                comboBoxClient.Text = "";
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DemandSet demand = new DemandSet();
            demand.MinPrice = Convert.ToInt32(textBoxMinPrice.Text);
            demand.MaxPrice = Convert.ToInt32(textBoxMaxPrice.Text);
            demand.MinArea = Convert.ToInt32(textBoxMinArea.Text);
            demand.MaxArea = Convert.ToInt32(textBoxMaxArea.Text);
            if (comboBoxType.SelectedIndex == 0)
            {
                demand.Type = 0;
                demand.MinRooms = Convert.ToInt32(textBoxMinRooms.Text);
                demand.MaxRooms = Convert.ToInt32(textBoxMaxRooms.Text);
                demand.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                demand.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                demand.Type = 1;
                demand.MinFloors = Convert.ToInt32(textBoxMinFloors.Text);
                demand.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);
            }
            else
            {
                demand.Type = 2;
            }
            Program.агенство_Недвижимости.DemandSet.Add(demand);
            Program.агенство_Недвижимости.SaveChanges();
            ShowDemandSet();
        }
        void ShowDemandSet()
        {
            listViewDemandSet_Apartment.Items.Clear();
            listViewDemandSet_House.Items.Clear();
            listViewDemandSet_Land.Items.Clear();
            foreach (DemandSet demand in Program.агенство_Недвижимости.DemandSet)
            {
                if (demand.Type == 0)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demand.MinPrice.ToString(), demand.MaxPrice.ToString(), demand.MinArea.ToString(), demand.MaxArea.ToString(), demand.MinRooms.ToString(), demand.MaxRooms.ToString(), demand.MinFloor.ToString(), demand.MaxFloor.ToString()
                    });
                    item.Tag = demand;
                    listViewDemandSet_Apartment.Items.Add(item);
                }
                else if (demand.Type == 1)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                       demand.MinPrice.ToString(), demand.MaxPrice.ToString(), demand.MinArea.ToString(), demand.MaxArea.ToString(), demand.MinFloors.ToString(), demand.MaxFloors.ToString()
                    });
                    item.Tag = demand;
                    listViewDemandSet_House.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demand.MinPrice.ToString(), demand.MaxPrice.ToString(), demand.MinArea.ToString(), demand.MaxArea.ToString()
                    });
                    item.Tag = demand;
                    listViewDemandSet_Land.Items.Add(item);
                }
            }
            listViewDemandSet_Apartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewDemandSet_House.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewDemandSet_Land.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                if (listViewDemandSet_Apartment.SelectedItems.Count == 1)
                {
                    DemandSet demand = listViewDemandSet_Apartment.SelectedItems[0].Tag as DemandSet;
                    demand.MinPrice = Convert.ToInt32(textBoxMinPrice.Text);
                    demand.MaxPrice = Convert.ToInt32(textBoxMaxPrice.Text);
                    demand.MinArea = Convert.ToInt32(textBoxMinArea.Text);
                    demand.MaxArea = Convert.ToInt32(textBoxMaxArea.Text);
                    demand.MinRooms = Convert.ToInt32(textBoxMinRooms.Text);
                    demand.MaxRooms = Convert.ToInt32(textBoxMaxRooms.Text);
                    demand.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                    demand.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);
                    Program.агенство_Недвижимости.SaveChanges();
                    ShowDemandSet();
                }
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                if (listViewDemandSet_House.SelectedItems.Count == 1)
                {
                    DemandSet demand = listViewDemandSet_House.SelectedItems[0].Tag as DemandSet;
                    demand.MinPrice = Convert.ToInt32(textBoxMinPrice.Text);
                    demand.MaxPrice = Convert.ToInt32(textBoxMaxPrice.Text);
                    demand.MinArea = Convert.ToInt32(textBoxMinArea.Text);
                    demand.MaxArea = Convert.ToInt32(textBoxMaxArea.Text);
                    demand.MinFloors = Convert.ToInt32(textBoxMinFloors.Text);
                    demand.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);
                    Program.агенство_Недвижимости.SaveChanges();
                    ShowDemandSet();
                }
            }
            else
            {
                if (listViewDemandSet_Land.SelectedItems.Count == 1)
                {
                    DemandSet demand = listViewDemandSet_Land.SelectedItems[0].Tag as DemandSet;
                    demand.MinPrice = Convert.ToInt32(textBoxMinPrice.Text);
                    demand.MaxPrice = Convert.ToInt32(textBoxMaxPrice.Text);
                    demand.MinArea = Convert.ToInt32(textBoxMinArea.Text);
                    demand.MaxArea = Convert.ToInt32(textBoxMaxArea.Text);
                    Program.агенство_Недвижимости.SaveChanges();
                    ShowDemandSet();
                }
            }
        }

        private void listViewDemandSet_House_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemandSet_House.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemandSet_House.SelectedItems[0].Tag as DemandSet;
                comboBoxAgent.SelectedItem = comboBoxAgent.FindString(demand.IdAgent.ToString());
                comboBoxClient.SelectedItem = comboBoxAgent.FindString(demand.IdClient.ToString());
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                textBoxMinArea.Text = demand.MinArea.ToString();
                textBoxMaxArea.Text = demand.MaxArea.ToString();
                textBoxMinFloors.Text = demand.MinFloors.ToString();
                textBoxMaxFloors.Text = demand.MaxFloors.ToString();
            }
            else
            {
                comboBoxAgent.SelectedItem = null;
                comboBoxClient.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinFloors.Text = "";
                textBoxMaxFloors.Text = "";
            }
        }

        private void listViewDemandSet_Land_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemandSet_Land.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemandSet_Land.SelectedItems[0].Tag as DemandSet;
                comboBoxAgent.SelectedItem = comboBoxAgent.FindString(demand.IdAgent.ToString());
                comboBoxClient.SelectedItem = comboBoxAgent.FindString(demand.IdClient.ToString());
                textBoxMinPrice.Text = demand.MinPrice.ToString();
            textBoxMaxPrice.Text = demand.MaxPrice.ToString();
            textBoxMinArea.Text = demand.MinArea.ToString();
            textBoxMaxArea.Text = demand.MaxArea.ToString();
        }
            else
            {
                comboBoxAgent.SelectedItem = null;
                comboBoxClient.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
            }

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.SelectedIndex == 0)
                {
                    if (listViewDemandSet_Apartment.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewDemandSet_Apartment.SelectedItems[0].Tag as DemandSet;
                        Program.агенство_Недвижимости.DemandSet.Remove(demand);
                        Program.агенство_Недвижимости.SaveChanges();
                        ShowDemandSet();
                    }
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrice.Text = "";
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                    textBoxMinRooms.Text = "";
                    textBoxMaxRooms.Text = "";
                    textBoxMinFloor.Text = "";
                    textBoxMaxFloor.Text = "";
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listViewDemandSet_House.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewDemandSet_House.SelectedItems[0].Tag as DemandSet;
                        Program.агенство_Недвижимости.DemandSet.Remove(demand);
                        Program.агенство_Недвижимости.SaveChanges();
                        ShowDemandSet();
                    }
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrice.Text = "";
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                    textBoxMinFloors.Text = "";
                    textBoxMaxFloors.Text = "";
                }
                else
                {
                    if (listViewDemandSet_Land.SelectedItems.Count ==1)
                    {
                        DemandSet demand = listViewDemandSet_Land.SelectedItems[0].Tag as DemandSet;
                        Program.агенство_Недвижимости.DemandSet.Remove(demand);
                        Program.агенство_Недвижимости.SaveChanges();
                        ShowDemandSet();
                    }
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrice.Text = "";
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxAgent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void ShowAgents()
        {
            comboBoxAgent.Items.Clear();
            foreach (AgentSet agentSet in Program.агенство_Недвижимости.AgentSet)
            {
                string[] item = { agentSet.Id.ToString() + ".", agentSet.FirstName, agentSet.LastName };
                comboBoxAgent.Items.Add(string.Join(" ", item));
            }
        }

        void ShowClients()
        {
            comboBoxClient.Items.Clear();
            foreach (ClientsSet clientsSet in Program.агенство_Недвижимости.ClientsSet)
            {
                string[] item = { clientsSet.Id.ToString() + ".", clientsSet.FirstName, clientsSet.MiddleName, clientsSet.LastName };
                comboBoxClient.Items.Add(string.Join(" ", item));
            }
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
