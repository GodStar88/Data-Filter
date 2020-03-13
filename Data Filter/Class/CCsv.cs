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
            // list.AddRange(ReadCsvContact(path));
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
                csv.Read();
                var header = csv.Context.Record;

                int nList = 1, nName = 2, nfirstName = 3, nlastName = 4, nTitle = 5, nLIProfileUrl = 6, nCompanyLIProfileUrl = 7,
                    nCompany = 8, nCompanyIndustry = 9, nWebsite = 10, nCompanyLocation = 11, ncompanyStreet1 = 12, nContactLocation = 13,
                    nPhone = 14, nEmail = 15, nemail1 = 16, nemail2 = 17, nPersonalEmail = 18, ncompanyPhone1 = 19, ncompanyPhone2 = 20,
                    ncompanyPhone3 = 21, ncontactPhone1 = 22, ncontactPhone2 = 23;

                for (int i = 0; i < header.Length; i++)
                {
                    switch (header[i].ToLower())
                    {
                        case "list": nList = i; break;
                        case "name": nName = i; break;
                        case "firstname": nfirstName = i; break;
                        case "lastname": nlastName = i; break;
                        case "title": nTitle = i; break;
                        case "liprofileurl": nLIProfileUrl = i; break;
                        case "companyliprofileurl": nCompanyLIProfileUrl = i; break;
                        case "company": nCompany = i; break;
                        case "companyindustry": nCompanyIndustry = i; break;
                        case "website": nWebsite = i; break;
                        case "companylocation": nCompanyLocation = i; break;
                        case "companystreet1": ncompanyStreet1 = i; break;
                        case "contactlocation": nContactLocation = i; break;
                        case "phone": nPhone = i; break;
                        case "email": nEmail = i; break;
                        case "email1": nemail1 = i; break;
                        case "email2": nemail2 = i; break;
                        case "personalemail": nPersonalEmail = i; break;
                        case "companyphone1": ncompanyPhone1 = i; break;
                        case "companyphone2": ncompanyPhone2 = i; break;
                        case "companyphone3": ncompanyPhone3 = i; break;
                        case "contactphone1": ncontactPhone1 = i; break;
                        case "contactphone2": ncontactPhone2 = i; break;
                    }
                }

                while (csv.Read())
                {
                    try
                    {
                        var record = csv.Context.Record;
                        var profile = new CContact();
                        profile.List = record[nList];
                        profile.Name = record[nName];
                        profile.firstName = record[nfirstName];
                        profile.lastName = record[nlastName];
                        profile.Title = record[nTitle];
                        profile.LIProfileUrl = record[nLIProfileUrl];
                        profile.CompanyLIProfileUrl = record[nCompanyLIProfileUrl];
                        profile.Company = record[nCompany];
                        profile.CompanyIndustry = record[nCompanyIndustry];
                        profile.Website = record[nWebsite];
                        profile.CompanyLocation = record[nCompanyLocation];
                        profile.companyStreet1 = record[ncompanyStreet1];
                        profile.ContactLocation = record[nContactLocation];
                        profile.Phone = record[nPhone];
                        profile.Email = record[nEmail];
                        profile.email1 = record[nemail1];
                        profile.email2 = record[nemail2];
                        profile.PersonalEmail = record[nPersonalEmail];
                        profile.companyPhone1 = record[ncompanyPhone1];
                        profile.companyPhone2 = record[ncompanyPhone2];
                        profile.companyPhone3 = record[ncompanyPhone3];
                        profile.contactPhone1 = record[ncontactPhone1];
                        profile.contactPhone2 = record[ncontactPhone1];
                        if (profile.List != "List")
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
    }
}
