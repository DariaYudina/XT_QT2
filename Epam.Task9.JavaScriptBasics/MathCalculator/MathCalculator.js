let expr = '-1.2 + 3 * 3 =';
// let reg = /(-?\d+(\.\d+)?\s?[-+/*]{1}\s?)+(\d+(\.\d+)?){1}\s?[=]{1}/;
let reg = /(-?\d+(?:\.\d+)?)\s?([-+*\/])\s?(-?\d+(?:\.\d+)?)\s?(=)/;

let result = ['2', '+', '3', '*', '5', '='];
const operators = ['+', '-', '*', '/', '='];

// result.shift();
let res = matchCalc();
function matchCalc(){
    let leftSide = 0;
    for (let i = 0; i < result.length; i++) {
        if(operators.indexOf(result[i]) === -1) {
            if (i === 0) {
                leftSide += +result[i];
            } else {
                continue;
            }
        } else {
            switch(result[i]) {
                case '+':
                    leftSide += +result[i + 1];
                    break;
                case '-':
                    leftSide -= +result[i + 1];
                    break;
                case '*':
                    leftSide *= +result[i + 1];
                    break;
                case '/':
                    leftSide /= +result[i + 1];
                    break;
                case '=':
                    break;
            }
        }
    }
    return leftSide;
}
console.log(res);

