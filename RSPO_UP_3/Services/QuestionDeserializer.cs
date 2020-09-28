using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RSPO_UP_3.Models;

namespace RSPO_UP_3.Services
{
    /// <summary>
    /// класс-локатор для получения коллекции вопросов для игры
    /// </summary>
    public static class QuestionDeserializer
    {
        /// <summary>
        /// метод, возвращающий коллекцию вопросов со всеми ответами
        /// </summary>
        /// <returns></returns>
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
                //Application.Current.Shutdown(0);
                throw new FileLoadException();
            }
        }
    }
}
