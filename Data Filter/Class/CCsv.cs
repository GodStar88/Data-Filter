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
        public class CEmail
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        

        public void SaveCsv<T>(List<T> list, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            using (CsvWriter cw = new CsvWriter(sw))
            {
                cw.WriteHeader<T>();
                cw.NextRecord();
                foreach (T item in list)
                {
                    cw.WriteRecord<T>(item);
                    cw.NextRecord();
                }
            }
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
                        if (profile.name != "name")
                        {
                            list.Add(profile);
                        }
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
                    do
                    {
                        try
                        {
                            var record = csv.Context.Record;
                            var profile = new CContact();
                            profile.List = record[1];
                            profile.Name = record[2];
                            profile.firstName = record[3];
                            profile.lastName = record[5];
                            profile.Title = record[6];
                            profile.LIProfileUrl = record[7];
                            profile.CompanyLIProfileUrl = record[8];
                            profile.Company = record[10];
                            profile.CompanyIndustry = record[11];
                            profile.Website = record[15];
                            profile.CompanyLocation = record[16];
                            profile.companyStreet1 = record[17];
                            profile.ContactLocation = record[26];
                            profile.Phone = record[36];
                            profile.Email = record[37];
                            profile.email1 = record[38];
                            profile.email2 = record[41];
                            profile.PersonalEmail = record[44];
                            profile.companyPhone1 = record[51];
                            profile.companyPhone2 = record[53];
                            profile.companyPhone3 = record[55];
                            profile.contactPhone1 = record[57];
                            profile.contactPhone2 = record[59];
                            if (profile.List != "List")
                            {
                                list.Add(profile);
                            }
                            break;
                        }
                        catch (Exception)
                        {
                        }

                        try
                        {
                            var record = csv.Context.Record;
                            var profile = new CContact();
                            profile.List = record[0];
                            profile.Name = record[1];
                            profile.firstName = record[2];
                            profile.lastName = record[3];
                            profile.Title = record[4];
                            profile.LIProfileUrl = record[5];
                            profile.CompanyLIProfileUrl = record[6];
                            profile.Company = record[7];
                            profile.CompanyIndustry = record[8];
                            profile.Website = record[9];
                            profile.CompanyLocation = record[10];
                            profile.companyStreet1 = record[11];
                            profile.ContactLocation = record[12];
                            profile.Phone = record[13];
                            profile.Email = record[14];
                            profile.email1 = record[15];
                            profile.email2 = record[16];
                            profile.PersonalEmail = record[17];
                            profile.companyPhone1 = record[18];
                            profile.companyPhone2 = record[19];
                            profile.companyPhone3 = record[20];
                            profile.contactPhone1 = record[21];
                            profile.contactPhone2 = record[22];
                            if (profile.List != "List")
                            {
                                list.Add(profile);
                            }
                            break;
                        }
                        catch (Exception)
                        {
                        }
                    } while (false);

                }
                textReader.Close();
            }
            return list;
        }
    }
}
