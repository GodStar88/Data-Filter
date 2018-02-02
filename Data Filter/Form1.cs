using Data_Filter.Properties;
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
        private class StopwatchHelper
        {
            private ListBox _listbox;
            private Stopwatch _sw = new Stopwatch();

            public StopwatchHelper(ListBox listbox)
            {
                _listbox = listbox;
            }

            public void Start()
            {
                _sw.Restart();
            }

            public void Stop(string msg)
            {
                _sw.Stop();
                _listbox.Items.Add(String.Format("{0}: {1} ms", msg, _sw.ElapsedMilliseconds));
            }
        }


        private List<CProfile> ProfileList = new List<CProfile>();
        public Thread process;
        public FrmMain()
        {
            InitializeComponent();
        }
        DataTable DTable = new DataTable();
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
                ProfileList = new CCsv().ReadCsv(path);
                // _swDGV = new StopwatchHelper(lstResultsDGV);
                // RepopulateDGV();
                process = new Thread(() => LoadProfile(""));
                process.Start();                
            }
        }
        StopwatchHelper _swDGV;
        private void RepopulateDGV()
        {
            _swDGV.Start();

            dataGridView_Profile.Rows.Clear();

            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            for (int i = 1; i < ProfileList.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView_Profile);
                row.Cells[0].Value = ProfileList[i].name;
                row.Cells[1].Value = ProfileList[i].title;
                rows.Add(row);
            }

            dataGridView_Profile.Rows.AddRange(rows.ToArray());

            _swDGV.Stop(String.Format("Populating {0} rows", ProfileList.Count.ToString()));
        }
        private void LoadProfile(string str)
        {
            int count = 0;
            object obj = (from m in ProfileList.Where(delegate (CProfile m)
            {
                switch (comboBox_Search.Text)
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
                        break;
                }
                return false;
            }) select new
            {
                Check = false,
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
                this.Text = "Data Filter  Loading csv file";
                dataGridView_Profile.AutoGenerateColumns = false;
                dataGridView_Profile.DataSource = obj;
                this.Text = "Data Filter";
            });
        }

        private void LoadProfile1(string v)
        {
            for (int i = 0; i < ProfileList.Count; i++)
            {
                CheckForIllegalCrossThreadCalls = false;
                this.Invoke((MethodInvoker)delegate
                {
                    if (ProfileList[i].title.Contains(v))
                        dataGridView_Profile.Rows.Add(false, (dataGridView_Profile.Rows.Count + 1).ToString(), ProfileList[i].name, ProfileList[i].title, ProfileList[i].service, ProfileList[i].email1, ProfileList[i].email2, ProfileList[i].email3, ProfileList[i].phone1, ProfileList[i].phone2, ProfileList[i].phone3, ProfileList[i].website);
                });
            }
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

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView_Profile.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dataGridView_Profile.Rows[i].Cells[0].Value))
                    dataGridView_Profile.Rows.RemoveAt(i);
            }
            for (int i = 0; i < dataGridView_Profile.Rows.Count; i++)
            {
                dataGridView_Profile.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {            
            try { process.Abort(); } catch (Exception) { };
            process = new Thread(() => LoadProfile(textBox_Search.Text));
            process.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_Profile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Profile.CheckState.ToString() == "Checked")
            {
                for (int i = 0; i < dataGridView_Profile.Rows.Count; i++)
                {
                    dataGridView_Profile.Rows[i].Cells[0].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dataGridView_Profile.Rows.Count; i++)
                {
                    dataGridView_Profile.Rows[i].Cells[0].Value = false;
                }
            }
        }

        public void GridClear(DataGridView dataGridView)
        {
            for (int i = dataGridView.Rows.Count - 1; i >= 0; i--)
            {
                dataGridView.Rows.RemoveAt(i);
            }
        }
    }
}
