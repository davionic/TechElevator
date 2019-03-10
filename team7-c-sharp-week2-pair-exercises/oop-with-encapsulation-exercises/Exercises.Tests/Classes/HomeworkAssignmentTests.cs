using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Individual.Exercises.Classes;

namespace Exercises.Tests.Classes
{
    [TestClass]
    public class HomeworkAssignmentTests
    {
        [TestMethod]
        public void Homework_HasRequiredProperties()
        {
            Type type = typeof(HomeworkAssignment);
            HomeworkAssignment assignment = (HomeworkAssignment)Activator.CreateInstance(type, 100, "Default Name");

            PropertyInfo[] properties = type.GetProperties();

            PropertyInfo prop = FindPropertyByName(properties, "TotalMarks");
            PropertyValidator.ValidateReadWrite(prop, "TotalMarks", typeof(int));
            
            prop = FindPropertyByName(properties, "PossibleMarks");
            PropertyValidator.ValidateReadOnly(prop, "PossibleMarks", typeof(int));
            
            prop = FindPropertyByName(properties, "SubmitterName");
            PropertyValidator.ValidateReadOnly(prop, "SubmitterName", typeof(string));
            
            
            prop = FindPropertyByName(properties, "LetterGrade");
            PropertyValidator.ValidateReadOnly(prop, "LetterGrade", typeof(string));
            
        }

        [TestMethod]
        public void HomeworkAssignment_Constructor()
        {
            Type type = typeof(HomeworkAssignment);
            HomeworkAssignment assignment = (HomeworkAssignment)Activator.CreateInstance(type, 100, "Default Name");

            PropertyInfo prop = FindPropertyByName(type.GetProperties(), "PossibleMarks");
            Assert.AreEqual(100, prop.GetValue(assignment), "Passed 100 into constructor and expected PossibleMarks property to return 100");
        }

        [TestMethod]
        public void HomeworkAssignment_LetterGradeTests()
        {
            Type type = typeof(HomeworkAssignment);
            HomeworkAssignment assignment = (HomeworkAssignment)Activator.CreateInstance(type, 100, "Default Name");

            PropertyInfo letterProp = FindPropertyByName(type.GetProperties(), "LetterGrade");

            PropertyInfo prop = FindPropertyByName(type.GetProperties(), "TotalMarks");
            prop.SetValue(assignment, 91);
            Assert.AreEqual("A", letterProp.GetValue(assignment), "Expected A for score of 91%");
            
            prop.SetValue(assignment, 81);
            Assert.AreEqual("B", letterProp.GetValue(assignment), "Expected B for score of 81%");

            prop.SetValue(assignment, 71);
            Assert.AreEqual("C", letterProp.GetValue(assignment), "Expected C for score of 71%");

            prop.SetValue(assignment, 61);
            Assert.AreEqual("D", letterProp.GetValue(assignment), "Expected C for score of 61%");

            prop.SetValue(assignment, 51);
            Assert.AreEqual("F", letterProp.GetValue(assignment), "Expected C for score of 51%");
        }

        private PropertyInfo FindPropertyByName(PropertyInfo[] properties, string name)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                if(properties[i].Name == name)
                {
                    return properties[i];
                }
            }

            return null;
        }
    }
}
