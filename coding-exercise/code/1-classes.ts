class Person {
  name: string;
  age: number;

  constructor(name: string, age: number) {
    this.name = name;
    this.age = age;
  }

  greet() {
    console.log(`Hi! My name is ${this.name}, and I am ${this.age} years old`);
  }
}

let person1: Person = new Person("Jocke", 18);
person1.greet();
