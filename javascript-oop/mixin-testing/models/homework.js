function generateAssignments(number) {
    const assignments = [];
    for (let i = 0; i < number; i += 1) {
        assignments.push({
            presentationId: i + 1,
            status: false
        });
    }

    return assignments;
}

class Homework {
    constructor(numberOfPresentations) {
        this.assignments = generateAssignments(numberOfPresentations);
    }
}

module.exports = Homework;