function* IdProvider() {
    lastId = 0;
    while (true) {
        yield lastId += 1;
    }
}

module.exports = IdProvider;