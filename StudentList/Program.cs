// See https://aka.ms/new-console-template for more information
using StudentList;
using System.Text.RegularExpressions;

Boolean inputState = false;
List<StudentGroup> groups = new List<StudentGroup> { };
List<Student> students = new List<Student> { };
string welcomeMessage = "Приложение \'Список студентов\'\n" +
    "Разработал студент группы ИСТ-Tb41\n" + "Игнатенко Н.А.\n";
StudentGroup currentGroup = null;
Student currentStudent = null;

groupsList();


void studentsList()
{
    Console.Clear();
    Console.WriteLine(welcomeMessage);
    int studensInCurrentGroup = 0;
    foreach (Student student in students)
    {
        if (student.Group == currentGroup)
        {
            studensInCurrentGroup++;
        }
    }
    if (students != null && studensInCurrentGroup > 0)
    {
        Console.WriteLine("Список студентов в группе " + currentGroup.Name + ":");
        Console.WriteLine("ID  ФИО");
        foreach (Student student in students)
        {
            if (student.Group == currentGroup)
            {
                Console.WriteLine(student.Id + "   " + student.Name);
            }
        }
        Console.WriteLine("\n1 - Добавить студента");
        Console.WriteLine("2 - Изменить ФИО студента");
        Console.WriteLine("3 - Удалить студента");
        Console.WriteLine("4 - Вернуться к группам");
        Console.WriteLine("Выберите действие:");
        inputState = true;
        string input = Console.ReadLine();
        while (inputState)
        {
            Boolean check = true;
            if (!int.TryParse(input, out int inputInt))
            {
                check = false;
            }
            else
            {
                if (inputInt > 0 && inputInt <= 5)
                {
                    inputState = false;
                    if (inputInt == 1)
                    {
                        addStudent();
                        studentsList();
                    }
                    if (inputInt == 2)
                    {
                        inputState = true;
                        while (inputState)
                        {
                            Console.WriteLine("Выберите ID студента:");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out int sId))
                            {
                                selectStudent(sId);
                                if (currentStudent != null)
                                {
                                    inputState = false;
                                    Console.WriteLine("Введите новое ФИО студента:");
                                    editNameStudent(sId, Console.ReadLine());
                                    Console.Clear();
                                    currentStudent = null;
                                    studentsList();
                                }
                            }
                        }
                    }
                    if (inputInt == 3)
                    {
                        inputState = true;
                        while (inputState)
                        {
                            Console.WriteLine("Выберите ID студента:");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out int sId))
                            {
                                selectStudent(sId);
                                if (currentStudent != null)
                                {
                                    inputState = false;
                                    deleteStudent(sId);
                                    Console.Clear();
                                    currentStudent = null;
                                    studentsList();
                                }
                            }
                        }
                    }
                    if (inputInt == 4)
                    {
                        Console.Clear();
                        groupsList();
                    }
                }
                else { check = false; }
            }
            if (!check)
            {
                Console.WriteLine("Выберите вариант действия от 1 до 4");
                input = Console.ReadLine();
            }
        }
    }
    else
    {
        Console.WriteLine("В группе " + currentGroup.Name + " отсутствуют студенты!");
        Console.WriteLine("\n1 - Добавить студента");
        Console.WriteLine("2 - Вернуться к группам");
        Console.WriteLine("Выберите действие:");
        inputState = true;
        string input = Console.ReadLine();
        while (inputState)
        {
            Boolean check = true;
            if (!int.TryParse(input, out int inputInt))
            {
                check = false;
            }
            else
            {
                if (inputInt > 0 && inputInt <= 2)
                {
                    inputState = false;
                    if (inputInt == 1)
                    {
                        addStudent();
                        studentsList();
                    }
                    if (inputInt == 2)
                    {
                        Console.Clear();
                        groupsList();
                    }
                }
                else { check = false; }
            }
            if (!check)
            {
                Console.WriteLine("Выберите вариант действия от 1 до 2");
                input = Console.ReadLine();
            }
        }
    }
}
void groupsList()
{
    Console.Clear();
    Console.WriteLine(welcomeMessage);
    if (groups != null && groups.Count > 0)
    {
        Console.WriteLine("Список групп в базе:");
        Console.WriteLine("ID  Название");
        foreach (StudentGroup group in groups)
        {
            Console.WriteLine(group.Id + "   " + group.Name);
        }
        Console.WriteLine("\n1 - Выбрать группу");
        Console.WriteLine("2 - Добавить группу");
        Console.WriteLine("3 - Изменить имя группы");
        Console.WriteLine("4 - Удалить группу");
        Console.WriteLine("5 - Выйти из программы");
        Console.WriteLine("Выберите действие:");
        inputState = true;
        string input = Console.ReadLine();
        while (inputState)
        {
            Boolean check = true;
            if (!int.TryParse(input, out int inputInt))
            {
                check = false;
            }
            else
            {
                if (inputInt > 0 && inputInt <= 5)
                {
                    inputState = false;
                    if (inputInt == 1)
                    {
                        inputState = true;
                        while (inputState)
                        {
                            Console.WriteLine("Выберите ID группы:");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out int gId))
                            {
                                selectGroup(gId);
                                if (currentGroup != null)
                                {
                                    inputState = false;
                                    Console.Clear();
                                    Console.WriteLine("Список студентов");
                                    studentsList();
                                }
                            }
                        }
                        addGroup();
                        groupsList();
                    }
                    if (inputInt == 2)
                    {
                        addGroup();
                        groupsList();
                    }
                    if (inputInt == 3)
                    {
                        inputState = true;
                        while (inputState)
                        {
                            Console.WriteLine("Выберите ID группы:");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out int gId))
                            {
                                selectGroup(gId);
                                if (currentGroup != null)
                                {
                                    inputState = false;
                                    Console.WriteLine("Введите новое название группы:");
                                    editNameGroup(gId, Console.ReadLine());
                                    Console.Clear();
                                    currentGroup = null;
                                    groupsList();
                                }
                            }
                        }
                    }
                    if (inputInt == 4)
                    {
                        inputState = true;
                        while (inputState)
                        {
                            Console.WriteLine("Выберите ID группы:");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out int gId))
                            {
                                selectGroup(gId);
                                if (currentGroup != null)
                                {
                                    inputState = false;
                                    deleteGroup(gId);
                                    Console.Clear();
                                    currentGroup = null;
                                    groupsList();
                                }
                            }
                        }
                    }
                    if (inputInt == 5)
                    {
                        System.Environment.Exit(1);
                    }
                }
                else { check = false; }
            }
            if (!check)
            {
                Console.WriteLine("Выберите вариант действия от 1 до 5");
                input = Console.ReadLine();
            }
        }
    }
    else
    {
        Console.WriteLine("В базе отсутствуют группы!");
        Console.WriteLine("\n1 - Добавить группу");
        Console.WriteLine("2 - Выйти из программы");
        Console.WriteLine("Выберите действие:");
        inputState = true;
        string input = Console.ReadLine();
        while (inputState)
        {
            Boolean check = true;
            if (!int.TryParse(input, out int inputInt))
            {
                check = false;
            }
            else
            {
                if (inputInt > 0 && inputInt <= 2)
                {
                    inputState = false;
                    if (inputInt == 1)
                    {
                        addGroup();
                        groupsList();
                    }
                    if (inputInt == 2)
                    {
                        System.Environment.Exit(1);
                    }
                }
                else { check = false; }
            }
            if (!check)
            {
                Console.WriteLine("Выберите вариант действия от 1 до 2");
                input = Console.ReadLine();
            }
        }
    }
}

