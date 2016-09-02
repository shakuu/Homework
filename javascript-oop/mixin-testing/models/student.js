class Student {
    constructor(firstname, lastname, homework) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.homework = homework;
    }

    get firstname() {
        return this._firstname;
    }

    set firstname(firstname) {
        this._firstname = firstname;
    }

    get lastname() {
        return this._lastname;
    }

    set lastname(lastname) {
        this._lastname = lastname;
    }

    get homework() {
        return this._homework;
    }

    set homework(homework) {
        this._homework = homework;
    }
}

module.exports = Student;