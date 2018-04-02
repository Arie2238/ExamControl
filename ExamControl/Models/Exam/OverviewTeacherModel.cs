﻿using System.Collections.Generic;
using System.Linq;

namespace ExamControl.Models.Exam
{
    public class OverviewTeacherModel
    {
        public OverviewTeacherModel(AppDbContext ctx)
        {
            Exams = ctx.Exams
                .Select(e => new Exam()
                {
                    SubjectId = e.Subject.Id,
                    SubjectName = e.Subject.Name,
                    ExamNeedsComputers = e.NeedsComputers,
                    ExamEstimatedAmountOfStudents = e.EstimatedAmountOfStudents
                });
        }

        public IEnumerable<Exam> Exams { get; set; }

        public class Exam
        {
            public int SubjectId { get; set; }

            public string SubjectName { get; set; }

            public bool ExamNeedsComputers { get; set; }

            public int ExamEstimatedAmountOfStudents { get; set; }
        }
    }
}