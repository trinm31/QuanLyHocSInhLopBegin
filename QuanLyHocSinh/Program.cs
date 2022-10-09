using System;
using System.Collections.Generic;

namespace QuanLyHocSinh
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            // define list to store student name
            List<String> studentList = new List<string>();

            bool isEnded = false;
            do
            {
                // welcome text to begin the app
                Welcome();
                // get input student name
                GetStudentName(studentList);
                // print all student
                PrintAllStudent(studentList);
                // sort asc
                Sort(studentList, 1);
                // sort dec
                Sort(studentList, -1);
                // count number of student
                CountNumberStudents(studentList);

                // ask user to finish all or not
                isEnded = AskUserToContinue(isEnded, studentList);
            } while (!isEnded);
        }

        public static bool AskUserToContinue(bool isEnded, List<String> studentList)
        {
            Console.WriteLine("Do you wanna finish? - input yes to finish");
            var action = Console.ReadLine();
            if (action.ToLower().Trim() == "yes")
            {
                isEnded = true;
            }

            studentList.Clear();
            Console.Clear();
            
            return isEnded;
        }

        public static void CountNumberStudents(List<string> studentList)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Number of student is {studentList.Count}");
        }

        public static void Welcome()
        {
            Console.WriteLine("Welcome to student management app");
            Console.WriteLine("---------------------------------");
        }

        public static void GetStudentName(List<String> studentList)
        {
            bool isEnableToRun = true;
            Console.WriteLine("Let's input your data:(input end to finish)");
            do
            {
                // lấy giá trị input của user
                var input = Console.ReadLine();
                // "Finish" || "finISH"  - "finish"
                // kiểm tra xem người dùng muốn nhập tiếp hay ko dựa trên giá trị input "  end   "
                if (input == null || input.ToLower().Trim() == "finish" || input.ToLower().Trim() == "end")
                {
                    isEnableToRun = false;
                }
                else
                {
                    // add tên vào list studentList
                    studentList.Add(input);
                }
            } while (isEnableToRun);
        }

        public static void PrintAllStudent(List<String> studentList)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("List All Student");
            Console.WriteLine("------------------");
            int i = 1;
            foreach (var student in studentList)
            {
                Console.WriteLine($"Student {i} name: {student}");
                i++;
            }
        }
        
        // 1 - asc/tăng dần
        // -1 - dec/Giảm dần
        public static void Sort(List<String> studentList, int type)
        {
            if (type != -1 && type != 1)
            {
                Console.WriteLine("Type Error");
                return;
            }
            
            // asc
            studentList.Sort();
            
            if (type == -1)
            {
                studentList.Reverse();
            }

            Console.WriteLine(type == 1 ? "List of student which is sort asc" : "List of student which is sort dsc");

            PrintAllStudent(studentList);

        }
    }
}