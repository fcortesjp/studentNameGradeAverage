using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentNameGradeAverage
{
    //Nombre del estudiante: Francisco Cortes
    //Grupo: 268
    //Número y Texto del programa
    //Código Fuente: autoría propia
    class Student
    {
        // variables privadas con propiedades de empleado
        private string name;
        private double grade;

        // Public properties to access the name and age values
        public string Name
        {
            get
            {
                return name; // retorna nombre 
            }
            set
            {
                name = value; // guarda nombre
            }
        }

        public double Grade
        {
            get
            {
                return grade; // returna edad
            }
            set
            {
                grade = value; // guarda edad
            }
        }
    }
    class Program
    {
        static public int getNumberOfStudents()
        {
            int numberOfstudents = 0;
            while (true)
            {
                Console.Write("Ingrese numero de estudiantes: ");
                string numberOfStudentsStr = Console.ReadLine();

                // revise si el numero de estudiantes esta en blanco o nulo
                if (string.IsNullOrWhiteSpace(numberOfStudentsStr))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: el numero de estudiantes no puede estar en blanco");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si el numero de estudiantes puede ser un numero entero
                bool canBeInt = int.TryParse(numberOfStudentsStr, out numberOfstudents);
                if (canBeInt == false)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no es valido");
                    //regrese al inicio del loop
                    continue;
                }
                //revise si el numero es negativo o cero
                if (numberOfstudents <= 0)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("Error: El dato ingresado no puede ser negativo o cero");
                    //regrese al inicio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }

            return numberOfstudents;
        }

        static public Student[] getStudentInformation(int numberOfstudents)
        {
            //define el array para guardar students
            Student[] studentsArray = new Student[numberOfstudents];

            //por cada empleado...
            for (int i = 0; i < studentsArray.Length; i++)
            {
                //creamos un objeto studiante
                Student std = new Student();
                string studentName = "";
                double studentGrade = 0;

                //pidamos el nombre
                while (true)
                {
                    Console.Write("Ingrese nombre del estudiante numero " + (i + 1) + ": ");
                    studentName = Console.ReadLine();

                    // revise si el nombre del estudiante esta en blanco o nulo
                    if (string.IsNullOrWhiteSpace(studentName))
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: el del estudiante no puede estar en blanco");
                        //regrese al inicio del loop
                        continue;
                    }
                    //  revise si el nombre es un numero o tiene digitos
                    if (studentName.Any(char.IsDigit))
                    {
                        //si es asi indique mensaje de error
                        Console.WriteLine("el nombre no puede contener digitos");
                        //regrese al incio del loop
                        continue;
                    }
                    // si no hay problemas con la captura salga del loop
                    break;
                }

                //pidamos la nota y validemosla
                while (true)
                {
                    Console.Write("Ingrese la nota del Estudiante: " + (i + 1) + ": ");
                    string studentGradeStr = Console.ReadLine();

                    // revise si la nota esta en blanco o nulo
                    if (string.IsNullOrWhiteSpace(studentGradeStr))
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: La nota no puede estar en blanco o ser nulo");
                        //regrese al inicio del loop
                        continue;
                    }
                    // revise si la edad puede ser un numero entero
                    bool canBeDouble = double.TryParse(studentGradeStr, out studentGrade);
                    if (canBeDouble == false)
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("El dato ingresado no es valido");
                        //regrese al inicio del loop
                        continue;
                    }
                    //revise que si la edad es un numero negativo
                    if (studentGrade < 0 || studentGrade > 5)
                    {
                        //si es asi, indique mensaje de error
                        Console.WriteLine("Error: La nota no puede ser un numero negativo ni mayor que 5");
                        //regrese al inicio del loop
                        continue;
                    }
                    // si no hay problemas con la captura salga del loop
                    break;
                }
                //asigne el nombre y la edad validada al objeto empleado creado
                std.Name = studentName;
                std.Grade = studentGrade;
                //guarde el objeto empleado en el array;
                studentsArray[i] = std;
            }
            return studentsArray;
        }

        static double getGradeAverage(Student[] studentArray)
        {
            // definimos vairables totales e iniciales
            double sumTotalGrades = 0.0;
            double average = 0.0;
            //obtenesmos el total de la suma de las notas
            for (int j = 0; j < studentArray.Length; j++)
            {
                sumTotalGrades += studentArray[j].Grade;
            }
            //calculamos y retornamos el promedio
            average = sumTotalGrades / studentArray.Length;
            return average;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Este Programa pide las notas y nombre de n estudiantes y calcula el promedio \n");
            //obtenenmos el total de estudaintes a ingresar
            int studentsNumber = getNumberOfStudents();
            //obtenemos nombre y nota de cada estudiante
            Student[] studentArray = getStudentInformation(studentsNumber);
            //mostramos el promedio de nota de estudiantes
            double average = getGradeAverage(studentArray);
            Console.WriteLine("El nota promedio de los estudiantes es: {0:N2}", average);
            Console.WriteLine("Presione enter para finalizar...");
            Console.ReadLine();
        }
    }
}
