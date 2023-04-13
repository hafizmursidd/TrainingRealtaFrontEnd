function showPrompt(message) {
    return prompt(message, 'Type anything here');
}

function selectText(tbId) {
    var tb = document.querySelector("#" + tbId);

    if (tb.select) {
        tb.select();
    }
}

function setValueById(id, value) {
    document.getElementById(id).value = value;
}

function scrollToSelectedRow(gridSelector) {
    var gridWrapper = document.querySelector(gridSelector);
    if (gridWrapper) {
        var selectedRow = gridWrapper.querySelector("tr.k-state-selected");
        if (selectedRow) {
            selectedRow.scrollIntoView();
        }
    }
}
