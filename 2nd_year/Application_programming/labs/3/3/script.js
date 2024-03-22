const searchFunction = (searchString) => {
    if (searchString === '') {
        document.getElementById('searchResult').innerHTML = '';
        return;
    }

    let resultSearchOutput = '';

    const filteredResults = Array.from(Object.entries(searchDict))
        .filter(([word, quantity]) => (
            word.includes(searchString) || (calculateLevenshteinDistance(word, searchString) < 3)
        ))
        .sort((a, b) => {
            const wordA = Object.keys(a)[0];
            const wordB = Object.keys(b)[0];
            if (wordA.startsWith(searchString)) return -1;
            if (wordB.startsWith(searchString)) return 1;
            return 0;
        });

    for (const [word, quantity] of filteredResults) {
        const index = word.indexOf(searchString);
        const highlightedWord = index !== -1
            ? `${word.substring(0, index)}<strong>${word.substring(index, index + searchString.length)}</strong>${word.substring(index + searchString.length)}`
            : highlightDifferentLetters(word, searchString);
        resultSearchOutput += `
            <tr>
                <td>${highlightedWord}</td>
                <td>${quantity}</td>
            </tr>
        `;
    }

    {
        filteredResults.length !== 0
        ? inner = `
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>Word</th>
                    <th>Quantity</th>
                </tr>
            </thead>
            <tbody>
                ${resultSearchOutput}
            </tbody>
        </table>
        `
        : inner = '<p class="text-center"><strong>No match!</strong></p><hr>'
    }

    document.getElementById('searchResult').innerHTML = inner;
};

class Counter {
    constructor(word) {
        this.dict = this.countDict(word)
    };

    countDict = (word) => {
        let dict = {};
        for (let i = 0; i < word.length; i++) {
            let letter = word[i];
            let counter = dict[letter] ? dict[letter] !== undefined : 0
            dict[letter] = counter + 1;
        }
    
        return dict;
    };

    subtract = (otherCounter) => {
        const result = { ...this.dict };
        for (const letter in otherCounter.dict) {
            if (result[letter]) {
                result[letter] -= otherCounter.dict[letter];
            } else {
                result[letter] = -otherCounter.dict[letter];
            }
            if (result[letter] <= 0) {
                delete result[letter];
            }
        }
        return result;
    };
};

const highlightDifferentLetters = (word, searchString) => {
    let wordCounter = new Counter(word);
    let searchStringCounter = new Counter(searchString);
    let differenceDict = wordCounter.subtract(searchStringCounter)

    let highlightedWord = '';
    for (let i = 0; i < word.length; i++) {
        let letter = word[i];

        if (differenceDict[letter] && letter !== searchString[i]) {
            highlightedWord += `<strong><span style="color: red;">${letter}</span></strong>`;
            differenceDict[letter] -= 1;
        } else {
            highlightedWord += `<strong>${letter}</strong>`;
        };
    };
    return highlightedWord;
}


const calculateLevenshteinDistance = (a, b) => {
    const c = a.length + 1;
    const d = b.length + 1;
    const r = Array(c);
    for (let i = 0; i < c; ++i) r[i] = Array(d);
    for (let i = 0; i < c; ++i) r[i][0] = i;
    for (let j = 0; j < d; ++j) r[0][j] = j;

    for (let i = 1; i < c; ++i) {
        for (let j = 1; j < d; ++j) {
            const s = (a[i - 1] === b[j - 1] ? 0 : 1);
            r[i][j] = Math.min(r[i - 1][j] + 1, r[i][j - 1] + 1, r[i - 1][j - 1] + s);
        }
    }
    return r[a.length][b.length];
};

var input = document.body.children[0];

input.oninput = function() {
    searchFunction(input.value);
};


