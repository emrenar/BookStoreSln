



using LinqPractices.DbOperations;
using LinqPractices.Entities;
using System.Linq;

DataGenerator.Initialize();
LinqDbContext _context = new LinqDbContext();

var students = _context.Students.ToList<Student>();

// Find 
var student = _context.Students.Find(4);

// FirstOrDefault
student = _context.Students.Where(x => x.Surname == "Arda").FirstOrDefault();

//  SingleOrDefault => Beklediğinden fazla veri geldiğinde hata fırlatır.

student = _context.Students.SingleOrDefault(student => student.Name == "Deniz");


// ToList()
var studentList = _context.Students.Where(student => student.ClassId == 2).ToList();

foreach (var item in studentList)
{
    Console.WriteLine(item.Name);
}

Console.WriteLine(studentList.Count);

// OrderBy
Console.WriteLine("ORDER BYYY");

students = _context.Students.OrderBy(x => x.StudentId).ToList();

foreach (var item in students)
{
    Console.WriteLine(item.StudentId+ " - " + item.Name + " - " + item.Surname);
}

// OrderByDescending
Console.WriteLine("ORDER BYYY DESCENDING");

students = _context.Students.OrderByDescending(x => x.StudentId).ToList();

foreach (var item in students)
{
    Console.WriteLine(item.StudentId + " - " + item.Name + " - " + item.Surname);
}

// Anonymous Object Result
Console.WriteLine("");
Console.WriteLine("**** ANONYMOUS ****");

var anonymousObject = _context.Students.Where(x => x.ClassId == 2).Select(y =>new
{
    Id = y.StudentId,
    FullName=y.Name+ " " + y.Surname
}).ToList();

foreach (var obj in anonymousObject)
{
    Console.WriteLine(obj.Id+ " - " + obj.FullName);
}