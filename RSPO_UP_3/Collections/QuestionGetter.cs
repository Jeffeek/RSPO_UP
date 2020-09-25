using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using RSPO_UP_3.Models;

namespace RSPO_UP_3.Collections
{
    public static class QuestionGetter
    {
        public static List<Question> GetQuestionsFromFile()
        {
            try
            {
                List<Question> questions;
                using (var stream = new StreamReader($"{Directory.GetCurrentDirectory()}\\Questions.json"))
                {
                    questions = JsonConvert.DeserializeObject<List<Question>>(stream.ReadToEnd());
                }

                return questions;
            }
            catch
            {
                Application.Current.Shutdown(0);
                throw new FileLoadException();
            }
        }
    }
}
