const exportButton = document.getElementById('btn-export');
const table = document.getElementById('my-table');
//const Name = document.getElementById('h2').innerHTML.trim();
const Name = document.getElementById('h2');


exportButton.addEventListener('click', () => {
    // ایجاد نسخه‌ای جدید از جدول بدون ستون‌های دارای کلاس Noxlsx
    const tableClone = table.cloneNode(true);
    const columnsToRemove = Array.from(tableClone.querySelectorAll('th.Noxlsx'));

    columnsToRemove.forEach(th => {
        const index = Array.from(th.parentNode.children).indexOf(th);
        Array.from(tableClone.rows).forEach(row => {
            if (row.cells[index]) row.deleteCell(index);
        });
    });

    // ایجاد فایل اکسل از جدول جدید بدون ستون‌های Noxlsx
    const wb = XLSX.utils.table_to_book(tableClone, { sheet: 'sheet-1' });

    // ذخیره فایل اکسل با نام دلخواه
    const fileName = Name ? Name + '.xlsx' : 'MyTable.xlsx';
    XLSX.writeFile(wb, fileName);
});
