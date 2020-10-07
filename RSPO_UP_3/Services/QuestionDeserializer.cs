using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RSPO_UP_3.Models;
using RSPO_UP_3.Models.DataModels;

namespace RSPO_UP_3.Services
{
    /// <summary>
    /// класс-локатор для получения коллекции вопросов для игры
    /// </summary>
    public static class QuestionDeserializer
    {
        private static string filePath = $"{Directory.GetCurrentDirectory()}\\Questions.json";
        /// <summary>
        /// метод, возвращающий коллекцию вопросов со всеми ответами
        /// </summary>
        /// <returns></returns>
        public static List<Question> GetQuestionsFromFile()
        {
            List<Question> questions;
            using (var stream = new StreamReader(filePath))
            {
                questions = JsonConvert.DeserializeObject<List<Question>>(stream.ReadToEnd());
            }

            return questions;
        }

        public static void WriteQuestionsToFile(List<Question> questions)
        {
            var list = GetQuestionsFromFile();
            using (var stream = new StreamWriter(filePath))
            {
                stream.Write(string.Empty);
                string json = JsonConvert.SerializeObject(questions);
                stream.Write(json);
            }
        }

        public static void AddNewQuestion(Question question)
        {
            if (question == null) throw new ArgumentException();
            var list = GetQuestionsFromFile();
            var checkForDoubling = list.SingleOrDefault(x => x.Text == question.Text);
            if (checkForDoubling == null)
            {
                list.Add(question);
                WriteQuestionsToFile(list);
            }
        }

        public static void RemoveQuestion(int id)
        {
            var list = GetQuestionsFromFile();
            var item = list.SingleOrDefault(x => x.Id == id);
            if (item != null)
            {
                list.Remove(item);
                WriteQuestionsToFile(list);
            }
        }

        public static void ChangeAnswersInQuestion(int questionId, Answer[] answers)
        {
            var list = GetQuestionsFromFile();
            var item = list.SingleOrDefault(x => x.Id == questionId);
            if (item != null)
            {
                if (answers != null)
                {
                    item.Answers = answers;
                    WriteQuestionsToFile(list);
                }
            }
        }
    }
}
