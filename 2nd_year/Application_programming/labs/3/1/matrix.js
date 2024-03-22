function multiplyMatrices() {
    const m = parseInt(document.getElementById('m').value);
    const n = parseInt(document.getElementById('n').value);
    const matrixM = document.getElementById('matrixM').value.split(' ').map(Number);
    const matrixN = document.getElementById('matrixN').value.split(' ').map(Number);

    // Проверка возможности умножения
    let a, b, c;
    for (let i = 1; i <= Math.sqrt(m); i++) {
        if (m % i === 0) {
            a = i;
            b = m / i;
            if (n % b === 0) {
                c = n / b;
                break;
            }
        }
    }

    if (!a || !b || !c) {
        document.getElementById('result').innerHTML = 'NO!';
        return;
    }

    // Вывод размеров матриц
    const resultDiv = document.getElementById('result');
    resultDiv.innerHTML = `YES!<br>${a}x${b} ${b}x${c}<br>`;

    // Умножение матриц и вывод результата
    let resultMatrix = [];
    for (let i = 0; i < a; i++) {
        for (let j = 0; j < c; j++) {
            let sum = 0;
            for (let k = 0; k < b; k++) {
                sum += matrixM[i * b + k] * matrixN[k * c + j];
            }
            resultMatrix.push(sum);
        }
    }

    // Вывод результата в виде таблицы
    let table = '<table>';
    for (let i = 0; i < a; i++) {
        table += '<tr>';
        for (let j = 0; j < c; j++) {
            table += `<td>${resultMatrix[i * c + j]}</td>`;
        }
        table += '</tr>';
    }
    table += '</table>';
    resultDiv.innerHTML += table;
}
