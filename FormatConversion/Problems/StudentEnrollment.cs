using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormatConversion.Enums;
using System.Xml;
using System.Xml.Linq;


namespace FormatConversion.Problems
{
    public class StudentEnrollment : Problem
    {
        public StudentEnrollment()
        {
            this.rowDelimit = this.FetchRowDelimt(RowDelimit.NewLine);
            this.columnDelimit = this.FetchColumnDelimt(ColumnDelimit.Comma);
            this.Header = new string[] { "school_id", "classroom_id", "classroom_name", 
                "teacher_1_id", "teacher_1_last_name", "teacher_1_first_name", 
                "teacher_2_id", "teacher_2_last_name", "teacher_2_first_name", 
                "student_id", "student_last_name", "student_first_name", "student_grade"};
        }


        public override void Execute(StringBuilder sb, string inputfullpath)
        {
            // Fill the header line in the stringbuilder
            LineBuilder(sb, this.Header);

            // Call the XmlReader to streamingly read the file
            using (XmlReader reader = XmlReader.Create(inputfullpath))
            {
                var schoolId = string.Empty;
                var grade = string.Empty;
                var classroomId = string.Empty;
                var classroomName = string.Empty;

                // Parse the XML file,

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element
                        && reader.Name == "school")
                    {
                        schoolId = reader.GetAttribute("id");
                    }

                    if (reader.NodeType == XmlNodeType.Element
                       && reader.Name == "grade")
                    {
                        grade = reader.GetAttribute("id");

                        // move to classroom element
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.EndElement)
                                break;

                            if (reader.NodeType == XmlNodeType.Element
                                && reader.Name == "classroom")
                            {
                                classroomId = reader.GetAttribute("id");
                                classroomName = reader.GetAttribute("name");

                                //move to individuel item in the classroom
                                GetTeacherAndStudent(reader, sb, schoolId, grade, classroomId, classroomName);
                            }
                        }
                    }
                }
                reader.Close();
            }
        }


        /// <summary>
        /// Fill the teacher and student information to the string builder.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="sb"></param>
        /// <param name="schoolId"></param>
        /// <param name="grade"></param>
        /// <param name="classroomId"></param>
        /// <param name="classroomName"></param>
        private void GetTeacherAndStudent(XmlReader reader, StringBuilder sb, string schoolId,
                                          string grade, string classroomId, string classroomName)
        {
            var teacherId = new string[] { "", "" };
            var teacherLastName = new string[] { "", "" };
            var teacherFirstName = new string[] { "", "" };
            var studentId = string.Empty;
            var studentLastName = string.Empty;
            var studentFirstName = string.Empty;
            var teacherCount = 0;
            var studentCount = 0;

            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.EndElement
                    && studentCount != 0)
                    break;

                // Extract two teachers information
                if (reader.NodeType == XmlNodeType.Element
                && reader.Name == "teacher")
                {
                    teacherId[teacherCount] = reader.GetAttribute("id");
                    teacherLastName[teacherCount] = reader.GetAttribute("last_name");
                    teacherFirstName[teacherCount] = reader.GetAttribute("first_name");
                    teacherCount++;
                }

                // Extract students information
                if ((reader.NodeType == XmlNodeType.Element
                && reader.Name == "student") || (reader.NodeType == XmlNodeType.EndElement
                && studentCount == 0))
                {
                    var studentGrade = string.Empty;
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        studentId = reader.GetAttribute("id");
                        studentLastName = reader.GetAttribute("last_name");
                        studentFirstName = reader.GetAttribute("first_name");
                        studentGrade = grade;
                    }
                    studentCount++;

                    // Put all of the information to the line builder Array
                    var lineBuilderArray = new string[] { schoolId, classroomId, classroomName,
                        teacherId[0], teacherLastName[0], teacherFirstName[0], teacherId[1], teacherLastName[1],
                        teacherFirstName[1], studentId, studentLastName, studentFirstName, studentGrade};
                    
                    // Fill the single line with the information collected above
                    LineBuilder(sb, lineBuilderArray);

                }
            }
        }
        
        
        /// <summary>
        /// Fill each line in the string builder by the information from the string array
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        private void LineBuilder(StringBuilder sb, string[] items)
        {
            sb.Append(items[0]);
            for (int i = 1; i < items.Length; i++)
            {
                sb.Append(this.columnDelimit);
                sb.Append(items[i]);
            }
            sb.Append(this.rowDelimit);
        }

    }
}
