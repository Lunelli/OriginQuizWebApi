using System.Collections.Generic;

namespace OriginQuiz.Models
{
    public class Question
    {
        public string id { get; set; }
        public string question { get; set; }
        public string correctOptionId { get; set; }
        public List<Option> options { get; set; }

        public void addOption(string _id, string _value)
        {
            if (options == null)
                options = new List<Option>();

            var newOption = new Option();
            newOption.id = _id;
            newOption.value = _value;

            options.Add(newOption);

            //options.Add(new Option(_id, _value));
        }
    }
}
