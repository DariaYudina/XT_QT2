let str = "У попа была собака";
let separator = ["?", "!", ":", ";", ",", ".", " ", "\t"];
let arr = str.split(''), letters = {}, start = 0, words = [], result;
// заполняем массив words словами разбивая строку по разделителю из separator
arr.forEach((letter, i) => {
    if (separator.indexOf(letter) !== -1) {
        words.push(str.substr(start, i - start));
        start = i + 1;
    }
});
words.push(str.substr(start));
// ищем одинаковые буквы в словах и если есть добавляем в letters
words.forEach((word) => {
    word.split('').forEach((letter, i) => {
        if (!letters[letter] && word.indexOf(letter, i + 1) !== -1) {
            letters[letter] = true;
        }
    });
});
// проходим по всем буквам строки и удаляем те, что находятся в letters
result = arr.filter((letter) => {
    return !letters[letter];
});
console.log(result.join('')); 