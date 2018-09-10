using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskNote.Models
{
    public class Task
    {
        // ID задачи
        public int Id { get; set; }
        // Текст задачи
        [DataType(DataType.MultilineText)]
        public string TaskNote { get; set; }
        // Дата, до которой необходимо выполнить
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime FinishDate { get; set; }
    }
}