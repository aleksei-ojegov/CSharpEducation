using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Phonebook
    {
        private static Phonebook instance;

        private Phonebook() 
        {
            read_text_file();
        }

        public static Phonebook getInstance()
        {
            if (instance == null)
                instance = new Phonebook();
            return instance;
        }

        private List<Abonent> abonents = new List<Abonent>();
        private string pattern_array_abonent;

        public void read_text_file()
        {
            int count_adonent = 0;

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "phonebook.txt");
            FileInfo fileInfo = new FileInfo(filePath);
            using (StreamReader reader = fileInfo.OpenText())
            {
                string stroka = "";
                string stek_strok = "";
                while ((stroka = reader.ReadLine()) != null)
                {
                    stek_strok += stroka + 'θ';
                    count_adonent++;
                }
                pattern_array_abonent = stek_strok;
            }

            string[,] strings = new string[count_adonent, 2];
            string[] all_row = pattern_array_abonent.Split('θ');

            for (int i = 0; i < count_adonent; i++)
            {
                string[] one_string = new string[2];
                one_string = all_row[i].Split('ξ');
                strings[i, 0] = one_string[0];
                strings[i, 1] = one_string[1];
            }

            for (int i = 0; i < count_adonent; i++)
            {
                Abonent abonent = new Abonent();
                abonent.Name = strings[i, 0];
                abonent.Nomber = strings[i, 1];
                abonents.Add(abonent);
            }
        }

        public List<Abonent> getArray_abonent()
        {
            return abonents;
        }

        public void delete_abonent(int delete_nomber)
        {
            abonents.RemoveAt(delete_nomber);
        }

        public bool check_original_abonent(Abonent abo)
        {
            for (int i = 0; i < abonents.Count; i++)
            {
                Abonent abonent1 = abonents[i];
                if (abo.Nomber == abonent1.Nomber)
                    return false;
                if (abo.Name == abonent1.Name)
                    return false;
            }
            return true;
        }

        public string search_abonent_name(Abonent abo)
        {
            for (int i = 0; i < abonents.Count; i++)
            {
                Abonent abonent1 = abonents[i];
                if (abo.Nomber == abonent1.Nomber)
                    return abonents[i].Name;

            }
            return "Абонента с таким номером нет";
        }

        public string search_abonent_nomber(Abonent abo)
        {
            for (int i = 0; i < abonents.Count; i++)
            {
                Abonent abonent1 = abonents[i];
                if (abo.Name == abonent1.Name)
                    return abonents[i].Nomber;

            }
            return "Абонента с таким именем нет";
        }

        public void write_text_file(Abonent abo)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "phonebook.txt");
            FileInfo fileInfo = new FileInfo(filePath);

            using (StreamWriter writer = fileInfo.AppendText())
            {
                writer.WriteLine(abo.Name + "ξ" + abo.Nomber);
            }
            abonents.Add(abo);
        }

        public void write_text_file_end()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "phonebook.txt");
            FileInfo fileInfo = new FileInfo(filePath);
            File.Delete(filePath);
            File.Create(filePath).Close();

            using (StreamWriter writer = fileInfo.AppendText())
            {
                for (int i = 0; i < abonents.Count; i++)
                {
                    Abonent abonent1 = abonents[i];
                    writer.WriteLine(abonent1.Name + "ξ" + abonent1.Nomber);
                }
            }
        }
    }
}
