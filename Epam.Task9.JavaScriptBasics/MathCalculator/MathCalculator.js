const expr = '-1.2 + 3 * 3 =';
const regExp = /(-?\d+(?:\.\d+)?)\s?([-+*/])\s?(-?\d+(?:\.\d+)?)/;
const regExpForLastValue = /(-?\d+(?:\.\d+?)?)\s?(=)/;

console.log(calculate(expr));
function calculate(input) {
    let lastValue;
    if (regExpForLastValue.test(input)) {
        lastValue = input.replace(regExpForLastValue, (match, value, operator, offset, string) => +value);
        if (!isNaN(lastValue)) {
            return +lastValue;
        }
    }

    if (regExp.test(input)) {
        let newStr = input.replace(regExp, replaceWithOperator);
        return calculate(newStr);
    }

    return "";
}

function replaceWithOperator(match, left, operator, right, offset, string) {
    let value;
    switch (operator) {
        case "+":
            value = +left + +right;
            break;
        case "-":
            value = +left - +right;
            break;
        case "*":
            value = +left * +right;
            break;
        case "/":
            value = +left / +right;
            break;
    }

    return value;
}


