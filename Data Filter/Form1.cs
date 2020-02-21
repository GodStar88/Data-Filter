﻿using Data_Filter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Data_Filter
{
    public partial class FrmMain : Form
    {
        private List<CProfile> ProfileList = new List<CProfile>();
        private Thread ProfileProcess;
        private DataTable ProfileDTable = new DataTable();

        private List<CContact> ContactList = new List<CContact>();
        private Thread ContactProcess;
        private DataTable ContactDTable = new DataTable();

        public FrmMain()
        {
            InitializeComponent();
        }
       
        private void Btn_Open_Click(object sender, EventArgs e)
        {
            dataGridView_Profile.Visible = true;
            cb_profile.Visible = true;
            tb_profile.Visible = true;
            Btn_Search.Visible = true;
            Btn_Save.Visible = true;
            cb_profile_dedupe.Visible = true;
            btn_profile_dedupe.Visible = true;

            dataGridView_Contact.Visible = false;
            cb_contact.Visible = false;
            tb_contact.Visible = false;
            Btn__Contact_Search.Visible = false;
            Btn_Contact_Save.Visible = false;
            cb_contact_dedupe.Visible = false;
            btn_contact_dedupe.Visible = false;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open csv File";
            theDialog.Filter = "csv files|*.csv";
            theDialog.InitialDirectory = Settings.Default["OpenURL"].ToString();
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string path = Path.GetFullPath(theDialog.FileName);
                Settings.Default["OpenURL"] = Path.GetDirectoryName(theDialog.FileName);
                Settings.Default.Save();
                ProfileList = new CCsv().ReadCsv(path);
                ProfileProcess = new Thread(() => LoadProfile(""));
                ProfileProcess.Start();                
            }
        }

        private void LoadProfile(string str)
        {
            int count = 0;
            object obj = (from m in ProfileList.Where(delegate (CProfile m)
            {
                switch (cb_profile.Text)
                {
                    case "Name":
                        if (m.name.Contains(str))
                        {
                            count++;
                            return true;
                        }
                        break;
                    case "Title":
                        if (m.title.Contains(str))
                        {
                            count++;
                            return true;
                        }
                        break;
                    case "Service":
                        if (m.service.Contains(str))
                        {
                            count++;
                            return true;
                        }
                        break;
                    case "Email":
                        if (m.email1.Contains(str) || m.email2.Contains(str) || m.email3.Contains(str))
                        {
                            count++;
                            return true;
                        }
                        break;
                    case "Phone":
                        if (m.phone1.Contains(str) || m.phone2.Contains(str) || m.phone3.Contains(str))
                        {
                            count++;
                            return true;
                        }
                        break;
                    case "Website":
                        if (m.website.Contains(str))
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
            })
                          select new
                          {
                                 No = count.ToString(),
                                 Name = m.name,
                                 Title = m.title,
                                 Service = m.service,
                                 Email1 = m.email1,
                                 Email2 = m.email2,
                                 Email3 = m.email3,
                                 Phone1 = m.phone1,
                                 Phone2 = m.phone2,
                                 Phone3 = m.phone3,
                                 Website = m.website
                             }).ToList();

            CheckForIllegalCrossThreadCalls = false;
            this.Invoke((MethodInvoker)delegate
            {
                this.Text = "Data Manager  Loading csv file";
                dataGridView_Profile.AutoGenerateColumns = false;
                dataGridView_Profile.DataSource = obj;
                this.Text = "Data Manager 1.00";
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
                List<CProfile> list = new List<CProfile>();
                for (int i = 0; i < dataGridView_Profile.Rows.Count; i++)
                {
                    CProfile profile = new CProfile();
                    try { profile.name = dataGridView_Profile.Rows[i].Cells[1].Value.ToString(); } catch (Exception) { }
                    try { profile.title = dataGridView_Profile.Rows[i].Cells[2].Value.ToString(); } catch (Exception) { }
                    try { profile.service = dataGridView_Profile.Rows[i].Cells[3].Value.ToString(); } catch (Exception) { }
                    try { profile.email1 = dataGridView_Profile.Rows[i].Cells[4].Value.ToString(); } catch (Exception) { }
                    try { profile.email2 = dataGridView_Profile.Rows[i].Cells[5].Value.ToString(); } catch (Exception) { }
                    try { profile.email3 = dataGridView_Profile.Rows[i].Cells[6].Value.ToString(); } catch (Exception) { }
                    try { profile.phone1 = dataGridView_Profile.Rows[i].Cells[7].Value.ToString(); } catch (Exception) { }
                    try { profile.phone2 = dataGridView_Profile.Rows[i].Cells[8].Value.ToString(); } catch (Exception) { }
                    try { profile.phone3 = dataGridView_Profile.Rows[i].Cells[9].Value.ToString(); } catch (Exception) { }
                    try { profile.website = dataGridView_Profile.Rows[i].Cells[10].Value.ToString(); } catch (Exception) { }
                    list.Add(profile);
                }
                new CCsv().SaveCsv(list, path);
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {            
            try { ProfileProcess.Abort(); } catch (Exception) { };
            ProfileProcess = new Thread(() => LoadProfile(tb_profile.Text));
            ProfileProcess.Start();
        }

        private void Btn__Contact_Search_Click(object sender, EventArgs e)
        {
            try { ContactProcess.Abort(); } catch (Exception) { };
            ContactProcess = new Thread(() => LoadContact(tb_contact.Text));
            ContactProcess.Start();
        }

        private void Btn_Contact_Open_Click(object sender, EventArgs e)
        {
            dataGridView_Profile.Visible = false;
            cb_profile.Visible = false;
            tb_profile.Visible = false;
            Btn_Search.Visible = false;
            Btn_Save.Visible = false;
            cb_profile_dedupe.Visible = false;
            btn_profile_dedupe.Visible = false;

            dataGridView_Contact.Visible = true;
            cb_contact.Visible = true;
            tb_contact.Visible = true;
            Btn__Contact_Search.Visible = true;
            Btn_Contact_Save.Visible = true;
            cb_contact_dedupe.Visible = true;
            btn_contact_dedupe.Visible = true;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open csv File";
            theDialog.Filter = "csv files|*.csv";
            theDialog.InitialDirectory = Settings.Default["OpenURL"].ToString();
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string path = Path.GetFullPath(theDialog.FileName);
                Settings.Default["OpenURL"] = Path.GetDirectoryName(theDialog.FileName);
                Settings.Default.Save();
                ContactList = new CCsv().ReadCsvContact(path);
                ContactProcess = new Thread(() => LoadContact(""));
                ContactProcess.Start();
            }
        }

        private void Btn_Contact_Save_Click(object sender, EventArgs e)
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
            })
                          select new
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
                this.Text = "Data Manager  Loading csv file";
                dataGridView_Contact.AutoGenerateColumns = false;
                dataGridView_Contact.DataSource = obj;
                this.Text = "Data Manager 1.00";
            });
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "Data Manager 1.00";
        }

        private void btn_profile_dedupe_Click(object sender, EventArgs e)
        {
            int count = 0;
            object obj = null;

            switch (cb_profile_dedupe.Text)
            {
                case "Name":
                    obj = (from m in ProfileList.Where(delegate (CProfile m)
                    {
                        count++;
                        return true;
                    })
                           select new
                           {
                               No = count.ToString(),
                               Name = m.name,
                               Title = m.title,
                               Service = m.service,
                               Email1 = m.email1,
                               Email2 = m.email2,
                               Email3 = m.email3,
                               Phone1 = m.phone1,
                               Phone2 = m.phone2,
                               Phone3 = m.phone3,
                               Website = m.website
                           }).GroupBy(m => m.Name).Select(m => m.FirstOrDefault()).ToList();
                    break;
                case "Title":
                    obj = (from m in ProfileList.Where(delegate (CProfile m)
                    {
                        count++;
                        return true;
                    })
                           select new
                           {
                               No = count.ToString(),
                               Name = m.name,
                               Title = m.title,
                               Service = m.service,
                               Email1 = m.email1,
                               Email2 = m.email2,
                               Email3 = m.email3,
                               Phone1 = m.phone1,
                               Phone2 = m.phone2,
                               Phone3 = m.phone3,
                               Website = m.website
                           }).GroupBy(m => m.Title).Select(m => m.FirstOrDefault()).ToList();
                    break;
                case "Service":
                    obj = (from m in ProfileList.Where(delegate (CProfile m)
                    {
                        count++;
                        return true;
                    })
                           select new
                           {
                               No = count.ToString(),
                               Name = m.name,
                               Title = m.title,
                               Service = m.service,
                               Email1 = m.email1,
                               Email2 = m.email2,
                               Email3 = m.email3,
                               Phone1 = m.phone1,
                               Phone2 = m.phone2,
                               Phone3 = m.phone3,
                               Website = m.website
                           }).GroupBy(m => m.Service).Select(m => m.FirstOrDefault()).ToList();
                    break;
                case "Email":
                    obj = (from m in ProfileList.Where(delegate (CProfile m)
                    {
                        count++;
                        return true;
                    })
                           select new
                           {
                               No = count.ToString(),
                               Name = m.name,
                               Title = m.title,
                               Service = m.service,
                               Email1 = m.email1,
                               Email2 = m.email2,
                               Email3 = m.email3,
                               Phone1 = m.phone1,
                               Phone2 = m.phone2,
                               Phone3 = m.phone3,
                               Website = m.website
                           }).GroupBy(m => m.Email1).Select(m => m.FirstOrDefault()).ToList();
                    break;
                case "Phone":
                    obj = (from m in ProfileList.Where(delegate (CProfile m)
                    {
                        count++;
                        return true;
                    })
                           select new
                           {
                               No = count.ToString(),
                               Name = m.name,
                               Title = m.title,
                               Service = m.service,
                               Email1 = m.email1,
                               Email2 = m.email2,
                               Email3 = m.email3,
                               Phone1 = m.phone1,
                               Phone2 = m.phone2,
                               Phone3 = m.phone3,
                               Website = m.website
                           }).GroupBy(m => m.Phone1).Select(m => m.FirstOrDefault()).ToList();
                    break;
                case "Website":
                    obj = (from m in ProfileList.Where(delegate (CProfile m)
                    {
                        count++;
                        return true;
                    })
                           select new
                           {
                               No = count.ToString(),
                               Name = m.name,
                               Title = m.title,
                               Service = m.service,
                               Email1 = m.email1,
                               Email2 = m.email2,
                               Email3 = m.email3,
                               Phone1 = m.phone1,
                               Phone2 = m.phone2,
                               Phone3 = m.phone3,
                               Website = m.website
                           }).GroupBy(m => m.Website).Select(m => m.FirstOrDefault()).ToList();
                    break;
            }

            CheckForIllegalCrossThreadCalls = false;
            this.Invoke((MethodInvoker)delegate
            {
                this.Text = "Data Manager  Loading csv file";
                dataGridView_Profile.AutoGenerateColumns = false;
                dataGridView_Profile.DataSource = obj;
                this.Text = "Data Manager 1.00";
            });
        }

        private void btn_contact_dedupe_Click(object sender, EventArgs e)
        {
            int count = 0;
            object obj = null;

            switch (cb_contact_dedupe.Text)
            {
                case "Name":
                    obj = (from m in ContactList.Where(delegate (CContact m)
                    {
                        count++;
                        return true;
                    })
                           select new
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
                           }).GroupBy(m => m.Name).Select(m => m.FirstOrDefault()).ToList();
                    break;
                case "Title":
                    obj = (from m in ContactList.Where(delegate (CContact m)
                    {
                        count++;
                        return true;
                    })
                           select new
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
                           }).GroupBy(m => m.Title).Select(m => m.FirstOrDefault()).ToList();
                    break;
                case "Email":
                    obj = (from m in ContactList.Where(delegate (CContact m)
                    {
                        count++;
                        return true;
                    })
                           select new
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
                           }).GroupBy(m => m.email1).Select(m => m.FirstOrDefault()).ToList();
                    break;
                case "Phone":
                    obj = (from m in ContactList.Where(delegate (CContact m)
                    {
                        count++;
                        return true;
                    })
                           select new
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
                           }).GroupBy(m => m.Phone).Select(m => m.FirstOrDefault()).ToList();
                    break;
                case "Linkedin":
                    obj = (from m in ContactList.Where(delegate (CContact m)
                    {
                        count++;
                        return true;
                    })
                           select new
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
                           }).GroupBy(m => m.LIProfileUrl).Select(m => m.FirstOrDefault()).ToList();
                    break;
                default:
                    obj = (from m in ContactList.Where(delegate (CContact m)
                    {
                        count++;
                        return true;
                    })
                           select new
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
                    break;
            }

            CheckForIllegalCrossThreadCalls = false;
            this.Invoke((MethodInvoker)delegate
            {
                this.Text = "Data Manager  Loading csv file";
                dataGridView_Contact.AutoGenerateColumns = false;
                dataGridView_Contact.DataSource = obj;
                this.Text = "Data Manager 1.00";
            });
        }
    }
}