void addGroup()
{
    Console.WriteLine("Введите название группы: ");
    string groupName = Console.ReadLine();
    int id;
    if (groups.Count == 0 || groups == null)
    {
        id = 1;
    } else
    {
        id = groups[groups.Count - 1].Id + 1;
    }
    StudentGroup newGroup = new StudentGroup(id, groupName);
    groups.Add(newGroup);
}

void deleteGroup(int id)
{
    foreach (StudentGroup group in groups)
    {
        if (group.Id == id)
        {
            groups.Remove(group);
            break;
        }
    }
}
void editNameGroup(int id, string name)
{
    foreach (StudentGroup group in groups)
    {
        if (group.Id == id)
        {
            group.Name = name;
        }
    }
}

void selectGroup(int id)
{
    foreach (StudentGroup group in groups)
    {
        if (group.Id == id)
        {
            currentGroup = group;
        }
    }
}
void addStudent()
{
    Console.WriteLine("Введите ФИО студента: ");
    string studentName = Console.ReadLine();
    int id;
    if (students.Count == 0 || students == null)
    {
        id = 1;
    }
    else
    {
        id = students[students.Count - 1].Id + 1;
    }
    Student newStudent = new Student(id, studentName, currentGroup);
    students.Add(newStudent);
}

void deleteStudent(int id)
{
    foreach (Student student in students)
    {
        if (student.Id == id && student.Group == currentGroup)
        {
            students.Remove(student);
            break;
        }
    }
}
void editNameStudent(int id, string name)
{
    foreach (Student student in students)
    {
        if (student.Id == id && student.Group == currentGroup)
        {
            student.Name = name;
        }
    }
}
void selectStudent(int id)
{
    foreach (Student student in students)
    {
        if (student.Id == id)
        {
            currentStudent = student;
        }
    }
}