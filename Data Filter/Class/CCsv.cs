using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Filter
{
    class CCsv
    {
        /// <summary>
        /// Append CSV
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="path"></param>
        public void AppendCsv(CProfile profile, string path)
        {
            List<CProfile> list = new List<CProfile>();
            list.AddRange(ReadCsv(path));
            list.Add(profile);
            SaveCsv(list, path);
        }
        /// <summary>
        /// Save CSV
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public void SaveCsv(List<CProfile> list, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            using (CsvWriter cw = new CsvWriter(sw))
            {
                cw.WriteHeader<CProfile>();
                cw.NextRecord();
                foreach (CProfile item in list)
                {
                    cw.WriteRecord<CProfile>(item);
                    cw.NextRecord();
                }
            }
        }
        /// <summary>
        /// Read CSV
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<CProfile> ReadCsv(string path)
        {
            List<CProfile> list = new List<CProfile>();
            using (var textReader = File.OpenText(path))
            {
                var csv = new CsvReader(textReader);
                while (csv.Read())
                {
                    try
                    {
                        var record = csv.Context.Record;
                        var profile = new CProfile();
                        profile.name = record[0];
                        profile.title = record[1];
                        profile.service = record[2];
                        profile.email1 = record[3];
                        profile.email2 = record[4];
                        profile.email3 = record[5];
                        profile.phone1 = record[6];
                        profile.phone2 = record[7];
                        profile.phone3 = record[8];
                        profile.website = record[9];
                        list.Add(profile);
                    }
                    catch (Exception)
                    {
                    }                       
                    
                }
                textReader.Close();
            }
            return list;
        }


        public void AppendCsvContact(CContact profile, string path)
        {
            List<CContact> list = new List<CContact>();
            list.AddRange(ReadCsvContact(path));
            list.Add(profile);
            SaveCsvContact(list, path);
        }
        /// <summary>
        /// Save CSV
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public void SaveCsvContact(List<CContact> list, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            using (CsvWriter cw = new CsvWriter(sw))
            {
                cw.WriteHeader<CContact>();
                cw.NextRecord();
                foreach (CContact item in list)
                {
                    cw.WriteRecord<CContact>(item);
                    cw.NextRecord();
                }
            }
        }
        /// <summary>
        /// Read CSV
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<CContact> ReadCsvContact(string path)
        {
            List<CContact> list = new List<CContact>();
            using (var textReader = File.OpenText(path))
            {
                var csv = new CsvReader(textReader);
                while (csv.Read())
                {
                    try
                    {
                        var record = csv.Context.Record;
                        var profile = new CContact();
                        profile.name = record[2];
                        profile.title = record[6];
                        profile.email = record[37];
                        profile.phone = record[59];
                        list.Add(profile);
                    }
                    catch (Exception)
                    {
                    }

                }
                textReader.Close();
            }
            return list;
        }
    }
}
