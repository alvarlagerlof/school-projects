const fs = require("fs");

interface Operations<T> {
  create(item: T): string;
  update(ID: string, item: T);
  delete(ID: string);
  find(ID: string): T;
  list(): Array<[string, T]>;
}

abstract class Repository {
  // I know this is bad
  generateID(): string {
    return String(
      Math.round((new Date().getMilliseconds() + Math.random() * 100) * 1000)
    );
  }
}

class MemoryRepository<T> extends Repository implements Operations<T> {
  data: Array<[string, T]> = [];

  create(item: T) {
    let ID = super.generateID();
    this.data.push([ID, item]);
    return ID;
  }

  update(ID: string, item: T) {
    this.data.find((item: [string, T]) => item[0] === ID)[1] = item;
  }

  delete(ID: string) {
    this.data = this.data.filter((item: [string, T]) => item[0] != ID);
  }

  find(ID: string): T {
    let result = this.data.find((item: [string, T]) => item[0] === ID);
    return result ? result[1] : null;
  }

  list(): Array<[string, T]> {
    return this.data;
  }
}

class StoredRepository<T> extends Repository implements Operations<T> {
  data: Array<[string, T]> = [];
  fileName: String;

  constructor(fileName: string) {
    super();
    this.fileName = fileName;
    this.load();
  }

  save() {
    let rawdata = JSON.stringify(this.data);
    fs.writeFileSync(this.fileName, rawdata);
  }

  load() {
    try {
      let rawdata = fs.readFileSync(this.fileName);
      this.data = JSON.parse(rawdata);
    } catch (e) {
      this.data = [];
    }
  }

  create(item: T) {
    let ID = super.generateID();
    this.data.push([ID, item]);
    this.save();
    return ID;
  }

  update(ID: string, item: T) {
    this.data.find((item: [string, T]) => item[0] === ID)[1] = item;
    this.save();
  }

  delete(ID: string) {
    this.data = this.data.filter((item: [string, T]) => item[0] != ID);
    this.save();
  }

  find(ID: string): T {
    let result = this.data.find((item: [string, T]) => item[0] === ID);
    return result ? result[1] : null;
  }

  list(): Array<[string, T]> {
    return this.data;
  }
}

// Example 1
let randNumber = () => Math.round(Math.random() * 100);

class Dog {
  name: String;

  constructor(name: String) {
    this.name = name;
  }
}

let dogRepository = new MemoryRepository<Dog>();

console.log("Create dog");
let createdDogID: string = dogRepository.create(
  new Dog("Stina " + randNumber())
);
console.log(createdDogID);

console.log("\nFind dog");
let dog = dogRepository.find(createdDogID);
console.log(dog);

console.log("\nUpdate dog");
dogRepository.update(createdDogID, new Dog("Stina " + randNumber()));
let updatedDog = dogRepository.find(createdDogID);
console.log(updatedDog);

console.log("\nList all");
console.log(dogRepository.list());

console.log("\nDelete dog and find");
dogRepository.delete(createdDogID);
let deletedDog = dogRepository.find(createdDogID);
console.log(deletedDog);

console.log("\n\n\n");

// Example 2
class Cat {
  name: String;

  constructor(name: String) {
    this.name = name;
  }
}

let catRepository = new StoredRepository("cats.json");

console.log("Create cat");
let createdCatID: string = catRepository.create(
  new Cat("Gullen " + randNumber())
);
console.log(createdCatID);

console.log("\nFind cat");
let cat = catRepository.find(createdCatID);
console.log(cat);

console.log("\nUpdate cat");
catRepository.update(createdCatID, new Cat("Gullen " + randNumber()));
let updatedCat = catRepository.find(createdCatID);
console.log(updatedCat);

console.log("\nList all");
console.log(catRepository.list());
