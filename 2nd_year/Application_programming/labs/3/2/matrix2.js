class Matrix2x2 {
    constructor(arg) {
        if (typeof arg === 'undefined') {
            // Конструктор для нулевой матрицы
            this.matrix = [[0, 0], [0, 0]];
        } else if (typeof arg === 'number') {
            // Конструктор для матрицы, у которой каждый элемент равен поданному числу
            this.matrix = [[arg, arg], [arg, arg]];
        } else if (Array.isArray(arg)) {
            // Конструктор для матрицы, содержимое подается на вход в виде массива
            this.matrix = arg;
        }
    }

    add(matrix) {
        const result = new Matrix2x2();
        for (let i = 0; i < 2; i++) {
            for (let j = 0; j < 2; j++) {
                result.matrix[i][j] = this.matrix[i][j] + matrix.matrix[i][j];
            }
        }
        return result;
    }

    sub(matrix) {
        const result = new Matrix2x2();
        for (let i = 0; i < 2; i++) {
            for (let j = 0; j < 2; j++) {
                result.matrix[i][j] = this.matrix[i][j] - matrix.matrix[i][j];
            }
        }
        return result;
    }

    multNumber(number) {
        const result = new Matrix2x2();
        for (let i = 0; i < 2; i++) {
            for (let j = 0; j < 2; j++) {
                result.matrix[i][j] = this.matrix[i][j] * number;
            }
        }
        return result;
    }

    mult(matrix) {
        const result = new Matrix2x2();
        for (let i = 0; i < 2; i++) {
            for (let j = 0; j < 2; j++) {
                result.matrix[i][j] = this.matrix[i][0] * matrix.matrix[0][j] + this.matrix[i][1] * matrix.matrix[1][j];
            }
        }
        return result;
    }

    det() {
        return this.matrix[0][0] * this.matrix[1][1] - this.matrix[0][1] * this.matrix[1][0];
    }

    transpon() {
        const temp = this.matrix[0][1];
        this.matrix[0][1] = this.matrix[1][0];
        this.matrix[1][0] = temp;
    }

    inverseMatrix() {
        const det = this.det();
        if (det === 0) {
            alert('Ошибка: невозможно найти обратную матрицу для заданной.');
            return new Matrix2x2();
        }
        const result = new Matrix2x2([[this.matrix[1][1], -this.matrix[0][1]], [-this.matrix[1][0], this.matrix[0][0]]]);
        return result.multNumber(1 / det);
    }

    multVector(vector) {
        const x = this.matrix[0][0] * vector.x + this.matrix[0][1] * vector.y;
        const y = this.matrix[1][0] * vector.x + this.matrix[1][1] * vector.y;
        return new Vector2D(x, y);
    }
}

class Vector2D {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }
}


let getMatrixFromInputs = (prefix) => {
    return new Matrix2x2([
        [parseFloat(document.getElementById(prefix + '11').value), parseFloat(document.getElementById(prefix + '12').value)],
        [parseFloat(document.getElementById(prefix + '21').value), parseFloat(document.getElementById(prefix + '22').value)]
    ]);
}


let getVectorFromInputs = () => {
    let x = parseFloat(document.getElementById('v1').value);
    let y = parseFloat(document.getElementById('v2').value);
    if ((!x || !y) & (x != 0 || y != 0)) {
        alert('Укажите значения вектора')
    }

    return new Vector2D(x, y);
}


let performOperation = (operation) => {
    const matrixA = getMatrixFromInputs('a');
    let result;

    switch (operation) {
        case 'add':
            const matrixB = getMatrixFromInputs('b');
            result = matrixA.add(matrixB);
            break;
        case 'sub':
            result = matrixA.sub(getMatrixFromInputs('b'));
            break;
        case 'mult':
            result = matrixA.mult(getMatrixFromInputs('b'));
            break;
        case 'det':
            result = `Определитель: ${matrixA.det()}`;
            break;
        case 'transpon':
            matrixA.transpon();
            result = matrixA;
            break;
        case 'inverse':
            result = matrixA.inverseMatrix();
            break;
        case 'multVector':
            result = matrixA.multVector(getVectorFromInputs());
            break;
        default:
            result = 'Неизвестная операция';
    }

    if (typeof result === 'object') {
        if (result instanceof Matrix2x2) {
            document.getElementById('result').innerHTML = `
                Результат:<br>
                ${result.matrix[0][0]} ${result.matrix[0][1]}<br>
                ${result.matrix[1][0]} ${result.matrix[1][1]}
            `;
        } else if (result instanceof Vector2D) {
            document.getElementById('result').innerHTML = `
                Результат (Вектор):<br>
                ${result.x}<br>
                ${result.y}
            `;
        }
    } else {
        document.getElementById('result').innerText = result;
    }
}
