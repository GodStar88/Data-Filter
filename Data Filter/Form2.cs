﻿using Data_Filter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Data_Filter
{
    public partial class Form2 : Form
    {
        private List<CContact> ContactList = new List<CContact>();
        private Thread ContactProcess;
        private DataTable ContactDTable = new DataTable();

        public Form2()
        {
            InitializeComponent();
        }

        private void Btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open csv File";
            theDialog.Filter = "csv files|*.csv";
            theDialog.InitialDirectory = Settings.Default["OpenURL"].ToString();
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string path = Path.GetFullPath(theDialog.FileName);
                Settings.Default["OpenURL"] = Path.GetDirectoryName(theDialog.FileName);
                Settings.Default.Save();
                // ContactList = new CCsv().ReadCsvContact(path);
                ContactProcess = new Thread(() => LoadContact(""));
                ContactProcess.Start();                
            }
        }

        private void LoadContact(string str)
        {
            int count = 0;
            object obj = (from m in ContactList.Where(delegate (CContact m)
            {
                switch (cb_contact.Text)
                {
                    case "Name":
                        if (m.Name.ToLower().Contains(str.ToLower()))
                        {
                            count++;
                            return true;
                        }
                        break;
                    case "Title":
                        if (m.Title.ToLower().Contains(str.ToLower()))
                        {
                            count++;
                            return true;
                        }
                        break;
                 case "Email":
                        if (m.Email.ToLower().Contains(str.ToLower()) || m.email1.ToLower().Contains(str.ToLower()) || m.email2.ToLower().Contains(str.ToLower()) || m.PersonalEmail.ToLower().Contains(str.ToLower()))
                        {
                            count++;
                            return true;
                        }
                        break;
                    case "Phone":
                        if (m.companyPhone1.ToLower().Contains(str.ToLower()) || m.companyPhone2.ToLower().Contains(str.ToLower()) || m.companyPhone3.ToLower().Contains(str.ToLower()) || m.contactPhone1.ToLower().Contains(str.ToLower()) || m.contactPhone2.ToLower().Contains(str.ToLower()))
                        {
                            count++;
                            return true;
                        }
                        break;
                    default:
                        count++;
                        return true;
                }
                return false;
            }) select new
            {
                No = count.ToString(),
                List = m.List,
                Name = m.Name,
                firstName = m.firstName,
                lastName = m.lastName,
                Title = m.Title,
                LIProfileUrl = m.LIProfileUrl,
                CompanyLIProfileUrl = m.CompanyLIProfileUrl,
                Company = m.Company,
                CompanyIndustry = m.CompanyIndustry,
                Website = m.Website,
                CompanyLocation = m.CompanyLocation,
                companyStreet1 = m.companyStreet1,
                ContactLocation = m.ContactLocation,
                Phone = m.Phone,
                Email = m.Email,
                email1 = m.email1,
                email2 = m.email2,
                PersonalEmail = m.PersonalEmail,
                companyPhone1 = m.companyPhone1,
                companyPhone2 = m.companyPhone2,
                companyPhone3 = m.companyPhone3,
                contactPhone1 = m.contactPhone1,
                contactPhone2 = m.contactPhone2,
            }).ToList();

            
            
            CheckForIllegalCrossThreadCalls = false;
            this.Invoke((MethodInvoker)delegate
            {
                this.Text = "Data Filter  Loading csv file";
                dataGridView_Contact.AutoGenerateColumns = false;
                dataGridView_Contact.DataSource = obj;
                this.Text = "Data Filter";
            });
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            savefile.FileName = date + "- profile.csv";
            savefile.Filter = "csv files|*.csv";
            string path = "";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                path = Path.GetFullPath(savefile.FileName);
                List<CContact> list = new List<CContact>();
                for (int i = 0; i < dataGridView_Contact.Rows.Count; i++)
                {
                    CContact contact = new CContact();
                    try { contact.List = dataGridView_Contact.Rows[i].Cells[1].Value.ToString(); } catch (Exception) { }
                    try { contact.Name = dataGridView_Contact.Rows[i].Cells[2].Value.ToString(); } catch (Exception) { }
                    try { contact.firstName = dataGridView_Contact.Rows[i].Cells[3].Value.ToString(); } catch (Exception) { }
                    try { contact.lastName = dataGridView_Contact.Rows[i].Cells[4].Value.ToString(); } catch (Exception) { }
                    try { contact.Title = dataGridView_Contact.Rows[i].Cells[5].Value.ToString(); } catch (Exception) { }
                    try { contact.LIProfileUrl = dataGridView_Contact.Rows[i].Cells[6].Value.ToString(); } catch (Exception) { }
                    try { contact.CompanyLIProfileUrl = dataGridView_Contact.Rows[i].Cells[7].Value.ToString(); } catch (Exception) { }
                    try { contact.Company = dataGridView_Contact.Rows[i].Cells[8].Value.ToString(); } catch (Exception) { }
                    try { contact.CompanyIndustry = dataGridView_Contact.Rows[i].Cells[9].Value.ToString(); } catch (Exception) { }
                    try { contact.Website = dataGridView_Contact.Rows[i].Cells[10].Value.ToString(); } catch (Exception) { }
                    try { contact.CompanyLocation = dataGridView_Contact.Rows[i].Cells[11].Value.ToString(); } catch (Exception) { }
                    try { contact.companyStreet1 = dataGridView_Contact.Rows[i].Cells[12].Value.ToString(); } catch (Exception) { }
                    try { contact.ContactLocation = dataGridView_Contact.Rows[i].Cells[13].Value.ToString(); } catch (Exception) { }
                    try { contact.Phone = dataGridView_Contact.Rows[i].Cells[14].Value.ToString(); } catch (Exception) { }
                    try { contact.Email = dataGridView_Contact.Rows[i].Cells[15].Value.ToString(); } catch (Exception) { }
                    try { contact.email1 = dataGridView_Contact.Rows[i].Cells[16].Value.ToString(); } catch (Exception) { }
                    try { contact.email2 = dataGridView_Contact.Rows[i].Cells[17].Value.ToString(); } catch (Exception) { }
                    try { contact.PersonalEmail = dataGridView_Contact.Rows[i].Cells[18].Value.ToString(); } catch (Exception) { }
                    try { contact.companyPhone1 = dataGridView_Contact.Rows[i].Cells[19].Value.ToString(); } catch (Exception) { }
                    try { contact.companyPhone2 = dataGridView_Contact.Rows[i].Cells[20].Value.ToString(); } catch (Exception) { }
                    try { contact.companyPhone3 = dataGridView_Contact.Rows[i].Cells[21].Value.ToString(); } catch (Exception) { }
                    try { contact.contactPhone1 = dataGridView_Contact.Rows[i].Cells[22].Value.ToString(); } catch (Exception) { }
                    try { contact.contactPhone2 = dataGridView_Contact.Rows[i].Cells[23].Value.ToString(); } catch (Exception) { }
                    list.Add(contact);
                }
                new CCsv().SaveCsvContact(list, path);
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView_Contact.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dataGridView_Contact.Rows[i].Cells[0].Value))
                    dataGridView_Contact.Rows.RemoveAt(i);
            }
            for (int i = 0; i < dataGridView_Contact.Rows.Count; i++)
            {
                dataGridView_Contact.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {            
            try { ContactProcess.Abort(); } catch (Exception) { };
            ContactProcess = new Thread(() => LoadContact(tb_contact.Text));
            ContactProcess.Start();
        }
    }
}
