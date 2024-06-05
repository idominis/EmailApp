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


