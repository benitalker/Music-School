using MusicSchool.Model;
using System.Diagnostics.Metrics;
using static MusicSchool.Service.MusicSchoolService;
using static MusicSchool.Model.StudentModel;


namespace MusicSchool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CreateXmlIfNotExists();

            string className = "Jazz";
            InsertClassRoom(className);

            string teachername = "Enosh";
            InsertTeacher(className, teachername);

            string studentName1 = "Beni";
            string instrumentName1 = "Guitar";

            string studentName2 = "Shlomi";
            string instrumentName2 = "Drumes";

            AddManyStudents
                (
                    className,
                    new StudentModel(studentName1,new InstrumentModel(instrumentName1)),
                    new StudentModel(studentName2,new InstrumentModel(instrumentName2))
                );
            UpdateTeacherName(teachername, "Alef");
            StudentModel st = new StudentModel("Yossi", new InstrumentModel("Pipe"));
            UpdateStudentName(studentName2, st);
            RemoveStudent("Yossi");
        }
    }
}
