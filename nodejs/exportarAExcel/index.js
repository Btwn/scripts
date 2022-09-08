const reader = require('xlsx');

const json = [
    {
        id: 1,
        color: 'red',
        number: 75
    },
    {
        id: 2,
        color: 'blue',
        number: 62
    },
    {
        id: 3,
        color: 'yellow',
        number: 93
    },
];

let workBook = reader.utils.book_new();
const workSheet = reader.utils.json_to_sheet(json);
reader.utils.book_append_sheet(workBook, workSheet, `response`);
let exportFileName = `response.xls`;
reader.writeFile(workBook, exportFileName);