const searchDict = {
    'apple': 7,
    'banana': 3,
    'orange': 5,
    'grape': 9,
    'pear': 2,
    'watermelon': 6,
    'pineapple': 8,
    'strawberry': 4,
    'blueberry': 1,
    'kiwi': 10,
    'peach': 3,
    'mango': 6,
    'lemon': 7,
    'lime': 5,
    'cherry': 2,
    'apricot': 4,
    'plum': 8,
    'coconut': 1,
    'pomegranate': 9,
    'fig': 3,
    'nectarine': 6,
    'cantaloupe': 7,
    'raspberry': 4,
    'blackberry': 5,
    'cranberry': 2,
    'tangerine': 8,
    'melon': 9,
    'guava': 3,
    'persimmon': 5,
    'dragonfruit': 6,
    'avocado': 7,
    'papaya': 4,
    'passionfruit': 5,
    'lychee': 2,
    'gooseberry': 8,
    'kiwano': 3,
    'quince': 7,
    'soursop': 9,
    'mulberry': 6,
    'starfruit': 4,
    'boysenberry': 5,
    'rhubarb': 8,
    'kumquat': 3,
    'jackfruit': 7,
    'durian': 9,
    'date': 5,
    'elderberry': 6,
    'plantain': 4,
    'acai': 2,
    'banana': 7,
    'orange': 3,
    'grape': 5,
    'pear': 9,
    'watermelon': 2,
    'pineapple': 6,
    'strawberry': 8,
    'blueberry': 4,
    'kiwi': 7,
    'peach': 1,
    'mango': 9,
    'lemon': 3,
    'lime': 5,
    'cherry': 6,
    'apricot': 4,
    'plum': 7,
    'coconut': 8,
    'pomegranate': 2,
    'fig': 5,
    'nectarine': 4,
    'cantaloupe': 6,
    'raspberry': 1,
    'blackberry': 3,
    'cranberry': 7,
    'tangerine': 9,
    'melon': 2,
    'guava': 5,
    'persimmon': 6,
    'dragonfruit': 4,
    'avocado': 8,
    'papaya': 3,
    'passionfruit': 7,
    'lychee': 5,
    'gooseberry': 6,
    'kiwano': 2,
    'quince': 1,
    'soursop': 9,
    'mulberry': 4,
    'starfruit': 8,
    'boysenberry': 7,
    'rhubarb': 3,
    'kumquat': 6,
    'jackfruit': 5,
    'durian': 2,
    'date': 1,
    'elderberry': 9,
    'plantain': 4,
    'acai': 3,
    'banana': 8,
    'orange': 7,
    'grape': 4,
    'pear': 5,
    'watermelon': 6,
    'pineapple': 3,
    'strawberry': 2,
    'blueberry': 9,
    'kiwi': 1,
    'peach': 7,
    'mango': 8,
    'lemon': 5,
    'lime': 4,
    'cherry': 3,
    'apricot': 6,
    'plum': 7,
    'coconut': 9,
    'pomegranate': 2,
    'fig': 8,
    'nectarine': 1,
    'cantaloupe': 5,
    'raspberry': 4,
    'blackberry': 6,
    'cranberry': 3,
    'tangerine': 7,
    'melon': 9,
    'guava': 2,
    'persimmon': 4,
    'dragonfruit': 5,
    'avocado': 8,
    'papaya': 6,
    'passionfruit': 3,
    'lychee': 7,
    'gooseberry': 1,
    'kiwano': 4,
    'quince': 9,
    'soursop': 2,
    'mulberry': 8,
    'starfruit': 3,
    'boysenberry': 6,
    'rhubarb': 5,
    'kumquat': 7,
    'jackfruit': 9,
    'durian': 1,
    'date': 2,
    'elderberry': 4,
    'plantain': 3,
    'acai': 5,
    'banana': 6,
    'orange': 7,
    'grape': 8,
    'pear': 9,
    'watermelon': 4,
    'pineapple': 3,
    'strawberry': 2,
    'blueberry': 1,
    'kiwi': 5,
    'peach': 6,
    'mango': 7,
    'lemon': 8,
    'lime': 9,
    'cherry': 4,
    'apricot': 3,
    'plum': 2,
    'coconut': 1,
    'pomegranate': 6,
    'fig': 7,
    'nectarine': 8,
    'cantaloupe': 9,
    'raspberry': 5,
    'blackberry': 4,
    'cranberry': 3,
    'tangerine': 2,
    'melon': 1,
    'guava': 6,
    'persimmon': 7,
    'dragonfruit': 8,
    'avocado': 9,
    'papaya': 5,
    'passionfruit': 4,
    'lychee': 3,
    'gooseberry': 2,
    'kiwano': 1,
    'quince': 7,
    'soursop': 8,
    'mulberry': 9,
    'starfruit': 5,
    'boysenberry': 6,
    'rhubarb': 7,
    'kumquat': 8,
    'jackfruit': 9,
    'durian': 1,
    'date': 2,
    'elderberry': 3,
    'plantain': 4,
    'acai': 5,
    'banana': 6,
    'orange': 7,
    'grape': 8,
    'pear': 9,
    'watermelon': 1,
    'pineapple': 2,
    'strawberry': 3,
    'blueberry': 4,
    'kiwi': 5,
    'peach': 6,
    'mango': 7,
    'lemon': 8,
    'lime': 9,
    'cherry': 1,
    'apricot': 2,
    'plum': 3,
    'coconut': 4,
    'pomegranate': 5,
    'fig': 6,
    'nectarine': 7,
    'cantaloupe': 8,
    'raspberry': 9,
    'blackberry': 1,
    'cranberry': 2,
    'tangerine': 3,
    'melon': 4,
    'guava': 5,
    'persimmon': 6,
    'dragonfruit': 7,
    'avocado': 8,
    'papaya': 9,
    'passionfruit': 1,
    'lychee': 2,
    'gooseberry': 3,
    'kiwano': 4,
    'quince': 5,
    'soursop': 6,
    'mulberry': 7,
    'starfruit': 8,
    'boysenberry': 9,
    'rhubarb': 1,
    'kumquat': 2,
    'jackfruit': 3,
    'durian': 4,
    'date': 5,
    'elderberry': 6,
    'plantain': 7,
    'acai': 8,
    'banana': 9,
    'orange': 1,
    'grape': 2,
    'pear': 3,
    'watermelon': 4,
    'pineapple': 5,
    'strawberry': 6,
    'blueberry': 7,
    'kiwi': 8,
    'peach': 9,
    'mango': 1,
    'lemon': 2,
    'lime': 3,
    'cherry': 4,
    'apricot': 5,
    'plum': 6,
    'coconut': 7,
    'pomegranate': 8,
    'fig': 9,
    'nectarine': 1,
    'cantaloupe': 2,
    'raspberry': 3,
    'blackberry': 4,
    'cranberry': 5,
    'tangerine': 6,
    'melon': 7,
    'guava': 8,
    'persimmon': 9,
    'dragonfruit': 1,
    'avocado': 2,
    'papaya': 3,
    'passionfruit': 4,
    'lychee': 5,
    'gooseberry': 6,
    'kiwano': 7,
    'quince': 8,
    'soursop': 9,
    'mulberry': 1,
    'starfruit': 2,
    'boysenberry': 3,
    'rhubarb': 4,
    'kumquat': 5,
    'jackfruit': 6,
    'durian': 7,
    'date': 8,
    'elderberry': 9,
    'plantain': 1,
    'acai': 2
};


