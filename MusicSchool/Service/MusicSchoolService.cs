using MusicSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MusicSchool.Configuration.MusicSchoolConfiguration;

namespace MusicSchool.Service
{
    internal static class MusicSchoolService
    {
        public static void Enosh()
        {
            MessageBox.Show("hahahhaahahahhahahaha");
        }
        public static void RemoveStudent(string studentName)
        {
            try
            {
                XDocument document = XDocument.Load(musicSchoolPath);
                XElement? student = document.Descendants("Student")
                    .FirstOrDefault(t => t.Attribute("Name")?.Value == studentName);

                if (student != null)
                {
                    student.Remove();
                    document.Save(musicSchoolPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating teacher name: {ex.Message}");
            }
        }

        public static void UpdateStudentName(string currentName, StudentModel newStudent)
        {
            try
            {
                XDocument document = XDocument.Load(musicSchoolPath);
                XElement? student = document.Descendants("Student")
                    .FirstOrDefault(t => t.Attribute("Name")?.Value == currentName);

                if (student != null)
                {
                    student.SetAttributeValue("Name", newStudent.Name);
                    student.SetElementValue("Instrument", newStudent.Instrument.Name);
                    document.Save(musicSchoolPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating teacher name: {ex.Message}");
            }
        }

        public static void UpdateTeacherName(string currentName, string newName)
        {
            try
            {
                XDocument document = XDocument.Load(musicSchoolPath);
                XElement? teacher = document.Descendants("Teacher")
                    .FirstOrDefault(t => t.Attribute("Name")?.Value == currentName);

                if (teacher != null)
                {
                    teacher.SetAttributeValue("Name", newName);
                    document.Save(musicSchoolPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating teacher name: {ex.Message}");
            }
        }

        public static void UpdateStudentInstrument(string studentName, string studentInstrument)
        {
            try
            {
                XDocument document = XDocument.Load(musicSchoolPath);
                XElement? student = document.Descendants("Student")
                    .FirstOrDefault(cr => cr.Attribute("Name")?.Value == studentName);

                if (student != null)
                {
                    XElement? instrumentElement = student.Element("Instrument");
                    if (instrumentElement != null)
                    {
                        instrumentElement.Value = studentInstrument;
                    }
                    document.Save(musicSchoolPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student instrument: {ex.Message}");
            }
        }

        public static void AddManyStudents(string classRoomName, params StudentModel[] students)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classRoom =
                document.Descendants("Class-Room").FirstOrDefault(cr => cr.Attribute("Name")?.Value == classRoomName);
            if (classRoom != null)
            {
                List<XElement> studenstXElements = students.Select(st =>
                    new XElement(
                    "Student",
                    new XAttribute("Name", st.Name),
                    new XElement("Instrument", st.Instrument.Name)
                    )).ToList();
                classRoom.Add(studenstXElements);
                document.Save(musicSchoolPath);
            }
        }

        public static void CreateXmlIfNotExists()
        {
            if (!File.Exists(musicSchoolPath))
            {
                XDocument document = new();
                XElement musicSchool = new("Music-School");
                document.Add(musicSchool);
                document.Save(musicSchoolPath);
            }
        }

        public static void InsertClassRoom(string classRoomName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            var cars = document.Descendants("Music-School").FirstOrDefault();
            if (cars != null)
            {
                XElement classRoom = new(
                    "Class-Room",
                    new XAttribute("Name", classRoomName)
                );
                cars.Add(classRoom);
                document.Save(musicSchoolPath);
            }
            else
            {
                return;
            }
        }

        public static void InsertTeacher(string classRoomName, string teacherName)
        {
            try
            {
                XDocument document = XDocument.Load(musicSchoolPath);

                XElement? classRoom =
                    document.Descendants("Class-Room").FirstOrDefault(cr => cr.Attribute("Name")?.Value == classRoomName);

                if (classRoom != null)
                {
                    XElement teacher = new XElement(
                        "Teacher",
                        new XAttribute("Name", teacherName)
                    );
                    classRoom.Add(teacher);
                    document.Save(musicSchoolPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting teacher: {ex.Message}");
            }
        }

        public static void InsertStudent(string classRoomName, string studentname, string instrumentName)
        {
            try
            {
                XDocument document = XDocument.Load(musicSchoolPath);

                XElement? classRoom =
                    document.Descendants("Class-Room").FirstOrDefault(cr => cr.Attribute("Name")?.Value == classRoomName);

                if (classRoom != null)
                {
                    XElement student = new XElement(
                        "Student",
                        new XAttribute("Name", studentname)
                    );
                    XElement instrument = new XElement(
                        "Instrument",
                        instrumentName
                        );
                    student.Add(instrument);
                    classRoom.Add(student);
                    document.Save(musicSchoolPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting student: {ex.Message}");
            }
        }
    }
}
