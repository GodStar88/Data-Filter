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
    public partial class Form2 : Form
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


        private List<CContact> ProfileList = new List<CContact>();
        public Thread process;
        public Form2()
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
                ProfileList = new CCsv().ReadCsvContact(path);
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
            object obj = (from m in ProfileList.Where(delegate (CContact m)
            {
                switch (comboBox_Search.Text)
                {
                    case "Name":
                        if (m.name.ToLower().Contains(str.ToLower()))
                        {
                            count++;
                            return true;
                        }
                        break;
                    case "Title":
                        if (m.title.ToLower().Contains(str.ToLower()))
                        {
                            count++;
                            return true;
                        }
                        break;
                 case "Email":
                        if (m.email.ToLower().Contains(str.ToLower()))
                        {
                            count++;
                            return true;
                        }
                        break;
                    case "Phone":
                        if (m.phone.ToLower().Contains(str.ToLower()))
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
                Check = false,
                No = count.ToString(),
                Name = m.name,
                Title = m.title,
                Email1 = m.email,
                Phone1 = m.phone,
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
                        dataGridView_Profile.Rows.Add(false, (dataGridView_Profile.Rows.Count + 1).ToString(), ProfileList[i].name, ProfileList[i].title, ProfileList[i].email, ProfileList[i].phone);
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
                List<CContact> list = new List<CContact>();
                for (int i = 0; i < dataGridView_Profile.Rows.Count; i++)
                {
                    CContact profile = new CContact();
                    try { profile.name = dataGridView_Profile.Rows[i].Cells[1].Value.ToString(); } catch (Exception) { }
                    try { profile.title = dataGridView_Profile.Rows[i].Cells[2].Value.ToString(); } catch (Exception) { }
                    try { profile.email = dataGridView_Profile.Rows[i].Cells[3].Value.ToString(); } catch (Exception) { }
                    try { profile.phone = dataGridView_Profile.Rows[i].Cells[4].Value.ToString(); } catch (Exception) { }
                    list.Add(profile);
                }
                new CCsv().SaveCsvContact(list, path);
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

        public void GridClear(DataGridView dataGridView)
        {
            for (int i = dataGridView.Rows.Count - 1; i >= 0; i--)
            {
                dataGridView.Rows.RemoveAt(i);
            }
        }
    }
}
