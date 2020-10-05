let studentRegister = [];

class Student {
  age: number;

  constructor(age: number) {
    this.age = age;
  }
}

class School {
  join(student: Student) {
    console.log(
      `Student of age ${student.age} succesfully joined a school of type ${this.constructor["name"]}`
    );
    studentRegister.push(student);
  }
}

class ElementarySchool extends School {
  join(student: Student) {
    if (student.age > 5 && student.age < 10) {
      super.join(student);
    } else {
      throw new Error("Student not in age range");
    }
  }
}

class HighSchool extends School {
  join(student: Student) {
    if (student.age >= 10 && student.age < 15) {
      super.join(student);
    } else {
      throw new Error("Student not in age range");
    }
  }
}

let youngStudent = new Student(7);
let olderStudent = new Student(11);

let elementarySchool = new ElementarySchool();
let highSchool = new HighSchool();

try {
  elementarySchool.join(youngStudent);
} catch (e) {
  console.log(e.message);
}

try {
  highSchool.join(youngStudent);
} catch (e) {
  console.log(e.message);
}

try {
  highSchool.join(olderStudent);
} catch (e) {
  console.log(e.message);
}

console.log(studentRegister);
