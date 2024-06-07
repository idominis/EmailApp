window.confirmCancel = function (message) {
    return confirm(message);
};

window.showModal = (modalId) => {
    if (window.jQuery) {
        $(`#${modalId}`).modal('show');
    } else {
        console.error("jQuery is not loaded");
    }
};

window.hideModal = (modalId) => {
    if (window.jQuery) {
        $(`#${modalId}`).modal('hide');
    } else {
        console.error("jQuery is not loaded");
    }
};

function checkForErrorAndDownload() {
    fetch(window.location.href).then(response => {
        console.log('Response Headers:', response.headers); // Log the headers
        const xError = response.headers.get("X-Error");
        console.log('X-Error Header:', xError); // Log the X-Error header
        if (xError === "true") {
            const errorContent = atob(response.headers.get("X-Error-Content"));
            console.log('Error Content:', errorContent); // Log the error content
            downloadErrorFile(errorContent, "error.json", "application/json");
        }
    }).catch(error => console.error('Error fetching the document:', error));
}

window.downloadErrorFile = function (content) {
    const errorContent = atob(content);
    const shouldDownload = confirm("An error occurred. Do you want to download error.json?");
    if (shouldDownload) {
        const a = document.createElement("a");
        const file = new Blob([errorContent], { type: "application/json" });
        a.href = URL.createObjectURL(file);
        a.download = "error.json";
        a.click();
        console.log('Downloading error file:', errorContent);
    } else {
        console.log('User cancelled the download.');
    }
};



document.addEventListener("DOMContentLoaded", function () {
    console.log('DOMContentLoaded event fired'); // Log the DOMContentLoaded event
    checkForErrorAndDownload();
});








